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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadBtn_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
            {
                // Image src
                //String newFileName = "C:/Users/A01048343/Desktop/Images/octo.jpg";
                // //String DestinationLoc = "C:\Users\A01048343\Desktop\Images";

                //Reading from an image file
                //FileStream fs = File.OpenRead(newFileName);
                //Byte[] byData = new byte[fs.Length - 1];
                Byte[] byData = FileUpload1.FileBytes;
                //fs.Read(byData, 0, byData.Length);

                //inserting to RDBMS via ODBC
                try
                {
                    // Connection
                    string connectionString = "DSN=mySqlServer;Uid=SYSTEM;Pwd=password";
                    OdbcConnection conn = new OdbcConnection();
                    conn = new OdbcConnection(connectionString);
                    conn.Open();
                    string query = "INSERT INTO Customer (ID, Name, Address, Birthdate, Gender, Picture) VALUES (?, ?, ?, ?, ?, ?)";
                    OdbcCommand exe = new OdbcCommand(query, conn);
                    //exe.Parameters.AddWithValue("@guidValue", Guid.NewGuid().ToString("D"));
                    exe.Parameters.Add("@ID", OdbcType.Text).Value = Guid.NewGuid().ToString("D");
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
        }
    }
}