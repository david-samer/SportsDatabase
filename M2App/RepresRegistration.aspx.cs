using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M2App
{
    public partial class RepresRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string Aname = name.Text;
            string Club = Cname.Text;
            string user = username.Text;
            string pass = password.Text;



            SqlCommand check = new SqlCommand("checkUsername", conn);
            check.CommandType = System.Data.CommandType.StoredProcedure;
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("@user", user));
            SqlParameter flag = check.Parameters.Add("@flag", SqlDbType.Int);
            flag.Direction = ParameterDirection.Output;
            conn.Open();
            check.ExecuteNonQuery();
            conn.Close();

            SqlCommand checkC = new SqlCommand("checkClub", conn);
            checkC.CommandType = System.Data.CommandType.StoredProcedure;
            checkC.CommandType = CommandType.StoredProcedure;
            checkC.Parameters.Add(new SqlParameter("@CName", Club));
            SqlParameter flagC = checkC.Parameters.Add("@flag", SqlDbType.Int);
            flagC.Direction = ParameterDirection.Output;
            conn.Open();
            checkC.ExecuteNonQuery();
            conn.Close();

            if (Aname!="" && Club!="" && user!="" && pass!="")
            {
                if (flag.Value.ToString() == "1")
                {
                    if (flagC.Value.ToString() == "1")
                    {
                        SqlCommand addFunc = new SqlCommand("addRepresentative", conn);
                        addFunc.CommandType = System.Data.CommandType.StoredProcedure;
                        addFunc.Parameters.Add(new SqlParameter("@repName", Aname));
                        addFunc.Parameters.Add(new SqlParameter("@CName", Club));
                        addFunc.Parameters.Add(new SqlParameter("@username", user));
                        addFunc.Parameters.Add(new SqlParameter("@password", pass));

                        conn.Open();
                        addFunc.ExecuteNonQuery();
                        conn.Close();
                        Response.Redirect("FormStart.aspx");
                    }
                    else
                        Response.Write("<script>alert('Please enter a valid club name !!! ')</script>");

                    //Response.Write("Please enter a valid club name");

                }
                else
                    Response.Write("<script>alert('Username already taken. Please choose another one!!! ')</script>");

                //Response.Write("Username already taken. Please choose another one");
            }
            else
            {
                Response.Write("<script>alert('Please Fill All Fields!!! ')</script>");
            }



        }
    }
}