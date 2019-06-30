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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
           // label1.Text = firstMacAddress;
        }

        protected void bt2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm2.aspx");
        }

        protected void bt1_Click(object sender, EventArgs e)
        {
            String firstMacAddress = NetworkInterface.GetAllNetworkInterfaces().Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback).Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            con.Open();
            string str1 = "insert into users values(@p1,@p2,@p3,@p4,@p5)";
            SqlCommand cmd1 = new SqlCommand(str1, con);
            cmd1.Parameters.AddWithValue("@p1", firstMacAddress);
            cmd1.Parameters.AddWithValue("@p2", "New Device");
            cmd1.Parameters.AddWithValue("@p3", texbox1.Text);
            cmd1.Parameters.AddWithValue("@p4", textbox2.Text);
            cmd1.Parameters.AddWithValue("@p5", DateTime.Now.ToString("F"));
            cmd1.ExecuteNonQuery();
            con.Close();
            Response.Redirect("WebForm2.aspx");
        }

    }
}