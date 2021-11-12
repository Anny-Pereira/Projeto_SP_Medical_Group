import React from "react";
import logo from '../../assets/Imagens/Logo 3.png';
import  {Link}  from 'react-router-dom';


export default function Footer() {

    return (
        <footer class="footer">
        <div class="container conteudo_footer">
            <p>Copyright © 2020 Escola Senai de Informática</p>
            <Link to="/"><img class="logo-home" src={logo} /></Link>
            <nav class="itens-footer">
                <span>Contato</span>
                <span>Endereço</span>
                <span>Serviços</span>
            </nav>
        </div>
    </footer>
    )
}