'<Snippet1>
Imports System
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization
Imports System.Xml.Schema

Public Class Group
   <SoapAttribute (Namespace:= "http:'www.cpandl.com")> _
   Public GroupName As String 
   
   <SoapAttribute(DataType:= "base64Binary")> _
   Public GroupNumber() As Byte

   <SoapAttribute(DataType:= "date", _
   AttributeName:= "CreationDate")> _
   Public Today As DateTime 
   <SoapElement(DataType:= "nonNegativeInteger", _
   ElementName:= "PosInt")> _
   Public PostitiveInt As String 
   ' This is ignored when serialized unless it's overridden.
   <SoapIgnore> _ 
   Public IgnoreThis As Boolean 
   
   Public Grouptype As GroupType 

   Public MyVehicle As Vehicle 

   '  The SoapInclude allows the method to return a Car.
   <SoapInclude(GetType(Car))> _
   Public Function myCar(licNumber As String ) As Vehicle 
      Dim v As Vehicle 
      if licNumber = "" Then
         v = New Car()
         v.licenseNumber = "!!!!!!"
      else  
   	   v = New Car()
   	   v.licenseNumber = licNumber
      End If
      
      return v
   End Function
End Class
  
' SoapInclude allows Vehicle to accept Car type.
<SoapInclude(GetType(Car))> _
Public MustInherit  class Vehicle
   Public licenseNumber As String 
   Public makeDate As DateTime 
End Class

Public Class Car
   Inherits Vehicle

End Class

Public enum GroupType
   ' These enums can be overridden.
   <SoapEnum("Small")> _
   A
   <SoapEnum("Large")> _ 
   B
End Enum
 
