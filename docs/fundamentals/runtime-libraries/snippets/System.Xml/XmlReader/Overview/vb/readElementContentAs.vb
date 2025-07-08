Imports System.Text
Imports System.IO
Imports System.Xml

Class Read_Typed_Element
    
    
    Shared Sub Main() 
        
        
        ReadElementContentAsString_1()
        ReadElementContentAsString_2()
        ReadElementContentAsLong_1()
        ReadElementContentAsDateTime_1()
        ReadElementContentAs_1()
        ReadElementContentAsObject()
        ReadElementContentAsDouble_1()
    
    End Sub
     
    
    
  Public Shared Sub ReadElementContentAsString_1() 
  '<snippet1>	
    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("stringValue")
      Console.WriteLine(reader.ReadElementContentAsString())
    End Using
  '</snippet1>
  End Sub
 
    
  Public Shared Sub ReadElementContentAsString_2() 
  '<snippet2>        
    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("stringValue")
      Console.WriteLine(reader.ReadElementContentAsString("stringValue", ""))
    End Using
  '</snippet2>
  End Sub
     
    
  Public Shared Sub ReadElementContentAsLong_1() 
  '<snippet3>	
    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("longValue")
      Dim number As Long = reader.ReadElementContentAsLong()
      ' Do some processing with the number object.
    End Using
  '</snippet3>
  End Sub
    
    
  Public Shared Sub ReadElementContentAsDateTime_1() 
  '<snippet4>	
    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("date")
      Dim [date] As DateTime = reader.ReadElementContentAsDateTime()
                
      ' If the current culture is "en-US",
      ' this writes "Wednesday, January 8, 2003".
      Console.WriteLine([date].ToLongDateString())
    End Using
  '</snippet4>
  End Sub
     
        
  Public Shared Sub ReadElementContentAs_1() 
  '<snippet5>	
    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("date")
      Dim [date] As DateTime = CType(reader.ReadElementContentAs(GetType(System.DateTime), Nothing), DateTime)
                
      ' If the current culture is "en-US",
      ' this writes "Wednesday, January 8, 2003".
      Console.WriteLine([date].ToLongDateString())
    End Using
  '</snippet5>     
  End Sub
    
    
  Public Shared Sub ReadElementContentAsObject() 
  '<snippet6>
  ' Create a validating reader.
  Dim settings As New XmlReaderSettings()
  settings.ValidationType = ValidationType.Schema
  settings.Schemas.Add("urn:items", "item.xsd")
  Dim reader As XmlReader = XmlReader.Create("item.xml", settings)
        
  ' Get the CLR type of the price element. 
  reader.ReadToFollowing("price")
  Console.WriteLine(reader.ValueType)
        
  ' Return the value of the price element as Decimal object.
  Dim price As [Decimal] = CType(reader.ReadElementContentAsObject(), [Decimal])
        
  ' Add 2.50 to the price.
  price = [Decimal].Add(price, 2.5D)

  '</snippet6>      
  End Sub
     
    
  Public Shared Sub ReadElementContentAsDouble_1() 
  '<snippet7>	
    Using reader As XmlReader = XmlReader.Create("dataFile.xml")
      reader.ReadToFollowing("double")
      Dim number As [Double] = reader.ReadElementContentAsDouble()
      ' Do some processing with the number object.
    End Using
 '</snippet7>   
  End Sub

Public Shared Sub ReadTypedData1() 
'<snippet13>	
' Create a validating XmlReader object. The schema 
' provides the necessary type information.
Dim settings As XmlReaderSettings = New XmlReaderSettings()
settings.ValidationType = ValidationType.Schema
settings.Schemas.Add("urn:empl-hire", "hireDate.xsd")
Using reader As XmlReader = XmlReader.Create("hireDate.xml", settings) 
  ' Move to the hire-date element.
  reader.MoveToContent()
  reader.ReadToDescendant("hire-date")

  ' Return the hire-date as a DateTime object.
  Dim hireDate As DateTime = reader.ReadElementContentAsDateTime()
  Console.WriteLine("Six Month Review Date: {0}", hireDate.AddMonths(6))
End Using
 '</snippet13>   
End Sub

Public Shared Sub ReadTypedData2() 
'<snippet14>	
' Create an XmlReader object.
Using reader As XmlReader = XmlReader.Create("hireDate_1.xml")
  ' Move to the hire-date element.
  reader.MoveToContent()
  reader.ReadToDescendant("hire-date")

  ' Return the hire-date as a DateTime object.
  Dim hireDate As DateTime = reader.ReadElementContentAsDateTime()
  Console.WriteLine("Six Month Review Date: {0}", hireDate.AddMonths(6))
End Using
 '</snippet14>   
End Sub

End Class
