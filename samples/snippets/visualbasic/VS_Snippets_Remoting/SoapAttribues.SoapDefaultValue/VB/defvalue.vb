'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Schema
Imports System.ComponentModel

Public Class Group
   ' The default is set to .NET.
   <DefaultValue(".NET")> _
   Public GroupName As String
End Class
 
Public Class Run

   Public Shared Sub Main()
   
      Dim test As Run = new Run()
      test.SerializeOriginal("SoapOriginal.xml")
      test.SerializeOverride _
      ("mySoapAttributeOverridesideAttributes.xml")
      test.DeserializeOriginal("SoapOriginal.xml")
      test.DeserializeOverride _
      ("mySoapAttributeOverridesideAttributes.xml")
   End Sub
   
   public Sub SerializeOriginal(filename As String)
       ' Create an instance of the XmlSerializer class.
      Dim mySerializer As XmlSerializer =  _
      new XmlSerializer(GetType(Group))

      ' Writing the file requires a TextWriter.
      Dim writer As TextWriter = new StreamWriter(filename)

      ' Create an instance of the class that will be serialized.
      Dim myGroup As Group = new Group()

      ' Setting the GroupName to '.NET' is like not setting it at all
      ' because it is the default value. So no value will be 
      ' serialized, and on deserialization it will appear as a blank.
      myGroup.GroupName = ".NET"

      ' Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myGroup)
      writer.Close()
   End Sub

   Public Sub SerializeOverride(filename As String)
   
      ' Create an instance of the XmlSerializer class
      ' that overrides the serialization.
      Dim overRideSerializer As XmlSerializer = CreateOverrideSerializer()

      ' Writing the file requires a TextWriter.
      Dim writer As TextWriter = new StreamWriter(filename)

      ' Create an instance of the class that will be serialized.
      Dim myGroup As Group = new Group()

      ' The override specifies that the default value is now 
      ' 'Team1'. So setting the GroupName to '.NET' means
      ' the value will be serialized.
      myGroup.GroupName = ".NET"
      ' Serialize the class, and close the TextWriter.
      overRideSerializer.Serialize(writer, myGroup)
       writer.Close()

   End Sub


   Public Sub DeserializeOriginal(filename As String)
   
      ' Create an instance of the XmlSerializer class.
      Dim mySerializer As XmlSerializer = new XmlSerializer(GetType(Group))
      ' Reading the file requires a TextReader.
      Dim reader As TextReader = new StreamReader(filename)

      ' Deserialize and cast the object.
      Dim myGroup As Group = CType(mySerializer.Deserialize(reader), Group)

      Console.WriteLine(myGroup.GroupName)
      Console.WriteLine()
   End Sub

   Public Sub DeserializeOverride(filename As String)
   
      ' Create an instance of the XmlSerializer class.
      Dim overRideSerializer As XmlSerializer = CreateOverrideSerializer()
      ' Reading the file requires a TextReader.
      Dim reader As TextReader = new StreamReader(filename)

      ' Deserialize and cast the object.
      Dim myGroup As Group = CType(overRideSerializer.Deserialize(reader), Group)

      Console.WriteLine(myGroup.GroupName)

   End Sub

   Private Function CreateOverrideSerializer() As XmlSerializer 
   
      Dim mySoapAttributeOverrides As SoapAttributeOverrides  = _
      New SoapAttributeOverrides()
      Dim soapAtts As SoapAttributes = New SoapAttributes()
      ' Create a new DefaultValueAttribute object for the GroupName
      ' property.
      Dim newDefault As DefaultValueAttribute = _
      new DefaultValueAttribute("Team1")
      soapAtts.SoapDefaultValue = newDefault

     mySoapAttributeOverrides.Add(GetType(Group), "GroupName", _
     soapAtts)
      
      ' Create an XmlTypeMapping that is used to create an instance 
      ' of the XmlSerializer. Then return the XmlSerializer object.
      Dim myMapping As XmlTypeMapping = _
      (New SoapReflectionImporter( _
      mySoapAttributeOverrides)).ImportTypeMapping(GetType(Group))
	
      Dim ser As XmlSerializer = new XmlSerializer(myMapping)
      return ser
   End Function
End Class
'</Snippet1>

 
