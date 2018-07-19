using EasyHousingSolutions_BLL;
using EasyHousingSolutions_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SellerRegistration : System.Web.UI.Page
    {
        SellerValidations sellerObj = new SellerValidations();
        List<State> states = null;
        List<City> cities = null;
        static int stateId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            states = sellerObj.GetStates();
            cities = sellerObj.GetCities(stateId);
            if (!IsPostBack)
            {
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateName";
                ddlState.DataSource = states;
                ddlState.SelectedIndex = 0;
                ddlState.DataBind();
                
                ddlCity.DataSource = cities;
                ddlCity.SelectedIndex = 0;
                ddlCity.DataValueField = "CityName";
                ddlCity.DataBind();
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                State state = states[ddlState.SelectedIndex];
               stateId= state.StateId;
                cities= sellerObj.GetCities(stateId);
                ddlCity.DataSource = cities;
                ddlCity.SelectedIndex = 0;
                ddlCity.DataValueField = "CityName";
                ddlCity.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            {
                UsersValidations userObj = new UsersValidations();

                Seller seller = new Seller();
                User newUser = new User();

                seller.Address = txtAddress.Text;
                City city = cities[ddlCity.SelectedIndex];
                seller.CityId = city.CityId;
                State state = states[ddlState.SelectedIndex];
                seller.StateId = state.StateId;

                seller.DateofBirth = DateTime.Parse( txtDOB.Text);
                
                seller.EmailId = txtEmail.Text;
                seller.FirstName = txtFirstName.Text;
                seller.LastName = txtLastName.Text;
                // seller.Password = txtPass.Text;
                seller.PhoneNo = txtPhoneNo.Text;
                seller.UserName = txtUserName.Text;


                newUser.Password = txtPassword.Text;
                newUser.UserName = seller.UserName;
                newUser.UserType = "Seller";


                sellerObj.AddSeller(seller);
                userObj.AddUser(newUser);



                Response.Redirect("Default.aspx");
            }
           
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}