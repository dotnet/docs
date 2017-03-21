  Using reader As XmlReader = XmlReader.Create("dataFile_2.xml")
                
    reader.ReadToDescendant("item")
                
    Do
      reader.MoveToAttribute("sale-item")
      Dim onSale As [Boolean] = reader.ReadContentAsBoolean()
      If onSale Then
        Console.WriteLine(reader("productID"))
      End If
    Loop While reader.ReadToNextSibling("item")
            
  End Using