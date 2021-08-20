<h1>Controle de Estoque de Produtos</h1>

<p>🚀 Web Api ASP .NET 5 realizando Create, Update, Delete, Get by Id, GetAll.</p>

<p align="center">
 <a href="#Requisitos">Requisitos</a> •
 <a href="#Tecnologias">Tecnologias</a> •
 <a href="#Json API">Json API</a> •
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
- [x] Deploy da Aplicação no Azure

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
