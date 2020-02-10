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
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string uid = TextBox1.Text;
                string pass = TextBox2.Text;
                byte[] salt = new byte[128 / 8];
                using (var rng = RandomNumberGenerator.Create())
                {
                    rng.GetBytes(salt);
                }
                Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

                OdbcConnection myConn = new OdbcConnection(connectionString);
                myConn.Open();
                //string qry = "select * from Ulogin where UserId='" + uid + "' and Password='" + pass + "'";
                
                string qry = "select * from ulogin where userid=? and password=?";
                OdbcCommand cmd = new OdbcCommand(qry, myConn);
                cmd.Parameters.Add("@userid", OdbcType.Char).Value = uid;
                cmd.Parameters.Add("@password", OdbcType.Char).Value = pass;
                OdbcDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    Console.WriteLine("found user");
                    Session["LoggedIn"] = "true";
                    Session["User"] = uid;
                    Response.Redirect("Default.aspx");
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
