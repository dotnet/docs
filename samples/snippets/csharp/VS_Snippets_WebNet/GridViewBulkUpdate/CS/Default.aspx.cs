//<Snippet6>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //<Snippet1>
    private bool tableCopied = false;
    private System.Data.DataTable originalDataTable;

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
            if (!tableCopied)
            {
                originalDataTable = ((System.Data.DataRowView)e.Row.DataItem).Row.Table.Copy();
                ViewState["originalValuesDataTable"] = originalDataTable;
                tableCopied = true;
            }
    }
    //</Snippet1>

    //<Snippet2>
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        originalDataTable = (System.Data.DataTable)ViewState["originalValuesDataTable"];

        foreach (GridViewRow r in GridView1.Rows)
            if (IsRowModified(r)) { GridView1.UpdateRow(r.RowIndex, false); }

        // Rebind the Grid to repopulate the original values table.
        tableCopied = false;
        GridView1.DataBind();
    }

    protected bool IsRowModified(GridViewRow r)
    {
        int currentID;
        string currentLastName;
        string currentFirstName;

        currentID = Convert.ToInt32(GridView1.DataKeys[r.RowIndex].Value);

        currentLastName = ((TextBox)r.FindControl("LastNameTextBox")).Text;
        currentFirstName = ((TextBox)r.FindControl("FirstNameTextBox")).Text;

        System.Data.DataRow row =
            originalDataTable.Select(String.Format("EmployeeID = {0}", currentID))[0];

        if (!currentLastName.Equals(row["LastName"].ToString())) { return true; }
        if (!currentFirstName.Equals(row["FirstName"].ToString())) { return true; }

        return false;
    }
    //</Snippet2>
}
//</Snippet6>