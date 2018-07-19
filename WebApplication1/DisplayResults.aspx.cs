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
    public partial class DisplayResults : System.Web.UI.Page
    {
        SellerValidations sellerObj = new SellerValidations();
        AdminValidations adminObj = new AdminValidations();
        BuyerValidations buyerValidationObj = new BuyerValidations();
       
        List<State> states = null;
        List<City> cities = null;
        static int stateId = 1;
        string state = "";
        string city = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            cities = sellerObj.GetCities(stateId);
            states = sellerObj.GetStates();
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

                HttpCookie reqCookies = Request.Cookies["sortInfo"];
                if (reqCookies != null)
                {
                    state = reqCookies["State"].ToString();
                    city = reqCookies["City"].ToString();
                }
                DisplayProperties(sender,e);
            }
            if (Session["userId"] == null)
            {
                //Response.Redirect("Login.aspx");
                Master.Logout = false;
                Master.Login = true;
                Master.Signup = true;
                Master.Profile = false;
               
                //Master.lbl_Profile = Session["userName"].ToString();
            }
            else { 
            Master.Logout = true;
            Master.Login = false;
            Master.Signup = false;
            Master.Profile = true;
            Master.lbl_Profile = Session["userName"].ToString();  
                
            }
        }
        


        /// <summary>  
        /// Load Controls on OnInit event  
        /// </summary>  
        /// <param name="e"></param>  
        override protected void OnInit(EventArgs e)
        {
            BuyerValidations buyerValidationObj = new BuyerValidations();

            List<Property> propertyList = new List<Property>();
            propertyList = buyerValidationObj.showProperties(state, city);
            if (propertyList == null)
                Response.Write("<script>alert('There are no properties to be displayed');</script>");

            foreach (var k in propertyList)
            {

                string imgpath = @"Images\home_back.jpeg";


                // Intializing the UI Controls...

                Label lblPropname = new Label { CssClass = "space" };
                Label lblType = new Label { CssClass = "space" };
                Label lblPropOption = new Label { CssClass = "space" };
                Label lblPropDescription = new Label();
                Label lblAddress = new Label();
                Label lblPrice = new Label();
                Label lblIntialdeposit = new Label();
                Label lblLandMArk = new Label();

                //Create Group Container Div  
                HtmlGenericControl div = new HtmlGenericControl("div");
                div.Attributes.Add("class", "form-group");

                // dynamic image

                System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                img.ImageUrl = imgpath;





                // Mapping the Property data with UI controls...

                lblPropname.Text = k.PropertyName;
                lblType.Text = "Type :  " + k.PropertyType + "     ";
                lblPropOption.Text = "Option :  " + k.PropertyOption + "     ";
                // lblPropDescription.Text = "Description : \t" + k.Description;
                lblAddress.Text = "Address :  " + k.Address + "     ";
                lblPrice.Text = "Price :  " + k.PriceRange + "     ";
                lblIntialdeposit.Text = "Intial Deposit :  " + k.InitialDeposit + "     ";

                lblLandMArk.Text = "LandMark :  " + k.Landmark + "     ";


                // Appending All the UI Controls to stackpanel
                div.Controls.Add(lblPropname);
                div.Controls.Add(img);
                div.Controls.Add(lblType);
                div.Controls.Add(lblPropOption);
                div.Controls.Add(lblPrice);
                div.Controls.Add(lblIntialdeposit);
                div.Controls.Add(lblLandMArk);

                div.Controls.Add(lblAddress);

                div.Controls.Add(lblPropDescription);

                //// label for type
                //div.Controls.Add(new Label()
                //{
                //    Text = "Type :" + k.PropertyType,
                //    CssClass = "col-md-2 control-label"

                //});






                //button..
                string propertyId = k.PropertyId.ToString();
                var btnAddcart = new Button
                {
                    ID = "btnClick" + propertyId,
                    Text = "Add To Cart",
                    //  CssClass = "col-md-2 btn btn-info"
                };

               btnAddcart.Click += (s, RoutedEventArgs) => { ConfirmCart(s, e, propertyId); };

                // GetDataItem owner details..

                var btnOwnerDetails = new Button
                {
                    Text = "Get Owner Details",
                    // CssClass = "col-md-2 btn btn-info"
                };

                // Adding all the childs to div
                bodydiv.Controls.Add(div);
                bodydiv.Controls.Add(btnAddcart);
                bodydiv.Controls.Add(btnOwnerDetails);


                // After adding all the childs..
                bodydiv.Controls.Add(new LiteralControl("<br /><br/>"));
            }
        }

     

        

       protected void DisplayProperties(object sender , EventArgs e)
        {
           // Response.Write("<script>alert('page refreshed :" + "data" + "');</script>");
            OnInit(e);
        }


        /// <summary>  
        /// Load Controls on OnInit event  
        /// </summary>  
        /// <param name="e"></param>  
        //override protected void OnInit(EventArgs e)
        //{


        //}

        private void ConfirmCart(object sender, EventArgs e, string propertyId)
        {
           
            Response.Write("<script>alert('this is  cart function :" + propertyId + "');</script>");
            BuyerValidations buyerValidationObj = new BuyerValidations();
            List<Property> propertyList = new List<Property>();
            BuyerValidations buval = new BuyerValidations();
            StringBuilder sb = new StringBuilder();
            int BuyerID_login =int.Parse( Session["userId"].ToString());
            propertyList = buyerValidationObj.AddToCart(int.Parse(propertyId), BuyerID_login);
            foreach (var k in propertyList)
            {
                Response.Write("<script>alert('" + k.PropertyName + "<br/>This property added to cart :');</script>");
                sb.Append("Name: " + k.PropertyName + "\n");
                sb.Append("Type: " + k.PropertyType + "\n");
                sb.Append("Option :" + k.PropertyOption + "\n");
                sb.Append("Description :" + k.Description + "\n");
                sb.Append("Address :" + k.Address + "\n");
                sb.Append("Price: " + k.PriceRange + "\n");
                sb.Append("Intial Deposit: " + k.InitialDeposit + "\n");
                sb.Append("LandMark:" + k.Landmark + "\n");
                sb.Append("The Above Property is Added to cart successfully...");

            }
        }

        protected void btnSearchByRegion_Click(object sender, EventArgs e)
        {
           //HttpCookie sortInfo = Request.Cookies["sortInfo"]; ;
           // sortInfo = new HttpCookie("sortInfo");
           // sortInfo.Values["State"] = ddlState.SelectedItem.ToString(); ;
           // sortInfo.Values["City"] = ddlCity.SelectedItem.ToString();
           // sortInfo.Expires.Add(new TimeSpan(0, 1, 0));
           // Response.Cookies.Add(sortInfo);
           state= ddlState.SelectedItem.ToString();
            city= ddlCity.SelectedItem.ToString(); 
           // EventArgs ea = new EventArgs();
           
            DisplayProperties(sender,e);
        }

        protected void btnSearchByPrice_Click(object sender, EventArgs e)
        {

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
    }
}