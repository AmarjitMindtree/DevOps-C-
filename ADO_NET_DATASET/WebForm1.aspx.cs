using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADO_NET_DATASET
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("spGetDataFromTwoTable", con);
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                GridView1.DataSource = dataSet.Tables[0];
                GridView1.DataBind();

                GridView2.DataSource = dataSet.Tables[1];
                GridView2.DataBind();
            }
        }
    }
}