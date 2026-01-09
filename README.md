# 🛒 Orders API - FCG (FIAP Cloud Games)

API para gerenciamento de pedidos com arquitetura de microserviços e comunicação orientada a eventos. Parte da plataforma FCG que oferece um ecossistema completo para jogos em nuvem.

## ✅ Funcionalidades Principais

### 🛒 Gestão de Pedidos

- ✅ Criação de pedidos com validações completas
- ✅ Disparo assíncrono para fila de pagamento
- ✅ Listagem completa de pedidos com paginação
- ✅ Consulta de pedido por ID
- ✅ Rastreamento de status dos pedidos
- ✅ Atualização de status com notificações
- ✅ Cancelamento de pedidos
- ✅ Suporte para múltiplos métodos de pagamento
- ✅ Notificações de eventos em tempo real via Azure Service Bus

### 💳 Processamento de Pagamentos

- ✅ Integração com gateway de pagamento
- ✅ Suporte para múltiplos métodos (cartão, boleto, PIX)
- ✅ Processamento assíncrono de transações
- ✅ Rastreamento de status de pagamento
- ✅ Integração com Azure Service Bus para fila de pagamentos

### 🔐 Segurança e Middleware

- ✅ Middleware global de tratamento de erros
- ✅ Retorno padronizado com ErrorResponse
- ✅ Registro de logs com RequestId único
- ✅ Autenticação com Token JWT da FCG.Users API
- ✅ Verificação de permissões por endpoint
- ✅ CORS configurado para segurança
- ✅ Rate limiting e proteção contra ataques

### 📊 Observabilidade

- ✅ Testes unitários completos com cobertura alta
- ✅ Logging centralizado via New Relic
- ✅ Rastreamento de requisições
- ✅ Métricas de performance e transações

## 🧪 Testes

- Testes unitários completos com xUnit
- Cobertura de regras de domínio, processamento de pedidos e pagamentos
- Cenários válidos e inválidos
- Mocks de repositórios e serviços com Moq
- FluentAssertions para leitura clara dos testes

## 🛠 Tecnologias Utilizadas

| Camada                       | Tecnologias                                      |
| ---------------------------- | ------------------------------------------------ |
| **Framework**                | .NET 8                                           |
| **ORM**                      | Entity Framework Core com Migrations             |
| **Banco de Dados**           | SQL Server                                       |
| **Autenticação**             | JWT (JSON Web Tokens) - Integração FCG.Users API |
| **Testes**                   | xUnit, Moq, FluentAssertions                     |
| **API Documentation**        | Swashbuckle.AspNetCore (Swagger)                 |
| **Segurança**                | PBKDF2 para hash de senhas                       |
| **Logging**                  | Middleware customizado + New Relic               |
| **Containerização**          | Docker com multi-stage build                     |
| **Monitoramento**            | New Relic APM                                    |
| **Mensageria**               | Azure Service Bus (Tópicos e Subscriptions)      |
| **Processamento Assíncrono** | Hosted Services, Azure Functions                 |
| **Orquestração**             | Azure Container Apps                             |
| **API Gateway**              | Azure API Management                             |
| **CI/CD**                    | GitHub Actions / Azure DevOps                    |

## ⚙️ Pré-requisitos

- .NET 8 SDK ou superior
- SQL Server 2019+ (local ou Azure SQL Database)
- Docker (para containerização)
- Git
- Visual Studio 2022 ou VS Code com C# extensions

## 🛠️ Como Executar Localmente

### 1. Clonar o repositório

```bash
git clone https://github.com/seu-repo/fcg-orders.git
cd fcg-orders
```

### 2. Restaurar dependências

```bash
dotnet restore
```

### 3. Configurar o banco de dados

Atualize a connection string em `appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=FCGOrdersDb;User Id=sa;Password=YourPassword;"
  }
}
```

### 4. Executar as Migrations

```bash
dotnet ef database update --project Infrastructure --startup-project API
```

### 5. Executar a aplicação

```bash
dotnet run --project API
```

A API estará disponível em: `https://localhost:5003`

### 6. Acessar Swagger

```
https://localhost:5003/swagger
```

## 🐳 Executar com Docker

```bash
docker build -t fcg-orders:latest .
docker run -p 5003:5003 -e ASPNETCORE_ENVIRONMENT=Production fcg-orders:latest
```

Ou usando docker-compose (se existir):

```bash
docker-compose up -d
```

## 🔐 Autenticação

### Fluxo de Autenticação

1. Faça login na **FCG.Users API** em `/api/auth/login`
2. Copie o token Bearer retornado
3. Use o token no header `Authorization` das requisições protegidas

### Exemplo

```http
POST /api/orders
Authorization: Bearer {seu_token_aqui}
Content-Type: application/json

{
  "gameId": "550e8400-e29b-41d4-a716-446655440000",
  "quantity": 1,
  "paymentMethod": "CreditCard"
}
```

## 📚 Endpoints Principais

### Pedidos

- `POST /api/orders` - Criar pedido
- `GET /api/orders` - Listar pedidos com paginação
- `GET /api/orders/{id}` - Obter detalhes do pedido
- `PUT /api/orders/{id}` - Atualizar pedido
- `DELETE /api/orders/{id}` - Cancelar pedido
- `PATCH /api/orders/{id}/status` - Atualizar status
- `POST /api/orders/{id}/pay` - Processar pagamento

### Pagamentos

- `GET /api/orders/{orderId}/payment-status` - Verificar status do pagamento
- `POST /api/orders/{orderId}/payment-methods` - Listar métodos disponíveis

