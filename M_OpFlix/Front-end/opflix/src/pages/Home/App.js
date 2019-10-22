import React from 'react';
import './App.css';

// import jsonwebtoken from "jsonwebtoken";
import {Link} from "react-router-dom";
// import Axios from 'axios';
// import Moment from 'react-moment';

//img
import logo from '../../assets/img/Opflix.png';
import img from '../../assets/img/filmes2019.jpg';
function App() {
  return (
    <div className="body">
      <div>
        <nav>
          <img src={logo}></img>
        </nav>

        <main>
          <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s</p>
        <img src={img}></img>
        <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s</p>
        <Link className="buttonCadastrar" to="/Cadastrar">Cadastre-se</Link>
        </main>
      </div>
    </div>
  );
}

export default App;
