<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="WebApplication1.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td colspan="2">
                    <h1>流水帳管理系統-後台</h1>
                </td>
            </tr>
            <tr>
                <td >
                    <a href="WebForm1.aspx">第1頁</a><br />
                    <a href="WebForm2.aspx">第二頁</a><br />
                    <a href="WebForm3.aspx">第三頁</a>
                </td>
                <td>
                    <!--這裡放主要內容-->
                    <table>
                        <asp:Literal ID="Literal1" runat="server">第3頁</asp:Literal>
                    </table>

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
