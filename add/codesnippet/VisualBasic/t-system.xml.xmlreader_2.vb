' Display all attributes.
If reader.HasAttributes Then
  Console.WriteLine("Attributes of <" + reader.Name + ">")
  Dim i As Integer
  For i = 0 To (reader.AttributeCount - 1)
    Console.WriteLine("  {0}", reader(i))
  Next i
  ' Move the reader back to the element node.
  reader.MoveToElement() 
End If