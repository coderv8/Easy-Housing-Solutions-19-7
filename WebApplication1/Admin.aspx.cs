using EasyHousingSolutions_BLL;
using EasyHousingSolutions_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Admin : System.Web.UI.Page
    {
        SellerValidations sellerObj = new SellerValidations();
        AdminValidations adminObj = new AdminValidations();
        List<State> states = null;
        List<City> cities = null;
        static int stateId = 1;
        List<Property> propertyList = new List<Property>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userName"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            states = sellerObj.GetStates();
            cities = sellerObj.GetCities(stateId);
            if (!IsPostBack)
            {
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateName";
                ddlState.DataSource = states;
                // ddlState.SelectedIndex = 0;
                ddlState.DataBind();
                ddlCity.DataSource = cities;
                ddlCity.DataValueField = "CityName";
                ddlCity.DataBind();
                ddlSellerName.DataSource = adminObj.GetOwners();
                ddlSellerName.DataValueField = "UserName";
                ddlSellerName.DataBind();
            }
            Master.Login = false;
            Master.Signup = false;
            Master.Logout = true;
            Master.Profile = true;
            Master.lbl_Profile = Session["userName"].ToString();
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

        protected void btnSearchByRegion_Click(object sender, EventArgs e)
        {
          propertyList=  adminObj.viewProp(ddlState.SelectedItem.ToString(), ddlCity.SelectedItem.ToString()).ToList();
            gridView1.DataSource = propertyList;

            gridView1.DataBind();
        }

      

        protected void btnSearchBySeller_Click(object sender, EventArgs e)
        {
            //Seller typeSellerId = (Seller)cmbOwnerId.SelectedItem;


           int sellerId = sellerObj.GetSellerId(ddlSellerName.SelectedItem.ToString());
            
            gridView1.DataSource = adminObj.viewPropbyOwner(sellerId, ddlPropOption.SelectedItem.ToString()).ToList();

            gridView1.DataBind();

        }





        protected void gridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Activate")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Property prop = (Property)sellerObj.GetProp(id);
                prop.Status_Description = "Property is Activated";

                sellerObj.UpdateProperty(prop);
                adminObj.verifyProperty(id, true);
            }
            if (e.CommandName == "DeActivate")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Property prop = (Property)sellerObj.GetProp(id);
                prop.Status_Description = "Property is De-Activated";

                sellerObj.UpdateProperty(prop);
                adminObj.verifyProperty(id, false);
            }
            if (e.CommandName == "DeleteProperty")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Property prop = (Property)sellerObj.GetProp(id);

                prop.Status_Description = "Property Deleted";
                sellerObj.UpdateProperty(prop);
                adminObj.verifyProperty(id, null);
            }
            

        }

       
    }
}