//<Snippet1>
using System;
using System.IO;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
//using Examples.WebNet.Design;

namespace Examples.WebNet
{
    // Create a class that extends CreateUserWizardDesigner.
    public class MyCreateUserWizardDesigner : CreateUserWizardDesigner
    {
        // This variable contains debugging information.
        private string debugInfo = "Useful information.";
        
        // Override the GetErrorDesignTimeHtml method to add some more
        // information to the error message.
        protected override string GetErrorDesignTimeHtml(Exception e)
        {
            // Get the error message from the base class.
            string html = base.GetErrorDesignTimeHtml(e);
        
            // Append the debugging information to it.
            html += "<br>" + "DebugInfo: " + debugInfo;
        
            // Return the error message.
            return html;
        }
    }
}
//</Snippet1>
