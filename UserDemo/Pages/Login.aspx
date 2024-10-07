<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UserDemo.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: xx-large;
            text-align: center;
            color: #000099;
        }

        .auto-style2 {
            width: 100%;
            height: 130px;
            margin-bottom: 62px;
        }

        .auto-style3 {
            width: 141px;
        }

        .auto-style4 {
            width: 141px;
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <strong>Login Form</strong>
        </div>
        <p>
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </p>
        <table class="auto-style2">
            <tr>
                <td class="auto-style4" style="vertical-align: bottom">Email Address</td>
                <td>
                    <div>
                        <asp:RequiredFieldValidator ID="txtEmailAddressValidator" runat="server"
                            ErrorMessage="*" ControlToValidate="txtEmailAddress"
                            Style="display: block"
                            ForeColor="Red"
                            ValidationGroup="login">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmailAddress" ValidationGroup="login" runat="server" Width="295px"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" style="vertical-align: bottom">Password</td>
                <td>
                    <div>
                        <asp:RequiredFieldValidator ID="txtPasswordValidator1" runat="server"
                            ErrorMessage="*" ControlToValidate="txtPassword"
                            Style="display:block"
                            ForeColor="Red"
                            ValidationGroup="login">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPassword" runat="server" ValidationGroup="login" Width="295px"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="btnLogin" runat="server" Height="30px" OnClick="btnLogin_Click" Style="text-align: center" Text="Login" Width="165px" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
