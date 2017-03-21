While reader.Read()
  If reader.IsStartElement() Then
    If reader.IsEmptyElement Then
      Console.WriteLine("<{0}/>", reader.Name)
    Else
      Console.Write("<{0}> ", reader.Name)
      reader.Read() ' Read the start tag.
      If reader.IsStartElement() Then ' Handle nested elements.
        Console.Write(vbCr + vbLf + "<{0}>", reader.Name)
      End If
      Console.WriteLine(reader.ReadString()) 'Read the text content of the element.
    End If
  End If
End While