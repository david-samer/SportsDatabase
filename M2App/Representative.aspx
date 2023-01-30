<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Representative.aspx.cs" Inherits="M2App.Representative" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#ccffff">
    <div class="div" align="center">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" BorderStyle="Ridge" Font-Size="XX-Large" Text="Club Representative Homepage"></asp:Label>
        </div>
        <p>
            Send Request </p>
        Match :
        <asp:DropDownList ID="DropDownList1" runat="server" Width="288px" AppendDataBoundItems="true"
               AutoPostBack="false"  OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="30px">  
                <asp:ListItem Text="--Select--" Value="none" Enabled="False" Selected="True" />
            </asp:DropDownList> 
        <br />
        Stadium :
        <asp:DropDownList ID="DropDownList2" runat="server" Width="100px" AppendDataBoundItems="true"
               AutoPostBack="false"  OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" Height="31px">  
                <asp:ListItem Text="--Select--" Value="none" Enabled="False" Selected="True" />
            </asp:DropDownList> 
        <br />
        <p>
            <asp:Button ID="Button4" runat="server" Text="Request" OnClick="Button4_Click" style="height: 29px" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" BorderStyle="Double" Font-Size="Larger" Text="Displays"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="View My Club Info" Width="401px" OnClick="Button1_Click" />
             <asp:GridView ID="cinfo" runat="server" AutoGenerateColumns ="false"> 
           <Columns>
               <asp:BoundField DataField ="club_id" HeaderText ="club_id " />
               <asp:BoundField DataField ="Name" HeaderText ="Name " />
               <asp:BoundField DataField ="location" HeaderText =" location " />
      


           </Columns>
       </asp:GridView>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="View My Club's Upcomming Matches" OnClick="Button2_Click" />
             <asp:GridView ID="cmatch" runat="server" AutoGenerateColumns ="false"> 
           <Columns>
               <asp:BoundField DataField ="HostName" HeaderText ="Host " />
               <asp:BoundField DataField ="GuestName" HeaderText ="Guest " />
               <asp:BoundField DataField ="start_time" HeaderText =" start_time " />
               <asp:BoundField DataField ="end_time" HeaderText =" end_time " />
               <asp:BoundField DataField ="StadiumName" HeaderText =" Stadium " />


           </Columns>
       </asp:GridView>

        </p>
        <p>
            <asp:Button ID="Button3" runat="server" Text="View Available Stadiums From:" Width="250px" OnClick="Button3_Click" Height="29px" />
        
             &nbsp;<asp:TextBox ID="date"  TextMode="Date" runat="server" Height="18px" Width="180px"></asp:TextBox>
             &nbsp;<asp:TextBox ID="date2" TextMode="Time" runat="server"></asp:TextBox>

          <asp:GridView ID="vstadium" runat="server" AutoGenerateColumns ="false"> 
           <Columns>
               <asp:BoundField DataField ="name" HeaderText ="name " />
               <asp:BoundField DataField ="location" HeaderText ="location " />
               <asp:BoundField DataField ="Capacity" HeaderText =" Capacity " />
   
           </Columns>
       </asp:GridView>

        </p>
    </form>
        </div>
</body>
</html>
