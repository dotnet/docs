<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  ' Remove Step2 from the WizardStepCollection collection
  ' as the page is initialized. Then display the sidebar area
  ' so that it is apparent that the WizardStep2 page is gone.
  
  Sub Page_Init()
    Wizard1.WizardSteps.Remove(Me.WizardStep2)
    Wizard1.DisplaySideBar = True
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
        displaysidebar="false" >
        <WizardSteps>
          <asp:WizardStep id="WizardStep1" 
            runat="server" 
            title="Step 1">
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep2" 
            runat="server" 
            title="Step 2">
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep3" 
            runat="server" 
            title="Step 3">
          </asp:WizardStep>
        </WizardSteps>
        <HeaderTemplate>
          <b>WizardStepCollection Remove Example</b>
        </HeaderTemplate>
      </asp:Wizard>
    </form>
  </body>
</html>
<!-- </snippet1> -->
