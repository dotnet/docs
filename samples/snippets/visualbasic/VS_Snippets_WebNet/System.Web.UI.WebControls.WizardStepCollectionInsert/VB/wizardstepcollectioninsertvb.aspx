<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  ' Programmatically create a Wizard control and dynamically
  ' add WizardStep objects to it.    
  
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    Dim WizardControl As Wizard = New Wizard()
      
    ' Create some steps for the wizard and insert them
    ' into the WizardStepCollection collection.
    For i As Integer = 0 To 5
      Dim newStep As WizardStepBase = New WizardStep()
      newStep.ID = "Step" + (i + 1).ToString()
      WizardControl.WizardSteps.Insert(0, newStep)
    Next

    WizardControl.ActiveStepIndex = 0
    WizardControl.DisplaySideBar = True
    
    ' Display the wizard on the page.
    PlaceHolder1.Controls.Add(WizardControl)
  
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>WizardStepCollection Insert Example</title>
</head>
<body>
    <form id="Form1" runat="server">
      <h3>WizardStepCollection Insert Example</h3>
      <asp:PlaceHolder id="PlaceHolder1" 
        runat="server" />
    </form>
  </body>
</html>
<!-- </snippet1> -->

