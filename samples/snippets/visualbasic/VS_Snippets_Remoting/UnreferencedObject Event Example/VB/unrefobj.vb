'<Snippet1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Schema

' You must use the SoapIncludeAttribute to inform the XmlSerializer
' that the Vehicle type should be recognized when deserializing.
<SoapInclude(GetType(Vehicle))> _
Public Class Group
    Public GroupName As String 
   public GroupVehicle As Vehicle 
End Class

Public Class Vehicle
   Public licenseNumber As String 
End Class

 
Public Class Run
   Shared Sub Main()
      Dim test As Run = new Run()
      test.DeserializeObject("UnrefObj.xml")
   End Sub
   
   Public Sub DeserializeObject(filename As String)
      ' Create an instance of the XmlSerializer class.
      Dim myMapping As XmlTypeMapping = _
      (new SoapReflectionImporter().ImportTypeMapping _
      (GetType(Group)))
      Dim mySerializer As XmlSerializer =  _
      new XmlSerializer(myMapping)

      AddHandler mySerializer.UnreferencedObject, _
      AddressOf Serializer_UnreferencedObject

      ' Reading the file requires an  XmlTextReader.
      Dim reader As XmlTextReader = _
      new XmlTextReader(filename)
      reader.ReadStartElement()

      ' Deserialize and cast the object.
      Dim myGroup As Group  
      myGroup = CType( mySerializer.Deserialize(reader), Group)
      reader.ReadEndElement()
      reader.Close()
   End Sub
   
   Private Sub Serializer_UnreferencedObject _
   (sender As object , e As UnreferencedObjectEventArgs)
      Console.WriteLine("UnreferencedObject:")
      Console.WriteLine("ID: " + e.UnreferencedId)
      Console.WriteLine("UnreferencedObject: " + e.UnreferencedObject)
      Dim myVehicle As Vehicle = CType(e.UnreferencedObject, Vehicle)
      Console.WriteLine("License: " + myVehicle.licenseNumber)
       End Sub
 End Class
 
' The XML document should contain this information:

'<wrapper>

'  <Group xmlns:xsi="http:'www.w3.org/2001/XMLSchema-instance" 
'xmlns:xsd="http:'www.w3.org/2001/XMLSchema" id="id1" 
'n1:GroupName=".NET" xmlns:n1="http:'www.cpandl.com">
'   </Group>

'<Vehicle id="id2" n1:type="Vehicle" 
'xmlns:n1="http:'www.w3.org/2001/XMLSchema-instance">
'    <licenseNumber xmlns:q1="http:'www.w3.org/2001/XMLSchema" 
'n1:type="q1:string">ABCD</licenseNumber>
'  </Vehicle>

'<Vehicle id="id3" n1:type="Vehicle" 
'xmlns:n1="http:'www.w3.org/2001/XMLSchema-instance">
'    <licenseNumber xmlns:q1="http:'www.w3.org/2001/XMLSchema" 
'n1:type="q1:string">1234</licenseNumber>
'  </Vehicle>

'</wrapper>

'</Snippet1>