  ' Parse the file and display each price node.
  While reader.Read()
    If reader.IsStartElement("price") Then
      Console.WriteLine(reader.ReadInnerXml())
    End If
  End While