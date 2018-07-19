using EasyHousingSolutions_BLL;
using EasyHousingSolutions_Entity;
using EasyHousingSolutions_Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Login = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            User login = new User();
            UsersValidations userObj = new UsersValidations();
            SellerValidations sellerObj = new SellerValidations();
            BuyerValidations buyerObj = new BuyerValidations();

            login.UserName = txtUserName.Text;
            login.Password = txtPassword.Text;

            login = userObj.LoginUser(login);

            if (login != null)
            {
               
                if (login.UserType.ToLower() == "admin")
                {
                   
                    Session["userName"] = login.UserName;
                    Response.Redirect("Admin.aspx");
                }
                else if (login.UserType.ToLower() == "seller")
                {
                    int sellerId = sellerObj.GetSellerId(login.UserName);
                    Session["userId"] = sellerId;
                    Session["userName"] = login.UserName;
                    Response.Redirect("SellerHome.aspx");
                }
                else if (login.UserType.ToLower() == "buyer")
                {
                    int buyerId = buyerObj.BuyerId(login.UserName);
                    Session["userId"] = buyerId;
                    Session["userName"] = login.UserName;
                    Response.Redirect("DisplayResults.aspx");
                }

                Response.Write("<script type='text/javascript'>alert( '" + login.UserName + "');</script>");
            }
            //else
            //{
                
            //    throw new UserException("UserName/Password is invalid");


            //}
        }
    }
}