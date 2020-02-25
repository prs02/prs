using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    public const int   IterationIndex = 0;
    public const int SaltIndex = 1;
    public const int Pbkdf2Index = 2;

    public static bool ValidatePassword(string password, string correctHash)
    {
        char[] delimiter = { ':' };
        var split = correctHash.Split(delimiter);
        var iterations = Int32.Parse(split[IterationIndex]);
        var salt = Convert.FromBase64String(split[SaltIndex]);
        var hash = Convert.FromBase64String(split[Pbkdf2Index]);
        var testHash = GetPbkdf2Bytes(password, salt, iterations, hash.Length);
        return SlowEquals(hash, testHash);
    }

    private static bool SlowEquals(byte[] a, byte[] b)
    {
        var diff = (uint)a.Length ^ (uint)b.Length; for (int i = 0; i < a.Length && i < b.Length; i++)
        {
            diff |= (uint)(a[i] ^ b[i]);
        }
        return diff == 0;
    }

    private static byte[] GetPbkdf2Bytes(string password, byte[] salt, int iterations, int outputBytes)
    { var pbkdf2 = new Rfc2898DeriveBytes(password, salt);
        pbkdf2.IterationCount = iterations;
        return pbkdf2.GetBytes(outputBytes);
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void txtPassword_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void BtnLogin_Click(object sender, EventArgs e)
    {
        string UserID, UserName, Usertype;

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\prs02\Documents\Movie\App_Data\MovieDB.mdf;Integrated Security=True");
        con.Open();
        SqlCommand cmdPassword = new SqlCommand("select Password from Users where Email= '" + txtEmail.Text + " '", con);
        if (cmdPassword.ExecuteScalar() == null)
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Incorrect Email";
        }
        else
        {
            string pword = cmdPassword.ExecuteScalar().ToString().Replace(" ", "");
            if (ValidatePassword(txtPassword.Text, pword))
            {
                SqlCommand cmdType = new SqlCommand("Select UserId,FirstName,UserType from Users where Email='" + txtEmail.Text + "'", con);
                using (SqlDataReader sdr = cmdType.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        UserID = sdr["UserId"].ToString();
                        UserName = sdr["FirstName"].ToString();
                        Usertype = sdr["UserType"].ToString();
                        Session["uid"] = UserID;
                        Session["uname"] = UserName;
                        Session["utype"] = Usertype;
                    }

                }
                Response.Redirect("Home.aspx");

            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Incorrect Password";
            }
            con.Close();
        }
    }
}