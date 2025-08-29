# SeuProjeto (Backend .NET 8 + Frontend simples)
Conteúdo: pasta `backend/Api` com um Web API mínimo em .NET 8 e `frontend/` com HTML/CSS/JS que consome a API.

Como usar:
1. Instale .NET 8 SDK e MySQL.
2. Ajuste `backend/Api/appsettings.json` com sua connection string.
3. Na pasta `backend/Api` rode:
   - `dotnet tool install --global dotnet-ef` (se precisar)
   - `dotnet add package Pomelo.EntityFrameworkCore.MySql`
   - `dotnet add package Microsoft.EntityFrameworkCore.Design`
   - `dotnet add package Swashbuckle.AspNetCore`
   - `dotnet ef migrations add InitialCreate`
   - `dotnet ef database update`
   - `dotnet run`
4. Abra `frontend/index.html` no browser (ou use um servidor estático) e ajuste a URL da API se as portas diferirem.

Observações:
- Não comite senhas; use variáveis de ambiente em produção.
- Este projeto é uma base; sinta-se à vontade para pedir que eu gere variações (MVC, React/Vite, Docker, etc.).
