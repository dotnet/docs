'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

' The SoapType is overridden when the
' SerializeOverride  method is called.
<SoapType("SoapGroupType", "http://www.cohowinery.com")> _
Public class Group
   Public GroupName As String
   Public Employees() As Employee
End Class

<SoapType("EmployeeType")> _
Public Class Employee
   Public Name As String
End Class
   
Public class Run
   Public Shared Sub Main()
      Dim test As Run = New Run()
      test.SerializeOriginal("SoapType.xml")
      test.SerializeOverride("SoapType2.xml")
      test.DeserializeObject("SoapType2.xml")
   End Sub

   Public Sub SerializeOriginal(filename As String )
      ' Create an instance of the XmlSerializer class that
      ' can be used for serializing as a SOAP message.
     Dim mapp  As XmlTypeMapping = _
      (New SoapReflectionImporter()).ImportTypeMapping(GetType(Group))
      Dim mySerializer As XmlSerializer =  _
      New XmlSerializer(mapp)
      
      ' Writing the file requires a TextWriter.
      Dim writer As TextWriter = New StreamWriter(filename)

      ' Create an XML text writer.
      Dim xmlWriter As XmlTextWriter = New XmlTextWriter(writer)
      xmlWriter.Formatting = Formatting.Indented
      xmlWriter.Indentation = 2

      ' Create an instance of the class that will be serialized.
      Dim myGroup As Group = New Group()

      ' Set the object properties.
      myGroup.GroupName = ".NET"
      Dim e1 As Employee = New Employee()
      e1.Name = "Pat"
      myGroup.Employees=New Employee(){e1}

      ' Write the root element.
      xmlWriter.WriteStartElement("root")

      ' Serialize the class.
      mySerializer.Serialize(xmlWriter, myGroup)

      ' Close the root tag.
      xmlWriter.WriteEndElement()

      ' Close the XmlWriter.
      xmlWriter.Close()

      ' Close the TextWriter.
      writer.Close()
   End Sub

   Public Sub SerializeOverride(filename As string )
   
      ' Create an instance of the XmlSerializer class that
      ' uses a SoapAttributeOverrides object.
      Dim mySerializer As XmlSerializer =  CreateOverrideSerializer()

      ' Writing the file requires a TextWriter.
      Dim writer As TextWriter = New StreamWriter(filename)

      ' Create an XML text writer.
      Dim xmlWriter As XmlTextWriter = New XmlTextWriter(writer)
      xmlWriter.Formatting = Formatting.Indented
      xmlWriter.Indentation = 2

      ' Create an instance of the class that will be serialized.
      Dim myGroup As Group = New Group()

      ' Set the object properties.
      myGroup.GroupName = ".NET"
      Dim e1 As Employee = New Employee()
      e1.Name = "Pat"
      myGroup.Employees = New Employee(){e1}

      ' Write the root element.
      xmlWriter.WriteStartElement("root")

      ' Serialize the class.
      mySerializer.Serialize(xmlWriter, myGroup)

      ' Close the root tag.
      xmlWriter.WriteEndElement()

      ' Close the XmlWriter.
      xmlWriter.Close()

      ' Close the TextWriter.
      writer.Close()
   End Sub

   Private Function CreateOverrideSerializer() As XmlSerializer 
      ' Create and return an XmlSerializer instance used to
      ' override and create SOAP messages.
      Dim mySoapAttributeOverrides As SoapAttributeOverrides = _
      	New SoapAttributeOverrides()
      Dim soapAtts As SoapAttributes = New SoapAttributes()

      ' Override the SoapTypeAttribute.
      Dim soapType As SoapTypeAttribute = New SoapTypeAttribute()
      soapType.TypeName = "Team"
      soapType.IncludeInSchema = false
      soapType.Namespace = "http://www.microsoft.com"
      soapAtts.SoapType = soapType
      
      mySoapAttributeOverrides.Add(GetType(Group),soapAtts)

      ' Create an XmlTypeMapping that is used to create an instance 
      ' of the XmlSerializer. Then return the XmlSerializer object.
      Dim myMapping As XmlTypeMapping = (New SoapReflectionImporter( _
      mySoapAttributeOverrides)).ImportTypeMapping(GetType(Group))
	
      Dim  ser As XmlSerializer = New XmlSerializer(myMapping)
      
      return ser
   End Function

   Public Sub DeserializeObject(filename As String)
      ' Create an instance of the XmlSerializer class.
      Dim mySerializer As XmlSerializer =  CreateOverrideSerializer()

      ' Reading the file requires a TextReader.
      Dim reader As TextReader = New StreamReader(filename)

      ' Create an XML text reader.
      Dim xmlReader As XmlTextReader = New XmlTextReader(reader)
      xmlReader.ReadStartElement()

      ' Deserialize and cast the object.
      Dim myGroup As Group = CType(mySerializer.Deserialize(xmlReader), Group)
      xmlReader.ReadEndElement()
      Console.WriteLine("The GroupName is " + myGroup.GroupName)
      Console.WriteLine("Look at the SoapType.xml and SoapType2.xml " + _
        "files for the generated XML.")

      ' Close the readers.
      xmlReader.Close()
      reader.Close()
   End Sub
End Class
'</Snippet1>



