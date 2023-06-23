![image](https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQgDwmUNq7SglZ1tum81yxdFKJVA9NVwOonNkFq1zwa1g&s)

# API LAB CLOTHING COLLECTION

A API Lab Clothing Collection é um conjunto de ferramentas para o gerenciamente de usuários, coleções e modelos de uma empresa de moda.
O Projeto foi desenvolvido no curso Dev In House em Parceria com a Audaces.

## Problema resolvido

A API resolve o problema de organizar modelos, coleções e usuários de uma empresa de moda. A API atinge esse objetivo através da disponibilização de endpoints para cadastro, atualização e pesquisa das informações aramazenadas no seu banco de dados

## Técnicas e tecnologias utilizadas:
A API é desenvolvida utilizando as seguintes tecnologias e técnicas:

* **Linguagem de programação:** C# 7
* **Framework Backend:** .NET Core 7
* **Banco de dados:** SQL Server
* **Arquitetura:** MVC Pattern

## Como executar:

1- Certifique-se que você possui o Git, .Net 7 e SQL server 2022 instalados em sua máquina:

```
https://www.microsoft.com/pt-br/sql-server/sql-server-downloads

https://dotnet.microsoft.com/en-us/download

https://git-scm.com/downloads
```

2- Edite o arquivo appsettings.Development.json dentro do da pasta Lab-Clothing-Collection-M2-master/Lab-Clothing-Collection-M2, modificando a propriedade "DefaultConnection" com os dados da sua instalaçao do SQL Server.

```
"DefaultConnection": "Server=127.0.0.1,1433; Database=labclothingcollectionbd;User Id=SEU_USUARIO;Password=SUA_SENHA;TrustServerCertificate=true"git clone https://github.com/marceloSantosBrl/Lab-Clothing-Collection-M2.git
```

3- Agora dentro da pasta Lab-Clothing-Collection-M2-master/Lab-Clothing-Collection-M2 execute o comando:

```
dotnet ef migrations add FirstMigration --project Lab-Clothing-Collection-M2

dotnet ef database update --project Lab-Clothing-Collection-M2

dotnet run
```

4- Agora é só acessar a API através do swagger no link http://localhost:5089/swagger/index.html ou através de outro cliente de API rest

## Melhorias futuras:

* Adicionar uma api GraphQL;
* Implementar autenticação e autorização de usuários;
* Adicionar funcionalidades extras como reporting;
* Criar scripts para deploy automático.

## Feedback e contribuições:

Sinta-se à vontade para contribuir com este projeto! Se você encontrar algum bug ou tiver alguma sugestão de melhoria, por favor, crie uma issue ou envie um pull request. Seu feedback é muito valioso para nos ajudar a melhorar a API Lab Clothing Collection.
