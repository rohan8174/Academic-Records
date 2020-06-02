using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    private string cs = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    private SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Session.Abandon();
            //Session.Clear();

        }
    }
    protected void btnlogin_Click(object sender, EventArgs e)
    {
        
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        conn = new SqlConnection(cs);
        if (DropDownlist1.SelectedItem.Text == "STUDENTS")
        {
            using (SqlCommand cmd = new SqlCommand("select * from student_master where email=@email and password=@pass", conn))
            {
                cmd.Parameters.AddWithValue("@email", txtusername.Text);
                cmd.Parameters.AddWithValue("@pass", txtpassword.Text);
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        Session["sid"] = dt.Rows[0]["Student_Id"].ToString();
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Login')</script>");
                    }
                }
            }
        }
        else
        {
            using (
                SqlCommand cmd1 = new SqlCommand("select * from tpo_master where email=@email and password=@pass", conn)
                )
            {
                cmd1.Parameters.AddWithValue("@email", txtusername.Text);
                cmd1.Parameters.AddWithValue("@pass", txtpassword.Text);
                using (SqlDataAdapter adp1 = new SqlDataAdapter(cmd1))
                {
                    DataTable dt1 = new DataTable();
                    adp1.Fill(dt1);
                    if (dt1.Rows.Count > 0)
                    {
                        Session["tpo_id"] = dt1.Rows[0]["id"].ToString();
                        Response.Redirect("Home_Tpo.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Login')</script>");
                    }

                }
            }
        }
    }
}