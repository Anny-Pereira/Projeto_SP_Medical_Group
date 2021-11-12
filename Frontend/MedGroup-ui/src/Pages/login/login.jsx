import { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

import { usuarioAutenticado, parseJwt } from '../../services/auth';

import '../../Documents/css/Login.css';
import logo from "../../Documents/Imagens/Logo 1.png";

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

        this.setState({errorMessage: '', isLoading: true})

        axios.post('http://localhost:5000/api/Login',{
            email: this.state.email,
            senha: this.state.senha
        })

        .then(resposta => {
            if (resposta.status === 200) {
                console.log('O token é ' + resposta.data.token)
                localStorage.setItem('usuario-token', resposta.data.token);
                this.setState({isLoading: false})


                let base64 = localStorage.getItem('usuario-login').split('.')[1];

                console.log(this.props);

               switch (parseJwt.role) {
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
                        <div className="borda"></div>
                        <div className="margin container_login">
                            <h1>Login</h1>
                            <form className="form" onSubmit={this.efetuaLogin}>
                                <div className="centro">
                                    <div>
                                        <span>Email:</span>
                                        <input type="email" name="email" value={this.state.email} onChange={this.atualizaStateCampo} className="input" />
                                    </div>
                                    <div>
                                        <span>Senha:</span>
                                        <input type="password" name="senha" value={this.state.senha} onChange={this.atualizaStateCampo} className="input" />
                                    </div>
                                </div>
                                <div>
                                    <div className="borda_btn"></div>
                                    {/* <button className="btn" type="submit">Entrar</button> */}

                                    {
                                        // Caso seja true, renderiza o botão desabilitado com o texto 'Loading...'
                                        this.state.isLoading === true &&
                                        <button type="submit" disabled className="btn" id="btn__login">
                                            Loading...
                                        </button>
                                    }

                                    {
                                        // Caso seja false, renderiza o botão habilitado com o texto 'Login'
                                        this.state.isLoading === false &&
                                        <button
                                            className="btn" id="btn__login"
                                            type="submit"
                                            disabled={this.state.email === '' || this.state.senha === '' ? 'none' : ''}>
                                            Entrar
                                        </button>
                                    }

                                </div>
                            </form>
                            <p style={{ color: 'red' }} >{this.state.errorMessage}</p>
                        </div>

                    </section>
                </main>
            </div>
        )
    }
}