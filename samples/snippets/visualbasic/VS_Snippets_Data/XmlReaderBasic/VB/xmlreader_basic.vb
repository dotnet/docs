Imports System.Text
Imports System.IO
Imports System.Xml


Class XmlReader_Samples
    
    
    Shared Sub Main() 
    
    End Sub
     
    
Shared Sub AttributeCount() 
Dim reader As XmlReader = XmlReader.Create("books.xml")
reader.ReadToDescendant("book")
'<snippet1>
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
'</snippet1>    
End Sub
    
'==============================
' 
Shared Sub GetAttribute1() 
Dim reader As XmlReader = XmlReader.Create("books.xml")
'<snippet2>
reader.ReadToFollowing("book")
Dim isbn As String = reader.GetAttribute(2)
 '</snippet2>
End Sub
    
'==============================//
' 
Shared Sub GetAttribute2() 
Dim reader As XmlReader = XmlReader.Create("books.xml")
'<snippet3>
reader.ReadToFollowing("book")
Dim isbn As String = reader.GetAttribute("ISBN")
Console.WriteLine("The ISBN value: " + isbn)
'</snippet3>    
End Sub
       
'==============================//
' 
Shared Sub MoveToAttribute1() 
Dim reader As XmlReader = XmlReader.Create("books.xml")
reader.ReadToFollowing("book")
'<snippet4>
If reader.HasAttributes Then
  Console.WriteLine("Attributes of <" + reader.Name + ">")
  Dim i As Integer
  For i = 0 To reader.AttributeCount - 1
    reader.MoveToAttribute(i)
    Console.Write(" {0}={1}", reader.Name, reader.Value)
  Next i
  reader.MoveToElement() 'Moves the reader back to the element node.
End If
'</snippet4>    
End Sub
        
'==============================//
' 
Shared Sub MoveToFirstAttribute() 
Dim reader As XmlReader = XmlReader.Create("books.xml")
'<snippet5>
reader.ReadToFollowing("book")
reader.MoveToFirstAttribute()
Dim genre As String = reader.Value
Console.WriteLine("The genre value: " + genre)
'</snippet5>    
End Sub
    
'==============================//
' 
Shared Sub MoveToNextAttribute() 
Dim reader As XmlReader = XmlReader.Create("books.xml")
reader.ReadToFollowing("book")
'<snippet6>
If reader.HasAttributes Then
  Console.WriteLine("Attributes of <" + reader.Name + ">")
  While reader.MoveToNextAttribute()
    Console.WriteLine(" {0}={1}", reader.Name, reader.Value)
  End While
  ' Move the reader back to the element node.
  reader.MoveToElement()
