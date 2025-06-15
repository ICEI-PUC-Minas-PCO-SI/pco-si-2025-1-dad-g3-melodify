# Instruções de Utilização

Este projeto é estruturado em microserviços desenvolvidos no Visual Studio, utilizando .NET. A aplicação conta com um API Gateway que centraliza as requisições e distribui para os microserviços correspondentes, facilitando o gerenciamento e a segurança das chamadas. Para executar e testar a aplicação, é necessário rodar cada serviço individualmente e utilizar o Swagger ou Postman para consumir e validar os endpoints.

## Instalação do Sistema

1. **Clone o repositório:**
   ```bash
   
   git clone https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2025-1-dad-g3-melodify.git

2. **Acesse a pasta principal do projeto:**
   ```bash
   
   cd pco-si-2025-1-dad-g3-melodify

3. **Entre na pasta src, onde estão os microserviços separados:**
   ```bash
   
   cd src

3. **Escolha o microserviço que deseja rodar e entre na respectiva pasta:**
   ```bash
   
   cd Serviço (exemplo)
   
4. **Construa e rode a aplicação do microserviço selecionado:**
   ```bash
   
   dotnet build/ dotnet run

## Histórico de Versões

### [1.5.1] - 15/06/2025  
- Atualização do README e documentação de testes.

### [1.5.0] - 13/06/2025  
- Tratativa de erros em avaliações e comentários aprimorada.  
- Testes de autenticação e gestão de usuário realizados.  
- Correções em microserviços e playlists.

### [1.4.0] - 01/06/2025  
- Atualizações nas especificações e desenvolvimento geral.  
- Criação de diagramas UML e de classes para gestão musical.  
- Implementação de rotas no API Gateway.  
- Criação de controllers e services para recomendação musical.  
- Migração e ajustes no banco de dados.

### [1.3.0] - Maio de 2025  
- Primeiras versões das funcionalidades de autenticação, cadastro e estrutura base do projeto.  
- Upload e correção de imagens, diagramas e documentação.


