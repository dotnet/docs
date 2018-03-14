'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml

Public Class Group
   ' The Things array will be used to collect all unknown
   ' attributes found when deserializing.
   public GroupName As String 
   public Things() As XmlAttribute
End Class

Public Class Test
   Shared Sub Main()
      Dim t As Test = New Test()
      t.DeserializeObject("UnknownAttributes.xml")
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
      ' Use the CreateOverrideSerializer to return an instance
      ' of the XmlSerializer customized for overrides.
      Dim ser As XmlSerializer = CreateOverrideSerializer()
      ' A FileStream is needed to read the XML document.
      Dim fs As FileStream = New FileStream(filename, FileMode.Open)
     Dim g As Group = CType( _
     	ser.Deserialize(fs), Group)
     fs.Close()
     Console.WriteLine(g.GroupName)
     Console.WriteLine(g.Things.Length)
     Dim xAtt As XmlAttribute
     for each xAtt in g.Things
        Console.WriteLine(xAtt.Name & ": " & xAtt.InnerXml)
     Next
   End Sub

   Private Function CreateOverrideSerializer() As XmlSerializer 
      ' Override the Things field to capture all
      ' unknown XML attributes.
      Dim myAnyAttribute As XmlAnyAttributeAttribute = _
      New XmlAnyAttributeAttribute()
      Dim xOverride As XmlAttributeOverrides = _
      New XmlAttributeOverrides()
      Dim xAtts As XmlAttributes = New XmlAttributes()
      xAtts.XmlAnyAttribute=myAnyAttribute
      xOverride.Add(GetType(Group), "Things", xAtts)
      return New XmlSerializer(GetType(Group) , xOverride)
   End Function
End Class
 '</Snippet1>  


