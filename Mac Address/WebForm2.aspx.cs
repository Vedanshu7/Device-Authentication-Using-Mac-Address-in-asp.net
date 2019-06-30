using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mac_Address
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bindcontrol();
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            String firstMacAddress = NetworkInterface.GetAllNetworkInterfaces().Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback).Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            con.Open();
            string str = "select MacAdd from users where email=@p1 AND password=@p2";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@p1", texbox1.Text);
            cmd.Parameters.AddWithValue("@p2", textbox2.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            if (ds.Rows.Count <= 0)
            {
                label.Text = "In Valid User";
            }
            else
            {
                int count = 0;
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    if (ds.Rows[i][0].ToString() == firstMacAddress)
                    {
                        string str1 = "insert into users values(@p1,@p2,@p3,@p4,@p5)";
                        SqlCommand cmd1 = new SqlCommand(str1, con);
                        cmd1.Parameters.AddWithValue("@p1", firstMacAddress);
                        cmd1.Parameters.AddWithValue("@p2", "Same Device");
                        cmd1.Parameters.AddWithValue("@p3", texbox1.Text);
                        cmd1.Parameters.AddWithValue("@p4", textbox2.Text);
                        cmd1.Parameters.AddWithValue("@p5", DateTime.Now.ToString("F"));
                        cmd1.ExecuteNonQuery();
                        break;
                    }
                    else
                    {
                        count++;
                    }
                }
                if (count == ds.Rows.Count)
                {
                    string str1 = "insert into users values(@p1,@p2,@p3,@p4,@p5)";
                    SqlCommand cmd1 = new SqlCommand(str1, con);
                    cmd1.Parameters.AddWithValue("@p1", firstMacAddress);
                    cmd1.Parameters.AddWithValue("@p2", "Different Device");
                    cmd1.Parameters.AddWithValue("@p3", texbox1.Text);
                    cmd1.Parameters.AddWithValue("@p4", textbox2.Text);
                    cmd1.Parameters.AddWithValue("@p5", DateTime.Now.ToString("F"));
                    cmd1.ExecuteNonQuery();
                }
            }
            con.Close();
            bindcontrol();
        }

        protected void bt2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
        private void bindcontrol()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            con.Open();
            String s = "select * from users";
            SqlCommand cmd = new SqlCommand(s, con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}