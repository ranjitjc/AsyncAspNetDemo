<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="AsyncAwaitWebUI.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="alert alert-info">
        <h1>Dashboard</h1>
    </div>
    <div class="alert alert-success">
       <%-- <div class="col-md-4">Load ElapsedTime : <%=LoadElapsedTime%></div>--%>
        <span>Page ElapsedTime : <%=PageElapsedTime%></span>
        <div>
            <asp:GridView ID="ThreadGridView" runat="server" AutoGenerateColumns="true"></asp:GridView>
        </div>
    </div>
    <div class="well">
        <div class="row">
        <div class="col-md-4">
            <div class="alert alert-info">
                <strong>Products</strong>
            </div>
            <asp:GridView ID="ProductGridView" runat="server" AutoGenerateColumns="true" ItemType="AsyncAwaitWebUI.ProductProxyService.Product"></asp:GridView>
        </div>
        <div class="col-md-4">
             <div class="alert alert-info">
                <strong>SaleOrders</strong>
            </div>
            <asp:GridView ID="SaleOrderGridView" runat="server" AutoGenerateColumns="true" ItemType="AsyncAwaitWebUI.SaleOrderProxyService.SaleOrder"></asp:GridView>
        </div>
        <div class="col-md-4">
            <div class="alert alert-info">
                <strong>Persons</strong>
            </div>
            <asp:GridView ID="PersonGridView" runat="server" AutoGenerateColumns="true" ItemType="AsyncAwaitWebUI.PersonProxyService.Person"></asp:GridView>
        </div>
        </div>
    </div>
</asp:Content>
