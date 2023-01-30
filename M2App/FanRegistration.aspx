<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanRegistration.aspx.cs" Inherits="M2App.FanRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccffff">
    <div class="div" align="center">
    <form id="form1" runat="server">
        <div>
            Fan Registration
            <br />
            <br />
            Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp; <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            <br />
            Username:&nbsp;&nbsp; <asp:TextBox ID="username" runat="server"></asp:TextBox>
            <br />
            <br />
            Password:&nbsp;&nbsp; <asp:TextBox ID="password" runat="server"></asp:TextBox>
            <br />
            <br />
            National ID:<asp:TextBox ID="NatId" runat="server"></asp:TextBox>
            <br />
            <br />
            Birth Date&nbsp; :<asp:TextBox ID="BirthDate" TextMode ="Date" runat="server"></asp:TextBox>
            <br />
            <br />
            Address&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="address" runat="server"></asp:TextBox>
            <br />
            <br />
            Phone No.&nbsp; :<asp:TextBox ID="Phone" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Register" />
        </div>
    </form>
        </div>
</body>
</html>