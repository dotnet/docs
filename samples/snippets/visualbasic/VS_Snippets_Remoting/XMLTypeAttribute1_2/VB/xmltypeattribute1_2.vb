' System.Xml.Serialization.XmlTypeAttribute.XmlTypeAttribute()
' System.Xml.Serialization.XmlTypeAttribute.XmlTypeAttribute(string)

'   The following example demonstrates the contructors 'XmlTypeAttribute()'
'   and 'XmlTypeAttribute(string)' of class 'XmlTypeAttribute'.
'   This program demonstrates 'Person' and 'Address' classes to 
'   which the 'XmlTypeAttribute' has been applied.This sample then 
'   serializes an object of class 'Person' into an XML document.

' <Snippet1>
' <Snippet2>
Imports System
Imports System.IO
Imports System.Xml.Serialization

Public Class Person
   Public personName As String
   Public address As Address
End Class

Public Class Address
   Public state As String
   Public zip As String
End Class

Public Class PersonTypeAttribute

   Public Shared Sub Main()
      Dim myPersonTypeAttribute As New PersonTypeAttribute()
      myPersonTypeAttribute.SerializeObject("XmlType.xml")
   End Sub

   Public Function CreateOverrider() As XmlSerializer
      Dim personOverride As New XmlAttributeOverrides()
      Dim personAttributes As New XmlAttributes()
      Dim personType As New XmlTypeAttribute()
      personType.TypeName = "Employee"
      personType.Namespace = "http://www.microsoft.com"
      personAttributes.XmlType = personType

      Dim addressAttributes As New XmlAttributes()
      ' Create 'XmlTypeAttribute' with 'TypeName' as an argument.
      Dim addressType As New XmlTypeAttribute("Address")
      addressType.Namespace = "http://www.microsoft.com"
      addressAttributes.XmlType = addressType

      personOverride.Add(GetType(Person), personAttributes)
      personOverride.Add(GetType(Address), addressAttributes)

      Dim myXmlSerializer As New XmlSerializer(GetType(Person), personOverride)
      Return myXmlSerializer
   End Function

   Public Sub SerializeObject(filename As String)
      Dim myXmlSerializer As XmlSerializer = CreateOverrider()

      Dim myAddress As New Address()
      myAddress.state = "AAA"
      myAddress.zip = "11111"

      Dim myPerson As New Person()
      myPerson.personName = "Smith"
      myPerson.address = myAddress
      ' Serialize to a file.
      Dim writer = New StreamWriter(filename)
      myXmlSerializer.Serialize(writer, myPerson)
   End Sub
End Class
' </Snippet2>
' </Snippet1>