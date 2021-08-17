<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AccountingList.aspx.cs" Inherits="AccountingNote.SystemAdmin.AccountingList" %>

<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>
<%@ Register Src="~/UserControls/ucPager2.ascx" TagPrefix="uc1" TagName="ucPager2" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
                <td>
                    <a href="UserInfo.aspx">使用者資訊</a><br />
                    <a href="AccountingList.aspx">流水帳管理</a>
                </td>
                <td>
                     <!--這裡放主要內容-->
                    <asp:Button ID="btnCreate" runat="server" Text="Add Accounting" OnClick="btnCreate_Click"/>
                    <asp:GridView ID="gvAccountingList" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvAccountingList_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:BoundField HeaderText="標題" DataField="Caption" />
                            <asp:BoundField HeaderText="金額" DataField="Amount" />                       
                            <asp:TemplateField HeaderText="In/Out">
                                <ItemTemplate>
                                    <%--<%# ((int)Eval("ActType")==0) ? "支出" : "收入"%>--%>
                                    <%--<asp:Literal ID="ltActType" runat="server"></asp:Literal>--%>
                                    <asp:Label ID="lblActType" runat="server" ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="建立日期" DataField="CreateDate" DataFormatString="{0:yyyy-MM-dd}"/>
                            <asp:TemplateField HeaderText="Act">
                                <ItemTemplate>
                                    <a href="/SystemAdmin/AccountingDetail.aspx?ID=<%# Eval("ID")%>">Edit</a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>

                    <asp:Literal ID="ltPager" runat="server"></asp:Literal>

                    <uc1:ucPager runat="server" ID="ucPager" PageSize="3"
                     CurrentPage="1" TotalSize="10" Url="AccountingList.aspx" />
                   
                    <div style="background-color:darkgrey">
                    <uc1:ucPager2 runat="server" ID="ucPager2" PageSize="3" Url="/SystemAdmin/AccountingList.aspx"/>
                   </div>
                    <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                        <p style="color:red">
                            流水帳記事內無資料
                        </p>
                    </asp:PlaceHolder>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
