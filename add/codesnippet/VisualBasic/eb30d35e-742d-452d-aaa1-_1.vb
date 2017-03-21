  Using reader As XmlReader = XmlReader.Create("dataFile_2.xml")

    reader.ReadToDescendant("item")
                
    reader.MoveToAttribute("colors")
    Dim colors As String() = CType(reader.ReadContentAs(GetType(String()), Nothing), String())
    Dim color As String
    For Each color In  colors
      Console.WriteLine("Colors: {0}", color)
    Next color
            
  End Using