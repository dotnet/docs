Private Sub AddToolbarButtons(toolBar As ToolBar)
   If Not toolBar.Buttons.IsReadOnly Then
      ' If toolBarButton1 in in the collection, remove it.
      If toolBar.Buttons.Contains(toolBarButton1) Then
         toolBar.Buttons.Remove(toolBarButton1)
      End If

      ' Create three toolbar buttons.
      Dim tbb1 As New ToolBarButton("tbb1")
      Dim tbb2 As New ToolBarButton("tbb2")
      Dim tbb3 As New ToolBarButton("tbb3")

      ' Add toolbar buttons to the toolbar.		
      toolBar.Buttons.AddRange(New ToolBarButton() {tbb2, tbb3})
      toolBar.Buttons.Add("tbb4")

      ' Insert tbb1 into the first position in the collection.
      toolBar.Buttons.Insert(0, tbb1)
   End If
End Sub