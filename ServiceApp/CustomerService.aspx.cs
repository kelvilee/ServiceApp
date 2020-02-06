using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections;
using System.Data;
using System.Data.Odbc;

namespace ServiceApp
{
    public partial class CustomerService : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ListView2.ItemCommand += new EventHandler<ListViewCommandEventArgs>(ListView1_ItemCommand);
        }
        void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //Literal1.Text = "You clicked the " + (String)e.CommandName + " button";
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string myConnection = "dsn=myOracle;uid=system;pwd=oracle1";
            OdbcConnection myConn = new OdbcConnection(myConnection);
            myConn.Open();
            string mySelectQuery = "select utl_raw.cast_to_varchar2(UTL_RAW.cast_to_raw(CustomerID)) as CustomerID, utl_raw.cast_to_varchar2(UTL_RAW.cast_to_raw(ServiceTypeID)) as ServiceTypeID, ExpectedDuration from customerservice;";
            OdbcCommand command = new OdbcCommand(mySelectQuery, myConn);

            if (!Page.IsPostBack)
            {
                ListView2.DataSource = command.ExecuteReader();
                ListView2.DataBind();
            }
            myConn.Close();
        }

        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("testing in selectedindexchanged.");
        }
    }
}