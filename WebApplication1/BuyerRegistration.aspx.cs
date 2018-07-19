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
    public partial class BuyerRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UsersValidations userObj = new UsersValidations();
            User newUser = new User();
            BuyerValidations buval = new BuyerValidations();
            Buyer buyer = new Buyer();
            buyer.UserName = txtUserName.Text;
            buyer.FirstName = txtFirstName.Text;
            buyer.LastName = txtLastName.Text;
            buyer.DateOfBirth = DateTime.Parse(txtDOB.Text);
            buyer.PhoneNo = txtPhoneNo.Text;
            buyer.EmailId = txtEmail.Text;

           

            newUser.Password = txtPassword.Text;
            newUser.UserName = buyer.UserName;
            newUser.UserType = "Buyer";
            buval.AddBuyer(buyer);
            userObj.AddUser(newUser);
            Response.Redirect("Default.aspx");

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}