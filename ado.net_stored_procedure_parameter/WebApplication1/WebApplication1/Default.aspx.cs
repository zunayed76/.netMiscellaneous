using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Connection string captured from web.config
            //string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            //// new connection object
            //SqlConnection con = new SqlConnection(CS);
            //try
            //{
            //    SqlCommand cmd = new SqlCommand("select count(*) from CmnBank", con);  // new sqlcommand(the command to be executed, connection object con)
            //    con.Open(); //opens the connection to sql server
            //    int totalRows = (int)cmd.ExecuteScalar();  // execute the command and retrieve data from database
            //    Response.Write("Total rows are: " + totalRows.ToString());
            //    //GridView1.DataSource = rdr;
            //    //GridView1.DataBind();
            //}
            //catch(Exception eee)
            //{

            //}
            //finally
            //{
            //    con.Close();
            //}


            //////////////SqlConnection con = new SqlConnection()
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //Read the connection string from Web.Config file
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                //Create the SqlCommand object
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                //Specify that the SqlCommand is a stored procedure
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //Add the input parameters to the command object
                cmd.Parameters.AddWithValue("@Name", txtEmployeeName.Text);  //txtEmployeeName is id of the textbox
                cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@Salary", txtSalary.Text);
                //cmd.Parameters.AddWithValue("@Employee", txtEmployeeName.Text); 




                //Add the output parameter to the command object
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@EmployeeId";   //name of the output parameter in stored procedure
                outPutParameter.SqlDbType = System.Data.SqlDbType.Int;  // data type of @EmployeeID
                outPutParameter.Direction = System.Data.ParameterDirection.Output;  //direction of the parameter is output
                cmd.Parameters.Add(outPutParameter);

                //Open the connection and execute the query
                con.Open();
                cmd.ExecuteNonQuery();

                //Retrieve the value of the output parameter
                string EmployeeId = outPutParameter.Value.ToString();
                lblMessage.Text = "Employee Id = " + EmployeeId;
            }
        }

    }       
}




    //code for procedure
//Create Procedure spAddEmployee  
//@Name nvarchar(50),  
//@Gender nvarchar(20),  
//@Salary int,  
//@EmployeeId int Out  
//as  
//Begin  
// Insert into tblEmployees values(@Name, @Gender, @Salary)  
// Select @EmployeeId = SCOPE_IDENTITY()  
//End