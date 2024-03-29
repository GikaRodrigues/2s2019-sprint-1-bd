import React,{Component} from 'react';
import logo from    '../../img/logo.png';
import {Link} from 'react-router-dom';
import './Cadastro.css';

class CadastrarCategoria extends Component{

    constructor(){
        super();
        this.state = {
            lista: [],
            nome: ''
        };
    }

    componentDidMount(){
       this.listaAtualizada();
    }

    listaAtualizada = () =>{
        fetch('http://localhost:5000/api/Categorias')
            .then(response => response.json())
            .then(data => this.setState({ lista: data}));
    }

    adicionaItem = (event) => {
        event.preventDefault();
        console.log(this.state.nome);
        fetch('http://localhost:5000/api/Categorias',{
            method: "POST",
            body: JSON.stringify({ nome: this.state.nome}),
            headers: {
                "Content-Type": "application/json"
            }
        })
        .then(this.listaAtualizada())
        .catch(error => console.log(error))
        
    }

    adicionaCategoria = () =>{
        let valores_lista = this.state.lista;
        let categoria = {nome: this.state.nome}

        valores_lista.push(categoria);

        this.setState({lista: valores_lista});
    }

    atualizarNome = (event) =>{
        this.setState({nome: event.target.value})
        console.log(this.state);
    }

    render(){
        return(
            <div className="divona">
                <Link to="/"><img src={logo} alt="" className="logo"/></Link>
                <div id="box_login">
                    <h2>Cadastrar Categoria</h2>
                    <form>
                        <input type='text' placeholder='Nome' value={this.state.nome}
                            onInput={this.atualizarNome}></input>
                        <input type="submit" name="" value="Cadastrar-se" id="submit_login" onClick={this.adicionaItem}/>
                    </form>
                </div>
            </div>
        )
    }
}

export default CadastrarCategoria;