import React,{Component} from 'react';
import {Link} from "react-router-dom";


class Cadastro extends Component{

    constructor(){
        super();
        this.state = {
            lista: [
                // {idCategoria: 1, nome: "Design"},
                // {idCategoria: 2, nome: "Jogos"},
                // {idCategoria: 3, nome: "Meetup"}
            ],
            nome: '',
            Cpf: '',
            email: '',
            senha: ''

        };
    }

    componentDidMount(){
       this.listaAtualizada();
    }

    listaAtualizada = () =>{
        fetch('http://localhost:5000/api/Usuarios')
            .then(response => response.json())
            .then(data => this.setState({ lista: data}));
    }

    adicionaItem = (event) => {
        event.preventDefault();
        console.log(this.state.nome , this.state.Cpf , this.state.email , this.state.senha);

        fetch('http://localhost:5000/api/Usuarios',{
            method: "POST",
            body: JSON.stringify({ nome: this.state.nome , cpf: this.state.Cpf , email: this.state.email , senha: this.state.senha}),
            headers: {
                "Content-Type": "application/json"
            }
        })
        .then(this.listaAtualizada())
        .catch(error => console.log(error))
        
    }

    adicionaUsuario = () =>{
        let valores_lista = this.state.lista;
        let Usuarios = {nome: this.state.nome};
        // let Usuarios = {cpf: this.state.Cpf};
        // let Usuarios = {email: this.state.email};
        // let Usuarios = {senha: this.state.senha};

        valores_lista.push(Usuarios);

        this.setState({lista: valores_lista});
    }

    atualizarNome = (event) =>{
        this.setState({nome: event.target.value})
        console.log(this.state);
    }

    atualizarCpf = (event) =>{
        this.setState({cpf: event.target.value})
        console.log(this.state);
    }

    atualizarEmail = (event) =>{
        this.setState({email : event.target.value})
        console.log(this.state);
    }

    atualizarSenha = (event) =>{
        this.setState({senha: event.target.value})
        console.log(this.state);
    }

    render(){
        return(
            <div className="div">
                <div id="login">
                <Link className="buttonCadastrar" to="/login">Ja possui uma conta?</Link>
                    <h2>Cadastro</h2>
                    <form>
                        <input type='text' placeholder='Nome' value={this.state.nome}
                            onInput={this.atualizarNome}></input>
                        <br />
                        <input type='text' placeholder='CPF' maxLength= '11' value={this.state.CPF}
                            onInput={this.atualizarCpf}></input>
                        <br />
                        <input type='text' placeholder='Email' value={this.state.email}
                            onInput={this.atualizarEmail}></input>
                        <br />
                        <input type='password' placeholder='Senha' value={this.state.senha}
                            onInput={this.atualizarSenha}></input>
                        <br />
                        <input type="submit" name="" value="Cadastrar-se" id="submit_login" onClick={this.adicionaItem}/>
                    </form>
                </div>
            </div>
        )
    }
}

export default Cadastro;