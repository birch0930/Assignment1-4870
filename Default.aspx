<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="logo" runat="server" Text="Logo"></asp:Label>
        <br />
        <asp:TextBox ID="keyword" runat="server"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text="Search" />
        <asp:ImageButton ID="head" runat="server" />
        <asp:ImageButton ID="prev" runat="server" />
        <asp:ImageButton ID="next" runat="server" />
        <asp:ImageButton ID="end" runat="server" />
        <br />
        <asp:Label ID="filename" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="range" runat="server" Text="Label"></asp:Label>
        <br />
        <textarea id="content" cols="20" name="S1" rows="2"></textarea><asp:ImageButton ID="print" runat="server" />
             <br />
        <asp:ImageButton ID="save" runat="server"  />
    
    </div>
    </form>
</body>
</html>
