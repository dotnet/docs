' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Xml.Schema
Imports Microsoft.VisualBasic

Public Class Group
   Public GroupName As String 
End Class

Public Class Test
   Shared Sub Main()
      Dim t As Test = new Test()
      ' Deserialize the file containing unknown elements.
      t.DeserializeObject("UnknownAttributes.xml")
   End Sub

   Private Sub Serializer_UnknownAttribute _
   (sender As Object , e As XmlAttributeEventArgs)
      Console.WriteLine("Unknown Attribute")
      Console.WriteLine(ControlChars.Tab & e.Attr.Name + " " & e.Attr.InnerXml)
      Console.WriteLine(ControlChars.Tab & e.LineNumber & ":"  & e.LineNumber)
      Console.WriteLine(ControlChars.Tab & e.LinePosition & ":"   & e.LinePosition)
      
      Dim x As Group = CType( e.ObjectBeingDeserialized, Group)
      Console.WriteLine (x.GroupName)
      Console.WriteLine (sender.ToString())
   End Sub
   
   Private Sub DeserializeObject(filename As String)
      Dim ser As XmlSerializer = new XmlSerializer(GetType(Group))
      ' Add a delegate to handle unknown element events.
      AddHandler ser.UnknownAttribute, _
      AddressOf Serializer_UnknownAttribute 
      ' A FileStream is needed to read the XML document.
     Dim fs As FileStream  = new FileStream(filename, FileMode.Open)
     Dim g  As Group = CType(ser.Deserialize(fs),Group)
     fs.Close()
   End Sub
End Class
 '</Snippet1>  






