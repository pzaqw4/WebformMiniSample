<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 523px;
            height: 293px;
        }

        .auto-style3 {
            width: 111px;
        }

        .auto-style4 {
            width: 312px;
            height: 53px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style2">
            <tr>
                <td colspan="2">
                    <h1>流水帳管理系統-後台</h1>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <a href="WebForm1.aspx">第1頁</a><br />
                    <a href="WebForm2.aspx">第二頁</a><br />
                    <a href="WebForm3.aspx">第三頁</a>
                </td>
                <td>
                    <!--這裡放主要內容-->
                    <table class="auto-style4">
                        <asp:Literal ID="Literal1" runat="server">第一頁</asp:Literal>
                    </table>

                </td>
            </tr>
        </table>
    </form>
</body>
</html>
