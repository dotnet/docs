'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml

Public Class Group
   Public GroupName As String 
   <XmlAnyElement> _
   Public Things () As object
End Class

Public Class Test
   Shared Sub Main()
      Dim t As Test = New Test()
      ' 1 Run this and create the XML document.
      ' 2 Add New elements to the XML document.
      ' 3 Comment out the New line, and uncomment
      ' the DeserializeObject line to deserialize the
      ' XML document and see unknown elements.
     t.SerializeObject("UnknownElements.xml")
     
      't.DeserializeObject("UnknownElements.xml")
   End Sub

   Private Sub SerializeObject(filename As String)
      Dim ser As XmlSerializer = New XmlSerializer(GetType (Group))
      Dim writer As TextWriter = New StreamWriter(filename)
      
      Dim g As Group = New Group()
      g.GroupName = "MyGroup"
      ser.Serialize(writer, g)
      writer.Close()
   End Sub

   
   Private Sub DeserializeObject(filename As String)

      Dim ser As XmlSerializer = CreateOverrideSerializer()
      ' A FileStream is needed to read the XML document.
      Dim fs As FileStream = New FileStream(filename, FileMode.Open)
     Dim g As Group = CType( _
     	ser.Deserialize(fs), Group)
     fs.Close()
     Console.WriteLine(g.GroupName)
     Console.WriteLine(g.Things.Length)
     Dim xelement As XmlELement
     for each xelement in g.Things
        Console.WriteLine(xelement.Name &": " & xelement.InnerXml)
     next
   End Sub
   

   Private Function CreateOverrideSerializer() As XmlSerializer 
      Dim myAnyElement As XmlAnyElementAttribute = _
      New XmlAnyElementAttribute()
      Dim xOverride As XmlAttributeOverrides = _
      New XmlAttributeOverrides()
      Dim xAtts As XmlAttributes = New XmlAttributes()
      xAtts.XmlAnyElements.Add(myAnyElement)
      xOverride.Add(GetType(Group), "Things", xAtts)
      return New XmlSerializer(GetType(Group) , xOverride)
   End Function
End Class
'</Snippet1>

