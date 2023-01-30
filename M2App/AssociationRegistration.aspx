<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssociationRegistration.aspx.cs" Inherits="M2App.AssociationRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccffff">
    <div class="div" align="center">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" BackColor="White" BorderStyle="Ridge" Text="Sports Association Manager Homepage"></asp:Label>
        </div>
        <p>
            &nbsp;Add New Match</p>
        <p>
            Host Club Name :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="AHost" runat="server" Height="16px"></asp:TextBox>
        </p>
        <p>
            Guest Club Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="AGuest" runat="server"></asp:TextBox>
        </p>
        <p>
            Start Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="AStart" TextMode="Date" runat="server"></asp:TextBox>
            &nbsp;<asp:TextBox ID="AATime" TextMode="Time" runat="server"></asp:TextBox>
        </p>
        <p>
            End Time&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :<asp:TextBox ID="AEnd" TextMode="Date" runat="server"></asp:TextBox>
            &nbsp;<asp:TextBox ID="AAEnd" TextMode="Time" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" style="height: 29px" />
        </p>
        <p>
            ------------------------------------------------</p>
        <p>
            Delete Match</p>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="603px" AppendDataBoundItems="true"
               AutoPostBack="true"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="78px">  
                <asp:ListItem Text="--Select--" Value="none" Enabled="False" Selected="True" />
            </asp:DropDownList> 
       
        <p>
            <asp:Button ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" />
        </p>
        <p>
            -----------------------------------------------------</p>
        <p>
            <asp:Label ID="Label2" runat="server" BorderStyle="Double" Font-Size="Larger" Height="45px" Text="      Displays" Width="137px"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" Text="View All Upcoming Matches" OnClick="Button3_Click" Width="304px" />
              <asp:GridView ID="allup" runat="server" AutoGenerateColumns ="false"> 
           <Columns>
               <asp:BoundField DataField ="Host" HeaderText ="Host " />
               <asp:BoundField DataField ="Guest" HeaderText ="Guest " />
               <asp:BoundField DataField ="start_time" HeaderText =" start_time " />
               <asp:BoundField DataField ="end_time" HeaderText ="end_time " />


           </Columns>
       </asp:GridView>
        </p>
        <p>
              <asp:Button ID="Button4" runat="server" Text="View Played Matches" Width="304px" OnClick="Button4_Click" />
            <asp:GridView ID="already" runat="server" AutoGenerateColumns ="false"> 
           <Columns>
               <asp:BoundField DataField ="Host" HeaderText ="Host " />
               <asp:BoundField DataField ="Guest" HeaderText ="Guest " />
               <asp:BoundField DataField ="start_time" HeaderText =" start_time " />
               <asp:BoundField DataField ="end_time" HeaderText ="end_time " />


           </Columns>
       </asp:GridView>
        </p>
      

        <p>
            <asp:Button ID="Button5" runat="server" Text="View Clubs Never Matched" Width="303px" OnClick="Button5_Click1" />
             <asp:GridView ID="never" runat="server" AutoGenerateColumns ="false"> 
           <Columns>
               <asp:BoundField DataField ="Club1" HeaderText ="Club1 " />
               <asp:BoundField DataField ="Club2" HeaderText ="Club2 " />
               

           </Columns>
       </asp:GridView>
        </p>
    </form>
                </div>

    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
</body>
</html>