End If
'</snippet6>    
End Sub
     
    
'==============================//
' 
Shared Sub Item() 
Dim reader As XmlReader = XmlReader.Create("books.xml")
'<snippet7>
reader.ReadToDescendant("book")
Dim isbn As String = reader("ISBN")
Console.WriteLine("The ISBN value: " + isbn)
'</snippet7>    
End Sub
     
    
'==============================//
' 
Shared Sub Node_Value() 
'<snippet8>
Dim settings As New XmlReaderSettings()
settings.DtdProcessing = DtdProcessing.Parse
Dim reader As XmlReader = XmlReader.Create("items.xml", settings)
reader.MoveToContent()
' Parse the file and display each of the nodes.
While reader.Read()
  Select Case reader.NodeType
    Case XmlNodeType.Element
      Console.Write("<{0}>", reader.Name)
    Case XmlNodeType.Text
      Console.Write(reader.Value)
    Case XmlNodeType.CDATA
      Console.Write("<![CDATA[{0}]]>", reader.Value)
    Case XmlNodeType.ProcessingInstruction
      Console.Write("<?{0} {1}?>", reader.Name, reader.Value)
    Case XmlNodeType.Comment
      Console.Write("<!--{0}-->", reader.Value)
    Case XmlNodeType.XmlDeclaration
      Console.Write("<?xml version='1.0'?>")
    Case XmlNodeType.Document
    Case XmlNodeType.DocumentType
      Console.Write("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value)
    Case XmlNodeType.EntityReference
      Console.Write(reader.Name)
    Case XmlNodeType.EndElement
      Console.Write("</{0}>", reader.Name)
  End Select
End While
'</snippet8>    
End Sub
        
    
'==============================//
' 
Shared Sub NamespaceURI() 
'<snippet9>
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
'</snippet9>    
End Sub
     
    
'==============================
' 
Shared Sub IsStartElement() 
Dim reader As XmlReader = XmlReader.Create("elems.xml")
'<snippet10>
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
'</snippet10>    
End Sub
     
    
'==============================
' 
Shared Sub ReadEndElement() 
'<snippet11>
Using reader As XmlReader = XmlReader.Create("book3.xml")               
  ' Parse the XML document.  ReadString is used to 
  ' read the text content of the elements.
  reader.Read()
  reader.ReadStartElement("book")
  reader.ReadStartElement("title")
  Console.Write("The content of the title element:  ")
  Console.WriteLine(reader.ReadString())
  reader.ReadEndElement()
  reader.ReadStartElement("price")
  Console.Write("The content of the price element:  ")
  Console.WriteLine(reader.ReadString())
  reader.ReadEndElement()
  reader.ReadEndElement()            
End Using
'</snippet11>    
End Sub
    
'==============================
' 
Shared Sub ReadInnerXml() 
'<snippet12>
' Load the file and ignore all white space.
Dim settings As New XmlReaderSettings()
settings.IgnoreWhitespace = True
Using reader As XmlReader = XmlReader.Create("2books.xml")

  ' Moves the reader to the root element.
  reader.MoveToContent()
                
  ' Moves to book node.
  reader.Read()
                
  ' Note that ReadInnerXml only returns the markup of the node's children
  ' so the book's attributes are not returned.
  Console.WriteLine("Read the first book using ReadInnerXml...")
  Console.WriteLine(reader.ReadInnerXml())
                
  ' ReadOuterXml returns the markup for the current node and its children
  ' so the book's attributes are also returned.
  Console.WriteLine("Read the second book using ReadOuterXml...")
  Console.WriteLine(reader.ReadOuterXml())

End Using
'</snippet12>    
End Sub
     
    
'==============================
' 
Shared Sub ReadSubtree() 
'<snippet13>
Dim settings As New XmlReaderSettings()
settings.IgnoreWhitespace = True
Using reader As XmlReader = XmlReader.Create("books.xml", settings)

  ' Position the reader on the second book node.
  reader.ReadToFollowing("Book")
  reader.Skip()
                
  ' Create another reader that contains just the second book node.
  Dim inner As XmlReader = reader.ReadSubtree()
            
  inner.ReadToDescendant("Title")
  Console.WriteLine(inner.Name)

  ' Do additional processing on the inner reader. After you 
  ' are done, call Close on the inner reader and 
  ' continue processing using the original reader.
  inner.Close()

End Using
'</snippet13>    
End Sub
     
    
'==============================
' 
Shared Sub ReadtoDescendant() 
'<snippet14>
Using reader As XmlReader = XmlReader.Create("2books.xml")

  ' Move the reader to the second book node.
  reader.MoveToContent()
  reader.ReadToDescendant("book")
  reader.Skip() 'Skip the first book.
  ' Parse the file starting with the second book node.
  Do
    Select Case reader.NodeType
      Case XmlNodeType.Element
        Console.Write("<{0}", reader.Name)
        While reader.MoveToNextAttribute()
            Console.Write(" {0}='{1}'", reader.Name, reader.Value)
        End While
        Console.Write(">")
      Case XmlNodeType.Text
        Console.Write(reader.Value)
      Case XmlNodeType.EndElement
        Console.Write("</{0}>", reader.Name)
    End Select
  Loop While reader.Read()

End Using
'</snippet14>    
End Sub
     
    
'==============================
' 
Shared Sub ReadToFollowing() 
'<snippet15>
Using reader As XmlReader = XmlReader.Create("books.xml")
  reader.ReadToFollowing("book")
  Do
    Console.WriteLine("ISBN: {0}", reader.GetAttribute("ISBN"))
  Loop While reader.ReadToNextSibling("book")
End Using
'</snippet15>    
End Sub
     
    
'==============================
' 
Shared Sub HasValue() 
'<snippet16>
Dim settings As New XmlReaderSettings()
settings.IgnoreWhitespace = True
Using reader As XmlReader = XmlReader.Create("book1.xml", settings)
  ' Parse the file and display each node.
  While reader.Read()
    If reader.HasValue Then
      Console.WriteLine("({0})  {1}={2}", reader.NodeType, reader.Name, reader.Value)
    Else
      Console.WriteLine("({0}) {1}", reader.NodeType, reader.Name)
    End If
  End While
End Using
'</snippet16>    
End Sub

'==============================
' 
Shared Sub IsStartElement_2() 
Using reader As XmlReader = XmlReader.Create("books.xml")
'<snippet17>
  ' Parse the file and display each price node.
  While reader.Read()
    If reader.IsStartElement("price") Then
      Console.WriteLine(reader.ReadInnerXml())
    End If
  End While
'</snippet17>  
End Using  
End Sub

End Class
