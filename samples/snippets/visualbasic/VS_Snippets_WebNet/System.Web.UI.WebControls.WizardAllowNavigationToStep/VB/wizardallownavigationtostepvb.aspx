<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  ' This custom wizard control defines the OnSideBarButtonClick method
  ' that uses the AllowNavigationToStep method to determine whether the
  ' value passed in can be used to set the ActiveStepIndex property.    
  Class CustomWizard
    Inherits Wizard
  
    Protected Overloads Sub OnSideBarButtonClick(ByVal sender As Object, _
      ByVal e As WizardNavigationEventArgs) Handles Me.SideBarButtonClick

      If AllowNavigationToStep(e.NextStepIndex) Then
        
        Me.Page.Response.Write("AllowNavigationToStep() returned true, moving to Step" & _
           (e.NextStepIndex + 1).ToString() & ".")
        Me.ActiveStepIndex = e.NextStepIndex
        
      Else
        
        Me.Page.Response.Write("AllowNavigationToStep() returned false for Step" & _
           (e.NextStepIndex + 1).ToString() & ", moving to Step2.")
        Me.ActiveStepIndex = 1
        
      End If
    End Sub
  End Class
  
  ' Add the custom wizard control to the page.
  Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    Dim WizardControl As New CustomWizard()
    WizardControl.ID = "WizardControl"
      
    ' Create some steps for the custom wizard.
    For i As Integer = 0 To 5
      Dim newStep As New WizardStep()
      newStep.ID = "Step" & (i + 1).ToString()
      ' Set AllowReturn to false for some of the steps.        
      If ((i Mod 2) = 0) Then
        newStep.AllowReturn = False
      End If
        
      ' Add each step to the custom wizard.
      WizardControl.WizardSteps.Add(newStep)
    Next
      
    ' Display the wizard on the page.
    PlaceHolder1.Controls.Add(WizardControl)
    
  End Sub
  
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
