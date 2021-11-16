import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, useHistory } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEllipsisV } from '@fortawesome/free-solid-svg-icons';

import logo from "../../assets/Imagens/Logo 1.png";
import icone from "../../assets/Imagens/caixa-medica 1.png"
import Footer from '../../components/Footer/footer';

import '../../assets/css/Administrador.css';
import '../../assets/css/style.css';

import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';

 const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    p: 4,
  };


export default function ConsultasAdm() {
    // const [ nomeState, funcaoAtualiza ] = useState( valorInicial );
    const [listaPacientes, setListaPacientes] = useState([]);
    const [listaMedicos, setListaMedicos] = useState([]);
    const [listaConsultas, setListaConsultas] = useState([]);
    const [idPaciente, setPaciente] = useState(0);
    const [idMedico, setMedico] = useState(0);
    const [idSituacao, setSituacao] = useState(0);
    const [dataConsulta, setData] = useState(new Date());
    const [descricao, setDescricao] = useState('');
    const [isLoading, setIsLoadig] = useState(false);
    const [Message, setMes] = useState('');
    let history = useHistory();


    //function BasicModal()
    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    //FUNÇÃO BUSCARCONSULTAS
    //FUNÇÃO CADASTRARCONSULTAS
    //FUNÇÃO ATUALIZARCAMPO 
    //FUNÇÃO LIMPAR CAMPO
    // function limparCampos(){
        // setPaciente(0)
        // setMedico(0)
        // setSituacao(0),
        // setData(new Date()),
        // setDescricao(''),
        // setIsLoadig(false)
        // console.log('Os states foram resetados!');
    //   };



    function logout() {
        localStorage.removeItem('usuario-login');
        history.push('/login');
    }


    function listarPacientes() {
        axios('http://localhost:5000/api/Pacientes', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        })

            .then((resposta) => {
                if (resposta.status === 200) {
                    setListaPacientes(resposta.data)
                }
            })
            .catch((erro) => console.log(erro));
    }




    function listarMedicos() {
        axios('http://localhost:5000/api/Medicos', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        })

            .then((resposta) => {
                if (resposta.status === 200) {
                    setListaMedicos(resposta.data)
                }
            })
            .catch((erro) => console.log(erro));
    }



    function listarConsultas() {
        axios('http://localhost:5000/api/Consultas', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    // console.log(resposta.data)
                    setListaConsultas(resposta.data)
                };
                setMes('');
            })
            .catch(erro => console.log(erro));
    }



    function cadastrarConsulta(evento) {
        evento.preventDefault();

        setIsLoadig(true);

        axios.post('http://localhost:5000/api/Consultas', {
            idPaciente: idPaciente,
            idMedico: idMedico,
            idSituacao: idSituacao,
            dataConsulta: dataConsulta,
            descricao: descricao
        }, {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        })

            .then(resposta => {
                if (resposta.status === 201) {                    
                    // limparCampos();
                    setPaciente(0)
                    setMedico(0);
                    setSituacao(0);
                    setData(new Date());
                    setDescricao('');
                    setIsLoadig(false);
                    console.log('Os states foram resetados!');
                    
                    //console.log('Cadastro realizado com sucesso!')


                    listarConsultas();
                };
            })
            .catch(erro => console.log(erro), setIsLoadig(false));

    }


    function excluirConsulta(consulta){
        //console.log(consulta)
        //console.log(consulta.idConsulta)
        axios.delete('http://localhost:5000/api/Consultas/' + consulta.idConsulta ,{
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        })
            .then(resposta => {
                if (resposta.status === 204) {
                    // console.log(
                    setMes( 'A consulta selecionada foi excluída! Clique fora da tela para sair e recarregue a página.');
                  }
                  listarConsultas();
            })
            .catch(erro => console.log(erro), setMes(''))
    }


    useEffect(listarConsultas, []);
    useEffect(listarPacientes, []);
    useEffect(listarMedicos, []);


    return (
        <div>
            <section className="fundo_img">
                <header className="header container">
                    <Link to="/login" onClick={logout}><img className="logo-home" src={logo} /></Link>
                    <div className="espaco">
                        <span className="span-header">Contato</span>
                        <button className="span-header botao-sair" onClick={logout}>Sair</button>
                    </div>
                </header>
                <main className="container">
                    <section className="cadastro-consulta">
                        <div className="form">
                            <div className="borda_form"></div>
                            <div className="espacamento">
                                <h2 className="h2-adm">Nova Consulta</h2>
                                <div className="item-form">
                                    <span className="span">Nome do Paciente:</span>
                                    <select className="input" type="text" onChange={(campo) => setPaciente(campo.target.value)} >
                                        <option value="0" selected disabled>Informe o paciente:</option>
                                        {listaPacientes.map((paciente) => {
                                            return (
                                                <option
                                                    key={paciente.idPaciente}
                                                    value={paciente.idPaciente}
                                                >
                                                    {paciente.nomePaciente}
                                                </option>
                                            );
                                        })}
                                    </select>
                                </div>
                                <div className="item-form">
                                    <span className="span">Nome do Médico:</span>
                                    <select className="input" type="text" onChange={(campo) => setMedico(campo.target.value)} >
                                        <option value="0" selected disabled>Informe o médico:</option>
                                        {listaMedicos.map((medico) => {
                                            return (
                                                <option
                                                    key={medico.idMedico}
                                                    value={medico.idMedico}
                                                >
                                                    {medico.nomeMedico}
                                                </option>
                                            );
                                        })}
                                    </select>
                                </div>
                                <div className="item-form">
                                    <span className="span">Situação da Consulta:</span>
                                    <select className="input" type="text" onChange={(campo) => setSituacao(campo.target.value)}>
                                        <option value="0" selected disabled>Informe a situação da consulta:</option>
                                        <option value="1" >Realizada</option>
                                        <option value="2"  >Cancelada</option>
                                        <option value="3"  >Agendada</option>
                                    </select>
                                </div>
                                <div className="item-form">
                                    <span className="span">Data e Hora:</span>
                                    <input className="input" type="datetime-local" value={dataConsulta} onChange={(campo) => setData(campo.target.value)} />
                                </div>
                                <div className="item-form">
                                    <span className="span">Descrição:</span>
                                    <input className="input" type="text" value={descricao} onChange={(campo) => setDescricao(campo.target.value)} />
                                </div>
                                {
                                    isLoading === false &&
                                    <div className="botao" onClick={cadastrarConsulta}>
                                        <div className="border_btn"></div>
                                        <button className="btn" >Cadastrar</button>
                                    </div>
                                    //mensagem
                                }

                                {
                                    isLoading === true &&
                                    <div className="botao" >
                                        <div className="border_btn"></div>
                                        <button className="btn" >Loading...</button>
                                    </div>
                                }

                            </div>
                        </div>
                    </section>
                </main>
            </section>
            <main >
                <div className="bac-color">
                    <section className="space container">
                        <img className="icone_medico" src={icone} />
                    </section>
                </div>
                <section className="consultas">
                    <div className="container">
                        <h1 className="h1-consulta">Consultas</h1>
                    </div>
                </section>
                <section className="lista-consultas">
                    <div className="container container-cards">
                        <div className="area-busca">
                            <input className="input_busca" placeholder="  Busque uma consulta" />
                            <div>
                                <div className="border_btn"></div>
                                <button className="btn">Buscar</button>
                            </div>
                        </div>
                        <div className="cards">
                            {
                                listaConsultas.map((itemConsulta) => {
                                    //console.log(itemConsulta)
                                    return (
                                        <div className="item-card" id={itemConsulta.idConsulta}>
                                            <div className="borda_consulta"></div>
                                            <article className="consulta">
                                                <div className="titulo-icone">
                                                    <span></span>
                                                    <h3>Atendimento</h3>
                                                    <div>
                                                        {/* <i className="fas fa-ellipsis-v"></i> */}
                                                        {/* <FontAwesomeIcon icon={faEllipsisV}  className="icone-ellipsis" /> */}

                                                        <Button onClick={handleOpen}>
                                                            <FontAwesomeIcon icon={faEllipsisV}  className="icone-ellipsis" />
                                                        </Button>

                                                        <Modal
                                                            open={open}
                                                            onClose={handleClose}
                                                            aria-labelledby="modal-modal-title"
                                                            aria-describedby="modal-modal-description"
                                                            
                                                        >
                                                            <Box sx={style}>
                                                               <div>
                                                                   <button className="botao-icone-ellipsis" onClick={() => excluirConsulta(itemConsulta)} >Excluir</button>
                                                                   <p style={{ color: '#6D60F7', margin: '10px 0px'}} >{Message}</p>
                                                               </div>
                                                            </Box>
                                                        </Modal>
                                                    </div>
                                                </div>
                                                <div className="divisao-card">
                                                    <div className="lado-card">
                                                        <div className="item">
                                                            <span className="titulo">Paciente</span>
                                                            <span className="conteudo-consulta">{itemConsulta.idPacienteNavigation.nomePaciente}</span>
                                                        </div>
                                                        <div className="item">
                                                            <span className="titulo">Médico</span>
                                                            <span className="conteudo-consulta">{itemConsulta.idMedicoNavigation.nomeMedico}</span>
                                                        </div>
                                                        <div className="item">
                                                            <span className="titulo">Especialidade</span>
                                                            <span className="conteudo-consulta">{itemConsulta.idMedicoNavigation.idEspecialidadeNavigation.tituloEspecialidade}</span>
                                                        </div>
                                                        <div className="item">
                                                            <span className="titulo">Clínica</span>
                                                            <span className="conteudo-consulta">{itemConsulta.idPacienteNavigation.idUsuarioNavigation.idClinicaNavigation.nomeClinica}</span>
                                                        </div>
                                                        <div className="item">
                                                            <span className="titulo">Descrição</span>
                                                            <span className="conteudo-consulta">{itemConsulta.descricao}</span>
                                                        </div>
                                                    </div>
                                                    <div className="lado-card">
                                                        <div className="item">
                                                            <span className="titulo">Data</span>
                                                            {/* <span className="conteudo-consulta">{itemConsulta.dataConsulta}</span> */}
                                                            {/* <span className="conteudo-consulta">{itemConsulta.dataConsulta.split('T')[0]}</span> */}
                                                            <span className="conteudo-consulta">{Intl.DateTimeFormat("pt-BR", {
                                                                year: 'numeric', month: '2-digit', day: 'numeric',
                                                            }).format(new Date(itemConsulta.dataConsulta))}</span>
                                                        </div>
                                                        <div className="item">
                                                            <span className="titulo">Hora</span>
                                                            {/* <span className="conteudo-consulta">09:00</span> */}
                                                            <span className="conteudo-consulta">{Intl.DateTimeFormat("pt-BR", {
                                                                hour: 'numeric', minute: 'numeric',
                                                                hour12: true
                                                            }).format(new Date(itemConsulta.dataConsulta))}</span>
                                                        </div>
                                                        <div className="item">
                                                            <span className="titulo">Situação</span>
                                                            <span className="conteudo-consulta">{itemConsulta.idSituacaoNavigation.descricao}</span>
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
                </section>
            </main>
            <Footer />
        </div>
    )
}