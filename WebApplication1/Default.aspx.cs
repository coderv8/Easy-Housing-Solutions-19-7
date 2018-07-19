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
    public partial class _Default : Page
    {
        SellerValidations sellerObj = new SellerValidations();
        List<State> states = null;
        List<City> cities = null;
        static int stateId = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userId"] == null )
            {
                Session["userId"] = null;
                Session["userName"] = null;
                Master.Login = true;
                Master.Signup = true;
                Master.Profile = false;
            }
            else
            {
                Master.Login = false;
                Master.Signup = false;
                Master.Profile = true;
                Master.lbl_Profile = Session["userName"].ToString();
                Master.Logout = true;
            }

            states = sellerObj.GetStates();
            cities = sellerObj.GetCities(stateId);
            if (!IsPostBack)
            {
                ddlState.DataTextField = "StateName";
                ddlState.DataValueField = "StateName";
                ddlState.DataSource = states;
                 ddlState.SelectedIndex = 0;
                ddlState.DataBind();
                ddlCity.DataSource =cities;
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

        protected void submit_Click(object sender, EventArgs e)
        {
            HttpCookie sortInfo = new HttpCookie("sortInfo");
            sortInfo["State"] = ddlState.SelectedItem.ToString() ;
            sortInfo["City"] =ddlCity.SelectedItem.ToString() ;
            sortInfo.Expires.Add(new TimeSpan(0, 1, 0));
            Response.Cookies.Add(sortInfo);
            Response.Redirect("DisplayResults.aspx");
        }
    }
}