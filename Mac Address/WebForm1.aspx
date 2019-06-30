<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Mac_Address.WebForm1" %>

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
                Create Account
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
                
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="bt1" Text="Create Account" OnClick="bt1_Click"/>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="bt2" Text="Log IN" OnClick="bt2_Click"/>
            </div>
        </div>
    </form>
</body>
</html>
