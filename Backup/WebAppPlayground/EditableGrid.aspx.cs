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
            if (!Page.IsPostBack)
            {
                DataTable dtCategories = new DataTable();
                getCategories(out dtCategories);
                dtCategories.Columns["CategoryID"].ReadOnly = true;


                grdEditableGrid.DataSource = dtCategories;
                grdEditableGrid.DataBind();
            }
            
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

                    dtCategories.Columns["CategoryID"].ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return dtCategories;
        }

        private DataTable getDirtyRows()
        {
            DataTable dtDirtyRows = new DataTable();            

            dtDirtyRows.Columns.Add("CategoryID");

            foreach (GridViewRow item in grdEditableGrid.Rows)
            {
                HiddenField editStatus = item.FindControl("hdnEditStatus") as HiddenField;
                if (editStatus != null)
                {
                    if (editStatus.Value == "true")
                    {
                        var lblCategoryID = item.FindControl("lblCategoryID") as Label;
                        if (lblCategoryID != null)
                        {
                            DataRow dr = dtDirtyRows.Rows.Add();
                            dr["CategoryID"] = lblCategoryID.Text;
                        }
                    }
                }
            }

            return dtDirtyRows;
        }

        protected void grdEditableGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            TextBox categoryName = e.Row.FindControl("txtCategoryName") as TextBox;
            if (categoryName != null)
            {
                categoryName.Attributes.Add("onkeyup", "updateEditStatus(\"" + e.Row.FindControl("hdnEditStatus").ClientID + "\");");
            }           

            TextBox description = e.Row.FindControl("txtDescription") as TextBox;
            if (description != null)
            {
                description.Attributes.Add("onkeyup", "updateEditStatus(\"" + e.Row.FindControl("hdnEditStatus").ClientID + "\");");
            }
        }

        protected void btnSaveData_Click(object sender, EventArgs e)
        {
            getDirtyRows();
        }
    }
}