<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="WebApplication1.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
    <Columns>
        <asp:BoundField DataField="PropertyName" HeaderText="PropertyName" SortExpression="PropertyName" />
        <asp:BoundField DataField="PropertyType" HeaderText="PropertyType" SortExpression="PropertyType" />
        <asp:BoundField DataField="PropertyOption" HeaderText="PropertyOption" SortExpression="PropertyOption" />
        <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
        <asp:BoundField DataField="PriceRange" HeaderText="PriceRange" SortExpression="PriceRange" />
        <asp:BoundField DataField="InitialDeposit" HeaderText="InitialDeposit" SortExpression="InitialDeposit" />
        <asp:BoundField DataField="Landmark" HeaderText="Landmark" SortExpression="Landmark" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:16MayCHNConnectionString %>" SelectCommand="SELECT PropertyName, PropertyType, PropertyOption, Description, Address, PriceRange, InitialDeposit, Landmark FROM EasyHousingSolutions.Property WHERE (IsActive = 'True')"></asp:SqlDataSource>
</asp:Content>
