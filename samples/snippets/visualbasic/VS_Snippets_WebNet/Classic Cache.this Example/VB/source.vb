Imports System
Imports System.Collections
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.HTMLControls
Imports System.Web.UI.WebControls
Imports Microsoft.VisualBasic

Public Class Page1: Inherits Page
    Protected divCacheContents As HtmlGenericControl
    Protected txtName As TextBox
    Protected txtValue As TextBox
' <Snippet1>
<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Sub ShowCachedItems()
   ' Declare variables.
   dim strCacheContents as String
   dim objItem as DictionaryEntry
   dim strName as String

   ' Display all the items stored in the ASP.NET cache.
   strCacheContents = "<b>The ASP.NET application cache contains:</b><br/>"
   For Each objItem In Cache
       strName = objItem.Key
       If Left(strName, 7) <> "System." Then
        strCacheContents = "key=" & strName & "<br />" 
	Response.Write(strCacheContents)
	strCacheContents = "value=" & Convert.ToString(objItem.Value) & "<br/>"
	Response.Write(strCacheContents)
       End If
   Next
   divCacheContents.InnerHTML = strCacheContents
End Sub
' </Snippet1>
' <Snippet2>
Private Sub cmdAdd_Click(objSender As Object, objArgs As EventArgs)
  If txtName.Text <> "" Then
    ' Add this item to the cache.
  Cache(txtName.Text) = txtValue.Text
  End If
End Sub
' </Snippet2>

End Class
