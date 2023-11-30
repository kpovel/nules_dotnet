<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Завдання</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Прізвище: <asp:TextBox ID="SurnameTextBox" runat="server"></asp:TextBox><br />
        Ім'я: <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox><br />
        Email: <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox><br />
        <asp:Button ID="SubmitButton" runat="server" Text="Відправити" OnClick="SubmitButton_Click" />
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>

