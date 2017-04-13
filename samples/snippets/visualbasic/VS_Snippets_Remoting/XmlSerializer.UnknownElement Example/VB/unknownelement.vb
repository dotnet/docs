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
      t.DeserializeObject("UnknownElements.xml")
   End Sub

   Private Sub Serializer_UnknownElement _
   (sender As Object , e As XmlElementEventArgs)
      Console.WriteLine("Unknown Element")
      Console.WriteLine(ControlChars.Tab & e.Element.Name + " " & e.Element.InnerXml)
      Console.WriteLine(ControlChars.Tab & e.LineNumber & ":"  & e.LineNumber)
      Console.WriteLine(ControlChars.Tab & e.LinePosition & ":"   & e.LinePosition)
      
      Dim x As Group = CType( e.ObjectBeingDeserialized, Group)
      Console.WriteLine (x.GroupName)
      Console.WriteLine (sender.ToString())
   End Sub
   
   Private Sub DeserializeObject(filename As String)
      Dim ser As XmlSerializer = new XmlSerializer(GetType(Group))
      ' Add a delegate to handle unknown element events.
      AddHandler ser.UnknownElement, _
      AddressOf Serializer_UnknownElement 
      ' A FileStream is needed to read the XML document.
     Dim fs As FileStream  = new FileStream(filename, FileMode.Open)
     Dim g  As Group = CType(ser.Deserialize(fs),Group)
     fs.Close()
   End Sub
End Class
 '</Snippet1>  





