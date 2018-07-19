<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SellerRegistration.aspx.cs" Inherits="WebApplication1.SellerRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div  class="row vertical-center-row">
    <div class="col-md-8 col-md-offset-1">
       <legend style="font-size:40px">Seller Registration</legend>
        <fieldset>

          <!-- Form Name -->
            
            

          <legend>Personal Information Details</legend>

          <!-- Text input-->
          <div class="form-group">
            <div class="col-sm-4">
                <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" class="form-control"></asp:TextBox>
             <%-- <input type="text" name="fistName" placeholder="First Name" class="form-control">--%>
            </div>
           
            <div class="col-sm-4">
                <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" class="form-control"></asp:TextBox>
              <%--<input type="text" name="lastName" placeholder="Last Name" class="form-control">--%>
            </div>
          </div>
            <br />
         
          <!-- Text input-->
          <div class="form-group">
            <div class="col-sm-4">
               
                <asp:TextBox ID="txtDOB" runat="server" placeholder="Date Of Birth" class="form-control" TextMode="Date"></asp:TextBox>
              <%--<input type="date" placeholder="Date Of Birth" class="form-control">--%>
            </div>
          </div>

          <!-- Text input-->
          
          

<!-- Address Section -->
          <!-- Form Name -->
            <br />
            <br />
            
                <legend>Address Details</legend>
           
          
          <!-- Text input-->
          <div class="form-group">
            <div class="col-sm-8">
                
                 <asp:TextBox TextMode="MultiLine" Columns="1" Rows="2" ID="txtAddress" runat="server" placeholder="Address" class="form-control" ></asp:TextBox>
<%--              <input type="text" name="addressLine" placeholder="Address" class="form-control">--%>
            </div>
          </div>
         <br />
          <br />
           <br />
          <!-- Text input-->
          <div class="form-group">
            <div class="col-sm-4">
             <asp:DropDownList runat="server" Class="form-control" ID="ddlState"  placeholder="State" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" ></asp:DropDownList>
            </div>
            <div class="col-sm-4">
                <asp:DropDownList runat="server" Class="form-control" ID="ddlCity"  placeholder="City" AutoPostBack="True"  > </asp:DropDownList>
              <%--<input type="text" name="state" placeholder="State" class="form-control">--%>
            </div>
         
          </div>
<!-- Parent/Guadian Contact Section -->
          <!-- Form Name -->
            <br /><br />
          <legend>User Details</legend>
          <!-- Text input-->
          <div class="form-group">
            <div class="col-sm-4">
                <asp:TextBox ID="txtUserName" Text="" runat="server" placeholder="User Name" class="form-control"></asp:TextBox>
             <%-- <input type="text" name="pFistName" placeholder="User Name" class="form-control">--%>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtPassword" Text="" TextMode="Password" runat="server" placeholder="Password" class="form-control"></asp:TextBox>
              <%--<input type="text" name="pFistName" placeholder="Password" class="form-control">--%>
            </div>
             <%-- <div class="col-sm-4"></div>--%>
          </div>
            <br />
          <br />
            <div class="col-sm-4">
                <asp:TextBox ID="txtPhoneNo"  runat="server" placeholder="Phone No" class="form-control"></asp:TextBox>
              <%--<input type="pPhoneNbr" placeholder="Phone Number" class="form-control">--%>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" class="form-control"></asp:TextBox>
              <%--<input type="email" name="pEmail" placeholder="Email" class="form-control">--%>
          
           </div>

            <br />
            <br />
            <br />
            <br />
          <div class="form-group">
            <div class="col-sm-4 col-sm-offset-1">
              <div class="pull-right">
                  <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Save" OnClick="btnSubmit_Click"/>
                   <asp:Button ID="btnCancel" runat="server" class="btn btn-default" Text="Cancel" OnClick="btnCancel_Click"/>
                <%--<button type="submit" class="btn btn-default">Cancel</button>
                <button type="submit" class="btn btn-primary">Save</button>--%>
              </div>
            </div>
          </div>
        </fieldset>
  
    </div><!-- /.col-lg-12 -->
</div><!-- /.row -->



   
</asp:Content>
