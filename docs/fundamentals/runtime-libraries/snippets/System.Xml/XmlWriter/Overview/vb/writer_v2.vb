Imports System.Text
Imports System.IO
Imports System.Xml

Class Whidbey_Write_Methods
    
    
    Shared Sub Main() 
    
    End Sub
     
    ' WriteQName();
    
    
Public Shared Sub WriteDateTime() 
'<snippet1>	
Dim price As [Double] = 9.95
Dim [date] As New DateTime(2004, 5, 20)
        
Using writer As XmlWriter = XmlWriter.Create("data.xml")
  writer.WriteStartElement("book")
  writer.WriteStartAttribute("pub-date")
  writer.WriteValue([date])
  writer.WriteEndAttribute()
            
  writer.WriteStartElement("price")
  writer.WriteValue(price)
  writer.WriteEndElement()
            
  writer.WriteEndElement()
  writer.Flush()
End Using
'</snippet1>    
End Sub
         

Public Shared Sub CreateURI() 
'<snippet2>	
Using writer As XmlWriter = XmlWriter.Create("output.xml")
  writer.WriteStartElement("book")
  writer.WriteElementString("price", "19.95")
  writer.WriteEndElement()
  writer.Flush()
End Using
'</snippet2>    
End Sub
       
Public Shared Sub Create_Console() 
'<snippet3>	
Using writer As XmlWriter = XmlWriter.Create(Console.Out)
  writer.WriteStartElement("book")
  writer.WriteElementString("price", "19.95")
  writer.WriteEndElement()
  writer.Flush()
End Using
'</snippet3>    
End Sub
    
Public Shared Sub Create_StringWriter() 
'<snippet4>	
Dim settings As New XmlWriterSettings()
settings.OmitXmlDeclaration = True
Dim sw As New StringWriter()
        
Using writer As XmlWriter = XmlWriter.Create(sw, settings)
  writer.WriteStartElement("book")
  writer.WriteElementString("price", "19.95")
  writer.WriteEndElement()
  writer.Flush()
            
  Dim output As String = sw.ToString()
End Using
 '</snippet4>    
End Sub
         
Public Shared Sub WriteQName() 
'<snippet5>	
Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.OmitXmlDeclaration = True
Using writer As XmlWriter = XmlWriter.Create(Console.Out, settings)
  writer.WriteStartElement("root")
  writer.WriteAttributeString("xmlns", "x", Nothing, "urn:abc")
  writer.WriteStartElement("item")
  writer.WriteStartAttribute("href", Nothing)
  writer.WriteString("#")
  writer.WriteQualifiedName("test", "urn:abc")
  writer.WriteEndAttribute()
  writer.WriteEndElement()
  writer.WriteEndElement()
End Using
'</snippet5>    
End Sub
     
    
' # 6 placeholder for XmlQualfieldName.Empty snippet

Public Shared Sub GenericCreate() 
'<snippet7>	
Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.IndentChars = "    "
Using writer As XmlWriter = XmlWriter.Create("books.xml", settings)
  ' Write XML data.
  writer.WriteStartElement("book")
  writer.WriteElementString("price", "19.95")
  writer.WriteEndElement()
  writer.Flush()
End Using
'</snippet7>    
End Sub
         
Public Shared Sub Output1() 
'<snippet8>	
Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.IndentChars = vbTab
Dim writer As XmlWriter = XmlWriter.Create("books.xml", settings)
'</snippet8>    
End Sub
    
Public Shared Sub Output2() 
'<snippet9>	
Dim settings As New XmlWriterSettings()
settings.Indent = True
settings.NewLineOnAttributes = True
Dim writer As XmlWriter = XmlWriter.Create("books.xml", settings)
'</snippet9>    
End Sub
         
Public Shared Sub Attrs1() 
'<snippet10>
Dim settings As New XmlWriterSettings()
settings.Indent = True
Using writer As XmlWriter = XmlWriter.Create(Console.Out, settings)
	writer.WriteStartElement("Product")
        writer.WriteAttributeString("supplierID", "A23-1")
        writer.WriteElementString("ProductID", "12345")
        writer.WriteEndElement()
