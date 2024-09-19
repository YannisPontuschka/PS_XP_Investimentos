# API de cadastro de clientes (CRUD)

Esse repositório é engloba uma **API de cadastro de cliente CRUD 
(Create, Read, Update and Delete)**, desenvolvida com a plataforma .NET Core. Está relacionado ao Processo Seletivo da XP Investimentos.
A explicação do documento é guiada pelos requisitos do desafio.

## 1 - CRUD
As operações de Criar, Ler, Atualizar e Deletar foram implementadas utilizando métodos HTTP. Decidiu-se desenvolver as seguinte operações:

* **Create**: `POST /api/Client/add` - operação que adiciona um cliente ao banco de dados.
* **Read**: `GET /api/Client/showAll` - operação que devolve todos os clientes cadastrados no momento.
* **Read**: `GET /api/Client/show/{cpf}` - operação que devolve um cliente com CPF `cpf`.


  
 * `\Challenge` inclui a implementação da API CRUD, em si;
 * `\ChallengeTest` inclui testes unitários feitos à API CRUD;



`dotnet test ChallengeTests/ChallengeTests.csproj /p:CollectCoverage=true`
`dotnet run --project .\Challenge\Challenge.csproj`
