<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostProperty.aspx.cs" Inherits="WebApplication1.PostProperty" %>
<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
          
                <Legend>Add New Property</Legend>
        <br />
        <br />
                <div class="form-group">
                    <label for="txtPropName" class="col-sm-3 control-label">Property Name</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtPropName" runat="server" class="form-control" placeholder="Property Name"></asp:TextBox>
                        <%--<input type="text" id="firstName" placeholder="Full Name" class="form-control" autofocus>--%>
                        <%--<span class="help-block">Last Name, First Name, eg.: Smith, Harry</span>--%>
                    </div>
                </div>
                <br />
               <br />
                 <div class="form-group">
                    <label class="control-label col-sm-3">Property Type</label>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-2">
                                <label class="radio-inline">
                                    <asp:RadioButton GroupName="grpPropertyType" ID="rdbFlat" runat="server" Text="Flat"  />
                                    <%--<input type="radio" id="femaleRadio" value="Female">Female--%>
                                </label>
                            </div>
                            <div class="col-sm-2">
                                <label class="radio-inline">
                                    <asp:RadioButton GroupName="grpPropertyType" ID="rdbOffice" runat="server" Text="Office"  />
                                   <%-- <input type="radio" id="maleRadio" value="Male">Male--%>
                                </label>
                            </div>
                            <div class="col-sm-2">
                                <label class="radio-inline">
                                    <asp:RadioButton GroupName="grpPropertyType" ID="rdbVilla" runat="server" Text="Villa"  />
                                    <%--<input type="radio" id="uncknownRadio" value="Unknown">Unknown--%>
                                </label>
                            </div>
                        </div>
                    </div>
                </div> <!-- /.form-group -->
                <br />
           <br />
                <div class="form-group">
                    <label class="control-label col-sm-3">Property Option</label>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-2">
                                <label class="radio-inline">
                                    <asp:RadioButton GroupName="grpPropertyOption" ID="rdbSell" runat="server" Text="Sell" OnCheckedChanged="rdbSell_CheckedChanged" />
                                    <%--<input type="radio" id="femaleRadio" value="Female">Female--%>
                                </label>
                            </div>
                            <div class="col-sm-2">
                                <label class="radio-inline">
                                    <asp:RadioButton GroupName="grpPropertyOption" ID="rdbRent" runat="server" Text="Rent" OnCheckedChanged="rdbRent_CheckedChanged" />
                                   <%-- <input type="radio" id="maleRadio" value="Male">Male--%>
                                </label>
                            </div>
                            
                        </div>
                    </div>
                </div> <!-- /.form-group -->
                <br />
                <br />
                <div class="form-group">
                    <label for="txtAddress" class="col-sm-3 control-label">Address</label>
                    <div class="col-sm-3">
                        <asp:TextBox TextMode="MultiLine" ID="txtAddress" runat="server" class="form-control" placeholder="Address"></asp:TextBox>
                        <%--<input type="email" id="email" placeholder="Email" class="form-control">--%>
                    </div>
                </div>
                <br />   <br />
        <br />
                <div class="form-group">
                    <label for="txtLandMark" class="col-sm-3 control-label">LandMark</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtLandMark" runat="server" class="form-control" placeholder="Landmark"></asp:TextBox>
                        <%--<input type="password" id="password" placeholder="Password" class="form-control">--%>
                    </div>
                </div>
               <br />   <br />
                <div class="form-group">
                    <label for="ddlState" class="col-sm-3 control-label">State</label>
                    <div class="col-sm-2">
                <asp:DropDownList runat="server" Class="form-control" ID="ddlState"  placeholder="State" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"  ></asp:DropDownList>
            </div>
                </div>
                <br />   <br />
                <div class="form-group">
                    <label for="ddlCity" class="col-sm-3 control-label">City</label>
            <div class="col-sm-2">
                <asp:DropDownList runat="server" Class="form-control" ID="ddlCity"  placeholder="City" AutoPostBack="True"   > </asp:DropDownList>
              <%--<input type="text" name="state" placeholder="State" class="form-control">--%>
            </div>
                    </div>
                  <br />
                <br />
            <div class="form-group">
                    <label for="txtAddress" class="col-sm-3 control-label">Initial Deposit</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtInitialDeposit" runat="server" class="form-control" placeholder="Initial Deposit"></asp:TextBox>
                        <%--<input type="email" id="email" placeholder="Email" class="form-control">--%>
                    </div>
            </div>
                <br />
           <br />
            <div class="form-group">
                    <label for="txtPriceRange" class="col-sm-3 control-label">Price Range</label>
                    <div class="col-sm-9">
                        <asp:TextBox ID="txtPriceRange" runat="server" class="form-control" placeholder="Price Range"></asp:TextBox>
                        <%--<input type="email" id="email" placeholder="Email" class="form-control">--%>
                    </div>
            </div>


        <br />
        <br />
        <div class="form-group">
                    <label for="txtDesc" class="col-sm-3 control-label">Description</label>
                    <div class="col-sm-3">
                        <asp:TextBox TextMode="MultiLine" ID="txtDesc" runat="server" class="form-control" placeholder="Description"></asp:TextBox>
                        <%--<input type="email" id="email" placeholder="Email" class="form-control">--%>
                    </div>
                </div>
                <br />
           <br />   <br />   
                <div class="form-group">
                    <div class="col-sm-4 col-sm-offset-3">
                        <asp:Button ID="btnRegister" class="btn btn-primary btn-block" runat="server" Text="Register" OnClick="btnRegister_Click" />
                       <%-- <button type="submit" class="btn btn-primary btn-block">Register</button>--%>
                    </div>
                </div>
     
        </div> <!-- ./container -->
</asp:Content>
