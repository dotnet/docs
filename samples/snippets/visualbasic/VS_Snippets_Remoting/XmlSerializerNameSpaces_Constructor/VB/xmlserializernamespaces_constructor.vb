' System.Xml.Serialization.XmlSerializerNamespaces.constructor

'   The following example demonstrates the constructor of class
'   XmlSerializerNamespaces. This sample serializes an object of 'MyPriceClass'
'   into an XML document.

Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO

Public Class MyBook
   Public BookName As String
   Public Author As String
   Public BookPrice As MyPriceClass
   Public Description As String
End Class

Public Class MyPriceClass
   <XmlAttribute()> Public Units As String
   Public Price As Decimal
End Class

Public Class MyMainClass

   Public Shared Sub Main()
      Dim myMain As New MyMainClass()
      ' Create the XML document.
      myMain.CreateBook("myBook.xml")
   End Sub

' <Snippet1>
   Private Sub CreateBook(filename As String)
      Try
         ' Create instance of XmlSerializerNamespaces and add the namespaces.
         Dim myNameSpaces As New XmlSerializerNamespaces()
         myNameSpaces.Add("BookName", "http://www.cpandl.com")

         ' Create instance of XmlSerializer and specify the type of object;
         ' to be serialized.
         Dim mySerializerObject As New XmlSerializer(GetType(MyBook))

         Dim myWriter = New StreamWriter(filename)
         ' Create object to be serialized.
         Dim myXMLBook As New MyBook()

         myXMLBook.Author = "XMLAuthor"
         myXMLBook.BookName = "DIG THE XML"
         myXMLBook.Description = "This is a XML Book"

         Dim myBookPrice As New MyPriceClass()
         myBookPrice.Price = CDec(45.89)
         myBookPrice.Units = "$"
         myXMLBook.BookPrice = myBookPrice

         ' Serialize the object.
         mySerializerObject.Serialize(myWriter, myXMLBook, myNameSpaces)
         myWriter.Close()
      Catch e As Exception
         Console.WriteLine("Exception :" & e.Message & "Occured")
      End Try
   End Sub
' </Snippet1>
End Class