import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link, useHistory } from 'react-router-dom';

import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faPen } from '@fortawesome/free-solid-svg-icons';
import Button from '@mui/material/Button';
import Box from '@mui/material/Box';
import Modal from '@mui/material/Modal';


import logo from "../../assets/Imagens/Logo 1.png";
import Footer from '../../components/Footer/footer';

import '../../assets/css/Administrador.css';
import '../../assets/css/style.css';


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


export default function ConsultasMedico() {
    const [listaConsultas, setListaConsultas] = useState([]);
    const [descricao, setDescricao] = useState('');
    const [id_atual, setIDAtual] = useState(0);
  
    //const [idDescricaoAlterada, setidDescricaoAlterada] = useState(0);
    let history = useHistory();



    //function BasicModal()
    const [open, setOpen] = React.useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);




    function abrirModal(id){


        console.log(id);
        setIDAtual(id);


        handleOpen();


    }


    function logout() {
        localStorage.removeItem('usuario-login');
        history.push('/login');
    }

    function buscarMInhasConsultas() {
        axios('http://192.168.3.253:5000/api/consultas/medico', {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    // console.log(resposta.data)
                    setListaConsultas(resposta.data)
                };
            })
            .catch(erro => console.log(erro));
    }

    function addDescricao(id) {
        console.log(id)
        console.log('Vamos editar!')
        axios.patch('http://192.168.3.253:5000/api/Consultas/descricao/' + id, {
            Descricao: descricao
        }, {
            headers: { 'Authorization': 'Bearer ' + localStorage.getItem('usuario-login') }
        })
            .then(resposta => {
                if (resposta.status === 200) {
                    console.log('A descri????o foi alterada!');
                    setDescricao(resposta.data);
                    //setidDescricaoAlterada(id)
                }
                buscarMInhasConsultas();
            })
            .catch(erro => console.log(erro))

    }


    useEffect(buscarMInhasConsultas, []);


    return (
        <div>
            <main>
                <section className="fundo_img_medico">
                    <header className="header container">
                        <Link to="/login" onClick={logout}><img className="logo-home" src={logo} /></Link>
                        <div className="espaco">
                            <span className="span-header">Contato</span>
                            <button className="span-header botao-sair" onClick={logout}>Sair</button>
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
                            <Modal
                                                                open={open}
                                                                onClose={handleClose}
                                                                aria-labelledby="modal-modal-title"
                                                                aria-describedby="modal-modal-description"

                                                            >
                                                                <Box sx={style}>
                                                                    <div>
                                                                   
                                                                    <div className="space-modal-descricao">
                                                                        <form>
                                                                            <input type="text"  onChange={(campo) => setDescricao(campo.target.value)} />
                                                                        </form>
                                                                        <button
                                                                            
                                                                            className="add-descricao-btn"
                                                                            disabled={descricao === '' ? 'none' : ''}
                                                                            onClick={() =>addDescricao(id_atual)}
                                                                        >
                                                                           Salvar
                                                                        </button>
                                                                    </div>
                                                                

                                                                    </div>
                                                                </Box>
                                                            </Modal>


                                {
                                    listaConsultas.map((consulta) => {
                                        return (
                                            <div key={consulta.idConsulta} className="item-card" id={consulta.idConsulta}>
                                                 <div className="borda_consulta"></div>
                                                <article className="consulta">
                                                    <div className="titulo-icone">
                                                        <span></span>
                                                        <h3>Atendimento</h3>
                                                        <div >
                                                            {/* <button value={descricao} className="botao-icone-ellipsis" onClick={() => addDescricao(consulta)} >
                                                                <FontAwesomeIcon icon={faPen} className="icone-ellipsis" />
                                                            </button>  */}
                                                            <Button onClick={() =>abrirModal(consulta.idConsulta)}>
                                                                <FontAwesomeIcon icon={faPen} className="icone-ellipsis" />
                                                            </Button>

                                                            {/* <i className="fas fa-ellipsis-v"></i> */}
                                                            {/* <FontAwesomeIcon icon={faEllipsisV}  className="icone-ellipsis" /> */}

                                                           
                                                        </div>
                                                    </div>
                                                    <div className="divisao-card">
                                                        <div className="lado-card">
                                                            <div className="item">
                                                                <span className="titulo">Paciente</span>
                                                                <span className="conteudo-consulta">{consulta.idPacienteNavigation.nomePaciente}</span>
                                                            </div>
                                                            <div className="item">
                                                                <span className="titulo">M??dico</span>
                                                                <span className="conteudo-consulta">{consulta.idMedicoNavigation.nomeMedico}</span>
                                                            </div>
                                                            <div className="item">
                                                                <span className="titulo">Especialidade</span>
                                                                <span className="conteudo-consulta">{consulta.idMedicoNavigation.idEspecialidadeNavigation.tituloEspecialidade}</span>
                                                            </div>
                                                            <div className="item">
                                                                <span className="titulo">Cl??nica</span>
                                                                <span className="conteudo-consulta">{consulta.idMedicoNavigation.idUsuarioNavigation.idClinicaNavigation.nomeClinica}</span>
                                                            </div>
                                                            <div className="item">
                                                                <span className="titulo">Descri????o</span>
                                                                <span className="conteudo-consulta">{consulta.descricao}</span>
                                                                
                                                            </div>
                                                        </div>
                                                        <div className="lado-card">
                                                            <div className="item">
                                                                <span className="titulo">Data</span>
                                                                <span className="conteudo-consulta">{Intl.DateTimeFormat("pt-BR", {
                                                                    year: 'numeric', month: '2-digit', day: 'numeric',
                                                                }).format(new Date(consulta.dataConsulta))}</span>
                                                            </div>
                                                            <div className="item">
                                                                <span className="titulo">Hora</span>
                                                                <span className="conteudo-consulta">{Intl.DateTimeFormat("pt-BR", {
                                                                    hour: 'numeric', minute: 'numeric',
                                                                    hour12: true
                                                                }).format(new Date(consulta.dataConsulta))}</span>
                                                            </div>
                                                            <div className="item">
                                                                <span className="titulo">Situa????o</span>
                                                                <span className="conteudo-consulta">{consulta.idSituacaoNavigation.descricao}</span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </article>
                                               
                                            </div>
                                            
                                        )
                                    })
                                }
                                {/* <div>
                        <form>
                            <input value={descricao} onChange={ (campo) => setDescricao(campo.target.value)}/>
                        </form>
                    </div> */}
                            </div>


                        </div>

                    </div>
                </section>
            </main>
            <Footer />
        </div>
    )
}
