import "../../assets/css/flexbox.css"
import "../../assets/css/reset.css"
import "../../assets/css/style.css"

import  {Link, useHistory}  from 'react-router-dom';
import axios from 'axios';

import logo from '../../assets/img/logo.png';
import Rodape from "../../components/rodape/rodape";
import { useEffect, useState } from "react/cjs/react.development";


function App() {

  const [listaEventos, setListaeventos] = useState([]);
  let history = useHistory();

  function buscarEventos(){
    axios('http://localhost:5000/api/eventos')
    .then(resposta => {
      if (resposta.status === 200) {
        console.log('Os eventos foram atualizados!')
        setListaeventos(resposta.data)
      }
    })
    .catch(erro => console.log(erro))
  }

  useEffect(buscarEventos, []);

  function inscrever(evento){
    console.log(evento)

    axios.post('http://localhost/api/presencas/inscricao/' + evento.idEvento, {},{
      headers: {
        'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
    }
    })
    .then(resposta => {
      if (resposta.status === 201) {
        console.log('Inscrição realizada com sucesso!')
        history.push("/meusEventos")
      }
    })
    .catch(erro => console.log(erro))
  }
  
  return (
    <div>
    <header className="cabecalhoPrincipal">
      <div className="container">
       <Link to="/"> <img src={logo} alt="Logo da Gufi" /> </Link>

        <nav className="cabecalhoPrincipal-nav">
          <Link to="/">Home</Link>
          <Link to="/meusEventos">Meus eventos</Link>
          <a href="#conteudoPrincipal-contato">Contato</a>
          {/* <a className="cabecalhoPrincipal-nav-login" href="/login">Login</a> */}
          <Link className="cabecalhoPrincipal-nav-login" to="/login">Login</Link>
        </nav>
      </div>
    </header>

    <section className="conteudoImagem">
      <div>
        <h1>Gufi</h1>
        <h2>Área de eventos da Escola SENAI de Informática.</h2>
      </div>
    </section>

    <main className="conteudoPrincipal">
      <section id="conteudoPrincipal-eventos">
        <h1 id="conteudoPrincipal-eventos-titulo">Próximos Eventos</h1>
        <div className="container">
          <nav>
            <ul className="conteudoPrincipal-dados">

              {
                listaEventos.map((evento)=>{
                  return(
                    <li key={evento.idEvento} className="conteudoPrincipal-dados-link eventos">
                    <h2>{evento.nomeEvento}</h2>
                    <p>{evento.descricao}</p>
                    <td>{Intl.DateTimeFormat("pt-BR", {year: 'numeric', month: 'numeric', day: 'numeric', hour: 'numeric', minute: 'numeric', hour12: false }).format(new Date(evento.dataEvento))}</td>
                    <button onClick={() => inscrever(evento)} >Inscrever</button>
                  </li>
                  )
                })
              }
         
            </ul>
          </nav>
        </div>
      </section>

      <section id="conteudoPrincipal-visao">
        <h1 id="conteudoPrincipal-visao-titulo">Por Quê Participar?</h1>
        <div className="container">
          <p className="visao-texto">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit. <br />
            Nullam auctor suscipit eros sed blandit. <br />
            Fusce euismod neque sed dapibus sollicitudin. <br />Duis vel lacus
            vestibulum, molestie dui eu, bibendum nunc.
          </p>
        </div>
      </section>

      <section id="conteudoPrincipal-contato">
        <h1 id="conteudoPrincipal-contato-titulo">Contato</h1>
        <div
          className="container conteudo-contato-titulo"
        >
          <div
            className="contato-mapa conteudo-contato-mapa"
          ></div>
          <div
            className="contato-endereco conteudo-contato-endereco"
          >
            Alameda Barão de Limeira, 539 <br />
            São Paulo - SP
          </div>
        </div>
      </section>
    </main>

      <Rodape />

  </div>

  );
}

export default App;
