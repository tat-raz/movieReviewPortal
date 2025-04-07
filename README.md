
# Russian

Это веб-приложение на ASP.NET Web Forms, которое позволяет пользователям просматривать список фильмов и оставлять отзывы с рейтингом. Интерфейс стилизован под кинотеатр.

## Установка

Клонируйте репозиторий на свой компьютер:
```bash
git clone https://github.com/your-username/MovieReviewPortal.git
```

Откройте проект в Visual Studio и настройте строку подключения в `Web.config`:
```xml
<connectionStrings>
  <add name="DefaultConnection" connectionString="Data Source=YOUR_SERVER;Initial Catalog=MovieDB;Integrated Security=True" />
</connectionStrings>
```

Создайте базу данных и выполните начальный SQL-скрипт, если требуется.

## Запуск

Запустите проект в Visual Studio:
- Нажмите `F5` или кнопку **Start Debugging**

Приложение откроется в браузере по адресу `http://localhost:PORT/`

## Функциональность

- Отображение списка фильмов
- Просмотр и добавление отзывов
- Аутентификация и регистрация пользователей с проверкой данных
- Тематический интерфейс в стиле кинозала

## Технологии  
ASP.NET Web Forms  
C#  
ADO.NET  
HTML / CSS  
SQL Server  

## Автор  
https://github.com/tat-raz

---

# English

This is a web application built with ASP.NET Web Forms that allows users to view a list of movies and submit reviews with ratings. The interface is styled like a cinema hall.

## Installation

Clone the repository to your computer:
```bash
git clone https://github.com/your-username/MovieReviewPortal.git
```

Open the project in Visual Studio and configure the connection string in `Web.config`:
```xml
<connectionStrings>
  <add name="DefaultConnection" connectionString="Data Source=YOUR_SERVER;Initial Catalog=MovieDB;Integrated Security=True" />
</connectionStrings>
```

Create a database and run the initial SQL script if required.

## Launch

Run the project in Visual Studio:
- Press `F5` or click **Start Debugging**

The application will open in your browser at `http://localhost:PORT/`

## Functionality

- View a list of movies  
- View and add reviews  
- User registration and authentication with data verification
- Cinema-themed user interface  

## Technologies  
ASP.NET Web Forms  
C#  
ADO.NET  
HTML / CSS  
SQL Server  

## Author  
https://github.com/tat-raz
