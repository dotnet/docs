<!-- <snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
  
  Sub OnCancelButtonClick(ByVal sender As Object, ByVal e As EventArgs)
    ' When the Cancel button is clicked, redirect to http://www.wingtiptoys.com/.
    Response.Redirect("http://www.wingtiptoys.com/")
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
        displaycancelbutton="True"
        oncancelbuttonclick="OnCancelButtonClick">
        <HeaderTemplate>
          <b>CancelButtonClick Example</b>
        </HeaderTemplate>
        <WizardSteps>
          <asp:WizardStep title="Step 1" 
            runat="server">
          </asp:WizardStep>
          <asp:WizardStep title="Step 2" 
            runat="server">
          </asp:WizardStep>
        </WizardSteps>
      </asp:Wizard>
    </form>
  </body>
</html>
<!-- </snippet1> -->