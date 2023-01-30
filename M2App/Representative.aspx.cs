using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M2App
{
    public partial class Representative : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string constr = ConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
                // connection string  
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand com = new SqlCommand(" select m.start_time Starts, g.Name Guest from ClubRepresentative rep inner join Club c on rep.Club_Id=c.club_Id inner join Match m on m.host_club_Id=c.club_Id inner join Club g on m.guest_club_Id=g.club_Id where rep.username=@use and current_Timestamp < m.start_time ", con);
                com.Parameters.Add(new SqlParameter("@use", FormStart.Userol));

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                DropDownList1.DataValueField = "Starts";
                ds.Tables[0].Columns.Add("MatchInfo", typeof(string), " 'Guest: '+ Guest + ' Starts: '+ Starts");
                DropDownList1.DataTextField = "MatchInfo";
                DropDownList1.DataSource = ds;      //assigning datasource to the dropdownlist

                DropDownList1.DataBind();


                SqlCommand com2 = new SqlCommand("select * from Stadium", con);
                // table name   
                SqlDataAdapter da2 = new SqlDataAdapter(com2);
                DataSet ds2 = new DataSet();
                da2.Fill(ds2);  // fill dataset  
                DropDownList2.DataTextField = ds2.Tables[0].Columns["Name"].ToString(); // text field name of table dispalyed in dropdown       
                DropDownList2.DataValueField = ds2.Tables[0].Columns["Name"].ToString();
                // to retrive specific  textfield name   
                DropDownList2.DataSource = ds2.Tables[0];      //assigning datasource to the dropdownlist

                DropDownList2.DataBind();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string SName = DropDownList2.SelectedItem.Value;
            string Time = DropDownList1.SelectedItem.Value;
            SqlCommand comm1 = new SqlCommand("select c.Name from ClubRepresentative r inner join Club c on r.Club_Id=c.Club_Id where r.username=@use", conn);
            comm1.Parameters.Add(new SqlParameter("@use", FormStart.Userol));
           
            SqlCommand addFunc = new SqlCommand("addHostRequest", conn);
            addFunc.CommandType = System.Data.CommandType.StoredProcedure;
            addFunc.Parameters.Add(new SqlParameter("@SName", SName));
            addFunc.Parameters.Add(new SqlParameter("@matchtime", Time));

            conn.Open();
            SqlDataReader reader= comm1.ExecuteReader();
            reader.Read();
            string ClubName = reader.GetString(0);
            addFunc.Parameters.Add(new SqlParameter("@CName", ClubName));
            reader.Close();
            addFunc.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Representative.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.SelectedValue = DropDownList1.SelectedItem.Value;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.SelectedValue = DropDownList2.SelectedItem.Value;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();

            SqlConnection con = new SqlConnection(strcon);

            SqlCommand clubId = new SqlCommand("SELECT cr.Club_Id FROM ClubRepresentative Cr WHERE cr.username = @user", con);


            clubId.Parameters.Add(new SqlParameter("@user", FormStart.Userol));

            con.Open();

            SqlDataReader reader1 = clubId.ExecuteReader();
            reader1.Read();
            int var = reader1.GetInt32(0);
            reader1.Close();

            SqlCommand clubInfo = new SqlCommand("SELECT * FROM Club c where c.Club_Id = @cid", con);

            clubInfo.Parameters.Add(new SqlParameter("@cid", var));

            reader1.Close();

            SqlDataReader reader2 = clubInfo.ExecuteReader();

            using (con)
            {

                DataTable dtb1 = new DataTable();

                dtb1.Load(reader2);

                cinfo.DataSource = dtb1;

                cinfo.DataBind();
            }
            con.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();

            SqlConnection con = new SqlConnection(strcon);

            SqlCommand clubId = new SqlCommand("SELECT cr.Club_Id FROM ClubRepresentative Cr WHERE cr.username = @user", con);


            clubId.Parameters.Add(new SqlParameter("@user", FormStart.Userol));

            con.Open();

            SqlDataReader reader1 = clubId.ExecuteReader();
            reader1.Read();
            int var = reader1.GetInt32(0);
            reader1.Close();

            SqlCommand matchInfo = new SqlCommand("SELECT c1.Name  as HostName, c2.Name as GuestName, m.start_time, m.end_time , st.Name as StadiumName FROM Match m inner join Club c1 on(m.host_club_Id=c1.club_Id) inner join Club c2 on (m.guest_club_Id = c2.club_Id) left outer join Stadium st on(st.Id=m.stadium_Id ) where m.host_club_Id = @cid or m.guest_club_Id = @cid ", con);

            matchInfo.Parameters.Add(new SqlParameter("@cid", var));

            SqlDataReader reader2 = matchInfo.ExecuteReader();

            using (con)
            {

                DataTable dtb1 = new DataTable();

                dtb1.Load(reader2);

                cmatch.DataSource = dtb1;

                cmatch.DataBind();
            }
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();

            SqlConnection con = new SqlConnection(strcon);

            SqlCommand clubId = new SqlCommand("SELECT cr.Club_Id FROM ClubRepresentative Cr WHERE cr.username = @user", con);


            clubId.Parameters.Add(new SqlParameter("@user", FormStart.Userol));

            con.Open();

            SqlDataReader reader1 = clubId.ExecuteReader();
            reader1.Read();
            int var = reader1.GetInt32(0);
            reader1.Close();

            SqlCommand Info = new SqlCommand("select s.Name , s.Location , s.capacity from Stadium s left outer join Match sp on ( sp.stadium_Id = s.Id) where s.Status = 1 AND (@x <> sp.start_time or sp.start_time is null)", con);
            string datetime = date.Text + " " + date2.Text;


            Info.Parameters.Add(new SqlParameter("@x", datetime));

            SqlDataReader reader2 = Info.ExecuteReader();

            using (con)
            {

                DataTable dtb1 = new DataTable();

                dtb1.Load(reader2);

                vstadium.DataSource = dtb1;

                vstadium.DataBind();
            }
            con.Close();
        }
    }
}