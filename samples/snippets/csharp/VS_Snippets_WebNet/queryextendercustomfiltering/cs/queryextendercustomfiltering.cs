//<Snippet2>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using System.Linq;

public partial class _Default : System.Web.UI.Page 
{
    protected void FilterProducts(object sender, CustomExpressionEventArgs e)
    {
        e.Query = from p in e.Query.Cast<Product>()
                  where p.ListPrice >= 3500
                  select p;
    }
}

//</Snippet2>
