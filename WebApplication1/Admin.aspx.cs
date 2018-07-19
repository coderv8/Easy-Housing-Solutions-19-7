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
            //foreach (TableRow row in gridView1.Rows)
            //{
            //    TableCell btnCell = new TableCell();

            //    Button btn = new Button();
            //    btn.Text = "Delete";
            //    //btn.Click += new EventHandler(BtnDelete_Click);
            //    btn.Click += (s, RoutedEventArgs) => { Edit1(s, e, ); };
            //    btnCell.Controls.Add(btn);

            //    row.Cells.Add(btnCell);
            //}
            gridView1.DataBind();
        }

        public void Edit1(object sender, EventArgs e, string propId)
        {
            Response.Write("<script>alert('data added to cart :" + propId + "');</script>");
            Session["PropId"] = propId;
            Response.Redirect("EditProperty.aspx");
        }
      

        protected void btnSearchBySeller_Click(object sender, EventArgs e)
        {

        }

        protected void gridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //List<string> columnValues = gridView1.Rows.Cast<GridViewRow>().Select(a => a.Cells[0].Text).ToList();

            GridViewRow row = gridView1.SelectedRow;
            string id = row.Cells[0].Text;

            Response.Write("<script>alert('data added to cart :" + id + "');</script>");
        }

        protected void gridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = gridView1.Rows[rowIndex];

                //Fetch value of Name.
                string id = (row.FindControl("prop") as TextBox).Text;

                //Fetch value of Country
                // string country = row.Cells[1].Text;

                Response.Write("<script>alert('data added to cart :" + id + "');</script>");
            }
        }

        protected void gridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            
        }

        protected void gridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}