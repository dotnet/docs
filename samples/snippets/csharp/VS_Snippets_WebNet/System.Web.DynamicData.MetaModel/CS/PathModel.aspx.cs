// <Snippet2>
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Web.DynamicData;

public partial class PathModel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DynamicDataManager1.RegisterControl(GridDataSource1);
    }

    // <Snippet22>
    // Get the data model. 
    public MetaModel GetModel(bool defaultModel)
    {
        MetaModel model;

        if (defaultModel)
            model = MetaModel.Default;
        else
            model =
               MetaModel.GetModel(typeof(AdventureWorksLTDataContext));
        return model;
    }
    // </Snippet22>

    // <Snippet23>
    // Get the registered action path.
    public string EvaluateActionPath()
    {
        string tableName = LinqDataSource1.TableName;
        
        MetaModel model = GetModel(false);

        string actionPath =
            model.GetActionPath(tableName,
                System.Web.DynamicData.PageAction.List, GetDataItem());
        return actionPath;
    }
    // </Snippet23>
}
// </Snippet2>