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
    <a href="Default.aspx" class="s">Главная</a>-><a href="Decipe.aspx" class="s">Расшифровка</a>
    
    <h3>Пожалуйста, введите недостающие данные</h3>
    <form id="form1" runat="server">
        <div>
             <asp:RadioButtonList ID="DeciperFileMode" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Table" AutoPostBack="true" OnSelectedIndexChanged="DeciperFileMode_SelectedIndexChanged">
            <asp:ListItem Text="Ввести исходный текст вручную" Value="Input" Selected="True" ></asp:ListItem>
                
            <asp:ListItem Text="Выбрать файл для загрузки" Value="Download"></asp:ListItem>            
        </asp:RadioButtonList>   
            <br>
            <asp:RadioButtonList ID="DeciperKeyMode" runat="server" 
            RepeatDirection="Horizontal" RepeatLayout="Table" OnSelectedIndexChanged="DeciperKeyMode_SelectedIndexChanged" AutoPostBack="true">
            <asp:ListItem Text="Ввести ключ вручную" Value="Input" Selected="True"></asp:ListItem>
                
            <asp:ListItem Text="Выбрать файл для загрузки" Value="Download"></asp:ListItem>            
        </asp:RadioButtonList>   
            <h4>Шаг 1 - Исходный текст</h4>
            <br>
            <br>
            <asp:TextBox ID="SourceText" runat="server" Height="200px" Width="100%" TextMode="MultiLine" CssClass="text">Введите исходный текст</asp:TextBox>
            <br>
            <br>
            <asp:FileUpload ID="FileUpload" runat="server" Visible="false" Enabled="false"/>&nbsp;&nbsp;&nbsp;<br>
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
            <br>
            <br>
            
            <asp:TextBox ID="Key" runat="server" Height="24px" Width="50%" CssClass="text">Введите ключ</asp:TextBox>
            <br>
            <br>
            <asp:FileUpload ID="KeyUpload" runat="server" Visible="false" Enabled="false" />&nbsp;&nbsp;&nbsp;<br>
            <asp:Label ID="KeyError" runat="server" Text=""></asp:Label>
        </div>
         <br>
    <asp:Button ID="DecipeFinal" runat="server" Text="Расшифровать" CssClass="button" Height="53px" Width="154px" OnClick="Deciper_Click"/>
    <br><br><br>
    <asp:TextBox ID="DecipeText" runat="server" Width="100%" Height="200px" TextMode="MultiLine" CssClass="text">Здесь будет выведено расшифрованное сообщение</asp:TextBox>
    <br><br>
    <asp:Button ID="SaveTXT" runat="server" Text="Сохранить txt" CssClass="button" OnClick="SaveTXT_Click" Visible="false" Enabled="false" Height="50px" />&nbsp;&nbsp;&nbsp;<asp:Button ID="SaveDOCX" runat="server" Text="Сохранить docx" CssClass="button" Visible="false" Enabled="false" OnClick="SaveDOCX_Click" Height="50px"/>
    </form>
    
        
    
   <a href="#" title="Вернуться наверх" class="buttonup"><img src="Img/buttonUp.png" id="up"></a>
</body>
</html>
