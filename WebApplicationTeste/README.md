Conexão com o banco de dados

- Instalar os pacotes para a solução
    - EntityFrameworkCore
    - EntityFrameworkCore tools
    - Mysql.EntityFrameworkCore

No Console do Gerenciador de pacotes execute:

```csharp
Add-Migration CriandoTabelaDeFilmes
```

```csharp
Update-Database
```