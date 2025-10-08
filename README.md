# Orders API

API para gerenciamento de pedidos com arquitetura de microserviços e comunicação orientada a eventos.

## ✅ Funcionalidades Principais
### 🎮 Gestão de Pedidos
- Criação de pedidos com disparo assíncrono para fila de pagamento
- Listagem completa de pedidos
- Consulta de pedido por ID
- Atualização de status dos pedidos
- Cancelamento de pedidos

### 🔐 Segurança e Middleware
- Middleware global de tratamento de erros
- Retorno padronizado com ErrorResponse
- Registro de logs com RequestId único
- Autenticação com Token JWT da FCG.Users.API
- Verificação de permissões por endpoint

## 🧪 Testes

- Testes unitários completos
- Cobertura de regras de domínio, autenticação e serviços
- Cenários válidos e inválidos
- Mocks de repositórios e serviços

  ## 🛠 Tecnologias Utilizadas

- **Framework**: .NET 8
- **ORM**: Entity Framework Core com Migrations
- **Banco de Dados**: SQL Server
- **Autenticação**: JWT (JSON Web Tokens)
- **Testes**: xUnit, Moq e FluentAssertions
- **Documentação**: Swashbuckle.AspNetCore (Swagger)
- **Segurança**: PBKDF2 para hash de senhas
- **Logging**: Middleware customizado para Request/Response
- **Containerização**: Docker com multi-stage build
- **Monitoramento**: New Relic
- **Mensageria**: Azure Service Bus com Tópicos e Subscriptions
- **Processamento Assíncrono**: Azure Functions
- **Orquestração**: Azure Container Apps
- **API Gateway**: Azure API Management
- **CI/CD**: Azure DevOps

## ⚙️ Pré-requisitos

- .NET 8 SDK
- SQL Server

## 🛠️ Configuração

1. Configure a connection string no `appsettings.json` ou variáveis de ambiente
2. Execute as migrations para criar o banco de dados
3. Execute a aplicação
4. Acesse a documentação Swagger em `http://localhost:<porta>/swagger/index.html`

## 🔐 Autenticação

1. Faça login em `/auth/login` (projeto do microservice fcg-users)
2. Use o token Bearer retornado no header `Authorization` das requisições protegidas

## 📁 Estrutura do Projeto

```
fcg-games/
├── API/                 # Controllers e Middlewares
├── Application/         # Serviços, DTOs e Interfaces
├── Domain/             # Entidades e Regras de Negócio
├── Infrastructure/     # EF, Repositórios, Migrations
├── Tests/              # Testes Unitários e de Integração
```

## ☁️ Infraestrutura Azure

- **Banco de Dados**: Azure SQL Database
- **Containerização**: Azure Container Registry & Container Apps
- **API**: Azure API Management
- **Mensageria**: Azure Service Bus
- **Serverless**: Azure Functions
- **Monitoramento**: New Relic (configurado via Dockerfile)
