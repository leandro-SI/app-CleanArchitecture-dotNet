# app-CleanArchitecture-dotNet
Criando uma aplicação (CRUD) de exemplo utilizando a abordagem da Clean Architecture

#

****** PROJETO *********

Escopo Geral: Criar um projeto Web para tratar com produtos e categorias que podem ser usados para criar catálogo de produtos de vendas
- Usando a abordagem da Clean Architecture
- Padrões que irei implementar no projeto: MVC, Reposotiry e CQRS
- Definir no projeto as funcionalidades para poder consultar, criar, editar e excluir (CRUD) produtos e categorias;
- Definir o modelo de domínio usando classes e com propriedades e comportamentos: Produto e Categoria;
- Definir qual arquitetura a ser usada no projeto: Será utilizado a abordagem da Clean Architecture;
- Definir os padrões que iremos implementar no projeto: Será utilizado MVC, Repository e CQRS
- Definir os atributos para o domínio Produto: Id (int, Identity), Nome (string), Descricao(string), Preco(decimal), Estoque(int), Imagem(string);
- Definir os atributos para o domínio Categoria: CategoriaId (int, Identity), Nome(string);
- Definir o relacionamento usado: teremos um relacionamento um-para-muitos entre Categoria e Produto

#

Escopo Geral - Definição das regras de negócio do Produto:

- Definir a funcionalidade para exibir os produtos;
- Definir a funcionalidade para criar um novo produto;
- Permitir alterar as propriedades de um produto existente (O Id do produto não poderá ser alterado);
- Definir a funcionalidade para excluir um produto existente pelo seu Id;
- Definir o relacionamento do produto com a categoria (propriedade de navegação);
- Não permitir a criação de um produto com estado inconsistente (criar um construtor parametrizado);
- Não permitir que os atributos do produto sejam alterados externamente (setter privados);
- Não permitir que os atributos Id, Estoque e Preco possuam valores negativos;
- Não permitir que os atributos Nome, Descricao sejam nulos ou vazios;
- Permitir que o atributo Imagem seja null;
- O atributo Nome não poderá conter menos que 3 caracteres;
- O atributo Descricao não poderá conter menos que 5 caracteres;
- O atributo Imagem não poderá conter mais que 250 caracteres;
- O atributo Imagem será armazenado como uma string e o seu arquivo será separado em uma pasta do projeto;
- Definir a validação das regras de negócio para o domínio Produto

Escopo Geral - Definição das regras de negócio da Categoria:

- Definir a funcionalidade para exibir as categorias;
- Definir a funcionalidade para criar uma nova categoria;
- Permitir alterar as propriedades de uma categoria existente (O Id da categoria não poderá ser alterado);
- Definir a funcionalidade para excluir uma categoria existente pelo seu Id;
- Definir o relacionamento entre categoria e produto (propriedade de navegação);
- Não permitir a criação de uma categoria com estado inconsistente (criar um construtor parametrizado);
- Não permitir que os atributos da categoria sejam alterados externamente (setter privados);
- Não permitir que o atributo CategoriaId tenha valor negativo;
- Não permitir que o atributos Nome seja null ou vazio;
- O atributo Nome não poderá conter menos que 3 caracteres;
- Definir a validação das regras de negócio para o domínio Categoria;

Escopo Geral - Persistência dos dados usada no projeto:

- Banco de dados relacional: SQL Server;
- Ferramenta ORM: Entity Framework Core;
- Sera utilizado a abordagem Code-First do Entity Framework Core para criar o banco de dados e as tabelas
- Desacoplamento da camada de acesso a dados do ORM: Padrão Repository

   ##

## Prerequisites

✔ - .Net 6.0

✔ - Visual code ou Visual Studio 2022

✔ - SQLServer

## Quick Start

```
  
  git clone https://github.com/leandro-SI/app-CleanArchitecture-dotNet/

  run project
  
```

