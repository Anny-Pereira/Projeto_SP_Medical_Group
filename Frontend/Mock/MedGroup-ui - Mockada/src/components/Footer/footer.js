import React from "react";
import logo from '../../assets/Imagens/Logo 3.png';
import  {Link}  from 'react-router-dom';

import '../../assets/css/footer.css';


export default function Footer() {

    return (
        <footer className="footer">
        <div className="container conteudo_footer">
            <p className="p-footer">Copyright © 2020 Escola Senai de Informática</p>
            <Link to="/"><img className="logo-home" src={logo} /></Link>
            <nav className="itens-footer">
                <span className="span-footer">Contato</span>
                <span className="span-footer">Endereço</span>
                <span className="span-footer">Serviços</span>
            </nav>
        </div>
    </footer>
    )
}