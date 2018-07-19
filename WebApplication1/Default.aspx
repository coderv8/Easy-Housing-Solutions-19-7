<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 
        <script type="text/javascript">
	// Prevent dropdown menu from closing when click inside the form
	$(document).on("click", ".navbar-right .dropdown-menu", function(e){
		e.stopPropagation();
	});
</script>
    




    <div class="row" style="padding-left:400px">

        
        <asp:DropDownList runat="server" CssClass="form-control"  ID="Type" Width="50%" Height="40px" >
            <asp:ListItem runat="server" Text="Buy" ></asp:ListItem>
             <asp:ListItem runat="server" Text="Rent"></asp:ListItem>
           
        </asp:DropDownList>
         &nbsp;&nbsp;
           <asp:DropDownList runat="server" CssClass="form-control" ID="ddlState" Width="50%" Height="40px" AutoPostBack="True"  OnSelectedIndexChanged="ddlState_SelectedIndexChanged" >

        </asp:DropDownList>
        
              &nbsp;&nbsp;
           <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCity" Width="50%" Height="40px" AutoPostBack="True"  >
          
           
        </asp:DropDownList>


          <br />

        <asp:Button runat="server" ID="submit"  Text="Search" ForeColor="White" BackColor="Green" class="btn btn-default"  Width="50%" Height="40px" OnClick="submit_Click"  />
        
        </div>
        <div class="col-md-4">
             
        </div>
        <div class="col-md-4">
           
        </div>
   
    
</asp:Content>
