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
                <div id="box">
                  
                    <div class="container">
  
 
  <div class="card" id="imgdiv" style="width:400px">
    
    <div class="card-body" id="bodydiv" runat="server">
     

        
        
    </div>
  </div>
  <br>
  </div>

              </div>

            </td>
        </tr>
    </table>


</asp:Content>
