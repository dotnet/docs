<%@ Import Namespace="System.Web.Profile" %>
<script language="VB" runat="server">

'<Snippet11>
Public Sub Profile_ProfileAutoSaving(sender As Object, args As ProfileAutoSaveEventArgs)
  If Profile.Cart.HasChanged Then
    args.ContinueWithProfileAutoSave = True
  Else
    args.ContinueWithProfileAutoSave = False
  End If
End Sub
'</Snippet11>
</script>