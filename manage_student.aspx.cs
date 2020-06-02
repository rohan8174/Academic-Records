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
    protected static bool flag;
    protected static DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["tpo_id"] == null)
        {
            Response.Redirect("login.aspx");
        }
        conn = new SqlConnection(cs);
        dt = new DataTable();
        using (SqlCommand cmd = new SqlCommand("select * from  Student_Master", conn))
        {

            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                sda.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                flag = true;
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        conn = new SqlConnection(cs);
        using(SqlCommand cmd = new SqlCommand("select * from student_master where student_id=@id",conn))
        {
            cmd.Parameters.AddWithValue("@id", txtid.Text);
            using(SqlDataAdapter adp= new SqlDataAdapter(cmd))
            {
                dt = new DataTable();
                adp.Fill(dt);
                if(dt.Rows.Count>0)
                {
                    
                        flag = true;
                    
                }

            }
        }
    }
}