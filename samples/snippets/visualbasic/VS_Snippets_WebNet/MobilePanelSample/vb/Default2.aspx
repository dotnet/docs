<!-- <Snippet3> -->
<%@ Page Language="VB" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim lab As System.Web.UI.MobileControls.Label

        For i As Integer = 1 To 15
            lab = New System.Web.UI.MobileControls.Label()
            lab.Text = i.ToString() & _
                " - This sentence repeats over and over."
            Panel1.Controls.Add(lab)
        Next
        Form1.Paginate = True
        Panel1.Paginate = True
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="Form1" runat="server">
        <mobile:Panel ID="Panel1" Runat="server">
        </mobile:Panel>
    </mobile:form>
</body>
</html>
<!-- </Snippet3> -->