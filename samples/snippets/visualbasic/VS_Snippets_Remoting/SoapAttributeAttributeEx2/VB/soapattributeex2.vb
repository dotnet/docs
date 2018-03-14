'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


Public Class Group
   ' This attribute will be overridden.
   <SoapAttribute (Namespace: = "http://www.cpandl.com")> _
   Public GroupName As String 
   
End Class

public class Run
   Public Shared Sub Main()
   
      Dim test  As Run = new Run()
      test.SerializeOverride("SoapOveride.xml")
   End Sub
   
   Public Sub SerializeOverride(filename As String )
      ' Create an instance of the XmlSerializer class
      ' that overrides the serialization.
      Dim overRideSerializer  As XmlSerializer = _
      CreateOverrideSerializer()

      ' Writing the file requires a TextWriter.
      Dim writer As TextWriter = new StreamWriter(filename)

      ' Create an instance of the class that will be serialized.
      Dim myGroup As Group = new Group()

      ' Set the object properties.
      myGroup.GroupName = ".NET"

      ' Serialize the class, and close the TextWriter.
      overRideSerializer.Serialize(writer, myGroup)
       writer.Close()
   End Sub


   Private Function CreateOverrideSerializer() As XmlSerializer 
   	
      Dim mySoapAttributeOverrides As SoapAttributeOverrides = _
      New SoapAttributeOverrides()
      Dim mySoapAttributes As SoapAttributes = New SoapAttributes()
      ' Create a new SoapAttributeAttribute to override the 
      ' one applied to the Group class. The resulting XML 
      ' stream will use the new namespace and attribute name.
      Dim mySoapAttribute As SoapAttributeAttribute = _
      New SoapAttributeAttribute()
      mySoapAttribute.AttributeName = "TeamName"
      ' Change the Namespace.
      mySoapAttribute.Namespace = "http://www.cohowinery"

      mySoapAttributes.SoapAttribute = mySoapAttribute
      mySoapAttributeOverrides. _
      Add(GetType(Group), "GroupName" ,mySoapAttributes)
	
      Dim myMapping  As XmlTypeMapping = (new SoapReflectionImporter _
      (mySoapAttributeOverrides)).ImportTypeMapping(GetType(Group))
	
      Dim ser As XmlSerializer = new XmlSerializer(myMapping)
      CreateOverrideSerializer = ser
   End Function

End Class
'<?xml version="1.0" encoding="utf-8" ?> 
'<Group xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
'xmlns:xsd="http://www.w3.org/2001/XMLSchema" n1:TeamName=".NET" 
'xmlns:n1="http://www.cohowinery" /> 
'</Snippet1>




