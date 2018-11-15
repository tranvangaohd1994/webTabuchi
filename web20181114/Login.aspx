<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Website.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <title>Login Form</title>
    <link rel="stylesheet" href="css/reset.css" />
    <link rel='stylesheet prefetch' href='http://daneden.github.io/animate.css/animate.min.css' />
    <link rel='stylesheet prefetch' href='http://fonts.googleapis.com/css?family=Roboto:400,100,400italic,700italic,700' />
    <link rel='stylesheet prefetch' href='http://maxcdn.bootstrapcdn.com/font-awesome/4.2.0/css/font-awesome.min.css' />
    <link rel="stylesheet" href="css/style.css" />
    <script>
        function button_click(objTextBox, objBtnID) {
            if (window.event.keyCode == 13) {
                document.getElementById(objBtnID).focus();
                document.getElementById(objBtnID).click();
            }
        }
    </script>
</head>

<body>
    <div class='info'>
        <h1>Tabuchi EDB </h1>
    </div>
    <div class='form aniamted bounceIn'>
        <div class='login'>
            <h2>Login To Your Account</h2>
            <form id="Form1" runat="server">
                <asp:TextBox runat="server" placeholder="Username" ID="txtUsername" />
                <asp:TextBox runat="server" TextMode="Password" placeholder="Password" ID="txtPassword" />
                <asp:LinkButton runat="server" Text="Login" ID="btnLogin" CssClass="button" Width="200px" OnClick="btnLogin_Click" />
                <footer>
                    <asp:Label runat="server" ID="lblAlart" Font-Bold="true" Font-Size="Small" ForeColor="Red"> </asp:Label>
                </footer>
            </form>
        </div>

    </div>
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src="js/index.js"></script>
</body>
</html>

