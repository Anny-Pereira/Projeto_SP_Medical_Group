import { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

import { usuarioAutenticado, parseJwt } from '../../services/auth';

import '../../assets/css/Login.css';
import logo from "../../assets/Imagens/Logo 1.png";

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            senha: '',
            errorMessage: '',
            isLoading: false
        };
    };

    efetuaLogin = (event) =>{
        event.preventDefault();

        console.log("api")

        this.setState({errorMessage: '', isLoading: true})

        axios.post('http://localhost:5000/api/Login',{
            email: this.state.email,
            senha: this.state.senha
        })

        .then(resposta => {
            if (resposta.status === 200) {
                console.log('O token é ' + resposta.data.token)
                localStorage.setItem('usuario-login', resposta.data.token);
                this.setState({isLoading: false})


               let base64 = localStorage.getItem('usuario-login').split('.')[1];

                console.log(this.props);

               switch (parseJwt().role) {
                   //caso ADM
                   case '1':
                    this.props.history.push('/consultasAdm');
                    console.log('Estou logado: ' + usuarioAutenticado());
                       break;

                   //caso MEDICO    
                   case '2':
                    this.props.history.push('/consultasMedico');
                    console.log('Estou logado: ' + usuarioAutenticado());
                       break;

                    //caso PACIENTE
                   case '3':
                    this.props.history.push('/consultasPaciente');
                    console.log('Estou logado: ' + usuarioAutenticado());
                       break;
               
                   default:
                       this.props.history.push('/');
                       break;
               }
            

            }
        })

        .catch(() => {
            this.setState({errorMessage: 'E-mail e/ou senha inválidos!', isLoading: false})
        })
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name]: campo.target.value })
    };



    render() {
        return (
            <div>
                <main >
                    <section className="login">
                        <Link to="/"><img className="logo-login" src={logo} /> </Link >
                        
                        <div className="margin container_login">
                            <h1 className="h1-login">Login</h1>
                            <form className="form-login" onSubmit={this.efetuaLogin}>
                                <div className="centro">
                                    <div>
                                        <span className="span-login">Email:</span>
                                        <input className="input-login" type="email" name="email" value={this.state.email} onChange={this.atualizaStateCampo} className="input" />
                                    </div>
                                    <div>
                                        <span className="span-login">Senha:</span>
                                        <input  className="input-login" type="password" name="senha" value={this.state.senha} onChange={this.atualizaStateCampo} className="input" />
                                    </div>
                                </div>
                                <div className="botao-login">
                                   
                                    {/* <button className="btn" type="submit">Entrar</button> */}

                                    {
                                        // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
                                        this.state.isLoading === true &&
                                        <button type="submit" disabled className="btn-login" id="btn__login">
                                            Loading...
                                        </button>
                                        
                                    }

                                    {
                                        // Caso seja false, renderiza o botão habilitado com o texto 'Login'
                                        this.state.isLoading === false &&
                                        <button
                                            className="btn-login" id="btn__login"
                                            type="submit"
                                            disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}>
                                            Entrar
                                        </button>
                                    }
                                     <div className="borda_btn"></div>

                                </div>
                            </form>
                            <p style={{ color: 'red', margin: '10px 0px'}} >{this.state.errorMessage}</p>
                        </div>

                        <div className="borda"></div>

                    </section>
                </main>
            </div>
        )
    }
}