
---

## Como Executar o Projeto

### 1. Clone o repositório

```bash
git clone https://github.com/jonatasgpj/recipeAPI-SQL-docker.git
cd recipeAPI-SQL-docker
```

### 2. Configure variáveis de ambiente

Crie um arquivo `.env` na raiz do projeto com o seguinte conteúdo:

```env
SA_PASSWORD=SENHA
```

### 3. Crie o arquivo `appsettings.json`

Dentro da pasta `recipe-docker`, crie um arquivo chamado `appsettings.json` com o seguinte conteúdo:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=recipeAPI;User Id=sa;Password=SENHA;TrustServerCertificate=True;"
  },
  "AllowedHosts": "*"
}
```

> Essa string de conexão é usada apenas ao rodar comandos `dotnet ef` fora do container.

### 4. Construa e suba os containers

```bash
docker compose up --build
```

Os containers criados:

- `recipe-api` (API .NET)
- `recipe-sql` (SQL Server)

### 5. Execute a migration (caso esteja fora do container)

No host (fora do container), atualize o banco de dados com:

```bash
dotnet ef database update
```

---

## Conexão com o banco de dados

- **Servidor:** `localhost,1433`
- **Usuário:** `sa`
- **Senha:** a mesma definida no `.env`
- **Banco:** `recipeAPI`
