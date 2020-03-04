<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  Sub OnNextButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
    ' When the Next button is clicked, increase the 
    ' Wizard1.BorderWidth by 1.
    Wizard1.BorderWidth = Unit.Pixel(CInt(Wizard1.BorderWidth.Value + 1))
  End Sub
  
  Sub OnPreviousButtonClick(ByVal sender As Object, ByVal e As WizardNavigationEventArgs)
    ' When the Previous button is clicked, decrease the 
    ' Wizard1.BorderWidth by 1.
    Wizard1.BorderWidth = Unit.Pixel(CInt(Wizard1.BorderWidth.Value - 1))
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
        onnextbuttonclick="OnNextButtonClick" 
        onpreviousbuttonclick="OnPreviousButtonClick"
        borderstyle="Solid" 
        bordercolor="#3300ff"
        borderwidth="1">
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
          <asp:WizardStep id="WizardStep4" 
            runat="server" 
            title="Step 4">
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep5" 
            runat="server" 
            title="Step 5">
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep6" 
            runat="server" 
            title="Step 6">
          </asp:WizardStep>
          <asp:WizardStep id="WizardStep7" 
            runat="server" 
            title="Step 7">
          </asp:WizardStep>
        </WizardSteps>
        <HeaderTemplate>
          <b>NextButtonClick and PreviousButtonClick Example</b>
        </HeaderTemplate>
      </asp:Wizard>
    </form>
  </body>
</html>
<!-- </snippet1> -->
