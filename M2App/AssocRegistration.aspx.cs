using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M2App
{
    public partial class AssocRegistration : System.Web.UI.Page
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



            SqlCommand check = new SqlCommand("checkUsername", conn);
            check.CommandType = System.Data.CommandType.StoredProcedure;
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("@user", user));
            SqlParameter flag = check.Parameters.Add("@flag", SqlDbType.Int);
            flag.Direction = ParameterDirection.Output;
            conn.Open();
            check.ExecuteNonQuery();
            conn.Close();

            if (Aname != "" && user != "" && pass != "")
            {
                if (flag.Value.ToString() == "1")
                {
                    SqlCommand addAssocProc = new SqlCommand("addAssociationManager", conn);
                    addAssocProc.CommandType = System.Data.CommandType.StoredProcedure;
                    addAssocProc.Parameters.Add(new SqlParameter("@name", Aname));
                    addAssocProc.Parameters.Add(new SqlParameter("@username", user));
                    addAssocProc.Parameters.Add(new SqlParameter("@password", pass));

                    conn.Open();
                    addAssocProc.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("FormStart.aspx");
                }
                else
                    Response.Write("<script>alert('Username already taken. Please choose another one')</script>");

                // Response.Write("Username already taken. Please choose another one");
            }
            else
                Response.Write("<script>alert('PLEASE FILL ALL FIELDS!!')</script>");



        }
    }
}