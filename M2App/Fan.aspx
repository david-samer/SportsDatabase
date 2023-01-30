<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fan.aspx.cs" Inherits="M2App.Fan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccffff">
    <div class="div" align="center">    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" BorderStyle="Ridge" Font-Size="X-Large" Text="Fan Homepage"></asp:Label>
        </div>
        <div id="PushaseDiv">
        <p>
            Purchase Ticket</p>
        <p>
            Host Club Name :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="PHost" runat="server"></asp:TextBox>
        </p>
        <p>
            Guest Club Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="PGuest" runat="server"></asp:TextBox>
        </p>
        <p>
            Match Start Time (YYYY-MM-DD HH:MM):<asp:TextBox ID="PTime" TextMode="Date" runat="server"></asp:TextBox>
            &nbsp;<asp:TextBox ID="PPTime" TextMode="Time" runat="server"></asp:TextBox>

        </p>
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Purchase" Width="310px" />
        </p>
        </div>
        <p>
            ---------------------------------------------</p>
        <p>
             <asp:TextBox ID="fmatch" TextMode="Date" runat="server" Height="30px" Width="272px"></asp:TextBox>
             &nbsp;<asp:TextBox ID="ffmatch" TextMode="Time" runat="server" Height="30px" Width="272px"></asp:TextBox>
            &nbsp;
            <asp:Button ID="Button1" runat="server" Text="View Available Matches To Attend" OnClick="Button1_Click" Height="33px" Width="264px" />
            <asp:GridView ID="fanm" runat="server" AutoGenerateColumns ="false"> 
           <Columns>
               <asp:BoundField DataField ="Host" HeaderText ="Host " />
               <asp:BoundField DataField ="Guest" HeaderText ="Guest " />
               <asp:BoundField DataField ="Stadium" HeaderText =" Stadium " />
               <asp:BoundField DataField ="StadiumLocation" HeaderText ="StadiumLocation " />
   
           </Columns>
       </asp:GridView>
        </p>
    </form>
        </div>
</body>
</html>
