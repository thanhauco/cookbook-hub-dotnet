# CookBook Hub - Deployment Guide

## Prerequisites
- .NET 9 SDK
- PostgreSQL 15+
- Docker (optional)

## Local Development

### 1. Database Setup
```bash
# Create PostgreSQL database
createdb cookbook_hub

# Update connection string in appsettings.json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=cookbook_hub;Username=postgres;Password=yourpassword"
}
```

### 2. Run Migrations
```bash
cd CookBookHub.Infrastructure
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3. Seed Database
```bash
cd CookBookHub.ApiService
dotnet run --seed
```

### 4. Run Application
```bash
# Terminal 1 - API
cd CookBookHub.ApiService
dotnet run

# Terminal 2 - Web
cd CookBookHub.Web
dotnet run
```

## Docker Deployment

### Build Images
```bash
# Build API image
docker build -t cookbook-api -f CookBookHub.ApiService/Dockerfile .

# Build Web image
docker build -t cookbook-web -f CookBookHub.Web/Dockerfile .
```

### Run with Docker Compose
```yaml
version: '3.8'
services:
  postgres:
    image: postgres:15
    environment:
      POSTGRES_DB: cookbook_hub
      POSTGRES_PASSWORD: yourpassword
    ports:
      - "5432:5432"

  api:
    image: cookbook-api
    depends_on:
      - postgres
    environment:
      ConnectionStrings__DefaultConnection: "Host=postgres;Database=cookbook_hub;Username=postgres;Password=yourpassword"
    ports:
      - "5000:80"

  web:
    image: cookbook-web
    depends_on:
      - api
    environment:
      ApiBaseUrl: "http://api:80"
    ports:
      - "5001:80"
```

```bash
docker-compose up -d
```

## Cloud Deployment

### Azure App Service

1. Create Azure resources:
```bash
az group create --name cookbook-rg --location eastus
az postgres flexible-server create --resource-group cookbook-rg --name cookbook-db
az appservice plan create --name cookbook-plan --resource-group cookbook-rg --sku B1
az webapp create --name cookbook-api --plan cookbook-plan --resource-group cookbook-rg
az webapp create --name cookbook-web --plan cookbook-plan --resource-group cookbook-rg
```

2. Deploy:
```bash
dotnet publish -c Release
az webapp deployment source config-zip --resource-group cookbook-rg --name cookbook-api --src api.zip
az webapp deployment source config-zip --resource-group cookbook-rg --name cookbook-web --src web.zip
```

### AWS Elastic Beanstalk

1. Install EB CLI:
```bash
pip install awsebcli
```

2. Initialize and deploy:
```bash
eb init -p dotnet-core cookbook-hub
eb create cookbook-env
eb deploy
```

## Environment Variables

### Required
- `ConnectionStrings__DefaultConnection` - Database connection string
- `ApiBaseUrl` - API base URL for web app

### Optional
- `ASPNETCORE_ENVIRONMENT` - Development/Staging/Production
- `Logging__LogLevel__Default` - Log level
- `AllowedHosts` - CORS allowed hosts

## Health Checks

API health endpoint: `GET /health`

Expected response:
```json
{
  "status": "Healthy",
  "database": "Connected"
}
```

## Monitoring

### Application Insights (Azure)
```json
"ApplicationInsights": {
  "InstrumentationKey": "your-key"
}
```

### CloudWatch (AWS)
```bash
aws logs create-log-group --log-group-name /aws/elasticbeanstalk/cookbook-hub
```

## Backup

### Database Backup
```bash
pg_dump cookbook_hub > backup.sql
```

### Restore
```bash
psql cookbook_hub < backup.sql
```

## Troubleshooting

### Database Connection Issues
- Verify connection string
- Check firewall rules
- Ensure database is running

### Migration Errors
```bash
dotnet ef database drop --force
dotnet ef database update
```

### Performance Issues
- Enable response caching
- Add database indexes
- Use CDN for static assets
