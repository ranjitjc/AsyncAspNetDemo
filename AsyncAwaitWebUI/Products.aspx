<%@ Page Language="C#" Async="true" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Products.aspx.cs" Inherits="AsyncAwaitWebUI.Products" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
       <div class="alert alert-info">
        <h1>Product</h1>
    </div>
    <div class="alert alert-success">
        <span class="col-md-6">Load ElapsedTime : <%=LoadElapsedTime%></span>
        <span class="col-md-6">Page ElapsedTime : <%=PageElapsedTime%></span>
        <div>
            <asp:GridView ID="ThreadGridView" runat="server" AutoGenerateColumns="true"></asp:GridView>
        </div>
    </div>

        <div class="well">
            <asp:GridView ID="ProductGridView" runat="server" CssClass="table table-striped" AutoGenerateColumns="true" ItemType="AsyncAwaitService.Product"></asp:GridView>
        </div>
    </asp:Content>
