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
    public partial class EditProperty : System.Web.UI.Page
    {
        SellerValidations sellerObj = new SellerValidations();
        Property prp = null;
        int propId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           propId=int.Parse( Session["PropId"].ToString());
            if (Session["userId"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Master.Logout = true;
            Master.Login = false;
            Master.Signup = false;
            Master.Profile = true;
            Master.lbl_Profile = Session["userName"].ToString();
            if (!IsPostBack)
            {
                prp = sellerObj.GetProp(propId);

                txtAddress.Text = prp.Address;
                txtInitialDeposit.Text = prp.InitialDeposit.ToString();
                txtDesc.Text = prp.Description;
                txtLandMark.Text = prp.Landmark;
                txtPriceRange.Text = prp.PriceRange.ToString();
                txtPropName.Text = prp.PropertyName;

                if (prp.PropertyType == "Flat")
                    rdbFlat.Checked = true;
                else if (prp.PropertyType == "Villa")
                    rdbVilla.Checked = true;
                else if (prp.PropertyType == "Office")
                    rdbOffice.Checked = true;


                if (prp.PropertyOption == "Rent")
                    rdbRent.Checked = true;
                else if (prp.PropertyOption == "Sell")
                    rdbSell.Checked = true;

                ddlState.DataSource = sellerObj.GetStateById(prp.StateId);
                ddlState.DataValueField = "StateName";
                ddlState.SelectedIndex = 0;
                ddlState.DataBind();
                ddlCity.DataSource = sellerObj.Get_City(prp.CityId);
                ddlCity.DataValueField = "CityName";
                ddlCity.SelectedIndex = 0;
                ddlCity.DataBind();
            }
        }
        
        

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            prp = new Property();
            prp.PropertyId = propId;
            int sellerId = int.Parse(Session["userId"].ToString());
            prp.Address = txtAddress.Text;
            prp.PropertyName = txtPropName.Text;
            prp.SellerId = sellerId;

            string prpOpt = "";
            if (rdbRent.Checked == true)
                prpOpt = "Rent";
            else if (rdbSell.Checked == true)
                prpOpt = "Sell";


            prp.PropertyOption = prpOpt;


            string prpType = "";
            if (rdbFlat.Checked == true)
                prpType = "Flat";
            else if (rdbOffice.Checked == true)
                prpType = "Office";
            else if (rdbVilla.Checked == true)
                prpType = "Villa";

            prp.PropertyType = prpType;

            prp.PriceRange = decimal.Parse(txtPriceRange.Text);
            if (txtInitialDeposit.Text == "")
                prp.InitialDeposit = 0;
            else
                prp.InitialDeposit = decimal.Parse(txtInitialDeposit.Text);
            prp.Landmark = txtLandMark.Text;
            prp.Description = txtDesc.Text;
            sellerObj.UpdateProperty(prp);
        }
    }
}