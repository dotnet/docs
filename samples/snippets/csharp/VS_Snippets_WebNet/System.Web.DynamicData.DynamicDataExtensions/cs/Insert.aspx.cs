// Source: C:\_ricka08\code\DD\Snippet\DynamicControlParameter\cs_DynamicControlParameter\DynamicData\CustomPages\ProductDescriptions\Insert.aspx.cs
// C:\sdtree\Orcas\Web.NET\System.Web.DynamicData.DynamicDataExtensions\cs
// <snippet1>
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Web.DynamicData;

public partial class Insert : System.Web.UI.Page {
    protected MetaTable table;

    protected void Page_Init(object sender, EventArgs e) {
        DynamicDataManager1.RegisterControl(DetailsView1);
    }

    protected void Page_Load(object sender, EventArgs e) {
        table = DetailsDataSource.GetTable();
        Title = table.DisplayName;
    }

    protected void DetailsView1_DataBound(object sender, EventArgs e) {

        var dsc = DetailsView1.FindDataSourceControl() as LinqDataSource;
        if (dsc == null || dsc.EnableInsert != true)
            return;

        var mTbl = DetailsView1.FindMetaTable() as MetaTable;
        if (mTbl != null)
            LblMetaTbl.Text = "Column count = " + mTbl.Columns.Count.ToString();


        var fldTmpUsrCtl = DetailsView1.FindFieldTemplate("Description") as FieldTemplateUserControl;
        if (fldTmpUsrCtl != null) {
            var entryFldDescript = fldTmpUsrCtl.DataControl as TextBox;
            entryFldDescript.Text = "(Enter short Description here.)";
        }

        var fldTmpUsrCtl2 = DetailsView1.FindFieldTemplate("ModifiedDate") as FieldTemplateUserControl;
        if (fldTmpUsrCtl2 != null) {
            var entryFldModDate = fldTmpUsrCtl2.DataControl as TextBox;
            entryFldModDate.Text = System.DateTime.Now.Date.ToShortDateString();
        }
    }

    protected void DetailsView1_ItemCommand(object sender, DetailsViewCommandEventArgs e) {
        if (e.CommandName == DataControlCommands.CancelCommandName) {
            Response.Redirect(table.ListActionPath);
        }
    }

    protected void DetailsView1_ItemInserted(object sender, DetailsViewInsertedEventArgs e) {
        if (e.Exception == null) {
            Response.Redirect(table.ListActionPath);
        }
    }
}
// </snippet1>