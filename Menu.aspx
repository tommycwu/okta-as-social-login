<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="OktaSocialLogin.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ImageMap ID="ImageMap1" runat="server" ImageUrl="~/developers.png">
            <asp:RectangleHotSpot Bottom="460" Left="400" NavigateUrl="~/GenerateOktaApp.aspx" Right="590" Top="400" />
        </asp:ImageMap>
    </form>
</body>
</html>
