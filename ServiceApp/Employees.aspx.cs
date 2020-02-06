using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ServiceApp
{
    public partial class Employees : Page
    {
        private string connectionString = "DSN=myOracle;Uid=system;Pwd=oracle1";
        protected void Page_Load(object sender, EventArgs e)
        {
            populateListView();
        }

        private void populateListView()
        {
            OdbcConnection myConn = new OdbcConnection(connectionString);
            myConn.Open();
            string mySelectQuery = "select * from Employee";
            OdbcCommand command = new OdbcCommand(mySelectQuery, myConn);

            if (!Page.IsPostBack)
            {
                ListViewEmployees.DataSource = command.ExecuteReader();
                ListViewEmployees.DataBind();
            }

            myConn.Close();
        }

        // hides the details of every employee
        protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("toggleDiv");
            div.Visible = false;
        }

        protected void ListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteButton")
            {
                try
                {
                    OdbcConnection myConn = new OdbcConnection(connectionString);
                    myConn.Open();
                    string deleteQuery = "DELETE FROM Employee WHERE ID = ?";
                    OdbcCommand command = new OdbcCommand(deleteQuery, myConn);
                    string id = (string)e.CommandArgument;
                    command.Parameters.Add("@ID", OdbcType.Text).Value = id.Replace("-", string.Empty);
                    int result = command.ExecuteNonQuery();
                    myConn.Close();

                    Response.Redirect("Employees.aspx");
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            }

            // displays the details by setting div visibility to true
            if (e.CommandName == "DetailsButton")
            {
                HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("toggleDiv");
                div.Visible = true;
            }
        }

    }
}