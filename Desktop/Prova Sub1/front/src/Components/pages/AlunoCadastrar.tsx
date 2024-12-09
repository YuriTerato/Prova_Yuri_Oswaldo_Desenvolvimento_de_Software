import { useEffect, useState} From "react";
import { Aluno } from "../../models/aluno";

function AlunoCadastrar (){
    const [nome, setNome] = useState("");
    const [sobrenome, setSobrenome] = useState ("");

}

useEffect(() => {
    axios
        .get<any[]>("http://localhost:5128/api/alunos/cadastrar")
    .then((resposta =>){
        setAlunos(resposta.data);
    });
}, []);