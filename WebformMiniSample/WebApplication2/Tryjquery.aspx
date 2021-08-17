<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tryjquery.aspx.cs" Inherits="WebApplication2.Tryjquery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="Scripts/jQuery-min-3.6.0.js"></script>
    <script>
        //$(document).ready(function () {
        $(function () {  //上面document.ready的縮寫
            $(".pp").click(function () {
                $(this).hide();
            });
            $("#c1").click(function () {
                $(".pp").show();
            });
            $("#txt1").change(function () {
                alert($(this).val());
            });
            $("#btn1").click(function () {
                $("#txt1").val("");
            });
            //$("#btn1").click(function () {
            //alert(123);
            //  });
            $("#btn1").on("click", function () {  //與上面$("#btn1").click(function ()做一樣的事情,寫法不同而已
            alert(123);
            });
            $("#txt1").mouseenter(function () {
                alert("You entered txt1!");
            });
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
