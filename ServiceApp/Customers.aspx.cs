using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.IO;
using System.Data.Common;

namespace ServiceApp
{
    public partial class Customers : Page
    {
        private string connectionString = "DSN=myOracle;Uid=system;Pwd=oracle1";
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                Byte[] byData = FileUpload1.FileBytes;
                //inserting to RDBMS via ODBC
                try
                {
                    OdbcConnection conn = new OdbcConnection();
                    conn = new OdbcConnection(connectionString);
                    conn.Open();
                    string query = "INSERT INTO Customer (ID, Name, Address, Birthdate, Gender, Picture) VALUES (HEXTORAW(?), ?, ?, ?, ?, ?)";
                    OdbcCommand exe = new OdbcCommand(query, conn);
                    exe.Parameters.Add("@ID", OdbcType.Text).Value = Guid.NewGuid().ToString("N");
                    exe.Parameters.Add("@Name", OdbcType.Text).Value = nameTextBox.Text;
                    exe.Parameters.Add("@Address", OdbcType.Text).Value = addressTextBox.Text;
                    exe.Parameters.Add("@Birthdate", OdbcType.DateTime).Value = birthCalendar.SelectedDate.ToShortDateString();
                    exe.Parameters.Add("@Gender", OdbcType.Text).Value = maleRadioBtn.Checked ? "M" : "F";
                    exe.Parameters.Add("@Picture", OdbcType.Image, byData.Length).Value = byData;
                    if (exe.ExecuteNonQuery() > 0)
                    {
                        conn.Close();
                    }
                    Label1.Text = "Customer added";
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
            }
            else
            {
                Label1.Text = "Customer was not added";
            }
            Response.Redirect("Customers.aspx");
        }
    }
}