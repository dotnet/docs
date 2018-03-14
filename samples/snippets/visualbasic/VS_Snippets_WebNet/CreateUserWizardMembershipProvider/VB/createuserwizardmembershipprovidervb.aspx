<!-- <Snippet1> -->
<%@ page language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub Createuserwizard1_NextButtonClick(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.WizardNavigationEventArgs)
    If Createuserwizard1.ActiveStepIndex = 0 Then
      Createuserwizard1.MembershipProvider = _
      divisionList.SelectedValue()
      Createuserwizard1.CreateUserStep.Title = _
        String.Format("Create your new {0} account.", _
          divisionList.SelectedItem.Text)
    End If
  End Sub
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>
      Untitled Page</title>
  </head>
  <body>
    <form id="form1" runat="server">
      <div>
        <asp:createuserwizard id="Createuserwizard1" runat="server" onnextbuttonclick="Createuserwizard1_NextButtonClick">
          <wizardsteps>
            <asp:wizardstep runat="server" title="Choose your division">
              <p>
                Choose your division and click "Next".</p>
              <asp:dropdownlist runat="server" id="divisionList">
                <asp:listitem value="accountingProvider">
                  Accounting</asp:listitem>
                <asp:listitem value="manufacturingProvider">
                  Manufacturing</asp:listitem>
                <asp:listitem value="marketingProvider">
                  Marketing</asp:listitem>
                <asp:listitem value="salesProvider">
                  Sales</asp:listitem>
              </asp:dropdownlist>
            </asp:wizardstep>
            <asp:createuserwizardstep runat="server" title="Sign Up for Your New Account">
            </asp:createuserwizardstep>
          </wizardsteps>
        </asp:createuserwizard>
      </div>
    </form>
  </body>
</html>
<!-- </Snippet1> -->
