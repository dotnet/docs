      Dim controlProperties As New ArrayList(3)
      
      controlProperties.Add(SortDirection)
      controlProperties.Add(SelectedColumn)
      controlProperties.Add(CurrentPage.ToString())
      
      ' Create an ObjectStateFormatter to serialize the ArrayList.
      Dim formatter As New ObjectStateFormatter()
      
      ' Call the Serialize method to serialize the ArrayList to a Base64 encoded string.
      Dim base64StateString As String = formatter.Serialize(controlProperties)
