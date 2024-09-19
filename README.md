# API de Cadastro de Clientes - Processo Seletivo XP

Esta API foi desenvolvida como parte de um processo seletivo da XP, com o objetivo de realizar o cadastro de clientes. Ela implementa operações CRUD (Create, Read, Update, Delete) e validações de CPF, Nome e Email. A aplicação foi construída em .NET 8.0 e inclui testes unitários para garantir a qualidade do código.

## Rotas Disponíveis da API

### 1. Cadastrar um Novo Cliente

**POST** - `/api/Client/add`

- **Descrição**: Esta rota é usada para cadastrar um novo cliente.
- **Parâmetros**:
  - CPF (string) - Obrigatório, enviado no corpo da requisição.
  - Nome (string) - Obrigatório, enviado no corpo da requisição.
  - Email (string) - Obrigatório, enviado no corpo da requisição.

---

### 2. Listar Todos os Clientes

**GET** - `/api/Client/showAll`

- **Descrição**: Usado para exibir todos os clientes cadastrados.
- **Parâmetros**: Nenhum.

---

### 3. Exibir um Cliente Específico

**GET** - `/api/Client/show/{cpf}`

- **Descrição**: Usado para mostrar os dados de um cliente específico, identificado pelo CPF.
- **Parâmetros**:
  - CPF (string) - Obrigatório, passado na URL.

---

### 4. Atualizar Dados de um Cliente

**PUT** - `/api/Client/update/{cpf}`

- **Descrição**: Usado para atualizar os dados de um cliente. O CPF é passado na URL e os campos `nome` e `email` podem ser atualizados.
- **Parâmetros**:
  - CPF (string) - Obrigatório, passado na URL.
  - Nome (string) - Opcional, enviado no corpo da requisição. Se for `null`, o nome não será atualizado.
  - Email (string) - Opcional, enviado no corpo da requisição. Se for `null`, o email não será atualizado.

---

### 5. Deletar um Cliente

**DELETE** - `/api/Client/delete/{cpf}`

- **Descrição**: Usado para apagar o cadastro de um cliente específico.
- **Parâmetros**:
  - CPF (string) - Obrigatório, passado na URL.

## Estrutura do Repositório

O projeto está organizado nas seguintes pastas:

- `Challenge/`: Contém a implementação da API.
  - **Controllers/**: 
    - `ClientController.cs`: Responsável por tratar as requisições HTTP e retornar respostas adequadas (e.g., 200, 400).
    - `RequestTypes.cs`: Define classes auxiliares para os tipos de requisição (Adição e Atualização de Cliente).
  - **Helper/**: 
    - `ClientValidation.cs`: Classe que contém a lógica de validação de CPF, Nome e Email.
  - **Models/**: 
    - `ClientModel.cs`: classe modelo que representa os dados do cliente, composto por CPF, Nome e Email.
  - **Services/**: 
    - `ClientService.cs`: Implementa a lógica de negócio e manipula o banco de dados em memória, utilizando um dicionário `<string,ClientModel>` para armazenar clientes.
  
- `ChallengeTests/`: Contém os testes unitários. Os testes individuais utilizam o atributo [Fact]. Enquanto testes parametrizados, o [Theory].
  - `ClientValidationTests.cs`: Testa os métodos da classe `ClientValidation`.
  - `ClientServiceTests.cs`: Testa os métodos da classe `ClientService`.

## Validações de Dados

- **CPF**: 
  - Formato esperado: `XXX.XXX.XXX-XX`
  - Segue o algoritmo de validação oficial do CPF (baseado no site [Macoratti](https://www.macoratti.net/alg_cpf.htm)).
  - Exemplo válido: `316.297.460-70`
  - Exemplo inválido: `31629746070`

- **Nome**:
  - Deve ter pelo menos 3 caracteres e conter apenas letras (acentos e espaços são permitidos).
  - Exemplo válido: `Yannis`
  - Exemplo inválido: `Ya21is`

- **Email**:
  - Deve conter um "@" e um domínio válido.
  - Exemplo válido: `yannisp77@gmail.com`
  - Exemplo inválido: `yannisp77@usp`


## Como Executar o Projeto

### Requisitos
- **Git**: Precisa estar instalado.
- **.NET SDK**: Versão 8.0 ou superior.
  
1. Clone o repositório:

   ```bash
   git clone https://github.com/YannisPontuschka/PS_XP_Investimentos.git
2. Navegue até a pasta do projeto

   ```bash
    cd PS_XP_Investimentos

3. Execute a Aplicação
   
     ```bash
       dotnet run --project .\Challenge\Challenge.csproj

Postman e Swagger foram utilizados pelo autor para testes. Abaixo segue uma imagem da apresentação das rotas pelo Swagger

![image](https://github.com/user-attachments/assets/6fa70b18-1ea1-475c-9d69-03c696b09a79)


## Execução de testes
Para executar os testes unitários e gerar o relatório de cobertura de código, execute o seguinte comando, a partir da pasta `PS_XP_investimentos`: 

      dotnet test ChallengeTests/ChallengeTests.csproj /p:CollectCoverage=true

Espera-se uma saída como essa:

    ```
    +---------+-------+--------+--------+
    |         | Line  | Branch | Method |
    +---------+-------+--------+--------+
    | Total   | 44.8% | 41.25% | 53.33% |
    +---------+-------+--------+--------+
    | Average | 44.8% | 41.25% | 53.33% |
    +---------+-------+--------+--------+

Se execução dos testes não funcioar, execute o código abaixo para instalar o `coverlet.msbuild`:
    
      cd .\ChallengeTests\
      dotnet add package coverlet.msbuild
      cd ..


## Tecnologias Utilizadas
* .NET 8.0
* Xunit para testes unitários
* Coverlet para quantificação da cobertura de testes

## Referencias
Segue algumas fontes de estudo para o desenvolviemnto da API descrita.

* [Curso XP Inc. - Full Stack Developer](https://web.dio.me/track/coding-the-future-xp-full-stack-developer)
* [Tutorial da Microsoft sobre API com .NET Core](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio)
* [Uso do método Replace do Regex](https://learn.microsoft.com/en-us/dotnet/api/system.text.regularexpressions.regex.replace?view=net-8.0#system-text-regularexpressions-regex-replace(system-string-system-string-system-string))
* [Algoritmo para validação de CPF](https://www.macoratti.net/alg_cpf.htm)

## Autor

[Yannis Pontuschka](https://www.linkedin.com/in/yannis-pontuschka-42512b238/)

