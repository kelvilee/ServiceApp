using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.IO;

namespace ServiceApp
{
    public partial class Customer : Page
    {
        private string connectionString = "DSN=mySqlServer;Uid=SYSTEM;Pwd=oracle1";
        protected void Page_Load(object sender, EventArgs e)
        {
            OdbcConnection myConn = new OdbcConnection(connectionString);
            myConn.Open();
            string mySelectQuery = "Select * from customer";
            OdbcCommand command = new OdbcCommand(mySelectQuery, myConn);

            if (!Page.IsPostBack)
            {

                CustomerListView.DataSource = command.ExecuteReader();
                CustomerListView.DataBind();
            }
            myConn.Close();
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (CustomerListView.SelectedIndex >= 0)
                CustomerListView.DeleteItem(CustomerListView.SelectedIndex);
            else
                Label1.Text = "No contact selected";
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            // Image src
            String newFileName = Path.Combine("D:/Work/Downloads/", "evan.jpg");
            // //String DestinationLoc = "C:\Users\A01048343\Desktop\Images";

            //Reading from an image file
            FileStream fs = File.OpenRead(newFileName);
            //Byte[] byData = new byte[fs.Length - 1];
            Byte[] byData = FileUpload1.FileBytes;
            Byte[] evanData = new byte[fs.Length - 1];
            fs.Read(evanData, 0, evanData.Length);

            //inserting to RDBMS via ODBC
            try
            {
                OdbcConnection conn = new OdbcConnection();
                conn = new OdbcConnection(connectionString);
                conn.Open();
                string query = "INSERT INTO Customer (ID, Name, Address, Birthdate, Gender, Picture) VALUES (HEXTORAW(?), ?, ?, ?, ?, ?)";
                OdbcCommand exe = new OdbcCommand(query, conn);
                //exe.Parameters.AddWithValue("@guidValue", Guid.NewGuid().ToString("D"));
                exe.Parameters.Add("@ID", OdbcType.Text).Value = Guid.NewGuid().ToString("N");
                exe.Parameters.Add("@Name", OdbcType.Text).Value = nameTextBox.Text;
                exe.Parameters.Add("@Address", OdbcType.Text).Value = addressTextBox.Text;
                exe.Parameters.Add("@Birthdate", OdbcType.DateTime).Value = birthCalendar.SelectedDate.ToShortDateString();
                exe.Parameters.Add("@Gender", OdbcType.Text).Value = maleRadioBtn.Checked ? "M" : "F";
                exe.Parameters.Add("@Picture", OdbcType.Image, byData.Length).Value = FileUpload1.HasFile ? byData : evanData;
                if (exe.ExecuteNonQuery() > 0)
                {
                    conn.Close();
                }
                Label1.Text = "Customer added";
            }
            catch (Exception err)
            {
                Label1.Text = "Error adding customer";
                Console.WriteLine(err.Message);
            }
        }
    }
}
