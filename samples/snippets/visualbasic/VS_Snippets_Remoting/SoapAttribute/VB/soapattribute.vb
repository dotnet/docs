'<Snippet1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Schema

<SoapInclude(GetType(Vehicle))> _
Public Class Group

   <SoapAttribute (Namespace:= "http:'www.cpandl.com")> _
   Public GroupName As String    
   <SoapAttribute(DataType:= "base64Binary")> _
   Public GroupNumber() As  Byte 

   <SoapAttribute(DataType:= "date", AttributeName:= "CreationDate")> _
   Public Today As DateTime 
   <SoapElement(DataType:= "nonNegativeInteger", _
   ElementName:= "PosInt")> _
   Public PostitiveInt As String 

   Public GroupVehicle As Vehicle 
End Class
  
Public Class Vehicle
   Public licenseNumber As String 
End Class

Public Class Run

   Shared Sub Main()
   
      Dim test As Run = New Run()
      test.SerializeObject("SoapAtts.xml")
      test.DeserializeObject("SoapAtts.xml")
   End Sub
   
   Public Sub SerializeObject(filename As String)
   
      ' Create an instance of the XmlSerializer Class that
      ' can generate encoded SOAP messages.
      Dim mySerializer As XmlSerializer  =  ReturnSOAPSerializer()

      Dim myGroup As Group = MakeGroup()
      ' Writing the file requires a TextWriter.
      Dim writer As XmlTextWriter = _
      New XmlTextWriter(filename, Encoding.UTF8)
      writer.Formatting = Formatting.Indented
      writer.WriteStartElement("wrapper")
      ' Serialize the Class, and close the TextWriter.
      mySerializer.Serialize(writer, myGroup)
      writer.WriteEndElement()
      writer.Close()
   End Sub

   Private Function MakeGroup() As Group 
      ' Create an instance of the Class that will be serialized.
      Dim myGroup As Group = New Group()

      ' Set the object properties.
      myGroup.GroupName = ".NET"

      Dim hexByte() As Byte= New Byte(1){Convert.ToByte(100), _
      Convert.ToByte(50)}
      myGroup.GroupNumber = hexByte

      Dim myDate As DateTime = New DateTime(2002,5,2)
      myGroup.Today = myDate
      myGroup.PostitiveInt= "10000"
      myGroup.GroupVehicle = New Vehicle()
      myGroup.GroupVehicle.licenseNumber="1234"
      return myGroup
   End Function   	

   Public Sub DeserializeObject(filename As String)
      ' Create an instance of the XmlSerializer Class that
      ' can generate encoded SOAP messages.
      Dim mySerializer As XmlSerializer =  ReturnSOAPSerializer()

      ' Reading the file requires an  XmlTextReader.
      Dim reader As XmlTextReader = _
      New XmlTextReader(filename)
      reader.ReadStartElement("wrapper")

      ' Deserialize and cast the object.
      Dim myGroup As Group 
      myGroup = _
      CType(mySerializer.Deserialize(reader), Group)
      reader.ReadEndElement()
      reader.Close()

   End Sub
   
   private Function ReturnSOAPSerializer() As XmlSerializer 
      ' Create an instance of the XmlSerializer Class.
      Dim myMapping As XmlTypeMapping = _
      (New SoapReflectionImporter().ImportTypeMapping _
      (GetType(Group)))
       return New XmlSerializer(myMapping)
   End Function
End Class
'</Snippet1>

 

