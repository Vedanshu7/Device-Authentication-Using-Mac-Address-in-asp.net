<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Mac_Address.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet"  href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="card">
            <div class="card-header text-xl-center">
                Login
            </div>
            <div class="card-body text-xl-center">
                <asp:Label runat="server" Text="Email"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox runat="server" ID="texbox1"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server" Text="Password"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox runat="server" id="textbox2"></asp:TextBox>
                <br />
                <br />
                <asp:Label runat="server" Text="" ID="label" CssClass="alert-danger"></asp:Label>
                <br />
                <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="bt1" Text="Log IN" OnClick="bt1_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="bt2" Text="Create Account" OnClick="bt2_Click"/>
                <br />
                <br />
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
                <br />
            </div>
        </div>
    </form>
</body>
</html>
