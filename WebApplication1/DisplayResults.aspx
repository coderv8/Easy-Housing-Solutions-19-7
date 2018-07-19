<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DisplayResults.aspx.cs" Inherits="WebApplication1.DisplayResults" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <meta charset="utf-8">
     <style>
#box {
    max-width: 60em;
    height: 24em;
    padding: 8.5em;
    margin: 0em;
   border: 0.062em solid #999;
    background-color: #fff;
    overflow: auto;
    direction: ltr;
    text-align: left;
}


.card {
    box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
    transition: 0.3s;
    width: 100%;
}

.card:hover {
    box-shadow: 0 8px 16px 0 rgba(0,0,0,0.2);
}

.card-body {
    padding: 2px 16px;
}

  </style>

  
        <div>
        <table style="width:100%">
       <tr>
            <td colspan="2" style="text-align: center">
            </td>
        </tr>
        <tr>
            <td style="width: 20%; vertical-align: top;">
                <div class="form-group">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlState" Width="50%" Height="40px" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCity" Width="50%" Height="40px" ></asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="btnSearchByRegion" Text="Search" ForeColor="White" BackColor="Gray" class="btn btn-default" Width="50%" Height="40px" OnClick="btnSearchByRegion_Click" />
                </div>

                <div class="form-group">
                    <asp:TextBox placeholder="MinRange" TextMode="Number" ID="txtMinRange" runat="server"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                      <asp:TextBox placeholder="MaxRange" TextMode="Number" ID="txtMaxRange" runat="server"  CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button runat="server" ID="btnSearchByPrice" Text="Search" ForeColor="White" BackColor="Gray" class="btn btn-default" Width="50%" Height="40px" OnClick="btnSearchByPrice_Click"/>
                </div>

            </td>
            <td style="width:80%;vertical-align:top">
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
            </div>

</asp:Content>
