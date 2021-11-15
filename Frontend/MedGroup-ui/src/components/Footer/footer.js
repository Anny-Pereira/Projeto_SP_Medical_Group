import React from "react";
import logo from '../../assets/Imagens/Logo 3.png';
import  {Link}  from 'react-router-dom';


export default function Footer() {

    return (
        <footer className="footer">
        <div className="container conteudo_footer">
            <p>Copyright © 2020 Escola Senai de Informática</p>
            <Link to="/"><img className="logo-home" src={logo} /></Link>
            <nav className="itens-footer">
                <span>Contato</span>
                <span>Endereço</span>
                <span>Serviços</span>
            </nav>
        </div>
    </footer>
    )
}