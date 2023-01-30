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
using System.Xml.Linq;

namespace M2App
{
    public partial class StadiumManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
                // connection string  
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand com = new SqlCommand("select req.Id RId, h.Name Host, g.Name Guest, mtch.start_time Starts from StadiumManager m inner join HostRequest req on m.Id=req.manager_Id inner join ClubRepresentative rep on req.representative_Id=rep.Id inner join Club h  on rep.Club_Id=h.club_Id inner join Match mtch on req.match_Id=mtch.match_Id inner join Club g on mtch.guest_club_Id=g.club_Id inner join Stadium st on m.Stadium_Id= st.Id where @use=m.username and req.Status is null", con);
                com.Parameters.Add(new SqlParameter("@use", FormStart.Userol));

                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                DropDownList1.DataValueField = "RId";
                ds.Tables[0].Columns.Add("MatchInfo", typeof(string), "'Host: '+ Host+ 'Guest: '+ Guest + ' Starts: '+ Starts");
                DropDownList1.DataTextField = "MatchInfo";
                DropDownList1.DataSource = ds;      //assigning datasource to the dropdownlist

                DropDownList1.DataBind();
            }
            
        }

        protected void Button3_Click(object sender, EventArgs e)
        {


            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string Rid = DropDownList1.SelectedItem.Value;



            SqlCommand addFunc = new SqlCommand("acceptReq2", conn);
            addFunc.CommandType = System.Data.CommandType.StoredProcedure;
            addFunc.Parameters.Add(new SqlParameter("@RId", Rid));


            conn.Open();
            addFunc.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("StadiumManager.aspx");


        }

        protected void Button4_Click(object sender, EventArgs e)
        {


            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string Rid = DropDownList1.SelectedItem.Value;



            SqlCommand addFunc = new SqlCommand("rejectReq2", conn);
            addFunc.CommandType = System.Data.CommandType.StoredProcedure;
            addFunc.Parameters.Add(new SqlParameter("@RId", Rid));


            conn.Open();
            addFunc.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("StadiumManager.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();

            SqlConnection con = new SqlConnection(strcon);

            SqlCommand stadiumId = new SqlCommand("SELECT s.Stadium_Id FROM StadiumManager s WHERE s.username = @user", con);


            stadiumId.Parameters.Add(new SqlParameter("@user", FormStart.Userol));

            con.Open();

            SqlDataReader reader1 = stadiumId.ExecuteReader();
            reader1.Read();
            int var = reader1.GetInt32(0);
            reader1.Close();

            SqlCommand stinfo = new SqlCommand("SELECT * FROM Stadium st where st.Id = @sid", con);

            stinfo.Parameters.Add(new SqlParameter("@sid", var));

            reader1.Close();

            SqlDataReader reader2 = stinfo.ExecuteReader();

            using (con)
            {

                DataTable dtb1 = new DataTable();

                dtb1.Load(reader2);

                sinfo.DataSource = dtb1;

                sinfo.DataBind();
            }
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string strcon = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();

            SqlConnection con = new SqlConnection(strcon);

            SqlCommand sId = new SqlCommand("SELECT s.Stadium_Id FROM StadiumManager s WHERE s.username = @user", con);


            sId.Parameters.Add(new SqlParameter("@user", FormStart.Userol));

            con.Open();

            SqlDataReader reader1 = sId.ExecuteReader();
            reader1.Read();
            int var = reader1.GetInt32(0);
            reader1.Close();

            SqlCommand Info = new SqlCommand("select cr.Name, c.Name Host, gu.Name Guest,sm.start_time, sm.end_time, r.Status  from HostRequest r  left outer join StadiumManager m on m.Id=r.manager_Id inner join ClubRepresentative cr  on r.representative_Id=cr.Id inner join Club c  on cr.Club_Id=c.club_Id inner join Match sm  on r.match_Id=sm.match_Id inner join Club gu  on sm.guest_club_Id=gu.club_Id  where  m.Stadium_Id = @x ", con);

            Info.Parameters.Add(new SqlParameter("@x", var));

            SqlDataReader reader2 = Info.ExecuteReader();

            using (con)
            {

                DataTable dtb1 = new DataTable();

                dtb1.Load(reader2);

                vrequest.DataSource = dtb1;

                vrequest.DataBind();
            }
            con.Close();
        }
    }
}
