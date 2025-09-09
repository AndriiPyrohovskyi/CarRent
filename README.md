LR1 Guide
---
## Delete old container and start new:
```fish
sudo docker stop sql2022
sudo docker rm sql2022
```
```fish
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=S2u0!i9aw678" -p 1433:1433 --name sql2022    --restart unless-stopped -d mcr.microsoft.com/mssql/server:2022-latest
```
## Work with DB
```fish
sqlcmd -S localhost -U SA -P 'S2u0!i9aw678' -C 
```


# Компілюємо проект
dotnet build

# Запускаємо проект
dotnet run

# Або з вказівкою URL
dotnet run --urls "http://localhost:5000"