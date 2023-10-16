# ToDo System | Asp.Net e Angular

### Informações Técnicas
- Para a criação da API, utilizei o framework de C# Asp.Net Core, compatível com diversas plataformas. Desenvolvi o sistema através da implementação da Arquitetura Hexagonal, uma arquitetura complexa e escalável que segue os princípios do DDD, além da utilização dos princípios SOLID.
- Para a criação da interface Frontend, utilizei Angular CLI com TypeScript, através da implementação de alguns dos princípios SOLID. Simulei uma simples aplicação ToDo, dando foco principal na conexão com a API, na componentização e na estilização do CSS.
- Para a criação do banco de dados, utilizei o PortgreSQL, realizando as queries de teste e criação da tabela no pgAdmin 4. Disponibilizei o código de criação da tabela TB01 na pasta utils.

### Run Backend
- Primeiramente, crie um banco de dados e cole o código presente em utils/database_postgres.sql para criar a tabela.
- Altere suas variáveis de ambiente no appsetting.json e/ou no api/src/entrypoints/EnvironmentVariables.cs.
    - No arquivo api/appsettings.json estão setadas as variáveis de ambiente de conexão com o banco de dados. No arquivo api/src/entrypoints/EnvironmentVariables.cs estão setadas variáveis default caso o app não consiga capturar as variáveis do appsettings.json.
- Para rodar, execute o comando no terminal: ``` cd api && dotnet run```

### Run Frontend
- Primeiramente, na pasta ```ui``` execute o comando no terminal ```npm install ``` para instalar todas as dependências.
- Para rodar, execute o comando no terminal: ```ng serve```
