Dim reader As XmlReader = XmlReader.Create("book2.xml")
        
' Parse the file.  If they exist, display the prefix and 
' namespace URI of each node.
While reader.Read()
  If reader.IsStartElement() Then
    If reader.Prefix = String.Empty Then
      Console.WriteLine("<{0}>", reader.LocalName)
    Else
      Console.Write("<{0}:{1}>", reader.Prefix, reader.LocalName)
      Console.WriteLine(" The namespace URI is " + reader.NamespaceURI)
    End If
  End If
End While
reader.Close()