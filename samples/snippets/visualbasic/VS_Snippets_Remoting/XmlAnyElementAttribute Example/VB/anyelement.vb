'<Snippet1>
Imports System
Imports System.Text
Imports System.IO
Imports System.Xml.Serialization
Imports System.Xml
Imports System.Xml.Schema


<XmlRoot(Namespace:= "http://www.cohowinery.com")> _
Public Class Group
   Public GroupName As String 

   ' This is for serializing Employee elements.
   <XmlAnyElement(Name:="Employee")> _
   Public  UnknownEmployees() As XmlElement

   ' This is for serializing City elements.   
   <XmlAnyElement _
   (Name:="City", _
   Namespace:="http://www.cpandl.com")> _
   Public UnknownCity() As XmlElement 

    ' This one is for all other unknown elements.
   <XmlAnyElement> _
   Public UnknownElements() As XmlElement 
End Class

Public Class Test
   Shared Sub Main()
      Dim t  As Test = New Test()
      t.SerializeObject("AnyElementArray.xml")
      t.DeserializeObject("AnyElementArray.xml")
      Console.WriteLine("Done")
   End Sub

   Private Sub SerializeObject(filename As String)
      Dim ser As XmlSerializer  = _
      New XmlSerializer(GetType(Group))
      ' Create an XmlNamespaces to use.
      Dim namespaces As XmlSerializerNamespaces = _
      New XmlSerializerNamespaces()
      namespaces.Add("c", "http://www.cohowinery.com")
      namespaces.Add("i", "http://www.cpandl.com")
      Dim myGroup As Group = New Group()
      ' Create arrays of arbitrary XmlElement objects.
      ' First create an XmlDocument, used to create the 
      ' XmlElement objects.
      Dim xDoc As XmlDocument = New XmlDocument()

      ' Create an array of Employee XmlElement objects.
      Dim El1 As XmlElement = xDoc.CreateElement("Employee", "http://www.cohowinery.com")
      El1.InnerText = "John"
      Dim El2 As XmlElement = xDoc.CreateElement("Employee", "http://www.cohowinery.com")
      El2.InnerText = "Joan"
      Dim El3 As XmlElement = xDoc.CreateElement("Employee", "http://www.cohowinery.com")
      El3.InnerText = "Jim"
      myGroup.UnknownEmployees= New XmlElement(){El1, El2, El3}     
    
      ' Create an array of City XmlElement objects.
      Dim inf1 As XmlElement = xDoc.CreateElement("City", "http://www.cpandl.com")
      inf1.InnerText = "Tokyo"
      Dim inf2 As XmlElement = xDoc.CreateElement("City", "http://www.cpandl.com")     
      inf2.InnerText = "New York"
      Dim inf3 As XmlElement = xDoc.CreateElement("City", "http://www.cpandl.com")     
      inf3.InnerText = "Rome"

      myGroup.UnknownCity = New XmlElement(){inf1, inf2, inf3}

      Dim xEl1 As XmlElement = xDoc.CreateElement("bld")
      xEl1.InnerText = "42"
      Dim xEl2 As XmlElement = xDoc.CreateElement("Region")
      xEl2.InnerText = "West"
      Dim xEl3 As XmlElement = xDoc.CreateElement("type")
      xEl3.InnerText = "Technical"
      myGroup.UnknownElements = _
      New XmlElement(){xEl1,xEl2,xEl3}
      ' Serialize the class, and close the TextWriter.
      Dim writer As TextWriter = New StreamWriter(filename)
      ser.Serialize(writer, myGroup, namespaces)
      writer.Close()

   End Sub

   Private Sub DeserializeObject(filename As String)
      Dim ser As XmlSerializer = _
      New XmlSerializer(GetType(Group))
      Dim fs As FileStream = New FileStream(filename, FileMode.Open)
      Dim myGroup As Group 
      myGroup = CType(ser.Deserialize(fs), Group)
      fs.Close()
      Dim xEmp As XmlElement
      for each xEmp in myGroup.UnknownEmployees
         Console.WriteLine(xEmp.LocalName & ": " & xEmp.InnerText)
      Next 
      
      Dim xCity As XmlElement
      for each xCity in myGroup.UnknownCity
         Console.WriteLine(xCity.LocalName & ": " & xCity.InnerText)
      Next
      
      Dim xEl As XmlElement
      for each  xEl in myGroup.UnknownElements
         Console.WriteLine(xEl.LocalName & ": " & xEl.InnerText)
      Next
   End Sub
 End Class

 '</Snippet1>  
