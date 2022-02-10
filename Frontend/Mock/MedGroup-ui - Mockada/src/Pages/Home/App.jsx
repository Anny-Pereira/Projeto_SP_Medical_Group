import '../../assets/css/Home.css';

import { Link } from 'react-router-dom';

import localizacao from"../../assets/Imagens/pin-de-localizacao 2.png";
import logo from "../../assets/Imagens/Logo 1.png";
import decoracao from "../../assets/Imagens/icone-decoracao.png"
import Footer from '../../components/Footer/footer';

function App() {
  return (
   <div>
      <section className="banner">
        <header className="header container">
            <img className="logo-home" src={logo} />
            <div className="espaco">
                <span className="span-header">Contato</span>
                <Link to="/login"><span className="span-header">Entrar</span></Link>
            </div>
        </header>
        <main className="container">
            <section className="conteudo_banner">
                <div className="titulos_banner">
                    <h1 className="h1-home">Sp Medical Group</h1>
                    <hr/>
                    <h2 className="h2-home">Bem vindo(a)!</h2>
                </div>
                <Link to="/login" ><div className="botao-entrar">
                    <div className="borda_btn"></div>
                   <button className="btn-home"  >Entrar</button>
                </div> </Link>
            </section>
            <img className="decoracao" src={decoracao} />
            </main>
    </section>
    <section className="endereco">
        <div className="container endereco-2">
            <div>
                <div className="borda_box"></div>
                <div className="box">
                    <span>Marcar uma consulta</span>
                </div>
            </div>
            <div>
                <div className="borda_box"></div>
                <div className="box box-endereco">
                    <img src={localizacao} />
                    <span className="texto-endereco">Av. Barão Limeira, 532 São Paulo, SP</span>
                </div>
            </div>

        </div>
    </section>
    <Footer/>
      </div>
    
      )
}

export default App;
