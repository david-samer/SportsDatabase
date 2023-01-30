using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace M2App
{
    public partial class Fan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand isBlocked = new SqlCommand("SELECT * FROM Fan f WHERE f.username = @user and f.Status=0", conn);
            isBlocked.Parameters.Add(new SqlParameter("@user", FormStart.Userol));

            conn.Open();
            SqlDataReader reader1 = isBlocked.ExecuteReader();
            reader1.Read();
            if (reader1.HasRows)
            {
                reader1.Close();
                Button2.Enabled = false;
                Response.Write("You are blocked from purchasing Tickets!");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string Hname = PHost.Text;
            string Gname = PGuest.Text;
            string STime = PTime.Text + " " + PPTime.Text;


            SqlCommand checkTick = new SqlCommand("checkTicket", conn);
            checkTick.CommandType = System.Data.CommandType.StoredProcedure;
            checkTick.CommandType = CommandType.StoredProcedure;
            checkTick.Parameters.Add(new SqlParameter("@hostName", Hname));
            checkTick.Parameters.Add(new SqlParameter("@guestName", Gname));
            checkTick.Parameters.Add(new SqlParameter("@startTime", STime));
            SqlParameter code = checkTick.Parameters.Add("@flag", SqlDbType.Int);
            code.Direction = ParameterDirection.Output;
            conn.Open();
            checkTick.ExecuteNonQuery();
            conn.Close();

            //SqlCommand isBlocked = new SqlCommand("SELECT * FROM Fan f WHERE f.username = @user and f.Status=0", conn);
            //isBlocked.Parameters.Add(new SqlParameter("@user", FormStart.Userol));

            //conn.Open();
            //SqlDataReader reader1 = isBlocked.ExecuteReader();
            //reader1.Read();
            //String Blocked = reader1.GetString(0);
            //reader1.Close();

            //if (reader1.HasRows)
            //{
            //    Button2.Enabled = false;
            //}

            if (code.Value.ToString() == "1")
            {
                SqlCommand addFunc = new SqlCommand("purchaseTicketUser", conn);
                addFunc.CommandType = System.Data.CommandType.StoredProcedure;
                addFunc.Parameters.Add(new SqlParameter("@hostName", Hname));
                addFunc.Parameters.Add(new SqlParameter("@guestName", Gname));
                addFunc.Parameters.Add(new SqlParameter("@startTime", STime));
                addFunc.Parameters.Add(new SqlParameter("@user", FormStart.Userol));

                conn.Open();
                addFunc.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('Purchase Successful')</script>");

            }
            else
                Response.Write("<script>alert('Ticket Info not valid!!! ')</script>");

            //Response.Write("Ticket Info not valid!!");
                
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();

            SqlConnection con = new SqlConnection(strcon);

            SqlCommand fani = new SqlCommand("SELECT f.NationalID FROM Fan f WHERE f.username = @user", con);


            fani.Parameters.Add(new SqlParameter("@user", FormStart.Userol));

            con.Open();

            SqlDataReader reader1 = fani.ExecuteReader();
            reader1.Read();
            String var = reader1.GetString(0);
            reader1.Close();

            SqlCommand minfo = new SqlCommand("select distinct c1.Name Host, c2.Name Guest, st.Name Stadium, st.Location StadiumLocation from Match s inner join Club c1 on ( c1.club_Id = s.host_club_Id) inner join Club c2 on(c2.club_Id = s.guest_club_Id) inner join Stadium st on ( st.Id = s.stadium_Id) inner join Ticket t on ( t.match_Id = s.match_Id)  where t.Status= 1   And @x < s.start_time", con);
            string datetime = fmatch.Text + " " + ffmatch.Text;
            minfo.Parameters.Add(new SqlParameter("@x", datetime));

            SqlDataReader reader2 = minfo.ExecuteReader();

            using (con)
            {

                DataTable dtb1 = new DataTable();

                dtb1.Load(reader2);

                fanm.DataSource = dtb1;

                fanm.DataBind();
            }
            con.Close();
        }


    }
}