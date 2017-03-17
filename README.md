# Lance Um Desafio
Aplicação web em asp.net mvc com entity framework database first e identity.

## Instalação 
Clone o repositorio abra o no visual studio e restaure os nuget packages.

## Instalação do Banco De Dados
Execute o script contido no repositorio com o nome LanceUmDesafioDB.sql
Execute um por um e pela ordem
dbo._MigrationHistory
dbo.AspNetUsers
dbo.AspNetRoles
dbo.AspNetUserClaims
dbo.AspNetUserLogins
dbo.AspNetUserRoles
dbo.Categoria
dbo.Desafio
dbo.Comentario

## Envio De Emails
Para utilizar o envio de emails crie uma conta no sendgrid e no visual studio com o botão direito em cima do seu projeto escolha opção properties > resources substitua o campo value pelo seu usuario e senha respectivamente.
ou altere o codigo para um provedor de sua preferência.


