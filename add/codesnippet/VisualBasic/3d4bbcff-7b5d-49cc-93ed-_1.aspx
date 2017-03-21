<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Protected Sub Button1_Click(ByVal sender As Object, _
    ByVal e As EventArgs)
    
    Dim list As New ArrayList(2)
    list.Add(AppearanceEditorPart1)
    list.Add(PropertyGridEditorPart1)
    ' Pass an ICollection object to the constructor.
    Dim myParts As New EditorPartCollection(list)
    Dim editor As EditorPart
    For Each editor In myParts
      editor.BackColor = System.Drawing.Color.LightBlue
      editor.Description = "My " + editor.DisplayTitle + " editor."
    Next editor
    
    ' Use the IndexOf property to locate an EditorPart control.
    Dim propertyGridPart As Integer = _
      myParts.IndexOf(PropertyGridEditorPart1)
    myParts(propertyGridPart).ChromeType = PartChromeType.TitleOnly
    
    ' Use the Contains method to see if an EditorPart exists.
    If Not myParts.Contains(LayoutEditorPart1) Then
      LayoutEditorPart1.BackColor = System.Drawing.Color.LightYellow
    End If
    
    ' Use the CopyTo method to create an array of EditorParts.
    Dim partArray(2) As EditorPart
    partArray(0) = LayoutEditorPart1
    myParts.CopyTo(partArray, 1)
    Label1.Text = "<h3>EditorParts in Custom Array</h3>"
    Dim ePart As EditorPart
    For Each ePart In partArray
      Label1.Text += ePart.Title + "<br />"
    Next ePart

  End Sub

</script>