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
            <h4>Шаг 1 - Исходный текст</h4>
             <asp:RadioButtonList ID="DeciperFileMode" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Table">
            <asp:ListItem Text="Введу исходный текст сам" Value="Input" Selected="True"></asp:ListItem>
                
            <asp:ListItem Text="Выберу файл для загрузки" Value="Download"></asp:ListItem>            
        </asp:RadioButtonList>   
            <br>
            <br>
            <asp:TextBox ID="SourceText" runat="server" Height="200px" Width="100%" TextMode="MultiLine">Введите исходный текст</asp:TextBox>
            <br>
            <br>
            <asp:FileUpload ID="FileUpload" runat="server"/>&nbsp;&nbsp;&nbsp;<br>
            <asp:Label ID="FileError" runat="server" Text=""></asp:Label>
            <br><br>
        </div>
        <hr>
        <div>
            <h4>Шаг 2 - выбор ключа</h4>
            <h4 style="color: orangered">Требования к ключу</h4>
    <ul >
  <li>Длина ключа не может превосходить длину сообщения</li>
  <li>Ключ должен состоять только из символов русского алфавита</li>
  <li>Ключ не чувствителен к регистру (КЛЮЧ=ключ)</li>
  
</ul>
            <asp:RadioButtonList ID="DeciperKeyMode" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Table">
            <asp:ListItem Text="Введу ключ сам" Value="Input" Selected="True"></asp:ListItem>
                
            <asp:ListItem Text="Выберу файл для загрузки" Value="Download"></asp:ListItem>            
        </asp:RadioButtonList>   
            <br>
            <br>
            
            <asp:TextBox ID="Key" runat="server" Height="16px" Width="50%">Введите ключ</asp:TextBox>
            <br>
            <br>
            <asp:FileUpload ID="KeyUpload" runat="server"/>&nbsp;&nbsp;&nbsp;<br>
            <asp:Label ID="KeyError" runat="server" Text=""></asp:Label>
        </div>
         <br>
    <asp:Button ID="DecipeFinal" runat="server" Text="Расшифровать" CssClass="button" Height="53px" Width="154px" OnClick="Deciper_Click"/>
    <br><br><br>
    <asp:TextBox ID="DecipeText" runat="server" Width="100%" Height="200px" TextMode="MultiLine">Здесь будет выведено расшифрованное сообщение</asp:TextBox>
    <br><br>
    <asp:Button ID="SaveTXT" runat="server" Text="Сохранить txt" CssClass="button1" OnClick="SaveTXT_Click" Visible="false" Enabled="false" />&nbsp;&nbsp;&nbsp;<asp:Button ID="SaveDOCX" runat="server" Text="Сохранить docx" CssClass="button1" Visible="false" Enabled="false" OnClick="SaveDOCX_Click"/>
    </form>
    
        
    
   <a href="#" title="Вернуться наверх" class="buttonup"><img src="Img/buttonUp.png" id="up"></a>
</body>
</html>
