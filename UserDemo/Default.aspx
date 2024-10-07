<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <a href="/Login" style="text-decoration: none" onclick="loginLink_Click">Login</a>
            <a href="/Register" style="text-decoration: none; margin-left: 20px">Register</a>
        </div>
        <p>
            <asp:Label ID="lblUserInfo" runat="server"></asp:Label>
        </p>

        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
            <table>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblFirstName" Text='<%# Eval("FirstName") %>' />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblLastName" Text='<%# Eval("LastName") %>' />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblRegistrationDate" Text='<%# Eval("RegistrationDate") %>' />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblLastLogin" Text='<%# Eval("LastLogin") %>' />
                </td>
                <td>
                    <asp:Label runat="server" ID="lblTotalLogins" Text='<%# Eval("TotalLogins") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <table>
        <tr>
            <td>
                <asp:PlaceHolder ID="plcPaging" runat="server" />
                <br /><asp:Label runat="server" ID="lblPageName" />
            </td>
        </tr>
    </table>
    </form>
    <script>

</script>
</body>
</html>
