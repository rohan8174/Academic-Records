using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leadgers : System.Web.UI.Page
{
    private string cs = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    private SqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        conn = new SqlConnection(cs);
        if (Session["sid"] == "")
        {
            Response.Redirect("Login.aspx?msg=logout");

        }
        else
        {
            string hash = "";
            string type = "";
            string id = Request.QueryString["ID"];
            using (SqlCommand cmd = new SqlCommand("select hash, type from log_master where id=@id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        hash = dt.Rows[0]["hash"].ToString();
                        type = dt.Rows[0]["type"].ToString();
                        if (type == "Registration")
                        {
                            using (
                                SqlCommand cmd1 =
                                    new SqlCommand(
                                        "select Name,Phone,Email,Address from student_master where gen_hash=@hash",
                                        conn))
                            {
                                cmd1.Parameters.AddWithValue("@hash", hash);
                                using (SqlDataAdapter adp1 = new SqlDataAdapter(cmd1))
                                {
                                    DataTable dt1 = new DataTable();
                                    adp1.Fill(dt1);
                                    dt1.Columns.Add("OperationType", typeof(String));
                                    //DataRow dr = dt1.Rows[4];
                                    //dr[4] = "Registration";
                                    dt1.Rows[0]["OperationType"] = "Registration";
                                    gridFileList.DataSource = dt1;
                                    gridFileList.DataBind();
                                }
                            }
                        }



                        else if (type == "Upload")
                        {
                            using (
                                SqlCommand cmd2 =
                                    new SqlCommand(
                                        "select Date,File_Name,Type from file_master where block_hash=@hash",
                                        conn))
                            {
                                cmd2.Parameters.AddWithValue("@hash", hash);
                                using (SqlDataAdapter adp2 = new SqlDataAdapter(cmd2))
                                {
                                    DataTable dt2 = new DataTable();
                                    adp2.Fill(dt2);
                                    dt2.Columns.Add("OperationType", typeof(String));
                                    //DataRow dr = dt1.Rows[4];
                                    //dr[4] = "Registration";
                                    dt2.Rows[0]["OperationType"] = "Upload";
                                    gridFileList.DataSource = dt2;
                                    gridFileList.DataBind();
                                }
                            }
                        }
                        else
                        {
                            using (
                               SqlCommand cmd3 =
                                   new SqlCommand(
                                       "select Date,File_Name,Description from user_file_master where block_hash=@hash",
                                       conn))
                            {
                                cmd3.Parameters.AddWithValue("@hash", hash);
                                using (SqlDataAdapter adp3 = new SqlDataAdapter(cmd3))
                                {
                                    DataTable dt3 = new DataTable();
                                    adp3.Fill(dt3);
                                    dt3.Columns.Add("OperationType", typeof(String));
                                    //DataRow dr = dt1.Rows[4];
                                    //dr[4] = "Registration";
                                    dt3.Rows[0]["OperationType"] = "Shared";
                                    gridFileList.DataSource = dt3;
                                    gridFileList.DataBind();
                                }
                            }
                        }



                    }

                }
            }
        }
    }
}