import React from "react";
import ComponenteExemplo from "./components/pages/tarefa/TarefaListar";
import ProdutoListar from "./components/pages/produto/ProdutoListar";
import TarefaCadastrar from "./components/pages/produto/TarefaListar";
import { BrowserRouter, Link, Route, Routes } from "react-router-dom";

function App() {
  return (
    <div id="app">
      <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to="/">Home</Link>
            </li>
            <li>
              <Link to="/pages/produto/listar">Listar Produtos</Link>
            </li>
            <li>
              <Link to="/pages/produto/cadastrar">Cadastrar Produto</Link>
            </li>
            <li>
              <Link to="/pages/endereco/consultar">Consultar CEP</Link>
            </li>
          </ul>
        </nav>
        <Routes>
          <Route path="/" element={<ProdutoListar />} />
          <Route path="/pages/produto/listar" element={<ProdutoListar />} />
          <Route
            path="/pages/produto/cadastrar"
            element={<ProdutoCadastrar />}
          />
          <Route path="/pages/endereco/consultar" element={<ConsultarCEP />} />
          {/* Para páginas não encontradas */}
          {/* <Route path="*" element={<Componente da Página não encontrada />} /> */}
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
