<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RepresRegistration.aspx.cs" Inherits="M2App.RepresRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccffff">
    <div class="div" align="center">
    <form id="RepresForm" runat="server">
        <div>
            Club Representative Registration<br />
            <br />
            Name&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            <br />
            Club Name:<asp:TextBox ID="Cname" runat="server"></asp:TextBox>
            <br />
            <br />
            Username:&nbsp; <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:&nbsp; <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
        </div>
    </form>
        </div>
</body>
</html>
