'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class Group
   Public GroupName As String 
   Public Grouptype As GroupType 
End Class

Public enum GroupType
' Use the SoapEnumAttribute to instruct the XmlSerializer
' to generate Small and Large instead of A and B.
   <SoapEnum("Small")> _
   A
   <SoapEnum("Large")> _
   B
End enum
 
Public Class Run
   Public Shared Sub Main()
      Dim test As Run = new Run()
      test.SerializeObject("SoapEnum.xml")
      test.SerializeOverride("SoapOverride.xml")
      Console.WriteLine("Fininished writing two files")
   End Sub

   Private Shared Sub SerializeObject(filename As string)
      ' Create an instance of the XmlSerializer Class.
      Dim mapp  As XmlTypeMapping = _
      (New SoapReflectionImporter()).ImportTypeMapping(GetType(Group))
      Dim mySerializer As XmlSerializer =  New XmlSerializer(mapp)

      ' Writing the file requires a TextWriter.
      Dim writer As TextWriter = New StreamWriter(filename)

      ' Create an instance of the Class that will be serialized.
      Dim myGroup As Group = New Group()

      ' Set the object properties.
      myGroup.GroupName = ".NET"
      myGroup.Grouptype= GroupType.A

      ' Serialize the Class, and close the TextWriter.
      mySerializer.Serialize(writer, myGroup)
       writer.Close()
   End Sub

   Private  Sub SerializeOverride(fileName As String)
      Dim soapOver As SoapAttributeOverrides = new SoapAttributeOverrides()
      Dim SoapAtts As SoapAttributes = new SoapAttributes()

      ' Add a SoapEnumAttribute for the GroupType.A enumerator. Instead
      ' of 'A' it will be "West".
      Dim soapEnum As SoapEnumAttribute = new SoapEnumAttribute("West")
      ' Override the "A" enumerator.
      SoapAtts.SoapEnum = soapEnum
      soapOver.Add(GetType(GroupType), "A", SoapAtts)

      ' Add another SoapEnumAttribute for the GroupType.B enumerator.
      ' Instead of 'B' it will be "East".
      SoapAtts= New SoapAttributes()
      soapEnum = new SoapEnumAttribute()
      soapEnum.Name = "East"
      SoapAtts.SoapEnum = soapEnum
      soapOver.Add(GetType(GroupType), "B", SoapAtts)

      ' Create an XmlSerializer used for overriding.
      Dim map As XmlTypeMapping = New SoapReflectionImporter _
      (soapOver).ImportTypeMapping(GetType(Group))
      Dim ser As XmlSerializer = New XmlSerializer(map)
      Dim myGroup As Group = New Group()
      myGroup.GroupName = ".NET"
      myGroup.Grouptype = GroupType.B
      ' Writing the file requires a TextWriter.
      Dim writer As TextWriter = New StreamWriter(fileName)
      ser.Serialize(writer, myGroup)
      writer.Close

   End Sub
End Class
'</Snippet1>


