using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections;
using System.Data;
using System.Data.Odbc;

namespace ServiceApp
{
    public partial class CustomerService : System.Web.UI.Page
    {
        private string connectionString = "DSN=myOracle;Uid=system;Pwd=oracle1";
        protected void Page_Init(object sender, EventArgs e)
        {
            ListView2.ItemCommand += new EventHandler<ListViewCommandEventArgs>(ListView1_ItemCommand);
        }
        void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        { 
            // displays the details by setting div visibility to true
            if (e.CommandName == "DetailsButton")
            {
                HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("toggleDiv");
                div.Visible = true;
            }
            if (e.CommandName == "UpdateButton")
            {
                try
                {
                    //OdbcConnection myConn = new OdbcConnection(connectionString);
                    //myConn.Open();
                    //string deleteQuery = "DELETE FROM CustomerService WHERE ID = ?";
                    //    OdbcCommand command = new OdbcCommand(deleteQuery, myConn);
                    //    string id = (string)e.CommandArgument;
                    //    command.Parameters.Add("@ID", OdbcType.Text).Value = id.Replace("-", string.Empty);
                    //    int result = command.ExecuteNonQuery();
                    //    myConn.Close();

                    //    Response.Redirect("CustomerService.aspx");
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            }
            if (e.CommandName == "DeleteButton")
            {
                try
                {
                    OdbcConnection myConn = new OdbcConnection(connectionString);
                    myConn.Open();
                    string deleteQuery = "DELETE FROM CustomerService WHERE ID = ?";
                    OdbcCommand command = new OdbcCommand(deleteQuery, myConn);
                    string id = (string)e.CommandArgument;
                    command.Parameters.Add("@ID", OdbcType.Text).Value = id.Replace("-", string.Empty);
                    int result = command.ExecuteNonQuery();
                    myConn.Close();

                    Response.Redirect("CustomerService.aspx");
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string myConnection = "dsn=myOracle;uid=system;pwd=oracle1";
            OdbcConnection myConn = new OdbcConnection(myConnection);
            myConn.Open();
            string mySelectQuery = "select utl_raw.cast_to_varchar2(UTL_RAW.cast_to_raw(CustomerID)) as CustomerID, utl_raw.cast_to_varchar2(UTL_RAW.cast_to_raw(ServiceTypeID)) as ServiceTypeID, ExpectedDuration, customerservice.id as customerserviceid, servicetype.id as servicetypeid, name, certificationrqts, rate from customerservice join servicetype on customerservice.servicetypeid = servicetype.id;";
            OdbcCommand command = new OdbcCommand(mySelectQuery, myConn);

            if (!Page.IsPostBack)
            {
                ListView2.DataSource = command.ExecuteReader();
                ListView2.DataBind();
            }
            myConn.Close();
        }
        // hides the details
        protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HtmlGenericControl div = (HtmlGenericControl)e.Item.FindControl("toggleDiv");
            div.Visible = false;
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("testing in selectedindexchanged.");
        }
    }
}