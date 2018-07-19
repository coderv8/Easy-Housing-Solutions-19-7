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
    public partial class SellerHome : System.Web.UI.Page
    {
        SellerValidations sellerObj = new SellerValidations();
        int sellerId = 0;
        List<Property> propertyList = new List<Property>();
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
            sellerId = int.Parse(Session["userId"].ToString());
            if (!IsPostBack)
            {
                allProp();
                DisplayProperties(sender, e);
            }
        }

        /// <summary>  
        /// Load Controls on OnInit event  
        /// </summary>  
        /// <param name="e"></param>  
        protected override void OnInit(EventArgs e)
        {

        //override protected void OnInit(EventArgs e)
        //{
        BuyerValidations buyerValidationObj = new BuyerValidations();

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
                    Text = "Edit",
                    //  CssClass = "col-md-2 btn btn-info"
                };

                btnAddcart.Click += (s, RoutedEventArgs) => { ConfirmCart(s, e, propertyId); };

                // GetDataItem owner details..

              
                // Adding all the childs to div
                bodydiv.Controls.Add(div);
                bodydiv.Controls.Add(btnAddcart);
               


                // After adding all the childs..
                bodydiv.Controls.Add(new LiteralControl("<br /><br/>"));
            }
        }

        protected void DisplayProperties(object sender, EventArgs e)
        {
            // Response.Write("<script>alert('page refreshed :" + "data" + "');</script>");
            OnInit(e);
        }
        private void ConfirmCart(object sender, EventArgs e, string propertyId)
        {
            Response.Write("<script>alert('data added to cart :" + propertyId + "');</script>");
            Session["PropId"] = propertyId;
            Response.Redirect("EditProperty.aspx");
           //  Response.Write("<script>alert('data added to cart :" + data + "');</script>");
        }


        protected void btnVerifiedProp_Click(object sender, EventArgs e)
        {
            propertyList = sellerObj.viewProp(sellerId, true);
            DisplayProperties(sender,e);
        }

        protected void btnDeactivatedProp_Click(object sender, EventArgs e)
        {
            bool? b = null;
            propertyList = sellerObj.viewProp(sellerId, b);

            OnInit(e);
        }

        protected void btnAllProp_Click(object sender, EventArgs e)
        {
            allProp();
        }

        protected void allProp()
        {
            propertyList = sellerObj.viewProp(sellerId);
        }

        protected void btnAddProp_Click(object sender, EventArgs e)
        {

            Response.Redirect("PostProperty.aspx");
        }

        protected void btnAllProp_Click1(object sender, EventArgs e)
        {
            allProp();
            OnInit(e);
        }
    }
}