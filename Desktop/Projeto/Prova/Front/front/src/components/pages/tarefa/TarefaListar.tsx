import { useEffect, useState } from "react";
import { Tarefa } from "../../../models/Tarefa";
import "./TarefaListar.css";

function TarefaListar() {
  const [tarefas, setTarefas] = useState<Tarefa[]>([]);

  useEffect(() => {
    TarefaListar();
  });

  function pesquisarProdutos() {
    fetch("http://localhost:5085/api/tarefas/listar")
      .then((resposta) => resposta.json())
      .then((produtos) => {
        // console.table(produtos);
        setTarefas(produtos);
      });
  }

  return (
    <div id="listar_tarefas">
      <h1>Lista de Produtos</h1>
      <table id="tabela">
        <thead>
          <tr>
            <th>#</th>
            <th>Descricao</th>
            <th>Status</th>
            <th>Categoria</th>
            <th>Titulo</th>
            <th>Criado em</th>
          </tr>
        </thead>
        <tbody>
          {tarefas.map((tarefas) => (
            <tr>
              <td>{tarefas.descricao}</td>
              <td>{tarefas.status}</td>
              <td>{tarefas.categoria}</td>
              <td>{tarefas.titulo}</td>
              <td>{tarefas.criadoEm}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default TarefaListar;

