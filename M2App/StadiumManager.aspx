<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManager.aspx.cs" Inherits="M2App.StadiumManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccffff">
    <div class="div" align="center">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" BorderStyle="Ridge" Font-Size="X-Large" Height="38px" Text="Stadium Manager Homepage" Width="371px"></asp:Label>
        </div>
        <p>
            Pending Requests</p>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="288px" AppendDataBoundItems="true"
               AutoPostBack="true"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="30px">  
                <asp:ListItem Text="--Select--" Value="none" Enabled="False" Selected="True" />
            </asp:DropDownList> 
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Accept" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" Text="Reject" OnClick="Button4_Click" Width="88px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            ------------------------------------------------------</p>
        <p>
            <asp:Label ID="Label2" runat="server" BorderStyle="Double" Font-Size="Larger" Text="Displays"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="View My Stadium's Info" OnClick="Button1_Click" />
            <asp:GridView ID="sinfo" runat="server" AutoGenerateColumns ="false"> 
           <Columns>
               <asp:BoundField DataField ="Id" HeaderText ="Id " />
               <asp:BoundField DataField ="Name" HeaderText ="Name " />
               <asp:BoundField DataField ="Location" HeaderText =" Location " />
               <asp:BoundField DataField ="Capacity" HeaderText =" Capacity " />
               <asp:BoundField DataField ="Status" HeaderText =" Status " />


           </Columns>
       </asp:GridView>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="View All Requests" Width="256px" OnClick="Button2_Click" />
             <asp:GridView ID="vrequest" runat="server" AutoGenerateColumns ="false"> 
           <Columns>
               
               <asp:BoundField DataField ="Name" HeaderText ="Name " />
               <asp:BoundField DataField ="Host" HeaderText =" Host " />
               <asp:BoundField DataField ="Guest" HeaderText =" Guest " />
               <asp:BoundField DataField ="start_time" HeaderText =" start_time " />
               <asp:BoundField DataField ="end_time" HeaderText ="end_time " />
                 <asp:BoundField DataField ="Status" HeaderText ="Status " />


           </Columns>
       </asp:GridView>
        </p>
    </form>
        </div>
</body>
</html>
