   Private Function LoadControlProperties(serializedProperties As String) As ICollection
      
      Dim controlProperties As ICollection = Nothing
      
      ' Create an ObjectStateFormatter to deserialize the properties.
      Dim formatter As New ObjectStateFormatter()
      
      ' Call the Deserialize method.
      controlProperties = CType(formatter.Deserialize(serializedProperties), ArrayList)
      
      Return controlProperties
   End Function 'LoadControlProperties   