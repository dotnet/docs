//<Snippet2>
using System;
using System.IO;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
//using Examples.WebNet;

namespace Examples.WebNet
{
    // Create a class that extends CreateUserWizard and uses
    // MyCreateUserWizardDesigner as its designer.

    [Designer(typeof(Examples.WebNet.MyCreateUserWizardDesigner))]
    public class MyCreateUserWizard : CreateUserWizard
    {
    }
}
//</Snippet2>