### Health Check

- `GET /health` - Status da aplicação

## 📁 Estrutura do Projeto

```
fcg-orders/
├── API/                          # Camada de Apresentação
│   ├── Controllers/              # Endpoints da API
│   ├── Middlewares/              # Error handling, logging
│   ├── Models/                   # Request/Response models
│   ├── Program.cs                # Configuração da aplicação
│   └── appsettings.json          # Configurações
│
├── Application/                  # Camada de Aplicação
│   ├── Services/                 # Lógica de negócio
│   ├── Interfaces/               # Contratos de serviços
│   ├── DTO/                      # Data Transfer Objects
│   ├── Mappings/                 # AutoMapper profiles
│   └── Exceptions/               # Exceções customizadas
│
├── Domain/                       # Camada de Domínio
│   ├── Entities/                 # Modelos de domínio (Order, Game)
│   ├── Enums/                    # Enumerações (OrderStatus, PaymentMethod)
│   ├── Exceptions/               # Exceções de negócio
│   ├── ValueObjects/             # Value Objects (PaymentMethodDetails)
│   └── Repositories/             # Interfaces de repositórios
│
├── Infrastructure/               # Camada de Infraestrutura
│   ├── Context/                  # DbContext do EF
│   ├── Repositories/             # Implementação de repositórios
│   ├── Migrations/               # Migrações do banco
│   ├── Services/                 # Serviços externos (Pagamento, Queue)
│   └── Configurations/           # Configurações do EF
│
├── Tests/                        # Testes Automatizados
│   └── UnitTests/                # Testes unitários
│
└── k8s/                          # Manifesto Kubernetes
    ├── deployment.yaml           # Configuração de deployment
    ├── service.yaml              # Serviço
    ├── configmap.yaml            # Variáveis de configuração
    └── secret.yaml               # Secrets
```

## 🚀 Deployment

### Azure Container Apps

1. **Build da imagem Docker**

```bash
az acr build --registry {seu-registry} --image fcg-orders:latest .
```

2. **Deploy com Kubernetes**

```bash
kubectl apply -f k8s/
```

3. **Verificar status**

```bash
kubectl get pods
kubectl logs -f deployment/fcg-orders
```

### Variáveis de Ambiente

Configure as seguintes variáveis:

```env
ASPNETCORE_ENVIRONMENT=Production
DATABASE_CONNECTION_STRING=Server=...;Database=...
JWT_SECRET_KEY=sua-chave-secreta-muito-segura
JWT_EXPIRATION_MINUTES=1440
NEW_RELIC_LICENSE_KEY=seu-license-key
AZURE_SERVICE_BUS_CONNECTION_STRING=Endpoint=...
LOG_LEVEL=Information
```

## ☁️ Infraestrutura Azure

- **Banco de Dados**: Azure SQL Database
- **Container Registry**: Azure Container Registry (ACR)
- **Orquestração**: Azure Container Apps
- **Mensageria**: Azure Service Bus (filas e tópicos)
- **Serverless**: Azure Functions (para processamento assíncrono de pagamentos)
- **API Gateway**: Azure API Management
- **Monitoramento**: New Relic APM
- **CI/CD**: GitHub Actions (workflows em `.github/workflows/`)

## 💳 Processamento de Pagamentos

### Criar Pedido com Pagamento

```http
POST /api/orders
Authorization: Bearer {token}
Content-Type: application/json

{
  "gameId": "550e8400-e29b-41d4-a716-446655440000",
  "quantity": 1,
  "paymentMethod": {
    "type": "CreditCard",
    "cardNumber": "****-****-****-1234",
    "expiryMonth": 12,
    "expiryYear": 2026
  }
}
```

### Verificar Status do Pagamento

```http
GET /api/orders/550e8400-e29b-41d4-a716-446655440000/payment-status
Authorization: Bearer {token}
```

## 🧪 Executar Testes

```bash
# Todos os testes
dotnet test

# Com cobertura
dotnet test /p:CollectCoverage=true

# Teste específico
dotnet test --filter "CategoryName=OrderServiceTests"
```

## 📊 Monitoramento

### New Relic

- Dashboard de performance
- Rastreamento de transações
- Alertas automáticos
- Análise de logs

### Health Check

```http
GET /health
```

Retorna status da aplicação e dependências:

```json
{
  "status": "Healthy",
  "timestamp": "2026-01-09T10:30:00Z",
  "database": "Connected",
  "servicebus": "Connected",
  "paymentGateway": "Connected"
}
```

## 📝 Logging

Todos os logs são centralizados via New Relic. O middleware customizado adiciona:

- RequestId único
- Timestamp
- HTTP Method e Path
- Status code
- Duração da requisição
- Detalhes de processamento de pagamento
- Erros detalhados

## 🔗 Links Úteis

- [Documentação .NET 8](https://learn.microsoft.com/pt-br/dotnet/)
- [Entity Framework Core](https://learn.microsoft.com/pt-br/ef/core/)
- [JWT.io](https://jwt.io/)
- [Azure Documentation](https://learn.microsoft.com/pt-br/azure/)
- [New Relic Docs](https://docs.newrelic.com/)

## 🤝 Contribuindo

1. Faça um Fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob licença MIT. Veja o arquivo LICENSE para mais detalhes.

## 👥 Autores

- **Projeto**: FIAP Cloud Games (FCG)
- **Mantido por**: Time de Desenvolvimento

## 📞 Suporte

Para problemas, dúvidas ou sugestões, abra uma issue no repositório ou entre em contato com o time de desenvolvimento.
