using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CircularManagementSystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connectionstring = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillData();
            }
        }
        protected void FillData()
        {
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("select EmployeeId,EmployeeName,EmployeePhoneNumber from Employee", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            EmployeeView.DataSource = dt;
            EmployeeView.DataBind();
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            int employeeId = Convert.ToInt16(EmployeeView.DataKeys[e.RowIndex].Values["EmployeeId"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Employee where @Employeeid =employeeId", con);
            cmd.Parameters.AddWithValue("@Employeeid", employeeId);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            FillData();
        }
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            EmployeeView.EditIndex = e.NewEditIndex;
            FillData();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            EmployeeView.EditIndex = -1;
            FillData();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);

            string txtEmployeename = Convert.ToString(EmployeeView.Rows[e.RowIndex].FindControl("TxtName"));
            string txtEmployeePhone = Convert.ToString(EmployeeView.Rows[e.RowIndex].FindControl("TxtPhone"));
            int id = int.Parse(EmployeeView.DataKeys[e.RowIndex].Value.ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_updatedata", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@employeeId", SqlDbType.Int).Value=id;
            cmd.Parameters.AddWithValue("@name", txtEmployeename);
            cmd.Parameters.AddWithValue("@phoneNumber", txtEmployeePhone);
            int i = cmd.ExecuteNonQuery();
            EmployeeView.EditIndex = -1;
            FillData();
            con.Close();
        }
    }
}