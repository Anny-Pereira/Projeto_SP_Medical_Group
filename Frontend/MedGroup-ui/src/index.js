import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import reportWebVitals from './reportWebVitals';

import Home from './Pages/Home/App.jsx';
import NotFound from './Pages/NotFound/notFound';
<<<<<<< HEAD
import Login from './Pages/Login/login';
import ConsultasAdm from './Pages/consultasAdm/consultasAdm';
=======
import Login from './Pages/login/login';
import ConsultasAdm from './Pages/consultasAdm/consultasAdm' ;
>>>>>>> fb47097c1f61627889733063ed3608243ca4beba

import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom';

//Elaborar tipos de permissão

const routing =(
  <Router>
    <div>
      <Switch>
        <Route exact path="/" component={Home} ></Route>
        <Route path="/login" component={Login} ></Route>
        <Route path="/consultasAdm" component={ConsultasAdm} ></Route>
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
