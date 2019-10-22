import React, { Component } from 'react';
import {Link} from "react-router-dom";
import Axios from 'axios';

class Login extends Component {

    constructor() {
        super();
        localStorage.removeItem("usuario-opflix");
        this.state = {
            Email: "",
            Senha: "",
            Erro: ""
        }
    }

    atualizaEstadoEmail = (event) => {
        this.setState({ Email: event.target.value });
    }

    atualizaEstadoSenha = (event) => {
        this.setState({ Senha: event.target.value });
    }

    efetuarLogin = (event) => {
        event.preventDefault();

        let url= "http://localhost:5000/api/login";

        Axios.post(url, {
            headers: {
                "Content-Type" : "application/json"
            },
            Email: this.state.Email,
            Senha: this.state.Senha,
        })
            .then(response => {
                if (response.status === 200) {
                    console.log(response.data.token);
                    localStorage.setItem("usuario-opflix", response.data.token);
                    this.props.history.push('/categorias');
                } else {
                    console.log('deu ruim');
                }
            })
            .catch(Erro => {
                this.setState({ Erro: "Usuário ou senha inválidos" });
                console.log(Erro);
            });
    }

    render() {
        return(
            <div className="div">
                <div id="login">
                    <h2>Login</h2>
                    <form onSubmit={this.efetuarLogin}>
                        <input type='text' placeholder='Email' onInput={this.atualizaEstadoEmail} name= "email"></input>
                        <br />
                        <input type='password' placeholder='Senha' onInput={this.atualizaEstadoSenha} name="password"></input>
                        <br />
                        <input type="submit" name="" value="Entrar" id="submit_login"/>
                    </form>
                    <Link to="/Cadastrar" id="login">Ainda não possui uma conta? Cadastre-se</Link>
                </div>
            </div>
        )
    }
}

export default Login;