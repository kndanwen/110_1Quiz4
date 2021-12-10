using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace _110_1Quiz4
{
    public partial class Quiz4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s_Connstr = "Data Source = (localdb)\\ProjectsV13;" +
                              "Initial Catalog = Text; Integrated Security = True;" +
                              "Connect Timeout = 30; Encrypt = False;" +
                              "TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False;" +
                              "User ID = sa;Password = 12345;";
            try
            {
                SqlConnection o_SQLCon = new SqlConnection(s_Connstr);

                SqlCommand o_SQLCom = new SqlCommand("Select * from Users", o_SQLCon);
                o_SQLCon.Open();
                SqlDataReader o_R = o_SQLCom.ExecuteReader();
                for (; o_R.Read();)
                {
                    for (int i_col = 0; i_col < o_R.FieldCount; i_col++)
                    {
                        Response.Write("&nbsp;&nbsp;" + o_R[i_col].ToString());
                    }
                    Response.Write("<br />");
                }
                Response.Write("Success");
                o_SQLCon.Close();
            }
            catch (Exception o_Ex)
            {
                Response.Write(o_Ex.ToString());
            }
        }
    }
}