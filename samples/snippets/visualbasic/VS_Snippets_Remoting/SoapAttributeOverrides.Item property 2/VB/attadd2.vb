'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

' The name of this type will be overridden using
' the SoapTypeAttribute.
Public Class Group
   Public GroupName As String 
End Class

Public Class Run

   Shared Sub Main()

      Dim test As Run = new Run()

      test.SerializeOverride("GetSoapAttributesVB2.xml")
      
   End Sub
   
   Public Sub SerializeOverride(filename As string )
      ' Create an instance of the XmlSerializer class
      ' that overrides the serialization.
      Dim overrideSerializer As XmlSerializer = _
      CreateOverrideSerializer()

      ' Writing the file requires a TextWriter.
      Dim writer As TextWriter = new StreamWriter(filename)

      ' Create an instance of the class that will be serialized.
      Dim myGroup As Group = new Group()
      
      ' Set the object properties.
      myGroup.GroupName = ".NET"

      ' Serialize the class, and close the TextWriter.
      overrideSerializer.Serialize(writer, myGroup)
       writer.Close()
   End Sub

   Private Function CreateOverrideSerializer() As XmlSerializer 
   
      Dim mySoapAttributeOverrides As SoapAttributeOverrides  = _
      New SoapAttributeOverrides()
      Dim mySoapAtts As SoapAttributes = new SoapAttributes()

      Dim mySoapType As SoapTypeAttribute = _
      new SoapTypeAttribute()
      mySoapType.TypeName = "Team"
      mySoapAtts.SoapType = mySoapType
      ' Add the SoapAttributes to the 
      ' mySoapAttributeOverridesrides object.
      mySoapAttributeOverrides.Add(GetType(Group), mySoapAtts)

      ' Get the SoapAttributes with the Item property.
      Dim thisSoapAtts As SoapAttributes = _
      mySoapAttributeOverrides(GetType(Group))
      Console.WriteLine("New serialized type name: " & _
      thisSoapAtts.SoapType.TypeName)

      ' Create an XmlTypeMapping that is used to create an instance 
      ' of the XmlSerializer. Then return the XmlSerializer object.
      Dim myMapping As XmlTypeMapping = _
      (New SoapReflectionImporter(mySoapAttributeOverrides)). _
      ImportTypeMapping(GetType(Group))
	
      Dim ser As XmlSerializer = new XmlSerializer(myMapping)
      return ser
   End Function

End Class
'</Snippet1>

 



