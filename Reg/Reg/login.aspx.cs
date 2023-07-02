using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data;
using System.Configuration;
//using System.Data.OracleClient.OracleException;



namespace Reg
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string mobile = txtMobile.Text;
            string sex = ddlSex.Text;
            string dob = txtDateOfBirth.Text;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO customer (USERNAME, PASSWORD, MOBILE, SEX, DOB) VALUES (:username, :password, :mobile, :sex, :dob)";
                    OracleCommand cmd = new OracleCommand(sql, con);
                    cmd.Parameters.Add(new OracleParameter("USERNAME", username));
                    cmd.Parameters.Add(new OracleParameter("PASSWORD", password));
                    cmd.Parameters.Add(new OracleParameter("MOBILE", mobile));
                    cmd.Parameters.Add(new OracleParameter("SEX", sex));
                    cmd.Parameters.Add(new OracleParameter("DOB", dob));
                    int db = cmd.ExecuteNonQuery();

                    if (db == 1)
                    {
                        Response.Write("Record Successfully Inserted: ");
                    }
                    else
                    {
                        Response.Write("Not Inserted: ");

                    }


                    txtUserName.Text = string.Empty;
                    txtPassword.Text = string.Empty;
                    txtMobile.Text = string.Empty; 
                    ddlSex.ClearSelection();
                    txtDateOfBirth.Text = string.Empty;

                    con.Close();
                   
                }
                catch (Exception ex)
                {
                    
                    Response.Write("Not Connected......!" + ex.Message);
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string mobile = txtMobile.Text;
            string sex = ddlSex.Text;
            string dob = txtDateOfBirth.Text;

            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                try
                {
                    con.Open();
                    string sql = "UPDATE customer SET PASSWORD = :password, MOBILE = :mobile, SEX = :sex, DOB = :dob WHERE USERNAME = :username";
                    OracleCommand cmd = new OracleCommand(sql, con);
                    cmd.Parameters.Add(new OracleParameter("USERNAME", username));
                    cmd.Parameters.Add(new OracleParameter("PASSWORD", password));
                    cmd.Parameters.Add(new OracleParameter("MOBILE", mobile));
                    cmd.Parameters.Add(new OracleParameter("SEX", sex));
                    cmd.Parameters.Add(new OracleParameter("DOB", dob));
                    cmd.ExecuteNonQuery();

                    Response.Write("Record Succesfully Updated: ");
                    con.Close();

                }
                catch (Exception ex)
                {

                    Response.Write("Error......!" + ex.Message);
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            
            using (OracleConnection con = new OracleConnection(ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString))
            {
                try
                {
                    con.Open();
                    string sql = "DELETE FROM customer WHERE USERNAME = (:username)";
                    OracleCommand cmd = new OracleCommand(sql, con);
                    cmd.Parameters.Add(new OracleParameter("USERNAME", username));
                    cmd.ExecuteNonQuery();

                    Response.Write("Record Deleted Inserted: ");
                    con.Close();

                }
                catch (Exception ex)
                {

                    Response.Write("Error......!" + ex.Message);
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;
            string query = "SELECT * FROM customer WHERE USERNAME = :username";

            OracleConnection connection = new OracleConnection(connectionString);


            OracleCommand command = new OracleCommand();
            command.CommandText = query;
            command.Connection = connection;

            OracleDataAdapter adapter = new OracleDataAdapter();
            adapter.SelectCommand = command;
            DataSet dataTable = new DataSet();
            adapter.Fill(dataTable);


            if (dataTable.Tables[0].Rows.Count > 0)
            {
                txtPassword.Text = dataTable.Tables[0].Rows[0]["PASSWORD"].ToString();
                txtMobile.Text = dataTable.Tables[0].Rows[0]["MOBILE"].ToString();
                ddlSex.SelectedValue = dataTable.Tables[0].Rows[0]["SEX"].ToString();
                txtDateOfBirth.Text = dataTable.Tables[0].Rows[0]["DOB"].ToString();

            }
            else
            {
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtMobile.Text = string.Empty;
                ddlSex.ClearSelection();
                txtDateOfBirth.Text = string.Empty;
            }
        }
        
    }
}