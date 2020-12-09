<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="FinalProjectASP.About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Styles.css"/>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>О разработчике</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 align="center">Информация о разработчике</h1>
    <a href="Default.aspx" class="s">Главная</a>-><a href="About.aspx" class="s">О разработчике</a>
  
    <h3 align="center">Константин Горбунов</h3>
             <p align="center">
            Контактные данные
                 </p>
            <h4 align="center">gorbunov.kostya@bk.ru</h4>
            <p align="center">
            <asp:Button ID="Button1" runat="server" Text="На главную" CssClass="button" OnClick="Button1_Click" Height="50px"/>
                </p>
        </div>
    </form>
</body>
</html>
