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
    public static int id1, new_id1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["sid"] == null)
            {
                Response.Redirect("login.aspx");
            }
            conn = new SqlConnection(cs);

            bind1();
            bind2();
        }

    }


    public void bind1()
    {
        conn = new SqlConnection(cs);
        using (SqlCommand cmd = new SqlCommand("select * from tpo_master", conn))
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DropDownList1.DataSource = dt;
                    DropDownList1.DataValueField = "id";
                    DropDownList1.DataTextField = "Company_name";
                    DropDownList1.DataBind();

                }
            }
        }
        DropDownList1.Items.Insert(0, new ListItem("--Select Company.--", ""));

    }



    public void bind2()
    {
        conn = new SqlConnection(cs);
        using (SqlCommand cmd = new SqlCommand("select distinct file_name from file_master where student_id=@sid", conn))
        {
            cmd.Parameters.AddWithValue("@sid", Session["sid"]);
            using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    DropDownList2.DataSource = dt;
                    DropDownList2.DataValueField = "file_name";
                    DropDownList2.DataTextField = "file_name";
                    DropDownList2.DataBind();

                }
            }
        }
        DropDownList2.Items.Insert(0, new ListItem("--Select File--", ""));

    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        conn = new SqlConnection(cs);
        string str = DropDownList2.SelectedItem.Text;
        //fileuplogo.PostedFile.SaveAs(Server.MapPath("~/User_Files/" + str));
        //string image = "~/User_Files/" + str.ToString();

        Blockchain phillyCoin = new Blockchain();
        //phillyCoin.AddGenesisBlock();

        //string hash=phillyCoin.AddBlock(new Block(DateTime.Now,null ,"5"));  //use this for upload
        string prev_hash = "";
        string file_id = "";
        string count = "";


        using (SqlCommand cmd3 = new SqlCommand("Select top 1 hash from log_master where student_id=@id order by id desc", conn))
        {
            cmd3.Parameters.AddWithValue("@id", Session["sid"]);
            using (SqlDataAdapter adp3 = new SqlDataAdapter(cmd3))
            {
                DataTable dt3 = new DataTable();
                adp3.Fill(dt3);
                {
                    prev_hash = dt3.Rows[0]["hash"].ToString();
                    B_Count.prev_hash = prev_hash;
                }
            }

        }

        using (SqlCommand cmd9 = new SqlCommand("Select top 1 id from file_master  order by id desc", conn))
        {

            using (SqlDataAdapter adp9 = new SqlDataAdapter(cmd9))
            {
                DataTable dt9 = new DataTable();
                adp9.Fill(dt9);
                if (dt9.Rows.Count > 0)
                {
                    id1 = Convert.ToInt32(dt9.Rows[0]["id"].ToString());
                    new_id1 = id1 + 1;
                }
                else
                {
                    new_id1 = 1;
                }
            }

        }

        using (SqlCommand cmd6 = new SqlCommand("select count(id) as id from log_master where student_id=@id", conn))
        {
            cmd6.Parameters.AddWithValue("@id", Session["sid"].ToString());
            using (SqlDataAdapter adp6 = new SqlDataAdapter(cmd6))
            {
                DataTable dt6 = new DataTable();
                adp6.Fill(dt6);
                if (dt6.Rows.Count > 0)
                {
                    count = dt6.Rows[0]["id"].ToString();
                    B_Count.id = Convert.ToInt32(count);
                }
            }
        }

        string new_id = Convert.ToString(new_id1);
        string hash_new = phillyCoin.AddBlock(new Block(DateTime.Now, prev_hash, new_id));  //use this for upload


        using (
                    SqlCommand cmd =
                        new SqlCommand(
                            "insert into user_file_master (file_name,student_id,tpo_id,Description,date,block_hash) values(@fname,@sid,@cid,@desc,getdate(),@hash)", conn
                            ))
        {
            cmd.Parameters.AddWithValue("@fname", str);
            cmd.Parameters.AddWithValue("@sid", Session["sid"].ToString());
            cmd.Parameters.AddWithValue("@cid", DropDownList1.SelectedValue);

            cmd.Parameters.AddWithValue("@desc", txtdes.Text);
            cmd.Parameters.AddWithValue("@hash", hash_new);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        using (
                    SqlCommand cmd5 =
                        new SqlCommand(
                            "insert into log_master(file_id,student_id,hash,date,type) values(@fid,@sid,@hash,getdate(),@type)",
                            conn))
        {
            cmd5.Parameters.AddWithValue("@fid", new_id1);
            cmd5.Parameters.AddWithValue("@sid", Session["sid"].ToString());
            cmd5.Parameters.AddWithValue("@hash", hash_new);
            cmd5.Parameters.AddWithValue("@type", "Shared");
            conn.Open();
            cmd5.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Shared Successfully')</script>");
        }
    }
}