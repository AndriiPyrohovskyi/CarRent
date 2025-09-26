# CarRent - Система Прокату Автомобілів

## Запуск проекту

### 1. Запуск SQL Server (Docker)
```bash
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=StrongPassword123!' -p 1433:1433 --name sql2022 --restart unless-stopped -v mssql-data:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest
```

### 2. Запуск застосунку
```bash
cd CarRent
dotnet restore
dotnet build
dotnet ef database update
dotnet run
```

### 3. Доступ до застосунку
- Основний сайт: `http://localhost:5019`
- Автомобілі: `http://localhost:5019/Cars`
- Адмін панель: `http://localhost:5019/Admin`

**3. Помилки компіляції Areas:**
- Перевірити наявність контролерів в Areas
- Перевірити атрибути [Area] в контролерах

---

## 📚 Корисні команди

```bash
# Очистка проекту
dotnet clean

# Відновлення пакетів
dotnet restore

# Перевірка версії .NET
dotnet --version

# Список встановлених EF tools
dotnet tool list --global

# Встановлення EF tools (якщо потрібно)
dotnet tool install --global dotnet-ef
```

---

## 📝 TODO для розвитку

- [ ] Додати автентифікацію та авторизацію
- [ ] Реалізувати CRUD операції для всіх сутностей
- [ ] Додати валідацію форм
- [ ] Створити API контролери
- [ ] Додати тестування
- [ ] Покращити UI/UX

---

## 👨‍💻 Автор

**Andriy Pyrohovskyi**  
GitHub: [AndriiPyrohovskyi](https://github.com/AndriiPyrohovskyi)

---

*Цей проект створено для навчальних цілей в рамках курсу ASP.NET Core MVC*



# 1. Переконайтесь що SQL Server працює
docker ps

# 2. Застосувати міграції з seed даними
dotnet ef database update

# Або з явним connection string:
dotnet ef database update --connection "Server=localhost,1433;Database=CarRentDB_Dev;User Id=sa;Password=StrongPassword123!;TrustServerCertificate=true;Encrypt=false"