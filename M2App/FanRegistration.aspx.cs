using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M2App
{
    public partial class FanRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string Aname = name.Text;
            string user = username.Text;
            string pass = password.Text;
            string nat =NatId.Text;
            string BD=BirthDate.Text;
            string ad = address.Text;


            SqlCommand check = new SqlCommand("checkUsername", conn);
            check.CommandType = System.Data.CommandType.StoredProcedure;
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("@user", user));
            SqlParameter flag = check.Parameters.Add("@flag", SqlDbType.Int);
            flag.Direction = ParameterDirection.Output;
            conn.Open();
            check.ExecuteNonQuery();
            conn.Close();

            if (Aname!="" && user!="" && pass!="" && nat!="" && BD!="" && Phone.Text!="" && ad!="")
            {
                int ph = Int16.Parse(Phone.Text);
                if (flag.Value.ToString() == "1")
                {
                    SqlCommand addFunc = new SqlCommand("addFan", conn);
                    addFunc.CommandType = System.Data.CommandType.StoredProcedure;
                    addFunc.Parameters.Add(new SqlParameter("@name", Aname));
                    addFunc.Parameters.Add(new SqlParameter("@username", user));
                    addFunc.Parameters.Add(new SqlParameter("@password", pass));
                    addFunc.Parameters.Add(new SqlParameter("@natId", nat));
                    addFunc.Parameters.Add(new SqlParameter("@bd", BD));
                    addFunc.Parameters.Add(new SqlParameter("@address", ad));
                    addFunc.Parameters.Add(new SqlParameter("@phone", ph));


                    conn.Open();
                    addFunc.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("FormStart.aspx");
                }
                else
                    Response.Write("<script>alert('Username already taken. Please choose another one !!! ')</script>");

                // Response.Write("Username already taken. Please choose another one");

            }
            else
                Response.Write("<script>alert('PLEASE FILL ALL FIELDS!!')</script>");
        }
    }
}