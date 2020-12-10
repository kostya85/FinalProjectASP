﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Readme.aspx.cs" Inherits="FinalProjectASP.Readme" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="Styles.css"/>
    <title>README</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 align="center">ИНФОРМАЦИЯ О СЕРВИСЕ</h1>
            <a href="Default.aspx" class="s">Главная</a>-><a href="Readme.aspx" class="s">Информация</a>
            
            <h3>Описание сервиса</h3>
            <p>Данный сервис представляет собой Web-приложение, которое может зашифровать и (или) расшифровать информациию, полученную от пользователя
                в виде загрузки файла на сервер, либо ввода информации в соответствующие поля. В программе используется шифр Вижинера (замена с ключом).
                Шифр Виженера является шифром подстановки, то есть шифром, в котором каждая буква исходного текста заменяется буквой шифр-текста.
            </p>
            <h3>Функциональные возможности</h3>
            <h4>Зашифровка текста</h4>
            <p>
                1. Ввод исходного текста вручную в соотвутствующее поле<br>
                2. Загрузка файла с исходным текстом пользователем (формат файла - .txt, .docx)<br>
                3. Вывод зашифрованного текста в соответствующее поле<br>
                4. Создание ссылок для скачивания зашифрованного текста в форматах .txt, .docx
            </p>
            <h4>Расшифровка текста</h4>
            <p>
                1. Ввод зашифрованного текста вручную в соотвутствующее поле<br>
                2. Загрузка файла с зашифрованным текстом пользователем (формат файла - .txt, .docx)<br>
                3. Вывод расшифрованного текста в соответствующее поле<br>
                4. Создание ссылок для скачивания расшифрованного текста в форматах .txt, .docx
            </p>
            <h4>Информация о разработчике</h4>
            <p>
                На данной странице пользователь сможет найти информацию о разработчике данного сервиса
            </p>
            <h3>Как пользоваться сервисом</h3>
            <h4>Если вы хотите зашифровать информацию</h4>
            <p>
                1. Нажать на пункт меню "Зашифровать" на главной странице сервиса<br>
                2. Выбрать способ передачи информации, подлежащей шифрованию<br>
                3. Выбрать способ передачи ключа шифрования<br>
                4. Ввести информацию, подлежащую шифрованию в поле ввода исходного текста или загрузить файл с компьютера <br>
                (в зависимости от выбранного способа передачи информации сервису)<br>                
                5. Ввести ключ шифрования в поле ввода ключа или загрузить файл с компьютера <br>
                (в зависимости от выбранного способа передачи ключа сервису)<br>
                6. Нажать на кнопку "Зашифровать"<br>
                7. При необходимости скачать файл с зашифрованной информацией в представленных форматах<br>
                
            </p>
             <h4>Если вы хотите расшифровать информацию</h4>
            <p>
                1. Нажать на пункт меню "Расшифровать" на главной странице сервиса<br>
                2. Выбрать способ передачи информации, подлежащей дешифровке<br>
                3. Выбрать способ передачи ключа шифрования<br>
                4. Ввести информацию, подлежащую дешифровке в поле ввода исходного текста или загрузить файл с компьютера <br>
                (в зависимости от выбранного способа передачи информации сервису)<br>
                
                5. Ввести ключ шифрования в поле ввода ключа или загрузить файл с компьютера <br>
                (в зависимости от выбранного способа передачи ключа сервису)<br>
                6. Нажать на кнопку "Расшифровать"<br>
                7. При необходимости скачать файл с расшифрованной информацией в представленных форматах<br>
                
            </p>
            
        </div>
        <a href="#" title="Вернуться наверх" class="buttonup"><img src="Img/buttonUp.png" id="up"></a>
    </form>
</body>
</html>
