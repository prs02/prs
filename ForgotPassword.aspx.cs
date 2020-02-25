using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
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

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\prs02\Documents\Movie\App_Data\MovieDB.mdf;Integrated Security=True");
        con.Open();
                string query ="update Users set Password='"+HashPassword("default123")+"'where Email= ='"+txtEmail.Text+"'";
        SqlCommand cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
       

        if(string.IsNullOrEmpty(txtEmail.Text) )
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("rajasuriya377@gmail.com");
            msg.To.Add(txtEmail.Text);
            msg.Subject = "Recover your Password";
            msg.Body = ("Your Temporary password is default123");
            msg.IsBodyHtml = true;
            SmtpClient smt = new SmtpClient();
            smt.Host = "smtp.gmail.com";
            System.Net.NetworkCredential ntwd = new System.Net.NetworkCredential();
            ntwd.UserName = "rajasuriya377@gmail.com";
            ntwd.Password= "admin123$123#";
            smt.Credentials = ntwd;
            smt.Port = 587;
            smt.EnableSsl = true;
            smt.Send(msg);
            LblMessage.ForeColor = System.Drawing.Color.ForestGreen;
            LblMessage.Text = "Password Sent Successfully";
        }
        con.Close();
    }
   
}