using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Diagnostics;

public partial class _Default : System.Web.UI.Page
{
    private string cs = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    private SqlConnection conn;
    protected static DataTable dt;
    public string hash = "";
    public static string hashData;
    public static string data1;
    public static string data2;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(cs);
        if (Session["tpo_id"] == null)
        {
            Response.Redirect("login.aspx");
        }
        else
        {

            string type = "";
            string sid = "";
            string fname = "";
            string id = Request.QueryString["ID"];
            using (SqlCommand cmd = new SqlCommand("select * from user_file_master where id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        sid = dt.Rows[0]["student_id"].ToString();
                        fname = dt.Rows[0]["file_name"].ToString();
                        using (SqlCommand cmd1 = new SqlCommand("select hash from file_master where file_name=@fname and student_id=@sid", conn))
                        {
                            cmd1.Parameters.AddWithValue("@sid", sid);
                            cmd1.Parameters.AddWithValue("@fname", fname);
                            using (SqlDataAdapter adp1 = new SqlDataAdapter(cmd1))
                            {
                                DataTable dt1 = new DataTable();
                                adp1.Fill(dt1);
                                if (dt1.Rows.Count > 0)
                                {
                                    hash = dt1.Rows[0]["hash"].ToString();
                                    Label2.Text = fname;
                                    Label4.Text = hash;
                                }
                            }


                        }
                    }
                }
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Stream inputStream = fileuplogo.PostedFile.InputStream;
        Byte[] data;

        using (var streamReader = new MemoryStream())
        {
            inputStream.CopyTo(streamReader);
            data = streamReader.ToArray();
            data1 = Convert.ToBase64String(data);
            data2 = Encoding.UTF8.GetString(data, 0, data.Length);
        }
        hashData = performHash(data2);

        conn = new SqlConnection(cs);
        Label5.Visible = true;
        Label6.Text = hashData;
        if (Label4.Text == Label6.Text)
        {
            Response.Write("<script>alert('Hash Value Matched')</script>");
        }
        else
        {
            Response.Write("<script>alert('Hash Value Not Matched')</script>");
        }

    }

    private string performHash(string data)
    {
        byte[] bytes = Encoding.Unicode.GetBytes(data);
        SHA256Managed hashstring = new SHA256Managed();
        byte[] hash = hashstring.ComputeHash(bytes);
        string hashString = string.Empty;
        foreach (byte x in hash)
        {
            hashString += String.Format("{0:x2}", x);
        }
        return hashString;
    }
}