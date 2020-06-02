using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class _Default : System.Web.UI.Page
{
    private string cs = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    private SqlConnection conn;
    protected static string msg = "";
    protected static string id;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            if (Session["sid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            string id = Session["sid"].ToString();

            conn = new SqlConnection(cs);
            using (SqlCommand cmd = new SqlCommand("select * from student_master where student_id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        txtid.Text = dt.Rows[0]["Student_id"].ToString();
                        txtname.Text = dt.Rows[0]["Name"].ToString();
                        txtaddress.Text = dt.Rows[0]["address"].ToString();
                        txtemail.Text = dt.Rows[0]["email"].ToString();
                        txtphone.Text = dt.Rows[0]["phone"].ToString();
                        txtdate.Text = dt.Rows[0]["dob"].ToString();
                        txtbranch.Text = dt.Rows[0]["Branch"].ToString();
                        txtsem.Text = dt.Rows[0]["Semester"].ToString();
                        txtpass.Text = dt.Rows[0]["Password"].ToString();
                        string str = dt.Rows[0]["profile"].ToString();
                        showimge.ImageUrl = ("~/admin/img/" + str);
                    }
                }
            }


        }

    }



    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        conn = new SqlConnection(cs);
        if (fileuplogo.HasFile)
        {
            string str = fileuplogo.FileName;
            fileuplogo.PostedFile.SaveAs(Server.MapPath("~/admin/img/" + str));
            string image = "~/admin/img/" + str.ToString();
            showimge.ImageUrl = ("~/admin/img/" + str);

            using (SqlCommand cmd1 = new SqlCommand("update student_master set name=@name,email=@email,address=@add,phone=@phone,profile=@profile,password=@pass,dob=@dob where student_id=@id", conn))
            {
                cmd1.Parameters.AddWithValue("@id", Session["sid"].ToString());
                cmd1.Parameters.AddWithValue("@name", txtname.Text);

                cmd1.Parameters.AddWithValue("@email", txtemail.Text);
                cmd1.Parameters.AddWithValue("@phone", txtphone.Text);
                cmd1.Parameters.AddWithValue("@add", txtaddress.Text);
                cmd1.Parameters.AddWithValue("@dob", txtdate.Text);
                cmd1.Parameters.AddWithValue("@profile", str);
                cmd1.Parameters.AddWithValue("@pass", txtpass.Text);
                conn.Open();
                cmd1.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Profile Updated Successfully')</script>");

            }
        }
    }
}