using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication1
{
    public partial class EditableGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtCategories = new DataTable(); 
            getCategories(out dtCategories);

            grdEditableGrid.DataSource = dtCategories;
            grdEditableGrid.DataBind();
        }

        private DataTable getCategories(out DataTable dtCategories)
        {
            dtCategories = new DataTable();
            try
            {
                using (SqlConnection nwndConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString))
                {
                    SqlCommand cmdCategories = new SqlCommand();
                    cmdCategories.Connection = nwndConnection;
                    cmdCategories.CommandText = "SELECT * FROM CATEGORIES";
                    cmdCategories.CommandType = System.Data.CommandType.Text;

                    nwndConnection.Open();                    
                    dtCategories.Load(cmdCategories.ExecuteReader());
                    nwndConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return dtCategories;
        }
    }
}