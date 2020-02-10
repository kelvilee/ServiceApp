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
            HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("toggleDetailsDiv");
            div.Visible = false;

            Panel updatePanel = (Panel)e.Item.FindControl("updateInfoPanel");
            updatePanel.Visible = false;
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
                HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("toggleDetailsDiv");
                div.Visible = true;
            }

            if (e.CommandName == "UpdateButton")
            {
                HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("toggleDetailsDiv");
                div.Visible = true;

                Panel updatePanel = (Panel)e.Item.FindControl("updateInfoPanel");
                updatePanel.Visible = true;

                Button submitChanges = (Button)e.Item.FindControl("SubmitButton");
                submitChanges.Visible = true;
            }
                
            if (e.CommandName == "SubmitButton")
            {
                TextBox nameValue = (TextBox)e.Item.FindControl("NameValue");
                TextBox jobTitleValue = (TextBox)e.Item.FindControl("TitleValue");
                TextBox addressValue = (TextBox)e.Item.FindControl("AdressValue");
                TextBox certifiedForValue = (TextBox)e.Item.FindControl("CertifiedForValue");
                TextBox salaryValue = (TextBox)e.Item.FindControl("SalaryValue");
                Label oldName = (Label)e.Item.FindControl("Name");
                Label oldJobtitleValue = (Label)e.Item.FindControl("Title");
                Label oldAdressValue = (Label)e.Item.FindControl("Address");
                Label oldCertifiedForValue = (Label)e.Item.FindControl("CertifiedFor");
                Label oldSalaryValue = (Label)e.Item.FindControl("Salary");

                if (nameValue.Text == "")
                {
                    nameValue.Text = oldName.Text;
                }

                if (jobTitleValue.Text == "")
                {
                    jobTitleValue.Text = oldJobtitleValue.Text;
                }

                if (addressValue.Text == "")
                {
                    addressValue.Text = oldAdressValue.Text;
                }

                if (certifiedForValue.Text == "")
                {
                    certifiedForValue.Text = oldCertifiedForValue.Text;
                }

                if (salaryValue.Text == "")
                {
                    salaryValue.Text = oldSalaryValue.Text;
                }

                try
                {
                    OdbcConnection myConn = new OdbcConnection(connectionString);
                    myConn.Open();
                    string query = "UPDATE Employee SET NAME = ?, ADDRESS = ?, JOBTITLE = ?, CERTIFIEDFOR = ?, SALARY = ? WHERE ID = HEXTORAW(?)";
                    OdbcCommand command = new OdbcCommand(query, myConn);
                    string id = (string)e.CommandArgument;
                    command.Parameters.Add("@NAME", OdbcType.Text).Value = nameValue.Text;
                    command.Parameters.Add("@ADDRESS", OdbcType.Text).Value = addressValue.Text;
                    command.Parameters.Add("@JOBTITLE", OdbcType.Text).Value = jobTitleValue.Text;
                    command.Parameters.Add("@CERTIFIEDFOR", OdbcType.Text).Value = certifiedForValue.Text;
                    command.Parameters.Add("@SALARY", OdbcType.Int).Value = int.Parse(salaryValue.Text);
                    command.Parameters.Add("@ID", OdbcType.Text).Value = id.Replace("-", string.Empty);
                    int result = command.ExecuteNonQuery();
                    myConn.Close();

                    Response.Redirect("Employees.aspx");

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }

        }

    }
}