using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiceApp
{
    public partial class Employees : Page
    {
        private string connectionString = "DSN=myOracle;Uid=system;Pwd=oracle1";
        protected void Page_Load(object sender, EventArgs e)
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
    }
}