End Using
'</snippet10>    
End Sub
        
Public Shared Sub Attrs2() 
'<snippet11>
Dim hireDate As New DateTime(2008, 5, 20)
Dim settings As New XmlWriterSettings()
settings.Indent = True
Using writer As XmlWriter = XmlWriter.Create(Console.Out, settings)
	writer.WriteStartElement("Employee")
	writer.WriteStartAttribute("review-date")
	writer.WriteValue(hireDate.AddMonths(6))
	writer.WriteEndAttribute()
	writer.WriteElementString("EmployeeID", "12345")
	writer.WriteEndElement()
End Using
'</snippet11>    
End Sub
        
Public Shared Sub Attrs3() 
'<snippet12>
Dim reader As XmlReader = XmlReader.Create("book.xml")
reader.ReadToDescendant("book")
Dim settings As New XmlWriterSettings()
settings.Indent = True
Using writer As XmlWriter = XmlWriter.Create(Console.Out, settings)
	writer.WriteStartElement("root")
	writer.WriteAttributes(reader, True)
	writer.WriteEndElement()
End Using
'</snippet12>   
End Sub
        
Public Shared Sub Elems1() 
Dim writer As XmlWriter = XmlWriter.Create(Console.Out)
'<snippet13>
writer.WriteElementString("price", "19.95")
'</snippet13>
writer.Flush()
End Sub
        
Public Shared Sub Elems2() 
Dim writer As XmlWriter = XmlWriter.Create(Console.Out)
'<snippet14>
writer.WriteStartElement("bk", "book", "urn:books")
writer.WriteAttributeString("genre", "urn:books", "mystery")
writer.WriteElementString("price", "19.95")
writer.WriteEndElement()
'</snippet14>
writer.Flush()
End Sub
        
Public Shared Sub Elems3() 
'<snippet15>
' Create a reader and position it on the book node.
Dim reader As XmlReader = XmlReader.Create("books.xml")
reader.ReadToFollowing("book")
        
' Write out the book node.
Dim writer As XmlWriter = XmlWriter.Create("newBook.xml")
writer.WriteNode(reader, True)
writer.Flush()
'</snippet15>    
End Sub
         
Public Shared Sub TypedWrite() 
' Create a reader and position it on the book node.
Dim reader As XmlReader = XmlReader.Create("books.xml")
Dim writer As XmlWriter = XmlWriter.Create(Console.Out)
'<snippet16>
reader.ReadToDescendant("price")
writer.WriteStartElement("price")
writer.WriteValue(reader.ReadElementContentAsDouble() * 1.15)
writer.WriteEndElement()
'</snippet16>
writer.Flush()    
End Sub
    
Public Shared Sub Namespace1() 
Dim writer As XmlWriter = XmlWriter.Create(Console.Out)
'<snippet17>
writer.WriteStartElement("root")
writer.WriteAttributeString("xmlns", "x", Nothing, "urn:1")
writer.WriteStartElement("item", "urn:1")
writer.WriteEndElement()
writer.WriteStartElement("item", "urn:1")
writer.WriteEndElement()
writer.WriteEndElement()
 '</snippet17>
writer.Flush()    
End Sub
        
Public Shared Sub Namespace2() 
Dim writer As XmlWriter = XmlWriter.Create(Console.Out)
'<snippet18>
writer.WriteStartElement("x", "root", "123")
writer.WriteStartElement("item")
writer.WriteAttributeString("xmlns", "x", Nothing, "abc")
writer.WriteEndElement()
writer.WriteEndElement()
'</snippet18>
writer.Flush()    
End Sub
        
Public Shared Sub Namespace3() 
Dim writer As XmlWriter = XmlWriter.Create(Console.Out)
'<snippet19>
writer.WriteStartElement("x", "root", "urn:1")
writer.WriteStartElement("y", "item", "urn:1")
writer.WriteEndElement()
writer.WriteEndElement()
'</snippet19>
writer.Flush()    
End Sub

End Class
