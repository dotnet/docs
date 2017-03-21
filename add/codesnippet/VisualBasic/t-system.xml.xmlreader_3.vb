If reader.HasAttributes Then
  Console.WriteLine("Attributes of <" + reader.Name + ">")
  While reader.MoveToNextAttribute()
    Console.WriteLine(" {0}={1}", reader.Name, reader.Value)
  End While
  ' Move the reader back to the element node.
  reader.MoveToElement()
End If