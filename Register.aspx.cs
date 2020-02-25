using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    public const int SaltByteSize = 24;
    public const int HashByteSize = 20;
    public const int Pbkdf2Iterations = 1000;

    public static string HashPassword(string password)
    {
        var cryptoProvider = new RNGCryptoServiceProvider();
        byte[] salt = new byte[SaltByteSize];
        cryptoProvider.GetBytes(salt);
        var hash = GetPbkdf2Bytes(password, salt, Pbkdf2Iterations, HashByteSize);
        return Pbkdf2Iterations + ":" + Convert.ToBase64String(salt) + ":" + Convert.ToBase64String(hash);
    }

    private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
    {
        var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
        pbkdf2.IterationCount = iterations;
        return pbkdf2.GetBytes(outputBytes);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\prs02\Documents\Movie\App_Data\MovieDB.mdf;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("registerUser", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@fName", txtFirstName.Text);
        cmd.Parameters.AddWithValue("@lName", txtLastName.Text);
        cmd.Parameters.AddWithValue("@pword", HashPassword (txtPassword.Text));
        cmd.Parameters.AddWithValue("@email", txtEmail.Text);
        cmd.Parameters.AddWithValue("@pNumber", txtPhoneNumber.Text);
        cmd.Parameters.AddWithValue("@uType", "Customer");
        try
        {

            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("<script type=\"text/javascript\">alert('Registration Successful.');</script>");
                   }
        catch(Exception ex)
        {
            Response.Write("Error:" + ex.ToString());
        }
    }
}

