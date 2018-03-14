// <snippet2>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class WizardStepCollectioncs_aspx : System.Web.UI.Page
{ 

    void Page_Load(object sender, EventArgs e)
    {
        // Programmatically create a wizard control.
        Wizard Wizard1 = new Wizard();

        // Create steps for the wizard control and insert them
        // into the WizardStepCollection collection.
        for (int i = 0; i <= 5; i++)
        {
            WizardStepBase newStep = new WizardStep();
            newStep.ID = "Step" + (i + 1).ToString();
            newStep.Title = "Step " + (i + 1).ToString();
            Wizard1.WizardSteps.Add(newStep);
        }

        // Display the wizard control on the Web page.
        PlaceHolder1.Controls.Add(Wizard1);
    }
    
}
// </snippet2>
