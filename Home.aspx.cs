using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    private string cs = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    public int countstudent;
    public int countnotice;
  
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["Stu_id"] == null)
        {
            //Response.Redirect("logout.aspx");
        }


        //SqlConnection conn = new SqlConnection(cs);
        //SqlDataAdapter da1 = new SqlDataAdapter(new SqlCommand("select count(Stu_id) as countstudent from [Student_Master]", conn));
        //DataTable dt1 = new DataTable();
        //da1.Fill(dt1);
        //countnotice = (int)(dt1.Rows[0]["countstudent"]);

    }
}