Public Class Run

   Shared Sub Main()
      Dim test As Run = New Run()
      test.SerializeOriginal("SoapOriginal.xml")
      test.SerializeOverride("SoapOverrides.xml")
      test.DeserializeOriginal("SoapOriginal.xml")
      test.DeserializeOverride("SoapOverrides.xml")
   End SUb
   
   Public Sub SerializeOriginal(filename As String)

      ' Create an instance of the XmlSerializer class.
      Dim myMapping As XmlTypeMapping = _
      (New SoapReflectionImporter().ImportTypeMapping _
      (GetType(Group)))
      Dim mySerializer As XmlSerializer =  _
      New XmlSerializer(myMapping)
      
      Dim myGroup As Group =MakeGroup()
      ' Writing the file requires a TextWriter.
      Dim writer As XmlTextWriter  = _
      New XmlTextWriter(filename, Encoding.UTF8)
      writer.Formatting = Formatting.Indented
      writer.WriteStartElement("wrapper")
      ' Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myGroup)
      writer.WriteEndElement()
      writer.Close()
   End Sub

   Public Sub SerializeOverride(filename As String)
      ' Create an instance of the XmlSerializer class
      ' that overrides the serialization.
      Dim overRideSerializer As XmlSerializer = _
      CreateOverrideSerializer()
      Dim myGroup As Group =MakeGroup()
      ' Writing the file requires a TextWriter.
      Dim writer As XmlTextWriter  = _
      New XmlTextWriter(filename, Encoding.UTF8)
      writer.Formatting = Formatting.Indented
      writer.WriteStartElement("wrapper")
      ' Serialize the class, and close the TextWriter.
      overRideSerializer.Serialize(writer, myGroup)
      writer.WriteEndElement()
      writer.Close()
    End Sub

   private Function MakeGroup() As Group 
      ' Create an instance of the class that will be serialized.
      Dim myGroup As Group  = New Group()

      ' Set the object properties.
      myGroup.GroupName = ".NET"

      Dim hexByte()As Byte = new Byte(1){Convert.ToByte(100), _
      Convert.ToByte(50)}
      myGroup.GroupNumber = hexByte

      Dim myDate As DateTime  = new DateTime(2002,5,2)
      myGroup.Today = myDate

      myGroup.PostitiveInt = "10000"
	myGroup.IgnoreThis = true
	myGroup.Grouptype = GroupType.B
	Dim thisCar As Car 
	thisCar =CType(myGroup.myCar("1234566"), Car)
	myGroup.myVehicle=thisCar
      return myGroup
   End Function   	

   Public Sub DeserializeOriginal(filename As String)
      ' Create an instance of the XmlSerializer class.
      Dim myMapping As XmlTypeMapping = _
      (New SoapReflectionImporter().ImportTypeMapping _
      (GetType(Group)))
      Dim mySerializer As XmlSerializer =  _
      New XmlSerializer(myMapping)

      ' Reading the file requires an  XmlTextReader.
      Dim reader As XmlTextReader = _
      New XmlTextReader(filename)
      reader.ReadStartElement("wrapper")

      ' Deserialize and cast the object.
      Dim myGroup As Group  = _
      CType(mySerializer.Deserialize(reader), Group)
      reader.ReadEndElement()
      reader.Close()
   End Sub

   Public Sub DeserializeOverride(filename As String)
      ' Create an instance of the XmlSerializer class.
      Dim overRideSerializer As XmlSerializer  = _
      CreateOverrideSerializer()

      ' Reading the file requires an  XmlTextReader.
      Dim reader As XmlTextReader = _
      New XmlTextReader(filename)
      reader.ReadStartElement("wrapper")

      ' Deserialize and cast the object.
      Dim myGroup As Group = _
      CType(overRideSerializer.Deserialize(reader), Group)
      reader.ReadEndElement()
      reader.Close()
      ReadGroup(myGroup)
   End Sub

   private Sub ReadGroup(myGroup As Group)
      Console.WriteLine(myGroup.GroupName)
      Console.WriteLine(myGroup.GroupNumber(0))
      Console.WriteLine(myGroup.GroupNumber(1))
      Console.WriteLine(myGroup.Today)
      Console.WriteLine(myGroup.PostitiveInt)
      Console.WriteLine(myGroup.IgnoreThis)
      Console.WriteLine()
   End Sub
   
   Private Function CreateOverrideSerializer() As XmlSerializer
      Dim soapOver As SoapAttributeOverrides = New SoapAttributeOverrides()
      Dim soapAtts As SoapAttributes = New SoapAttributes()

      Dim mySoapElement As SoapElementAttribute = New SoapElementAttribute()
      mySoapElement.ElementName = "xxxx"
      soapAtts.SoapElement = mySoapElement
      soapOver.Add(GetType(Group), "PostitiveInt", soapAtts)

      ' Override the IgnoreThis property.
      Dim myIgnore As SoapIgnoreAttribute  = new SoapIgnoreAttribute()
      soapAtts = New SoapAttributes()
      soapAtts.SoapIgnore = false
      soapOver.Add(GetType(Group), "IgnoreThis", soapAtts)

      ' Override the GroupType enumeration.
      soapAtts = New SoapAttributes()
      Dim xSoapEnum As SoapEnumAttribute = new SoapEnumAttribute()
      xSoapEnum.Name = "Over1000"
      soapAtts.SoapEnum = xSoapEnum
      ' Add the SoapAttributes to the SoapOverrides object.
      soapOver.Add(GetType(GroupType), "A", soapAtts)

      ' Create second enumeration and add it.
      soapAtts = New SoapAttributes()
      xSoapEnum = New SoapEnumAttribute()
      xSoapEnum.Name = "ZeroTo1000"
      soapAtts.SoapEnum = xSoapEnum
      soapOver.Add(GetType(GroupType), "B", soapAtts)

      ' Override the Group type.
      soapAtts = New SoapAttributes()
      Dim soapType As SoapTypeAttribute = New SoapTypeAttribute()
      soapType.TypeName = "Team"
      soapAtts.SoapType = soapType
      soapOver.Add(GetType(Group),soapAtts)
	
      Dim myMapping As XmlTypeMapping = (New SoapReflectionImporter( _
      soapOver)).ImportTypeMapping(GetType(Group))
	
       Dim ser As XmlSerializer = new XmlSerializer(myMapping)
      return ser
   End Function
End Class
'</Snippet1>

 

