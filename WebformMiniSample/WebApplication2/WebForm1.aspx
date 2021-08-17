<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script>
        //要注意順序,先初始化,在執行
       <%-- var val1 = <%=this.ForJSInt %>;
        var val2 = <%=(this.ForJSBool) ? "true" : "false" %>;           
        var val3 = '<%=this.ForJSString %>';         //這邊做變數初始化

        var ForJSBase = <%=this.ForJSBase %>;
        var ForJSCoffecion = <%=this.ForJSCoffecion %>;--%>

        var obj = <%=this.StringObject %>; /*StringObject取代了上述散亂的變數至obj裡面*/
    </script>
    <script src="Scripts/WebForm1.js"></script>   <%--加入js頁做計算--%>
</head>
<body>
    <form id="form1" runat="server">
        <button type="button" onclick="exec()">Click Me</button>
    </form>
</body>
</html>
