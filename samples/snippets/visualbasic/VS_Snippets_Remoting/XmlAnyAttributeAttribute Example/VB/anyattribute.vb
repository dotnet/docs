'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml

Public Class Group
   Public GroupName As String 
   ' The UnknownAttributes array will be used to collect all unknown
   ' attributes found when deserializing.
   <XmlAnyAttribute> _
    Public UnknownAttributes()As XmlAttribute
End Class

Public Class Test
   Shared Sub Main()
      Dim t  As Test = New Test()
      ' Deserialize the file containing unknown attributes.
      t.DeserializeObject("UnknownAttributes.xml")
   End Sub

   Private Sub DeserializeObject(filename As String)
      Dim ser As XmlSerializer = New XmlSerializer(GetType(Group))
      ' A FileStream is needed to read the XML document.
     Dim fs As FileStream = New FileStream(filename, FileMode.Open)
     Dim g As Group = CType(ser.Deserialize(fs), Group)
     fs.Close()
     ' Write out the data, including unknown attributes.
     Console.WriteLine(g.GroupName)
     Console.WriteLine("Number of unknown attributes: " & _ 
     g.UnknownAttributes.Length)
     Dim xAtt As XmlAttribute
     for each xAtt in g.UnknownAttributes
        Console.WriteLine(xAtt.Name & ": " & xAtt.InnerXml)
     Next
     ' Serialize the object again with the attributes added.
     Me.SerializeObject("AttributesAdded.xml",g)
   End Sub

   Private Sub SerializeObject(filename As String, g As object)
      Dim ser As XmlSerializer = New XmlSerializer(GetType(Group))
      DIm writer As TextWriter = New StreamWriter(filename)
      ser.Serialize(writer, g)
      writer.Close()
   End Sub
End Class
 '</Snippet1>  



