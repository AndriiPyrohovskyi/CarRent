# 🚗 CarRent - Система Прокату Автомобілів

ASP.NET Core MVC проект з Entity Framework Core для лабораторної роботи по ASP.NET

## 📋 Опис проекту

Система прокату автомобілів з розподілом по ролям:
- **Admin** - повне управління системою
- **Manager** - управління бронюваннями та договорами  
- **Client** - перегляд та бронювання автомобілів

## 🛠 Технології

- ASP.NET Core 9.0 MVC
- Entity Framework Core 9.0
- SQL Server 2022 (Docker)
- Bootstrap 5
- Areas архітектура

## 🗄️ Структура бази даних

- **Cars** - автомобілі (марка, модель, рік, ціна)
- **Users** - користувачі (ім'я, email, роль)  
- **Bookings** - бронювання (дати, статус, ціна)
- **Contracts** - договори (номер, умови)
- **Payments** - платежі (сума, спосіб оплати)

---

## 🚀 Швидкий старт

### 1. Встановлення SQL Server (Docker)

**Видалити старий контейнер (якщо є):**
```bash
sudo docker stop sql2022
sudo docker rm sql2022
```

**Запустити новий контейнер:**
```bash
sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=S2u0!i9aw678" -p 1433:1433 --name sql2022 --restart unless-stopped -d mcr.microsoft.com/mssql/server:2022-latest
```

### 2. Компіляція та запуск проекту

```bash
# Встановити залежності
dotnet restore

# Компілювати проект
dotnet build

# Застосувати міграції до БД
dotnet ef database update

# Запустити проект
dotnet run

# Або з вказівкою URL
dotnet run --urls "http://localhost:5000"
```

### 3. Перевірка бази даних

**Підключення до SQL Server:**
```bash
sqlcmd -S localhost -U SA -P 'S2u0!i9aw678' -C
```

**Основні SQL команди:**
```sql
-- Перегляд баз даних
SELECT name FROM sys.databases;

-- Використати нашу БД
USE CarRentDB_Dev;

-- Перегляд таблиць
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';

-- Перегляд користувачів
SELECT Id, FirstName, LastName, Email, Role FROM Users;

-- Перегляд автомобілів  
SELECT Id, Brand, Model, Year, LicensePlate, PricePerDay FROM Cars;
```

---

## 📁 Структура проекту

```
CarRent/
├── Areas/                          # Розподіл по ролям
│   ├── Admin/                      # Адміністратор
│   ├── Manager/                    # Менеджер
│   └── Client/                     # Клієнт
├── Controllers/                    # Основні контролери
├── Data/                          # EF Core контекст
│   └── CarRentContext.cs          # Налаштування БД
├── Models/                        # Сутності БД
│   ├── Car.cs                     # Автомобіль
│   ├── User.cs                    # Користувач
│   ├── Booking.cs                 # Бронювання
│   ├── Contract.cs                # Договір
│   └── Payment.cs                 # Платіж
├── Migrations/                    # EF Core міграції
├── Views/                         # Razor шаблони
├── wwwroot/                       # Статичні файли
└── Program.cs                     # Конфігурація додатку
```

---

## 🔧 Робота з Entity Framework

### Створення міграцій
```bash
# Додати нову міграцію
dotnet ef migrations add ИмяМиграции

# Застосувати міграції
dotnet ef database update

# Видалити останню міграцію
dotnet ef migrations remove
```

### Робота з базою даних
```bash
# Видалити БД
dotnet ef database drop

# Створити БД заново
dotnet ef database update

# Перегляд інформації про міграції
dotnet ef migrations list
```

---

## 🌐 Маршрути додатку

### Основні маршрути:
- `http://localhost:5000/` - Головна сторінка
- `http://localhost:5000/Home/Privacy` - Приватність

### Areas маршрути:
- `http://localhost:5000/Admin/` - Панель адміністратора
- `http://localhost:5000/Manager/` - Панель менеджера  
- `http://localhost:5000/Client/` - Панель клієнта

---

## 👥 Тестові користувачі

| Email | Роль | Пароль | Опис |
|-------|------|--------|------|
| admin@carrent.com | Admin | - | Повний доступ |
| manager@carrent.com | Manager | - | Управління бронюваннями |
| ivan@example.com | Client | - | Звичайний клієнт |

---

## 🚙 Тестові автомобілі

| Марка | Модель | Рік | Номер | Ціна/день |
|-------|--------|-----|-------|-----------|
| Toyota | Camry | 2022 | АА1234АА | 1200₴ |
| BMW | X5 | 2023 | ВВ5678ВВ | 2500₴ |
| Volkswagen | Golf | 2021 | СС9012СС | 800₴ |

---

## 🔍 Налагодження

### Перевірка Docker контейнера:
```bash
# Статус контейнерів
sudo docker ps

# Логи SQL Server
sudo docker logs sql2022

# Перезапуск контейнера
sudo docker restart sql2022
```

### Частіші проблеми:

**1. Помилка підключення до БД:**
- Перевірити чи запущений Docker контейнер
- Перевірити connection string в appsettings.json

**2. Помилки міграцій:**
- Видалити папку Migrations та створити заново
- Видалити БД і створити знову

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