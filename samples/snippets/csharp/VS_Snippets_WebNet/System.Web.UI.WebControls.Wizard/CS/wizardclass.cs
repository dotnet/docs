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

public partial class WizardClasscs_aspx : System.Web.UI.Page
{
    protected void OnFinishButtonClick(Object sender, WizardNavigationEventArgs e)
    {
        // The OnFinishButtonClick method is a good place to collect all
        // the data from the completed pages and persist it to the data store. 

        // For this example, write a confirmation message to the Complete page
        // of the Wizard control.
        Label tempLabel = (Label)Wizard1.FindControl("CompleteMessageLabel");
        if (tempLabel != null)
        {
            tempLabel.Text = "Your order has been placed. An e-mail confirmation will be sent to "
            + (EmailAddress.Text.Length == 0 ? "your e-mail address" : EmailAddress.Text) + ".";
        }
    }

    protected void OnGoBackButtonClick(object sender, EventArgs e)
    {
        // The GoBackButtonClick event is raised when the GoBackButton
        // is clicked on the Finish page of the Wizard.  

        // Check the value of Step1's AllowReturn property.
        if (Step1.AllowReturn)
        {
            // Return to Step1.
            Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(this.Step1);
        }
        else
        {
            // Step1 is not a valid step to return to; go to Step2 instead.
            Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(this.Step2);
            Response.Write("ActiveStep is set to Step2 because Step1 has AllowReturn set to false.");
        }
    }

    protected void OnActiveStepChanged(object sender, EventArgs e)
    {
        // If the ActiveStep is changing to Step3, check to see whether the 
        // SeparateShippingCheckBox is selected.  If it is not, skip to the
        // Finish step.
        if (Wizard1.ActiveStepIndex == Wizard1.WizardSteps.IndexOf(this.Step3))
        {
            if (this.SeparateShippingCheckBox.Checked)
            {
                Wizard1.MoveTo(this.Step3);
            }
            else
            {
                Wizard1.MoveTo(this.Finish);
            }
        }
    }
}
// </snippet2>
