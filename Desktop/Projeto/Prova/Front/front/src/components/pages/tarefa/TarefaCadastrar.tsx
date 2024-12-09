import { useState } from "react";
import { Tarefa } from "../../../models/Tarefa";

function TarefaCadastrar() {
  const [titulo, setTitulo] = useState("");
  const [descricao, setDescricao] = useState("");
  const [status, setStatus] = useState("");
  const [categoria, setCategoria] = useState("");

  function enviarProduto(event: any) {
    event.preventDefault();
    const tarefa: Tarefa = {
      titulo: titulo,
      descricao: descricao,
      status: status,
      categoria: Number(categoria),
    };

    //AXIOS - Biblioteca de requisições HTTP

    fetch("http://localhost:5085/api/tarefa/cadastrar", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(tarefa),
    })
      .then((resposta) => resposta.json())
      .then((produto) => {
        console.log(produto);
      });
  }

  return (
    <div>
      <h1>Cadastrar Tarefa</h1>
      <form onSubmit={enviarProduto} id="form-cadastro">
        <div className="form-group">
          <label htmlFor="descricao">Descrição:</label>
          <input
            type="text"
            id="descricao"
            name="descricao"
            required
            onChange={(event: any) => setDescricao(event.target.value)}
          />
        </div>

        <div className="form-group">
          <label htmlFor="status">Status:</label>
          <input
            type="text"
            id="status"
            name="status"
            required
            onChange={(event: any) => setStatus(event.target.value)}
          />
        </div>

        <div className="form-group">
          <label htmlFor="titulo">Titulo:</label>
          <input
            type="text"
            id="titulo"
            name="titulo"
            required
            onChange={(event: any) => setTitulo(event.target.value)}
          />
        </div>
        <button type="submit">Cadastrar Produto</button>
      </form>
    </div>
  );
}

export default TarefaCadastrar;
