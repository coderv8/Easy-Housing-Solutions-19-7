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
    public partial class ShowCartOfBuyer : System.Web.UI.Page
    {
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
        }



        private void ConfirmCart(object sender, EventArgs e, string propertyId)
        {

            BuyerValidations buyerValidationObj = new BuyerValidations();
          
            int BuyerID_login = int.Parse(Session["userId"].ToString());
            
            List<Property> propertyList = new List<Property>();
            BuyerValidations buval = new BuyerValidations();
            StringBuilder sb = new StringBuilder();
            propertyList = buyerValidationObj.DeletefromCart(int.Parse(propertyId), BuyerID_login);
            foreach (var k in propertyList)
            {
                sb.Append("Name: " + k.PropertyName + "\n");
                sb.Append("Type: " + k.PropertyType + "\n");
                sb.Append("Option :" + k.PropertyOption + "\n");
                sb.Append("Description :" + k.Description + "\n");
                sb.Append("Address :" + k.Address + "\n");
                sb.Append("Price: " + k.PriceRange + "\n");
                sb.Append("Intial Deposit: " + k.InitialDeposit + "\n");
                sb.Append("LandMark:" + k.Landmark + "\n");
                sb.Append("The Above Property will be Deleted from cart...!");
                Response.Write("<script>alert('data deleted from cart :" + k.PropertyName + "');</script>");
            }

            // string data = sb.ToString();

            // Response.Write("<script>alert('data added to cart :" + data + "');</script>");
        }


        /// <summary>  
        /// Load Controls on OnInit event  
        /// </summary>  
        /// <param name="e"></param>  
        override protected void OnInit(EventArgs e)
        {
            BuyerValidations buyerValidationObj = new BuyerValidations();
            int BuyerID_login = int.Parse(Session["userId"].ToString());
            List<Property> propertyList = new List<Property>();
            propertyList = buyerValidationObj.showCart(BuyerID_login);

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
                    Text = "Delete from Cart",
                    //  CssClass = "col-md-2 btn btn-info"
                };
                bodydiv.Controls.Add(div);
                bodydiv.Controls.Add(btnAddcart);
                btnAddcart.Click += (s, RoutedEventArgs) => { ConfirmCart(s, e, propertyId); };

                // GetDataItem owner details..

              

                // Adding all the childs to div
              
               


                // After adding all the childs..
                bodydiv.Controls.Add(new LiteralControl("<br /><br/>"));
            }
        }

    }
}