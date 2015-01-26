<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            padding: 20px;
        }

        .button {
            color: white;
            background-color: #3399FF;
            width: 100px;
            line-height: 25px;
            font-weight: 700;
            margin: 10px;
        }
       
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="logo" Style="text-align: center;" runat="server" Text="BCIT SearchStar" BackColor="#3399FF" Font-Bold="True" ForeColor="White" Height="30px" Width="30%" Font-Size="X-Large"></asp:Label>
                <br />

            </div>
            <div style="vertical-align: top; ">
                <asp:TextBox ID="keyword" runat="server"  Width="50%" Wrap="False" Height="25px" ></asp:TextBox>
                <asp:Button ID="search" runat="server" Text="Search" CssClass="button" OnClick="search_Click" />
                <asp:ImageButton ID="head" runat="server" ImageUrl="~/Img/leftend.jpg" OnClick="head_Click" />
                <asp:ImageButton ID="prev" runat="server" ImageUrl="~/Img/l.jpg" OnClick="prev_Click" />
                <asp:ImageButton ID="next" runat="server" ImageUrl="~/Img/r.jpg" OnClick="next_Click" />
                <asp:ImageButton ID="end" runat="server" ImageUrl="~/Img/rd.jpg" OnClick="end_Click" />
            </div>
            <asp:Label ID="filename" runat="server" BackColor="#B7E8FF" Width="55%"></asp:Label>
            <asp:Label ID="range" runat="server" BackColor="#B7E8FF" Width="10%"></asp:Label>
            <br />
            &nbsp;<asp:TextBox ID="tbContent" style="float:left; width:80%" runat="server" Height="245px" TextMode="MultiLine" Width="671px"></asp:TextBox>

            <div style="float: left; margin-left: 5%; padding: 5px;">
                <asp:ImageButton ID="print" runat="server" Style="margin: 10px;" ImageUrl="~/Img/printer.jpg" OnClick="print_Click" />

                <br />
                <asp:ImageButton ID="save" runat="server" Style="margin: 10px;" ImageUrl="~/Img/save.png" OnClick="save_Click" />
            </div>
        </div>
    </form>
</body>
</html>
