using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using System.Data.Odbc;
namespace ServiceApp
{
    public partial class Login : System.Web.UI.Page
    {
        private string connectionString = "DSN=myOracle;Uid=system;Pwd=oracle1";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Signup_Click(object sender, EventArgs e)
        {
            string uid = TextBox3.Text;
            string pass = ComputeSha256Hash(TextBox4.Text);

            OdbcConnection myConn = new OdbcConnection(connectionString);
            myConn.Open();

            string qry = "insert into ulogin (userid, password) values (?, ?)";
            OdbcCommand exe = new OdbcCommand(qry, myConn);
            exe.Parameters.Add("@userid", OdbcType.Char).Value = uid;
            exe.Parameters.Add("@password", OdbcType.Char).Value = pass;
            if (exe.ExecuteNonQuery() > 0)
            {
                StatusLabel.Text = "Sucessfully Added User";
                myConn.Close();
            }
            else
            {
                StatusLabel.Text = "User could not be added";
            }
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string uid = TextBox1.Text;
                string pass = ComputeSha256Hash(TextBox2.Text);

                OdbcConnection myConn = new OdbcConnection(connectionString);
                myConn.Open();

                string qry = "select * from ulogin where userid=? and password=?";
                OdbcCommand cmd = new OdbcCommand(qry, myConn);
                cmd.Parameters.Add("@userid", OdbcType.Char).Value = uid;
                cmd.Parameters.Add("@password", OdbcType.Char).Value = pass;
                OdbcDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    StatusLabel.Text = "User does not exist/Incorrect password";
                }
                myConn.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }


}
