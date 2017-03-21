   Public Sub SerializeOrder(filename As String)
      ' Create an XmlSerializer instance using the method below.
      Dim myXmlSerializer As XmlSerializer = CreateOverrider()

      ' Create the object, and set its Name property.
      Dim myStudent As New Student()
      myStudent.Name = "Student class1"

      ' Serialize the class, and close the TextWriter.
      Dim writer = New StreamWriter(filename)
      myXmlSerializer.Serialize(writer, myStudent)
      writer.Close()
   End Sub

   ' Return an XmlSerializer to override the root serialization.
   Public Function CreateOverrider() As XmlSerializer
      ' Create an XmlAttributes to override the default root element.
      Dim myXmlAttributes As New XmlAttributes()

      ' Create an XmlRootAttribute and set its element name and namespace.
      Dim myXmlRootAttribute As New XmlRootAttribute()
      myXmlRootAttribute.ElementName = "OverriddenRootElementName"
      myXmlRootAttribute.Namespace = "http://www.microsoft.com"

      ' Set the XmlRoot property to the XmlRoot object.
      myXmlAttributes.XmlRoot = myXmlRootAttribute
      Dim myXmlAttributeOverrides As New XmlAttributeOverrides()

      ' Add the XmlAttributes object to the XmlAttributeOverrides object.
      myXmlAttributeOverrides.Add(GetType(Student), myXmlAttributes)

      ' Create the Serializer, and return it.
      Dim myXmlSerializer As New XmlSerializer(GetType(Student), myXmlAttributeOverrides)
      Return myXmlSerializer
   End Function