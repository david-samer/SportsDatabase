<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormStart.aspx.cs" Inherits="M2App.FormStart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccffff">
    <div class="div" align="center">    <form id="form1" runat="server">
        <div>
            Please Login</div>
        <p>
            Username:<asp:TextBox ID="username" runat="server" Height="16px"></asp:TextBox>
        </p>
        <p>
            Password:<asp:TextBox ID="password" runat="server" Height="16px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="signin" runat="server" OnClick="login" Text="Login" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            ------Don&#39;t Have An Account Yet?-------</p>
        <asp:Button ID="AssocReg" runat="server" Text="Register As Association Manager" OnClick="AssocReg_Click" />
        <p>
            <asp:Button ID="RepresReg" runat="server" Text="Register As Club Representative" OnClick="RepresReg_Click" />
        </p>
        <asp:Button ID="StMgrReg" runat="server" Text="Register As Stadium Manager" OnClick="StMgrReg_Click" />
        <p>
            <asp:Button ID="FanReg" runat="server" Text="Register As Fan" OnClick="FanReg_Click" />
        </p>
     
    </form>
        </div>
</body>
</html>
