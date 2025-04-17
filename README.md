# Бронирование номеров в гостинице

## Описание проекта
Проект представляет собой приложение на C#, предназначенное для управления бронированием номеров в гостинице. Приложение позволяет администраторам и менеджерам добавлять, редактировать и удалять записи о бронировании, назначать уборку и ремонт номеров, а также управлять данными клиентов.

## Установка и запуск проекта

### Шаг 1: Установка MySQL
1. Скачайте и установите MySQL Server с официального сайта.
2. Создайте базу данных `room_reservations` и таблицы в соответствии со схемой ниже.

### Шаг 2: Настройка базы данных
Создайте базу данных `room_reservations` и таблицы с помощью следующих SQL-запросов:

CREATE DATABASE room_reservations;

USE room_reservations;

CREATE TABLE nf_role (
    id_role INT PRIMARY KEY AUTO_INCREMENT,
    name_role VARCHAR(50) NOT NULL
);

CREATE TABLE acount (
    id_acount INT PRIMARY KEY AUTO_INCREMENT,
    login VARCHAR(50) NOT NULL,
    pasword VARCHAR(50) NOT NULL,
    id_role INT,
    FOREIGN KEY (id_role) REFERENCES nf_role(id_role)
);

CREATE TABLE clients (
    id_client INT PRIMARY KEY AUTO_INCREMENT,
    lastname VARCHAR(50) NOT NULL,
    name VARCHAR(50) NOT NULL,
    second_name VARCHAR(50) NOT NULL,
    passport INT NOT NULL,
    statys VARCHAR(50) NOT NULL
);

CREATE TABLE reservation (
    id_reservation INT PRIMARY KEY AUTO_INCREMENT,
    familia_client VARCHAR(50) NOT NULL,
    checkin_date INT NOT NULL,
    exit_date INT NOT NULL,
    room INT NOT NULL,
    mount INT NOT NULL,
    year INT NOT NULL,
    comment VARCHAR(255),
    price INT
);
## Шаг 3: Настройка проекта
- Скачайте исходный код проекта с репозитория GitHub.
- Откройте проект в Visual Studio.
- Убедитесь, что строка подключения к базе данных в файле DBconection.cs соответствует вашим настройкам MySQL:
static string DBconect = "server = localhost; user=root; password=; database=room_reservations";
- Соберите и запустите проект.
## Использование приложения
### Авторизация
- Запустите приложение.
- Введите логин и пароль в соответствующие поля.
- Нажмите кнопку "Войти".
### Функциональность администратора
- Просмотр календаря бронирований : Выберите месяц и год в выпадающих списках и нажмите кнопку "Показать".
- Назначение уборки : Откройте форму "Назначение уборки" и заполните необходимые поля.
- Назначение ремонта : Откройте форму "Назначение ремонта" и заполните необходимые поля.
- Заселение гостя : Откройте форму "Заселение гостя" и заполните необходимые поля.
### Функциональность менеджера
- Просмотр списка клиентов : В форме менеджера отображается список всех клиентов.
- Добавление клиента : Заполните поля и нажмите кнопку "Добавить".
- Редактирование клиента : Выберите клиента в списке и нажмите кнопку "Редактировать".
- Удаление клиента : Выберите клиента в списке и нажмите кнопку "Удалить".
