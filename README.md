<h1>Controle de Estoque de Produtos</h1>

<p>🚀 Web Api ASP .NET 5 realizando Create, Update, Delete, Get by Id, GetAll.</p>

<p align="center">
 <a href="#Requisitos">Requisitos</a> •
 <a href="#Tecnologias">Tecnologias</a> •
 <a href="#Json-API">Json API</a> •
 <a href="#Testando-a-API">Testando a API</a> •
 <a href="#Autor">Autor</a> •
 <a href="#License">License</a>

</p>

<h4 align="center">
	🚧 Concluído 🚀 🚧
</h4>

### Requisitos

- [x] Cadastro de produto
- [x] Atualizar um produto existente pelo ID
- [x] Consultar todos os produtos
- [x] Consultar um produto pelo ID
- [x] Delete um produto pelo ID
- [x] Utilizar Entity Framework
- [x] Utilizar o SQL Server como banco de dados
- [x] Utilizar o Design Pattern Repository para acessar o banco
- [x] Utilizar o Swagger para Testar a API e Documenta-lá
- [x] Realizar Testes Unitários nas requisições basicas do Controler e do Repositório
- [x] Deploy da Aplicação no Azure - [Link](https://controleestoqueprodutoapi.azurewebsites.net/swagger/index.html) - ON ✔

### Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:

- [C#](https://docs.microsoft.com/pt-br/dotnet/csharp/)
- [ASP .NET 5](https://docs.microsoft.com/pt-br/archive/msdn-magazine/2014/special-issue/asp-net-5-introducing-the-asp-net-5-preview#aspnet-5)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-2019)
- [Entity Framework](https://docs.microsoft.com/pt-br/ef/)
- [Swagger](https://swagger.io/)
- [XUnit](https://xunit.net/)
- [NSubstitute](https://nsubstitute.github.io/help/getting-started/)

### Json API
```bash
{
  "id": 1,                                       // Id do produto
  "nome": "Produto 1",                           // Nome do Produto
  "qtde": 5,                                     // Quantidade do Produto em Estoque
  "ativo": true,                                 // Se o Produto está Ativo ou não
  "delete": false,                               // Delete somente virtual, então quando for "True", o produto não irá aparecer em nenhum Get e também não é possível alterá-lo.
  "dataInclusao": "2021-08-18T20:05:22.6084378", // Data e Hora de brasília da Inclusão do Produto
  "dataAlteracao": "2021-08-18T20:05:22.6084378" // Data e Hora de brasília da Alteração do Produto
}
```

### Testando a API

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:

- [Git](https://git-scm.com)
- [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/downloads/)

Caso você já tenha instalado no seu computador, segue as versões que foram utilizadas: 
- Git: git version 2.32.0.windows.2
- Visual Studio 2019: 16.10.3

Passo a Passo:

- Clone o repositório no seu computador; 
 	- Comando: git clone https://github.com/gpereira62/ControleEstoqueProduto.API.git
- Entre na pasta e execute o arquivo "ControleEstoqueProduto.API", abra ele pelo Visual Studio 2019; 
- Com o Visual Studio 2019 aberto, na barra de pesquisa, pesquise por "Package Manager Console" e abra essa janela;
- Ao abrir, execute o comando "Update-database";
- Agora execute o projeto; 
 	- Url: https://localhost:44342/swagger/index.html

![image](https://user-images.githubusercontent.com/42392839/130317078-29db6645-4010-4a25-acce-c1a974372211.png)

### Autor

<a href=https://www.linkedin.com/in/gustavo-pereira-18302316a/>
 <img style="border-radius: 50%;" src="https://media-exp1.licdn.com/dms/image/C4D03AQFICCCMopiLcQ/profile-displayphoto-shrink_200_200/0/1569797034513?e=1634774400&v=beta&t=368E-ErqfgKrjdb6b0Duk07Ic1q9QFbL0vQRwnkq7Og" width="100px;" alt=""/>
 <br />
 <sub><b>Gustavo Pereira</b></sub></a> <a href="https://www.linkedin.com/in/gustavo-pereira-18302316a/" title="Linkedin">🚀</a>


Feito com ❤️ por Gustavo Pereira 👋🏽 Entre em contato!

  <a href="https://www.linkedin.com/in/gustavo-pereira-18302316a/">
    <img src="https://img.shields.io/badge/linkedin-%230077B5.svg?&style=for-the-badge&logo=linkedin&logoColor=white" />
  </a>&nbsp;&nbsp;
  <a href="https://instagram.com/gustavops_dds">
    <img src="https://img.shields.io/badge/instagram-%23E4405F.svg?&style=for-the-badge&logo=instagram&logoColor=white" />        
  </a>&nbsp;&nbsp;
  <a href="mailto:gustavopereirasantos@hotmail.com">
    <img src="https://img.shields.io/badge/Microsoft_Outlook-0078D4?style=for-the-badge&logo=microsoft-outlook&logoColor=white" />        
  </a>&nbsp;&nbsp;
  

### License
This project is under the MIT license. See the [LICENSE](https://github.com/gpereira62/ControleEstoqueProduto.API/blob/master/LICENSE) for more information.
