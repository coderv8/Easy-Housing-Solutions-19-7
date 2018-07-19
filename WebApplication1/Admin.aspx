<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="WebApplication1.Admin" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table style="width: 100%">
        <tr>
            <td colspan="2" style="text-align: center"><Legend>Admin</Legend>
            </td>
        </tr>
        <tr>
            <td style="width: 20%; vertical-align: top;">
                <div class="form-group">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlState" Width="50%" Height="40px" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCity" Width="50%" Height="40px" AutoPostBack="True"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="btnSearchByRegion" Text="Search" ForeColor="White" BackColor="Gray" class="btn btn-default" Width="50%" Height="40px" OnClick="btnSearchByRegion_Click" />
                </div>

                <div class="form-group">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSellerName" Width="50%" Height="40px" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlPropOption" Width="50%" Height="40px" AutoPostBack="True">
                        <asp:ListItem runat="server" Text="Sell"></asp:ListItem>
                        <asp:ListItem runat="server" Text="Rent"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="btnSearchBySeller" Text="Search" ForeColor="White" BackColor="Gray" class="btn btn-default" Width="50%" Height="40px" OnClick="btnSearchBySeller_Click"/>
                </div>

            </td>

            <td style="width: 80%; vertical-align: top">
                <%--<asp:ContentPlaceHolder ID="cphLnDBody" runat="server"></asp:ContentPlaceHolder>--%>
               
    <asp:GridView ID="gridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="gridView1_RowCommand1" OnRowDeleting="gridView1_RowDeleting" Width="1063px" OnSelectedIndexChanged="gridView1_SelectedIndexChanged1">
        <Columns>
            <asp:TemplateField HeaderText="Id" ItemStyle-Width="150">
            <ItemTemplate>
                <asp:TextBox ID="prop" runat="server" Text='<%# Eval("PropertyId") %>' />
            </ItemTemplate>

<ItemStyle Width="150px"></ItemStyle>
        </asp:TemplateField>
            <asp:BoundField DataField="PropertyName" HeaderText="PropertyName" SortExpression="PropertyName" />
            <asp:BoundField DataField="PropertyType" HeaderText="PropertyType" SortExpression="PropertyType" />
            <asp:BoundField DataField="PropertyOption" HeaderText="PropertyOption" SortExpression="PropertyOption" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="PriceRange" HeaderText="PriceRange" SortExpression="PriceRange" />
            <asp:BoundField DataField="InitialDeposit" HeaderText="InitialDeposit" SortExpression="InitialDeposit" />
            <asp:BoundField DataField="Landmark" HeaderText="Landmark" SortExpression="Landmark" />
            <asp:BoundField DataField="Status_Description" HeaderText="Status_Description" SortExpression="Status_Description" />
            <asp:ButtonField CommandName="Activate" HeaderText="Activate" ShowHeader="True" Text="Activate" />
        
        </Columns>
                </asp:GridView>

               <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT PropertyName, PropertyType, PropertyOption, Description, Address, PriceRange, InitialDeposit, Landmark, Status_Description, IsActive FROM EasyHousingSolutions.Property"></asp:SqlDataSource>--%>

            </td>
        </tr>
    </table>


</asp:Content>
