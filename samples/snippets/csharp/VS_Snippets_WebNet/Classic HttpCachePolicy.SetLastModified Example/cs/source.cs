using System;
using System.Web;
using System.Web.UI;

public class Page1 : Page
{
        protected void Page_Load(object sender, EventArgs e)
        {
                // <Snippet1>
                Response.Cache.SetLastModified(DateTime.Parse("1/1/2001 00:00:01AM"));
                // </Snippet1>
        }
}

