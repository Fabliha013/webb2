using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using localhost;
using System.IO;

public partial class loginpage : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cs"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            Response.Redirect("userform.aspx");
        }
        else
        {
            con.Open();
            
        }

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string user = TextBox4.Text.Trim();
        bool t = false;
        string check = "select * from [table] where name='" + TextBox3.Text +"'and pw='" + TextBox4.Text +"'and email='" + TextBox2.Text + "'";
        SqlCommand cmd = new SqlCommand(check, con);
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        foreach (DataRow dr in dt.Rows)
        {

            t = true;

         }
        if (t == true)
        {
            Session["user"] = user;
            Response.Redirect("userform.aspx");
        }

            
       
    }
    protected void adminlogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminlogin.aspx");
    }
}