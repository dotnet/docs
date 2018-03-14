' System.Xml.Serialization.XmlAttributeAttribute.XmlAttributeAttribute()
' System.Xml.Serialization.XmlAttributeAttribute.XmlAttributeAttribute(String)

'  The following example demonstrates the constructor of XmlAttributeAttribute.
'  This sample serializes a class named 'Student'.The StudentName property is 
'  serialized as an XML attribute.It also serializes a class named 'Book' 

' <Snippet1>
' <Snippet2>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

' This is the class that will be serialized.
Public Class Student
   Public StudentName As String
   Public StudentNumber As Integer
End Class

Public Class Book
   Public BookName As String
   Public BookNumber As Integer
End Class

Public Class XMLAttributeAttribute_ctr1

   Public Shared Sub Main()
      Dim myAttribute As New XMLAttributeAttribute_ctr1()
      myAttribute.SerializeObject("Student.xml", "Book.xml")
   End Sub

   Public Sub SerializeObject(studentFilename As String, bookFilename As String)
      Dim mySerializer As XmlSerializer
      Dim writer As TextWriter

      ' Create the XmlAttributeOverrides and XmlAttributes objects.
      Dim myXmlAttributeOverrides As New XmlAttributeOverrides()
      Dim myXmlAttributes As New XmlAttributes()

      ' Create an XmlAttributeAttribute set it to the XmlAttribute property of the XmlAttributes object.
      Dim myXmlAttributeAttribute As New XmlAttributeAttribute()
      myXmlAttributeAttribute.AttributeName = "Name"
      myXmlAttributes.XmlAttribute = myXmlAttributeAttribute

      ' Add to the XmlAttributeOverrides. Specify the member name.
      myXmlAttributeOverrides.Add(GetType(Student), "StudentName", myXmlAttributes)

      ' Create the XmlSerializer.
      mySerializer = New XmlSerializer(GetType(Student), myXmlAttributeOverrides)

      writer = New StreamWriter(studentFilename)

      ' Create an instance of the class that will be serialized.
      Dim myStudent As New Student()

      ' Set the Name property, which will be generated as an XML attribute. 
      myStudent.StudentName = "James"
      myStudent.StudentNumber = 1
      ' Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myStudent)
      writer.Close()

      ' Create the XmlAttributeOverrides and XmlAttributes objects.
      Dim myXmlBookAttributeOverrides As New XmlAttributeOverrides()
      Dim myXmlBookAttributes As New XmlAttributes()

      ' Create an XmlAttributeAttribute set it to the XmlAttribute property of the XmlAttributes object.
      Dim myXmlBookAttributeAttribute As New XmlAttributeAttribute("Name")
      myXmlBookAttributes.XmlAttribute = myXmlBookAttributeAttribute

      ' Add to the XmlAttributeOverrides. Specify the member name.
      myXmlBookAttributeOverrides.Add(GetType(Book), "BookName", myXmlBookAttributes)

      ' Create the XmlSerializer.
      mySerializer = New XmlSerializer(GetType(Book), myXmlBookAttributeOverrides)

      writer = New StreamWriter(bookFilename)

      ' Create an instance of the class that will be serialized.
      Dim myBook As New Book()

      ' Set the Name property, which will be generated as an XML attribute.
      myBook.BookName = ".NET"
      myBook.BookNumber = 10
      ' Serialize the class, and close the TextWriter.
      mySerializer.Serialize(writer, myBook)
      writer.Close()
   End Sub
End Class
' </Snippet2>
' </Snippet1>