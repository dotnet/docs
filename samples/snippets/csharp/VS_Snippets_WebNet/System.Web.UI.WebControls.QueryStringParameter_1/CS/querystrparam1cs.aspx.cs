using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class querystrparam1cs_aspx : System.Web.UI.Page
{
    private void Page_Load(object sender, System.EventArgs e)
    {

// <snippet2>
        QueryStringParameter empIdParam = new QueryStringParameter();
        empIdParam.Name = "empId";
        empIdParam.QueryStringField = "empId";

        AccessDataSource1.SelectParameters.Add(empIdParam);
// </snippet2>

// <snippet4>
        MyAccessDataSource.SelectParameters.Add(new QueryStringParameter("employee", "employee"));
// </snippet4>

    }
}
