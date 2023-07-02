<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Reg.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
<style>
.divv
{
    margin: 72px 0 0 30%; 
}
.btnDiv
{
    margin: 2em 0 0 6em;
}
.btn
{
    margin: 0 0 0 15px;
}
</style>





<div class="divv" border="1">
    <form id="form1" runat="server" border="1">
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                   User Name :
                </td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
             <tr>
                <td>
                   Password  :
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Mobile :
                </td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Sex:
                </td>
                <td>
                    <asp:DropDownList ID="ddlSex" runat="server">
                    <asp:ListItem >SELECT</asp:ListItem>
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                    <asp:ListItem Value="O">Other</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Date of Birth
                </td>
                <td>
                    <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
                </td>
            </tr>
        </table>
        </div>
        <div class="btnDiv">
            <asp:Button class="btn" ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" />

            <asp:Button class="btn" ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />

            <asp:Button class="btn" ID="btnUpdate" runat="server" Text="Update" onclick="btnUpdate_Click" />

            <asp:Button class="btn" ID="btnDelete" runat="server" Text="Delete" onclick="btnDelete_Click" />

        </div>
    </form>
</div>
</body>
</html>
