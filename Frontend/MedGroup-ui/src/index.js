import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';

import { usuarioAutenticado, parseJwt } from '../src/services/auth';


import Home from './Pages/Home/App.jsx';
import NotFound from './Pages/NotFound/notFound';
<<<<<<< HEAD
import Login from './Pages/Login/login';
import ConsultasAdm from './Pages/consultasAdm/consultasAdm';
=======
import Login from './Pages/login/login';
import ConsultasAdm from './Pages/consultasAdm/consultasAdm' ;
<<<<<<< HEAD
import ConsultasMedico from './Pages/consultasMedico/consultasMedico';
import ConsultasPaciente from './Pages/consultasPaciente/consultasPaciente';
=======
>>>>>>> fb47097c1f61627889733063ed3608243ca4beba
>>>>>>> e2b03669dab06947647a2d8e7c4b2e0b3fb45f77

import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';




//Elaborar tipos de permissão
const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="/login" />
      )
    }
  />
);



const PermissaoMedico = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="/login" />
      )
    }
  />
);



const PermissaoPaciente = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '3' ? (
        // operador spread
        <Component {...props} />
      ) : (
        <Redirect to="/login" />
      )
    }
  />
);



const routing =(
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} ></Route>
        <Route path="/login" component={Login} ></Route>
        <PermissaoAdm path="/consultasAdm" component={ConsultasAdm} />
        <PermissaoMedico path="/consultasMedico" component={ConsultasMedico} />
        <PermissaoPaciente path="/consultasPaciente" component={ConsultasPaciente} />
        <Route path="/notFound" component={NotFound} ></Route>
        <Redirect to="/notFound" component={NotFound}/> {/* Redireciona para Not Found caso não encontre nenhuma rota */}
      </Switch>
    </div>
  </Router>
)


ReactDOM.render(
  // <React.StrictMode>
  //   <App />
  // </React.StrictMode>,
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
