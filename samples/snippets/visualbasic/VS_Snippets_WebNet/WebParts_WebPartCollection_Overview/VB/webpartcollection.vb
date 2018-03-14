' <snippet1>
Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Partial Public Class webpartcollectionvb

  Inherits System.Web.UI.Page

  Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Dim partCollection As WebPartCollection = mgr1.WebParts
    Dim part As WebPart

    For Each part In partCollection
      If part.ChromeState <> PartChromeState.Minimized Then
        part.ChromeState = PartChromeState.Minimized
      Else
        part.ChromeState = PartChromeState.Normal
      End If
    Next

  End Sub

  Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    Dim partCollection As WebPartCollection = WebPartZone1.WebParts

    If partCollection(0).Title = "My Link List" Then
      partCollection(0).Title = "Favorite Links"
    Else
      partCollection(0).Title = "My Link List"
    End If

  End Sub

End Class
' </snippet1>