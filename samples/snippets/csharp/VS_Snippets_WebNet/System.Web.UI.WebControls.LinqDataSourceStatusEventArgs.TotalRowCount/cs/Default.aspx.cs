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

    // <Snippet2>
    protected void LinqDataSource1_Selected(object sender, LinqDataSourceStatusEventArgs e)
    {
        Literal1.Text = e.TotalRowCount.ToString();
    }
    // </Snippet2>
}
