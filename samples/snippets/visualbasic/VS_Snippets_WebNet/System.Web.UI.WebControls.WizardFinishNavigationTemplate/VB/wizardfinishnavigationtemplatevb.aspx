<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Sub OnFinishButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
    ' Insert code here that determines if an email address was
    ' entered in emailTextBox. Then send an confirmation email if it was.     
  End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" 
      title="FinishNavigationTemplate Example" 
      runat="server">
      <asp:Wizard ID="Wizard1" 
        Runat="server" 
        ActiveStepIndex="0" 
        OnFinishButtonClick="OnFinishButtonClick">
        <WizardSteps>
          <asp:WizardStep Runat="server" 
            Title="Step 1">
            <!-- Put UI elements for Step 1 here. -->
            This is step one.
          </asp:WizardStep>
          <asp:WizardStep Runat="server" 
            Title="Step 2">
            <!-- Put UI elements for Step 2 here. -->
            This is step two.
          </asp:WizardStep>
          <asp:WizardStep Runat="server" 
            StepType="Complete" 
            Title="Complete">
            The Wizard has been completed.
          </asp:WizardStep>
        </WizardSteps>
        <FinishNavigationTemplate>
          Please enter your email address if you would like a confirmation email:
          <asp:TextBox ID="emailTextBox" 
            Runat="server">
          </asp:TextBox>
          &nbsp;<br />
          <asp:Button CommandName="MovePrevious"
              Runat="server" 
              Text="Previous" />
          <asp:Button CommandName="MoveComplete" 
            Runat="server" 
            Text="Finish" />
        </FinishNavigationTemplate>
        <HeaderTemplate>
          <b>FinishNavigationTemplate Example</b>
        </HeaderTemplate>
      </asp:Wizard>
    </form>
  </body>
</html>
<!-- </snippet1> -->
