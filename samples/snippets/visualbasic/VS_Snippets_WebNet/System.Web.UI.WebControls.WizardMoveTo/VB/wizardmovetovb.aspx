<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Sub OnActiveStepChanged(ByVal sender As Object, ByVal e As EventArgs)

    ' If the ActiveStep is changing to Step2, check to see whether the 
    ' CheckBox1 check box is selected.  If it is, skip to the Step3 step.
    If Wizard1.ActiveStepIndex = Wizard1.WizardSteps.IndexOf(Me.WizardStep2) Then
    
      If (Me.CheckBox1.Checked) Then
        Wizard1.MoveTo(Me.WizardStep3)
      Else
        Wizard1.MoveTo(Me.WizardStep2)
      End If
    
    End If

  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:Wizard id="Wizard1" 
        runat="server" 
        onactivestepchanged="OnActiveStepChanged">
        <WizardSteps>
          <asp:WizardStep id="WizardStep1" 
            title="Step 1" 
            runat="server">
            <asp:CheckBox id="CheckBox1" 
              runat="Server" 
              text="Select this check box to skip Step 2." />
              You are currently on Step 1.
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep2" 
            title="Step 2" 
            runat="server">
            You are currently on Step 2.
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep3" 
            runat="server" 
            title="Step 3">
            You are currently on Step 3.
          </asp:WizardStep>
        </WizardSteps>
        <HeaderTemplate>
          <b>MoveTo Example</b>
        </HeaderTemplate>
      </asp:Wizard>
    </form>
  </body>
</html>
<!-- </snippet1> -->