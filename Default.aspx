<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>

        .button{

            color:white;
            background-color:#3399FF;
            width:100px;
            font-weight: 700;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div >
        <asp:Label ID="logo" style="text-align: center;" runat="server" Text="Logo" BackColor="#3399FF" Font-Bold="True"  ForeColor="White" Height="30px" Width="30%" Font-Size="X-Large"></asp:Label>
        <br />

        </div>
        
        <asp:TextBox ID="keyword" runat="server" Width="50%" Wrap="False"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text="Search"  CssClass="button"  />
        <asp:ImageButton ID="head" runat="server" ImageUrl="~/Img/leftend.jpg" />
        <asp:ImageButton ID="prev" runat="server" ImageUrl="~/Img/l.jpg" />
        <asp:ImageButton ID="next" runat="server" ImageUrl="~/Img/r.jpg" />
        <asp:ImageButton ID="end" runat="server" ImageUrl="~/Img/rd.jpg" />
        <br />
        <asp:Label ID="filename" runat="server" BackColor="#B7E8FF" Width="55%" Height="20px"></asp:Label>
        <asp:Label ID="range" runat="server" BackColor="#B7E8FF" Width="10%" Height="20px"></asp:Label>
        <br />
        <textarea id="content" cols="40" name="S1" rows="55"></textarea><asp:ImageButton ID="print" runat="server" ImageUrl="~/Img/printer.jpg" OnClick="print_Click" />
             <br />
        <asp:ImageButton ID="save" runat="server" ImageUrl="~/Img/save.png"  />
    
    </div>
    </form>
</body>
</html>
