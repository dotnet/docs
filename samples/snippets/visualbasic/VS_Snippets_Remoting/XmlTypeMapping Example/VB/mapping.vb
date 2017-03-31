'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports System.Collections
Imports System.Xml
Imports System.Text


Namespace Company
	
<SoapType("TheGroup", "http://www.cohowinery.com")> _
Public Class Group

   ' The SoapElementAttribute specifies that the
   ' generated XML element name will be "Wheels"
   ' instead of "Vehicle".
   Public GroupName As String 
   public Things() As  Thing
   <SoapElement(DataType:= "language")> _
   Public Lang As String = "en"
   <SoapElement(DataType:= "integer")> _
   Public MyNumber As String 

   <SoapElement(DataType:= "duration")> _
   Public ReDate As String  = "8/31/01"
End Class

Public Class Thing 
   Public ThingName As String 
End Class

Public Class Test
   Shared Sub Main()
   
      Dim t As Test = new Test()

      t.GetMap("MyMap.xml")
   End Sub


   public Sub GetMap(filename As string )
      ' Create an XmlSerializer instance.
      Dim map As XmlTypeMapping = new SoapReflectionImporter().ImportTypeMapping(GetType(Group))
      Console.WriteLine("ElementName: " + map.ElementName)
      Console.WriteLine("Namespace: " + map.Namespace)
      Console.WriteLine("TypeFullName: " + map.TypeFullName)
      Console.WriteLine("TypeName: " + map.TypeName)
      Dim ser As XmlSerializer= new XmlSerializer(map)
      Dim xGroup As Group =  new Group()
      xGroup.GroupName= "MyCar"
      xGroup.MyNumber= 5454.ToString()
      xGroup.Things = new Thing(){new Thing(), new Thing()}
      ' To write the outer wrapper, use an XmlTextWriter.
      Dim writer As XmlTextWriter =  _
      new XmlTextWriter(filename, Encoding.UTF8)
      writer.Formatting = Formatting.Indented
      writer.WriteStartElement("wrapper")
      ser.Serialize(writer, xGroup)
      writer.WriteEndElement()
      writer.Close()
   End Sub
End Class

End namespace
'</Snippet1>
