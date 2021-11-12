import React, {useState, useEffect} from 'react';
import axios from 'axios';

import '../../Documents/css/Administrador.css';
import '../../Documents/css/style.css';

export default function ConsultasAdm(){
    // const [ nomeState, funcaoAtualiza ] = useState( valorInicial );
    const[listaConsultas, buscarConsultas] = [];
    const[]
    

    //FUNÇÃO BUSCARCONSULTAS
    //FUNÇÃO CADASTRARCONSULTAS
    //FUNÇÃO ATUALIZARCAMPO 
    //FUNÇÃO LIMPAR CAMPO
    limparCampos = () => {
        this.setState({
          //'ZERAR'states
        });
        console.log('Os states foram resetados!');
      };

    return(
        <div>
        <section class="fundo_img">
            <header class="header container">
                <img class="logo-home" src="../Imagens/Logo 1.png"/>
                <div class="espaco">
                <span>Contato</span>
                <span>Entrar</span>
                </div>
            </header>
            <main class="container">
            <section class="cadastro-consulta">
                <div class="form">
                    <div class="borda_form"></div>
                    <div class="espacamento">
                        <h2>Nova Consulta</h2>
                        <div class="item-form">
                            <span class="span">Nome do Paciente:</span>
                            <input class="input" type="text"/>
                        </div>
                        <div class="item-form">
                            <span class="span">Nome do Médico:</span>
                            <input class="input" type="text"/>
                        </div>
                        <div class="item-form">
                            <span class="span">Situação da Consulta:</span>
                            <input class="input" type="text"/>
                        </div>
                        <div class="item-form">
                            <span class="span">Data e Hora:</span>
                            <input class="input" type="datetime"/>
                        </div>
                        <div class="item-form">
                            <span class="span">Descrição:</span>
                            <input class="input" type="text"/>
                        </div>
                        <div class="botao">
                            <div class="border_btn"></div>
                            <button class="btn">Cadastrar</button>
                        </div>
                    </div>
                </div>
            </section>
            </main>
    </section>
    <main class="container">
    <section class="space">
        <img class="icone_medico" src="../Imagens/caixa-medica 1.png" />
    </section>
    <section class="consultas">
        <div class="container">
            <h1>Consultas</h1>
        </div>
    </section>
    <section class="lista-consultas">
        <div class="container container-cards">
            <div class="area-busca">
                <input class="input_busca" placeholder="  Busque uma consulta"/>
                <div>
                    <div class="border_btn"></div>
                    <button class="btn">Buscar</button>
                </div>
            </div>
            <div class="cards">
                <div class="item-card">
                    <div class="borda_consulta"></div>
                    <article class="consulta">
                        <div class="titulo-icone">
                            <span></span>
                            <h3>Atendimento</h3>
                            <div>
                                <i class="fas fa-ellipsis-v"></i>
                            </div>
                        </div>
                        <div class="divisao-card">
                            <div class="lado-card">
                                <div class="item">
                                    <span class="titulo">Paciente</span>
                                    <span class="conteudo-consulta">Fernando Lopes</span>
                                </div>
                                <div class="item">
                                    <span class="titulo">Médico</span>
                                    <span class="conteudo-consulta">Dr. Roberto Possarle</span>
                                </div>
                                <div class="item">
                                    <span class="titulo">Clínica</span>
                                    <span class="conteudo-consulta">Clinica Possarle</span>
                                </div>
                                <div class="item">
                                    <span class="titulo">Descrição</span>
                                    <span class="conteudo-consulta">O paciente está aguardando.</span>
                                </div>
                            </div>
                            <div class="lado-card">
                                <div class="item"> 
                                    <span class="titulo">Data</span>
                                    <span class="conteudo-consulta">15/10/2021</span>
                                </div>
                                <div class="item">
                                    <span class="titulo">Hora</span>
                                    <span class="conteudo-consulta">09:00</span>
                                </div>
                                <div class="item">
                                    <span class="titulo">Situação</span>
                                    <span class="conteudo-consulta">Aguardando</span>
                                </div>
                            </div>
                        </div>
                    </article>
                </div>
            </div>
           
        </div>
    </section>
   </main>
        </div>
    )
}