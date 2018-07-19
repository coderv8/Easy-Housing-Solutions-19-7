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
    public partial class PostProperty : System.Web.UI.Page
    {
        SellerValidations sellerObj = new SellerValidations();
        List<State> states = null;
        List<City> cities = null;
        static int stateId = 1;
        static int cityId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Master.Logout = true;
            Master.Login = false;
            Master.Signup = false;
            Master.Profile = true;
            Master.lbl_Profile = Session["userName"].ToString();

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
                stateId = state.StateId;
                cities = sellerObj.GetCities(stateId);
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

        protected void rdbSell_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSell.Checked == true)
            {
                txtInitialDeposit.Enabled = false;
            }
        }

        protected void rdbRent_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbRent.Checked == true)
                txtInitialDeposit.Enabled = true;
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SellerValidations sellerObj = new SellerValidations();
            Property addProperty = new Property();

            int userId = int.Parse(Session["userId"].ToString());

            addProperty.SellerId = userId;
            addProperty.PropertyName = txtPropName.Text;

            string propType = " ";
            if (rdbFlat.Checked == true)
                propType = "Flat";
            else if (rdbOffice.Checked == true)
                propType = "Office";
            else
                propType = "Villa";

            addProperty.PropertyType = propType;

            string propOption = "";
            if (rdbRent.Checked == true)
                propOption = "Rent";
            else
                propOption = "Sell";

            addProperty.PropertyOption = propOption;

            addProperty.Address = txtAddress.Text;
            addProperty.Landmark = txtLandMark.Text;
            addProperty.InitialDeposit = decimal.Parse(txtInitialDeposit.Text);
            addProperty.PriceRange = decimal.Parse(txtPriceRange.Text);

            State state = states[ddlState.SelectedIndex];
            stateId = state.StateId;
            addProperty.StateId = stateId;

            City city = cities[ddlCity.SelectedIndex];
            cityId = city.CityId;
            addProperty.CityId = cityId;
            addProperty.Description = txtDesc.Text;
            sellerObj.AddProperty(addProperty);

            Response.Redirect("SellerHome.aspx");

        }
    }
}