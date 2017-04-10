Imports System
Imports System.Text
Imports System.IO
Imports System.Xml

Class Typed_Read_Methods   
    
    Shared Sub Main() 
                
        ReadContentAsBoolean()
        ReadContentAs()
    
    End Sub 'Main
        
    
  Public Shared Sub ReadContentAsBoolean() 
  '<snippet1>	
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
  '</snippet1> 
  End Sub 'ReadContentAsBoolean
     
    
  Public Shared Sub ReadContentAs() 
  '<snippet2>	
  Using reader As XmlReader = XmlReader.Create("dataFile_2.xml")

    reader.ReadToDescendant("item")
                
    reader.MoveToAttribute("colors")
    Dim colors As String() = CType(reader.ReadContentAs(GetType(String()), Nothing), String())
    Dim color As String
    For Each color In  colors
      Console.WriteLine("Colors: {0}", color)
    Next color
            
  End Using
  '</snippet2>
  End Sub 'ReadContentAs

End Class 'Typed_Read_Methods 

' end class.