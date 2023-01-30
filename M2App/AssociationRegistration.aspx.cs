using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M2App
{
    public partial class AssociationRegistration : System.Web.UI.Page
    {
         string connectionString = @"server=(localdb)\MSSQLLocalDB;Initial Catalog=Milestone_2;Integrated Security=True ; ";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
                // connection string  
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand com = new SqlCommand("select m.match_Id MId, h.Name Host_Name, g.Name Guest_Name, m.start_time start, m.end_time ends from Match m inner join Club h on m.host_club_Id=h.club_Id inner join Club g on m.guest_club_Id=g.club_Id", con);
                // table name   
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                DropDownList1.DataValueField = "MId";
                ds.Tables[0].Columns.Add("MatchInfo", typeof(string), "'Host: ' +Host_Name + ' Guest: '+ Guest_Name + ' Starts: '+ start + ' End: ' +ends");
                DropDownList1.DataTextField = "MatchInfo";
                DropDownList1.DataSource = ds;      //assigning datasource to the dropdownlist

                DropDownList1.DataBind();
            }
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string AddH = AHost.Text;
            string AddG = AGuest.Text;
            string Astrt = AStart.Text + " " + AATime.Text;
            string ANd = AEnd.Text + " " + AAEnd.Text;


            SqlCommand comm1 = new SqlCommand("select * from Club where Name=@name", conn);
            comm1.Parameters.Add(new SqlParameter("@name", AddH));
            conn.Open();
            SqlDataReader reader= comm1.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                SqlCommand comm2 = new SqlCommand("select * from Club where Name=@name2", conn);
                comm2.Parameters.Add(new SqlParameter("@name2", AddG));
                SqlDataReader reader2 = comm2.ExecuteReader();
                if (reader2.HasRows)
                {
                    reader2.Close();
                    SqlCommand addFunc = new SqlCommand("addNewMatch", conn);
                    addFunc.CommandType = System.Data.CommandType.StoredProcedure;
                    addFunc.Parameters.Add(new SqlParameter("@hostName", AddH));
                    addFunc.Parameters.Add(new SqlParameter("@guestName", AddG));
                    addFunc.Parameters.Add(new SqlParameter("@start_time", Astrt));
                    addFunc.Parameters.Add(new SqlParameter("@endTime", ANd));

                    addFunc.ExecuteNonQuery();
                    Response.Redirect("AssociationRegistration.aspx");

                }
                else
                    Response.Write("<script>alert('Invalid Clubs Name')</script>");
                //Response.Write("Invalid Clubs Name");


            }
            else
                Response.Write("<script>alert('Invalid Clubs Name')</script>");

            //Response.Write("Invalid Clubs Name");


            conn.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            
            string M = DropDownList1.SelectedValue.ToString();
            SqlCommand addFunc = new SqlCommand("delete Match where match_Id=@Mat", conn);
            addFunc.Parameters.Add(new SqlParameter("@Mat", M));

            conn.Open();
            addFunc.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("AssociationRegistration.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(" select * from allUpcomingMatches ", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                allup.DataSource = dtbl;
                allup.DataBind();
            }

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.SelectedValue = DropDownList1.SelectedItem.Value;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(" select * from allPlayedMatches ", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                already.DataSource = dtbl;
                already.DataBind();
           
                
            }

        }

      

        protected void Button5_Click1(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(" select * from clubsNeverMatched ", sqlCon);
                DataTable dtbl = new DataTable();
                sqlDa.Fill(dtbl);
                never.DataSource = dtbl;
                never.DataBind();
            }
        }

        protected void AHost_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
