// <Snippet2>
using System;

public partial class MyCodeBehindCS : System.Web.UI.Page
{     
    protected void Page_Load(object sender, EventArgs e)
    {

        // Place page-specific code here.


    }

    // Define a handler for the button click.
    protected void SubmitBtn_Click(object sender, EventArgs e)
    {	

        MySpan.InnerHtml = "Hello, " + MyTextBox.Text + ".";

    }
}
// </Snippet2>
