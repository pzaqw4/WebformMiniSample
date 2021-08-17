<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryjQuery2.aspx.cs" Inherits="WebApplication2.TryjQuery2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script src="Scripts/jQuery-min-3.6.0.js"></script>
    <script>
        $(document).ready(function () {
            $(".pp").click(function () {
                $(this).hide("slow");
            });
            $("#btn1").click(function () {//()內的參數為具體花費的速度,10=10毫秒
                $(".pp").show(10).css("color", "red").css("font-size", "24pt");
            });  //.css為存取tag的style屬性



        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <p>If you click on me, I will disappear.</p>
            <p class="pp" id="c1">Click me away!</p>
            <p class="pp">Click me too!</p>
            <p class="pp">Click me too!</p>
            <p class="pp">Click me too!</p>
            <p class="pp">Click me too!</p>
            <p class="pp">Click me too!</p>

            <input type="text" id="txt1" />
            <button type="button" id="btn1">Click me</button>
        </div>
    </form>
</body>
</html>
