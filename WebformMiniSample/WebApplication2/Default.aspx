<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">      
        <asp:Label ID="lblName" runat="server">Hello</asp:Label><br />


        <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
        <asp:HiddenField runat="server" ID="hf1" />
        <asp:HiddenField ID="hf2" runat="server" />
       
         <!--瀏覽器端的警告訊息-->
        <asp:Button runat="server" Text="Button" OnClick="Unnamed_Click" OnClientClick="exec();alert('123');"/>

        <script>
            //瀏覽器端的警告訊息
            //alter("123");

            var val1 = <%=this.ForJSInt %>;
            alert(val1 * 40);

            var val2 = <%=(this.ForJSBool) ? "true" : "false" %>;
            alert(val2);

            var val3 = '<%=this.ForJSString %>';   //JS的字串要加""或是''
            alert(val3);

            function exce2() {
                var hf2 = document.getElementById("hf2");
                var val = hf2.value;

                alert(val);
            }
            exce2();

            function exec() {
                var lbl = document.getElementById("lblName");
                lbl.innerHTML = "World!";

                var hf1 = document.getElementById("hf1");
                hf1.value = "World";
            }
        </script>
    </form>
</body>
</html>
