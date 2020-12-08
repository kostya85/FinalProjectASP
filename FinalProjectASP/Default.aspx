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
        
            <p align="center">
            <asp:Button ID="Button1" runat="server" Height="74px" Text="Расшифровать" Width="157px" CssClass="button" OnClick="Button1_Click"/>
                </p>
        
        <p align="center">
            <asp:Button ID="Button2" runat="server" Height="63px" Text="Зашифровать" Width="157px" CssClass="button" OnClick="Button2_Click"/>
        </p>
        <p align="center">
        <asp:Button ID="Button3" runat="server" Height="58px" Text="О разработчике" Width="157px" CssClass="button" OnClick="Button3_Click" />
            </p>
    </form>
</body>
</html>
