using System;
using System.Diagnostics;
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
using System.Data.SqlClient;
using System.Configuration;

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
                HtmlGenericControl toggleDetailsDiv = (HtmlGenericControl)e.Item.FindControl("toggleDetailsDiv");
                toggleDetailsDiv.Visible = true;
            }
            if (e.CommandName == "UpdateButton")
            {
                HtmlGenericControl toggleUpdateDiv = (HtmlGenericControl)e.Item.FindControl("toggleUpdateDiv");
                toggleUpdateDiv.Visible = true;
            }
            if (e.CommandName == "SubmitUpdateButton")
            {
                HtmlGenericControl toggleUpdateDiv = (HtmlGenericControl)e.Item.FindControl("toggleUpdateDiv");
                toggleUpdateDiv.Visible = false;
                TextBox updateDurationTextBox = (TextBox)e.Item.FindControl("updateDurationTextBox");

                try
                {
                    OdbcConnection myConn = new OdbcConnection(connectionString);
                    myConn.Open();
                    string query = "UPDATE CustomerService SET ExpectedDuration = ? WHERE ID = HEXTORAW(?)";
                    OdbcCommand command = new OdbcCommand(query, myConn);
                    string customerserviceid = (string)e.CommandArgument;
                    command.Parameters.Add("@ExpectedDuration", OdbcType.Numeric).Value = updateDurationTextBox.Text;
                    command.Parameters.Add("@ID", OdbcType.Text).Value = customerserviceid.Replace("-", string.Empty);
                    int result = command.ExecuteNonQuery();
                    myConn.Close();

                    Response.Redirect("CustomerService.aspx");

                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
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
            string mySelectQuery = "select utl_raw.cast_to_varchar2(UTL_RAW.cast_to_raw(CustomerID)) as CustomerID, utl_raw.cast_to_varchar2(UTL_RAW.cast_to_raw(ServiceTypeID)) as ServiceTypeID, ExpectedDuration, customerservice.id as customerserviceid, servicetype.id as servicetypeid, servicetype.name as serviceName, certificationrqts, customer.name as customerName, customer.gender as gender, rate from customerservice join servicetype on customerservice.servicetypeid = servicetype.id join customer on customerservice.CustomerID = customer.id; ";
            OdbcCommand command = new OdbcCommand(mySelectQuery, myConn);

            if (!Page.IsPostBack)
            {
                ListView2.DataSource = command.ExecuteReader();
                ListView2.DataBind();
            }
            myConn.Close();
            bindDropDownLists();
        }
        // hides the details
        protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            HtmlGenericControl toggleDetailsDiv = (HtmlGenericControl)e.Item.FindControl("toggleDetailsDiv");
            toggleDetailsDiv.Visible = false;
            HtmlGenericControl toggleUpdateDiv = (HtmlGenericControl)e.Item.FindControl("toggleUpdateDiv");
            toggleUpdateDiv.Visible = false;
        }
        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("testing in selectedindexchanged.");
        }

        //private String strcon = ConfigurationManager.ConnectionStrings["hr"].ConnectionString;

        //private dropdownlist ddlTest;

        protected void bindDropDownLists()
        {
            string myConnection = "dsn=myOracle;uid=system;pwd=oracle1";
            OdbcConnection myConn = new OdbcConnection(myConnection);
            myConn.Open();
            string mySelectQuery = "select utl_raw.cast_to_varchar2(UTL_RAW.cast_to_raw(id)) as id, name from servicetype;";
            OdbcCommand command = new OdbcCommand(mySelectQuery, myConn);

            DataTable table = new DataTable();
            OdbcDataAdapter adapter = new OdbcDataAdapter(command);
            adapter.Fill(table);
            ServiceDropDownList.DataSource = table;
            ServiceDropDownList.DataTextField = "name";
            ServiceDropDownList.DataValueField = "id";
            ServiceDropDownList.DataBind();

            mySelectQuery = "select utl_raw.cast_to_varchar2(UTL_RAW.cast_to_raw(id)) as id, name from customer;";
            command = new OdbcCommand(mySelectQuery, myConn);

            table = new DataTable();
            adapter = new OdbcDataAdapter(command);
            adapter.Fill(table);
            CustomerDropDownList.DataSource = table;
            CustomerDropDownList.DataTextField = "name";
            CustomerDropDownList.DataValueField = "id";
            CustomerDropDownList.DataBind();

            myConn.Close();
        }

        protected void Add_Service_Btn(object sender, EventArgs e)
        {
            if (ServiceDropDownList.SelectedValue != null && CustomerDropDownList.SelectedValue != null && durationInput.Text != null)
            {
                string myConnection = "dsn=myOracle;uid=system;pwd=oracle1";
                OdbcConnection myConn = new OdbcConnection(myConnection);
                myConn.Open();
                string mySelectQuery = "INSERT INTO CustomerService (ID,CustomerID,ServiceTypeID,ExpectedDuration) VALUES (HEXTORAW(?), HEXTORAW(?), HEXTORAW(?), ?)";
                OdbcCommand command = new OdbcCommand(mySelectQuery, myConn);
                command.Parameters.Add("@ID", OdbcType.Text).Value = Guid.NewGuid().ToString("N");
                command.Parameters.Add("@CustomerID", OdbcType.Text).Value = CustomerDropDownList.SelectedValue;
                command.Parameters.Add("@ServiceTypeID", OdbcType.Text).Value = ServiceDropDownList.SelectedValue;
                command.Parameters.Add("@ExpectedDuration", OdbcType.Text).Value = durationInput.Text;

                Debug.WriteLine("CustomerDropDownList.DataValueField = " + CustomerDropDownList.SelectedValue);

                Debug.WriteLine("ServiceDropDownList.DataValueField = " + ServiceDropDownList.SelectedValue);

                //myConn.Close();

                if (command.ExecuteNonQuery() > 0)
                {
                    myConn.Close();

                }
            }
        }
    }
}