<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemAdmin.aspx.cs" Inherits="M2App.SystemAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccffff">
    <div class="div" align="center">
    <form id="form1" runat="server" >
        <div >
            <asp:Label ID="Label1" runat="server" BorderColor="Black" BorderStyle="Ridge" BorderWidth="2px" Text="System Admin Homepage" Font-Size="XX-Large"></asp:Label>
        </div>
    <p>
        Add Club </p>
    <p>
        Name:
        <asp:TextBox ID="AddClub" runat="server"></asp:TextBox>
        <br/>
        Location:
        <asp:TextBox ID="Location" runat="server"></asp:TextBox>
    </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
    </p>
        <p>
            ----------------------------------------</p>
        <p>
            Delete Club</p>
        <p>
            Name:
            <asp:DropDownList ID="DropDownList1" runat="server" Width="100px" AppendDataBoundItems="true"
               AutoPostBack="false"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="31px">  
                <asp:ListItem Text="--Select--" Value="none" Enabled="False" Selected="True" />
            </asp:DropDownList> 
    </p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />
    </p>
        <p>
            ---------------------------------------</p>
        <p>
            Add Stadium</p>
        <p>
            Name:
            <asp:TextBox ID="AddStad" runat="server"></asp:TextBox>
            <br/>
            Location:
            <asp:TextBox ID="StadLoc" runat="server"></asp:TextBox>
            <br/>
            Capacity:
            <asp:TextBox ID="Capacity" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" Text="Add" OnClick="Button3_Click" />
        </p>
        <p>
            --------------------------------------</p>
        <p>
            Delete Stadium</p>
        <p>
            Name: <asp:DropDownList ID="DropDownList2" runat="server" Width="100px" AppendDataBoundItems="true"
               AutoPostBack="false"  OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Height="31px">  
                <asp:ListItem Text="--Select--" Value="none" Enabled="False" Selected="True" />
            </asp:DropDownList> 
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" Text="Delete" OnClick="Button4_Click" />
        </p>
        <p>
            --------------------------------------</p>
        <p>
            Block Fan</p>
        <p>
            National ID:<asp:TextBox ID="BlockFan" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button5" runat="server" Text="Block" OnClick="Button5_Click" style="height: 29px" />
        </p>
    </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
        </div>
</body>
</html>
