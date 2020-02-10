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
    public partial class Services : Page
    {
        private string connectionString = "DSN=myOracle;Uid=system;Pwd=oracle1";
        protected void Page_Load(object sender, EventArgs e)
        {
            OdbcConnection myConn = new OdbcConnection(connectionString);
            myConn.Open();
            string mySelectQuery = "Select * from servicetype";
            OdbcCommand command = new OdbcCommand(mySelectQuery, myConn);

            if (!Page.IsPostBack)
            {

                ListViewServices.DataSource = command.ExecuteReader();
                ListViewServices.DataBind();
            }
            myConn.Close();
        }

        protected void ListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteButton")
            {
                try
                {
                    OdbcConnection myConn = new OdbcConnection(connectionString);
                    myConn.Open();
                    string deleteQuery = "DELETE FROM ServiceType WHERE ID = HEXTORAW(?)";
                    OdbcCommand command = new OdbcCommand(deleteQuery, myConn);
                    string id = (string)e.CommandArgument;
                    command.Parameters.Add("@ID", OdbcType.Text).Value = id.Replace("-", string.Empty);
                    int result = command.ExecuteNonQuery();
                    myConn.Close();

                    Response.Redirect("Services.aspx");
                }
                catch (Exception err)
                {
                    Label1.Text = "Could not remove service. Ensure it is removed from Customer Services.";
                    Console.WriteLine(err);
                }
            }

            // shows the update row for the service
            if (e.CommandName == "EditButton")
            {
                HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("updateRow");
                tr.Visible = true;
            }

            // hides the update row for the service
            if (e.CommandName == "CancelButton")
            {
                HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("updateRow");
                tr.Visible = false;
            }

            // updates the service with the provided info
            if (e.CommandName == "SubmitButton")
            {
                HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("updateRow");
                TextBox newReq = (TextBox)e.Item.FindControl("updateRequirementsTextBox");
                TextBox newRate = (TextBox)e.Item.FindControl("updateRateTextBox");
                Label oldReq = (Label)e.Item.FindControl("itemReq");
                Label oldRate = (Label)e.Item.FindControl("itemRate");
                tr.Visible = false;

                if(newReq.Text == "")
                {
                    newReq.Text = oldReq.Text;
                }

                if (newRate.Text == "")
                {
                    newRate.Text = oldRate.Text;
                }

                try
                {
                    OdbcConnection myConn = new OdbcConnection(connectionString);
                    myConn.Open();
                    string query = "UPDATE ServiceType SET CertificationRqts = ?, Rate = ? WHERE ID = HEXTORAW(?)";
                    OdbcCommand command = new OdbcCommand(query, myConn);
                    string id = (string)e.CommandArgument;
                    command.Parameters.Add("@CertificationRqts", OdbcType.Numeric).Value = newReq.Text;
                    command.Parameters.Add("@Rate", OdbcType.Numeric).Value = newRate.Text;
                    command.Parameters.Add("@ID", OdbcType.Text).Value = id.Replace("-", string.Empty);
                    int result = command.ExecuteNonQuery();
                    myConn.Close();

                    Response.Redirect("Services.aspx");

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
        }

        // hides the update row for every service
        protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("updateRow");
            tr.Visible = false;
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection conn = new OdbcConnection();
                conn = new OdbcConnection(connectionString);
                conn.Open();
                string query = "INSERT INTO ServiceType (ID, Name, CertificationRqts, Rate) VALUES (HEXTORAW(?), ?, ?, ?)";
                OdbcCommand exe = new OdbcCommand(query, conn);
                //exe.Parameters.AddWithValue("@guidValue", Guid.NewGuid().ToString("D"));
                exe.Parameters.Add("@ID", OdbcType.Text).Value = Guid.NewGuid().ToString("N");
                exe.Parameters.Add("@Name", OdbcType.Text).Value = nameTextBox.Text;
                exe.Parameters.Add("@CertificationRqts", OdbcType.Numeric).Value = requirementsTextBox.Text;
                exe.Parameters.Add("@Rate", OdbcType.Numeric).Value = rateTextBox.Text;
                if (exe.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                }

                Response.Redirect("Services.aspx");

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}