<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalProjectASP.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Главная</title>
    <link rel="stylesheet" href="Styles.css"/>
</head>
<body >
    <form id="form1" runat="server">
        <h1 align="center">Криптограф Версия 1.0</h1>
            <p align="center">
            <asp:Button ID="Button1" runat="server" Height="90px" Text="Расшифровать" Width="250px" CssClass="button" OnClick="Button1_Click" Font-Size="Large"/>
                </p>
        
        <p align="center">
            <asp:Button ID="Button2" runat="server" Height="90px" Text="Зашифровать" Width="250px" CssClass="button" OnClick="Button2_Click" Font-Size="Large"/>
        </p>
        <p align="center">
        <asp:Button ID="Button4" runat="server" Height="90px" Text="О сервисе" Width="250px" CssClass="button" OnClick="Button4_Click"  Font-Size="Large"/>
            </p>
        <p align="center">
        <asp:Button ID="Button3" runat="server" Height="90px" Text="О разработчике" Width="250px" CssClass="button" OnClick="Button3_Click"  Font-Size="Large"/>
            </p>
    </form>
</body>
</html>
