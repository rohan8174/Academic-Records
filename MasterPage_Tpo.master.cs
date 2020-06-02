using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private string cs = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    protected static bool flag;
    protected static DataTable dt;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        //if(!IsPostBack)
        //{
        //    SqlConnection conn = new SqlConnection(cs);
        //    dt=new DataTable();
        //    using (SqlCommand cmd = new SqlCommand("select * from Student_Master where Stu_id=@Stu_id", conn))
        //    {
        //        cmd.Parameters.AddWithValue("@Stu_id", Session["Stu_id"]);
        //        using(SqlDataAdapter sda=new SqlDataAdapter(cmd))
        //        {
        //            sda.Fill(dt);
        //            if(dt.Rows.Count>0)
        //            {
        //                masterimage.ImageUrl = "../Admin/" + dt.Rows[0]["Stuimage"].ToString();
        //                mastermenuimage.ImageUrl = "../Admin/" + dt.Rows[0]["Stuimage"].ToString();
        //            }
        //        }
        //    }
        //}
    }
}
