using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=ZUNAYED-AMBER-D;Initial Catalog=[redacted database name];Integrated Security=True"); 
            // new connection object 
            SqlCommand cmd = new SqlCommand("select * from redacted Tablename]", con);  // new sqlcommand(the command to be executed, connection object con)
            con.Open(); //opens the connection to sql server
            SqlDataReader rdr = cmd.ExecuteReader();  // execute the command and retrieve data from database
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            con.Close();
        }
    }
}