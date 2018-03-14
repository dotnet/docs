'<Snippet1>
Imports System
Imports System.IO
Imports System.Xml.Serialization
Imports System.Collections
Imports System.Xml
Imports System.Text
Public Class Transportation
   ' The SoapElementAttribute specifies that the
   ' generated XML element name will be "Wheels"
   ' instead of "Vehicle".
   <SoapElement("Wheels")> Public Vehicle As String 
   <SoapElement(DataType:= "dateTime")> _
   public CreationDate As DateTime    
   <SoapElement(IsNullable:= true)> _
   public thing As Thing
End Class

Public Class Thing
   <SoapElement(IsNullable:=true)> public ThingName As string 
End Class

Public Class Test

   Shared Sub Main()
      Dim t As Test = New Test()
      t.SerializeObject("SoapElementOriginalVb.xml")
      t.SerializeOverride("SoapElementOverrideVb.xml")
      Console.WriteLine("Finished writing two XML files.")
   End Sub

   ' Return an XmlSerializer used for overriding.
   Public Function CreateSoapOverrider() As XmlSerializer 
      ' Create the SoapAttributes and SoapAttributeOverrides objects.
      Dim soapAttrs As SoapAttributes = New SoapAttributes()

      Dim soapOverrides As SoapAttributeOverrides = _
      New SoapAttributeOverrides()
            
      ' Create a SoapElementAttribute to override 
      ' the Vehicles property. 
      Dim soapElement1 As SoapElementAttribute = _
      New SoapElementAttribute("Truck")
      ' Set the SoapElement to the object.
      soapAttrs.SoapElement= soapElement1

      ' Add the SoapAttributes to the SoapAttributeOverrides,
      ' specifying the member to override. 
      soapOverrides.Add(GetType(Transportation), "Vehicle", soapAttrs)
      
      ' Create the XmlSerializer, and return it.
      Dim myTypeMapping As XmlTypeMapping = (New _
      SoapReflectionImporter (soapOverrides)).ImportTypeMapping _
      (GetType(Transportation))
      return New XmlSerializer(myTypeMapping)
   End Function

   Public Sub SerializeOverride(filename As String)
      ' Create an XmlSerializer instance.
      Dim ser As XmlSerializer = CreateSoapOverrider()

      ' Create the object and serialize it.
      Dim myTransportation As Transportation = _
      New Transportation()

      myTransportation.Vehicle = "MyCar"
      myTransportation.CreationDate = DateTime.Now
      myTransportation.thing= new Thing()
      
      Dim writer As XmlTextWriter = _
      New XmlTextWriter(filename, Encoding.UTF8)
      writer.Formatting = Formatting.Indented
      writer.WriteStartElement("wrapper")
      ser.Serialize(writer, myTransportation)
      writer.WriteEndElement()
      writer.Close()
   End Sub

   Public Sub SerializeObject(filename As String)
      ' Create an XmlSerializer instance.
      Dim ser As XmlSerializer = _
      New XmlSerializer(GetType(Transportation))
      
      Dim myTransportation As Transportation = _
      New Transportation()
      
      myTransportation.Vehicle = "MyCar"
      myTransportation.CreationDate=DateTime.Now
      myTransportation.thing= new Thing()

      Dim writer As XmlTextWriter = _
      new XmlTextWriter(filename, Encoding.UTF8)
      writer.Formatting = Formatting.Indented
      writer.WriteStartElement("wrapper")
      ser.Serialize(writer, myTransportation)
      writer.WriteEndElement()
      writer.Close()
   End Sub
End Class
'</Snippet1>

