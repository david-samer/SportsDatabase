using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace M2App
{
    public partial class SystemAdmin : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
              if (!IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
                // connection string  
                SqlConnection con = new SqlConnection(constr);
                con.Open();

                SqlCommand com = new SqlCommand("select * from Club", con);
                // table name   
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                DropDownList1.DataTextField = ds.Tables[0].Columns["Name"].ToString(); // text field name of table dispalyed in dropdown       
                DropDownList1.DataValueField = ds.Tables[0].Columns["Name"].ToString();
                // to retrive specific  textfield name   
                DropDownList1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist

                DropDownList1.DataBind();

                //////
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

        protected void Button1_Click(object sender, EventArgs e)
        {


            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string Aname = AddClub.Text;
            string Loc = Location.Text;


            SqlCommand comm1 = new SqlCommand("select * from Club where Name=@name", conn);
            comm1.Parameters.Add(new SqlParameter("@name", Aname));
            conn.Open();
            SqlDataReader reader = comm1.ExecuteReader();
            if (!reader.HasRows && Aname!="")
            {
                conn.Close();
                SqlCommand addFunc = new SqlCommand("addClub", conn);
                addFunc.CommandType = System.Data.CommandType.StoredProcedure;
                addFunc.Parameters.Add(new SqlParameter("@cname", Aname));
                addFunc.Parameters.Add(new SqlParameter("@loc", Loc));

                conn.Open();
                addFunc.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("SystemAdmin.aspx");
            }
            else
            {
                Response.Write("<script>alert('Club Name Not Valid')</script>");

                //Response.Write("Club Name Not Valid!!");
            }
               
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string Cname = DropDownList1.SelectedItem.Value;

            try
            {
                SqlCommand addFunc = new SqlCommand("deleteClub", conn);
                addFunc.CommandType = System.Data.CommandType.StoredProcedure;
                addFunc.Parameters.Add(new SqlParameter("@Name", Cname));
                conn.Open();
                addFunc.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("SystemAdmin.aspx");
            }
            catch(Exception err)
            {
                Response.Redirect("SystemAdmin.aspx");
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string sname = AddStad.Text;
            string loc = StadLoc.Text;

            if (sname!="" && loc!="" && Capacity.Text!="")
            {
                int Cap = Int16.Parse(Capacity.Text);

                SqlCommand addFunc = new SqlCommand("addStadium", conn);
                addFunc.CommandType = System.Data.CommandType.StoredProcedure;
                addFunc.Parameters.Add(new SqlParameter("@Name", sname));
                addFunc.Parameters.Add(new SqlParameter("@Location", loc));
                addFunc.Parameters.Add(new SqlParameter("@Capacity", Cap));

                conn.Open();
                addFunc.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("SystemAdmin.aspx");
            }
            else
                Response.Write("<script>alert('PLEASE FILL ALL FIELDS BEFORE ADDING')</script>");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string dname = DropDownList2.SelectedItem.Value;


            SqlCommand addFunc = new SqlCommand("deleteStadium", conn);
            addFunc.CommandType = System.Data.CommandType.StoredProcedure;
            addFunc.Parameters.Add(new SqlParameter("@Name", dname));


            conn.Open();
            addFunc.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("SystemAdmin.aspx");

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["Milestone_2"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            string natid =BlockFan.Text;

            SqlCommand check = new SqlCommand("checkNatId", conn);
            
            check.CommandType = System.Data.CommandType.StoredProcedure;
            check.CommandType = CommandType.StoredProcedure;
            check.Parameters.Add(new SqlParameter("@natId", natid) ); 
            SqlParameter flag = check.Parameters.Add("@flag", SqlDbType.Int);
            flag.Direction = ParameterDirection.Output;
            conn.Open();
            check.ExecuteNonQuery();
            conn.Close();
            if (flag.Value.ToString() == "1")
            {
                SqlCommand addFunc = new SqlCommand("blockFan", conn);
                addFunc.CommandType = System.Data.CommandType.StoredProcedure;
                addFunc.Parameters.Add(new SqlParameter("@natID", natid));


                conn.Open();
                addFunc.ExecuteNonQuery();
                conn.Close();
            }
            else
                Response.Write("<script>alert('Invalid National ID!!! ')</script>");

           // Response.Write("Invalid National ID");


            
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList1.SelectedValue = DropDownList1.SelectedItem.Value;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList2.SelectedValue = DropDownList2.SelectedItem.Value;

        }
    }
    }
