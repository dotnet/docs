<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Sub OnFinishButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
    ' When the Finish button is clicked, write a confirmation
    ' that the wizard was completed to Label1, and make it visible.
    Label1.Text = "The wizard has been completed."
    Label1.Visible = True
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
        onfinishbuttonclick="OnFinishButtonClick">
        <WizardSteps>
          <asp:WizardStep id="WizardStep1" 
            title="Step 1" 
            runat="server">
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep2" 
            title="Step 2" 
            runat="server">
          </asp:WizardStep>
        </WizardSteps>
        <HeaderTemplate>
          <b>FinishButtonClick Example</b>
        </HeaderTemplate>
      </asp:Wizard>
      <asp:Label id="Label1" 
        runat="Server" 
        visible="False" />
    </form>
  </body>
</html>
<!-- </snippet1> -->

