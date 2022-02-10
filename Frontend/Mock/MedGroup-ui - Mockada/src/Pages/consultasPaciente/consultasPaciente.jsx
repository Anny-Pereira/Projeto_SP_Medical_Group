import React, {useState, useEffect} from 'react';
import axios from 'axios';
import { Link, useHistory } from 'react-router-dom';

import logo from "../../assets/Imagens/Logo 1.png";
import Footer from '../../components/Footer/footer';

import '../../assets/css/Administrador.css';
import '../../assets/css/style.css';

export default function ConsultasPaciente(){
    const[listaConsultas, setListaConsultas] = useState([]);
    let history = useHistory();


    function logout(){
        localStorage.removeItem('usuario-login');
        history.push('/login');
    }

    function buscarMInhasConsultas(){
        axios('http://192.168.3.253:5000/api/Consultas/paciente', {
            headers:{'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')}
        })
        .then(resposta => {
            if (resposta.status === 200) {
                // console.log(resposta.data)
                setListaConsultas( resposta.data )
            };
        })
        .catch( erro => console.log(erro) );
    }


    useEffect(buscarMInhasConsultas, []);


    return(
        <div>
    <main>
    <section className="fundo_img_medico">
        <header className="header container">
        <Link to="/login" onClick={logout}><img className="logo-home" src={logo}/></Link>
            <div className="espaco">
                <span  className="span-header ">Contato</span>
                <button onClick={logout}  className="span-header botao-sair">Sair</button>
            </div>
        </header>
        <section className="consultas-med">
                        <div className="container">
                            <h1 className="h1-consulta">Minhas Consultas</h1>
                        </div>
        </section>
    </section>
    </main>
    <main>
    <section className="lista-consultas">
        <div className=" container-cards-2">
            <div className="container cards-style">

                <div className="cards">
                    {
                        listaConsultas.map((consulta)=>{
                            return(
                                <div className="item-card" id={consulta.idConsulta}>
                    <div className="borda_consulta"></div>
                    <article className="consulta">
                        <div className="titulo-icone">
                            <span></span>
                            <h3>Atendimento</h3>
                            <div>
                            {/* <FontAwesomeIcon icon={faCoffee} /> */}
                            {/* <i className="fas fa-ellipsis-v"></i> */}
                            </div>
                        </div>
                        <div className="divisao-card">
                            <div className="lado-card">
                                <div className="item">
                                    <span className="titulo">Paciente</span>
                                    <span className="conteudo-consulta">{consulta.idPacienteNavigation.nomePaciente}</span>
                                </div>
                                <div className="item">
                                    <span className="titulo">Médico</span>
                                    <span className="conteudo-consulta">{consulta.idMedicoNavigation.nomeMedico}</span>
                                </div>
                                <div className="item">
                                    <span className="titulo">Especialidade</span>
                                    <span className="conteudo-consulta">{consulta.idMedicoNavigation.idEspecialidadeNavigation.tituloEspecialidade}</span>
                                </div>
                                <div className="item">
                                    <span className="titulo">Clínica</span>
                                    <span className="conteudo-consulta">{consulta.idPacienteNavigation.idUsuarioNavigation.idClinicaNavigation.nomeClinica}</span>
                                </div>
                                <div className="item">
                                    <span className="titulo">Descrição</span>
                                    <span className="conteudo-consulta">{consulta.descricao}</span>
                                </div>
                            </div>
                            <div className="lado-card">
                                <div className="item"> 
                                    <span className="titulo">Data</span>
                                    <span className="conteudo-consulta">{ Intl.DateTimeFormat("pt-BR", {
                                                year: 'numeric', month: '2-digit', day: 'numeric',                                              
                                            }).format(new Date(consulta.dataConsulta))}</span>
                                </div>
                                <div className="item">
                                    <span className="titulo">Hora</span>
                                    <span className="conteudo-consulta">{ Intl.DateTimeFormat("pt-BR", {
                                                hour: 'numeric', minute: 'numeric',
                                                hour12: true                                                
                                            }).format(new Date(consulta.dataConsulta))}</span>
                                </div>
                                <div className="item">
                                    <span className="titulo">Situação</span>
                                    <span className="conteudo-consulta">{consulta.idSituacaoNavigation.descricao}</span>
                                </div>
                            </div>
                        </div>
                    </article>
                </div>
                            )
                        })
                    }
                </div>

                
            </div>
           
        </div>
    </section>
   </main>
   <Footer/>
        </div>
    )
}
