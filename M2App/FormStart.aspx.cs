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
    public partial class FormStart : System.Web.UI.Page
    {
        public static string Userol = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void login(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn=new SqlConnection(connStr);

            string user = username.Text;
            string pass=password.Text;
            Userol = user;

            SqlCommand logProc = new SqlCommand("UserLogin", conn);
            logProc.CommandType = System.Data.CommandType.StoredProcedure;
            logProc.CommandType = CommandType.StoredProcedure;
            logProc.Parameters.Add(new SqlParameter("@username", user));
            logProc.Parameters.Add(new SqlParameter("@password", pass));
            SqlParameter code = logProc.Parameters.Add("@code", SqlDbType.Int);
            code.Direction = ParameterDirection.Output;
            conn.Open();
            logProc.ExecuteNonQuery();
            conn.Close();

            
            if (code.Value.ToString() == "1")
                Response.Redirect("SystemAdmin.aspx");
            else if (code.Value.ToString() == "2")
                Response.Redirect("AssociationRegistration.aspx");
            else if (code.Value.ToString() == "3")
                Response.Redirect("Representative.aspx");
            else if (code.Value.ToString() == "4")
                Response.Redirect("Fan.aspx");
            else if (code.Value.ToString() == "5")
                Response.Redirect("StadiumManager.aspx");
           

            else
                Response.Write("<script>alert('PLEASE WRITE A VALID USERNAME AND PASSWORD !!! ')</script>");
            // Response.Write("PLEASE ENTER A VALID USERNAME AND PASSWORD!!!");



        }

        protected void AssocReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssocRegistration.aspx");
        }

        protected void RepresReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("RepresRegistration.aspx");
        }

        protected void StMgrReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("StMgrRegistration.aspx");
        }

        protected void FanReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("FanRegistration.aspx");
        }
    }
}