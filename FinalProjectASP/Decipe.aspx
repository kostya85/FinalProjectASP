<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Decipe.aspx.cs" Inherits="FinalProjectASP.Decipe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Расшифровать</title>
    <link rel="stylesheet" href="Styles.css"/>
</head>
<body>
    <h1 align="center">Расшифровка сообщения</h1>
    <a href="Default.aspx">Главная</a>-><a href="Decipe.aspx">Расшифровка</a>
    <h2 align="center">На данной странице Вы сможете расшифровать сообщения с помощью шифра Вижинера</h2>
    <h3>Пожалуйста, введите недостающие данные</h3>
    <form id="form1" runat="server">
        <div>

             <asp:RadioButtonList ID="DeciperFileMode" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Table">
            <asp:ListItem Text="Введу исходный текст сам" Value="Input" Selected="True"></asp:ListItem>
                
            <asp:ListItem Text="Выберу файл для загрузки" Value="Download"></asp:ListItem>            
        </asp:RadioButtonList>   <asp:Button ID="FileChooser" runat="server" Text="Готово!" OnClick="FileChooser_Click" CssClass="button" Height="39px" Width="100px" />
            <br>
            <br>
            <asp:TextBox ID="SourceText" runat="server" Height="200px" Width="100%" TextMode="MultiLine">Введите исходный текст</asp:TextBox>
            <br>
            <br>
            <asp:FileUpload ID="FileUpload" runat="server"/>&nbsp;&nbsp;&nbsp;<asp:Button ID="Download" runat="server" Text="Загрузить файл" CssClass="button" Height="54px" OnClick="Download_Click"/>
            <br>
            <asp:Label ID="FileError" runat="server" Text=""></asp:Label>

        </div>
        <hr>
        <div>

            <asp:RadioButtonList ID="DeciperKeyMode" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Table">
            <asp:ListItem Text="Введу ключ сам" Value="Input" Selected="True"></asp:ListItem>
                
            <asp:ListItem Text="Выберу файл для загрузки" Value="Download"></asp:ListItem>            
        </asp:RadioButtonList>   <asp:Button ID="KeyChooser" runat="server" Text="Готово!" OnClick="KeyChooser_Click" CssClass="button" Height="39px" Width="100px" />
            <br>
            <br>
            
            <asp:TextBox ID="Key" runat="server" Height="16px" Width="50%">Введите ключ</asp:TextBox>
            <br>
            <br>
            <asp:FileUpload ID="KeyUpload" runat="server"/>&nbsp;&nbsp;&nbsp;<asp:Button ID="DownloadKey" runat="server" Text="Загрузить файл" CssClass="button" Height="54px"/>
            <br>

        </div>
         <br>
    <asp:Button ID="Button2" runat="server" Text="Расшифровать" CssClass="button" Height="53px" Width="154px"/>
    <br><br><br>
    <asp:TextBox ID="DecipeText" runat="server" Width="100%" Height="200px" TextMode="MultiLine"></asp:TextBox>
    <br><br>
    <asp:Button ID="SaveTXT" runat="server" Text="Сохранить txt" />&nbsp;&nbsp;&nbsp;<asp:Button ID="SaveDOCX" runat="server" Text="Сохранить docx" />
    </form>
    
    
        
    
   
</body>
</html>
