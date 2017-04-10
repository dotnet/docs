<!-- <snippet1> -->
<%@ page language="C#"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  // This custom wizard control defines the OnSideBarButtonClick method
  // that uses the AllowNavigationToStep method to determine whether the
  // value passed in can be used to set the ActiveStepIndex property.    
  class CustomWizard : Wizard
  {    
    override protected void OnSideBarButtonClick(WizardNavigationEventArgs e)
    {
      base.OnSideBarButtonClick(e);
      if (AllowNavigationToStep(e.NextStepIndex))
      {
        this.Page.Response.Write("AllowNavigationToStep() returned true, moving to Step" 
          + (e.NextStepIndex + 1).ToString() + ".");
        this.ActiveStepIndex = e.NextStepIndex;
      }
      else
      {
        this.Page.Response.Write("AllowNavigationToStep() returned false for Step" 
          + (e.NextStepIndex + 1).ToString() + ", moving to Step2.");
        this.ActiveStepIndex = 1;
      }
    }         
  }
  
  // Add the custom wizard control to the page.
  void Page_Load(object sender, EventArgs e) 
  {
      CustomWizard WizardControl = new CustomWizard();
      WizardControl.ID = "WizardControl";
      
      // Create some steps for the custom wizard.
      for (int i = 0; i <= 5; i++)
      {
        WizardStep newStep = new WizardStep();
        newStep.ID = "Step" + (i + 1).ToString();
        // Set AllowReturn to false for some of the steps.        
        if ((i % 2) == 0)
        {
          newStep.AllowReturn = false;
        }
        
        // Add each step to the custom wizard.
        WizardControl.WizardSteps.Add(newStep);
      }
            
      // Display the wizard on the page.
      PlaceHolder1.Controls.Add(WizardControl);
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>AllowNavigationToStep Example</title>
</head>
<body>
    <form id="Form1" runat="server">
      <h3>AllowNavigationToStep Example</h3>
      <asp:PlaceHolder id="PlaceHolder1" 
        runat="server" />
    </form>
  </body>
</html>
<!-- </snippet1> -->
