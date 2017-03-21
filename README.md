# Lance Um Desafio
Aplicação web em asp.net mvc com entity framework database first e identity.
Aplicação que abriga diversos desafios de programação em varias linguagens.
Para acessar a aplicação : [LanceUmDesafio](http://lanceumdesafio.azurewebsites.net)

## Instalação 
Clone o repositorio, abra o no visual studio e restaure os nuget packages.

## Instalação do Banco De Dados
Execute o script contido no repositorio com o nome LanceUmDesafioDB.sql
Execute um por um e pela ordem :
1. dbo._MigrationHistory
2. dbo.AspNetUsers
3. dbo.AspNetRoles
4. dbo.AspNetUserClaims
5. dbo.AspNetUserLogins
6. dbo.AspNetUserRoles
7. dbo.Categoria
8. dbo.Desafio
9. dbo.Comentario

## Envio De Emails
Para utilizar o envio de emails crie uma conta no sendgrid e no visual studio com o botão direito em cima do seu projeto escolha opção properties > resources substitua o campo value pelo seu usuario e senha respectivamente.
ou altere o codigo para um provedor de sua preferência.


