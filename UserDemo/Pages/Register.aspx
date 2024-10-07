<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="UserDemo.Pages.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            font-size: x-large;
            color: #0000CC;
        }

        .auto-style2 {
            width: 100%;
            height: 350px;
        }

        .auto-style3 {
            width: 144px;
            text-align: justify;
        }
        .auto-style4 {
            width: 144px;
            text-align: justify;
            height: 55px;
        }
        .auto-style5 {
            height: 55px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            Registeration Form
        </div>
        <table class="auto-style2">
            <tr>
                <td class="auto-style3" style="vertical-align:bottom">FirstName</td>
                <td>
                    <div>
                        <asp:RequiredFieldValidator
                            ID="txtFirstNameValidator"
                            ErrorMessage="*"
                            runat="server"
                            Style="display: block"
                            ForeColor="Red"
                            ValidationGroup="register"
                            ControlToValidate="txtFirstName">
                        </asp:RequiredFieldValidator>
                        <asp:TextBox ValidationGroup="register" ID="txtFirstName" runat="server" Width="235px"></asp:TextBox>

                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="vertical-align:bottom">LastName</td>
                <td>
                    <div>
                        <asp:RequiredFieldValidator
                            ID="txtLastNameValidator"
                            ErrorMessage="*"
                            runat="server"
                            Style="display: block"
                            ForeColor="Red"
                            ValidationGroup="register"
                            ControlToValidate="txtLastName">
                            </asp:RequiredFieldValidator>
                            <asp:TextBox ValidationGroup="register" ID="txtLastName" runat="server" Width="235px"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="vertical-align:bottom">Email</td>
                <td>
                    <div>
                        <asp:RequiredFieldValidator
                            ID="txtEmailValidator"
                            ErrorMessage="*"
                            runat="server"
                            Style="display: block"
                            ForeColor="Red"
                            ValidationGroup="register"
                            ControlToValidate="txtEmail">
                         </asp:RequiredFieldValidator>
                    <asp:TextBox ValidationGroup="register" ID="txtEmail" runat="server" Width="235px"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="vertical-align:bottom">Password</td>
                <td>
                    <div>
                        <asp:RequiredFieldValidator
                            ID="txtPasswordValidator"
                            ErrorMessage="*"
                            runat="server"
                            Style="display: block"
                            ForeColor="Red"
                            ValidationGroup="register"
                            ControlToValidate="txtPassword">
                         </asp:RequiredFieldValidator>
                    <asp:TextBox ValidationGroup="register" ID="txtPassword" runat="server" Width="235px"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" style="vertical-align:bottom">Repeat Password</td>
                <td>
                    <div>
                        <asp:RequiredFieldValidator
                            ID="txtConfirmPasswordValidator"
                            ErrorMessage="*"
                            runat="server"
                            Style="display: block"
                            ForeColor="Red"
                            ValidationGroup="register"
                            ControlToValidate="txtConfirmPassword">
                         </asp:RequiredFieldValidator>
                    <asp:TextBox ValidationGroup="register" ID="txtConfirmPassword" runat="server" Width="235px"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Profile Photo</td>
                <td class="auto-style5">
                    <asp:FileUpload ID="fileUpload" runat="server" Width="104px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Button ID="btnRegister" runat="server" Text="Register" Width="139px" OnClick="btnRegister_Click" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblMessage" runat="server"  Style="display:block"></asp:Label>
        <span>Go To </span>
        <a href="/" Style="margin-right: 10px; cursor:pointer; color:blue; ">Home</a>
        <a href="/Login" Style="cursor:pointer; color:blue;">Login</a>
    </form>
</body>
</html>
