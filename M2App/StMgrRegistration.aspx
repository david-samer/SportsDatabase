<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StMgrRegistration.aspx.cs" Inherits="M2App.StMgrRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccffff">
    <div class="div" align="center">
    <form id="form1" runat="server">
        <div>
            Stadium Manager Registration<br />
            <br />
            Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            <br />
            Stadium Name:<asp:TextBox ID="StadiumName" runat="server"></asp:TextBox>
            <br />
            <br />
            Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" style="height: 29px" />
        </div>
    </form>
        </div>
</body>
</html>
