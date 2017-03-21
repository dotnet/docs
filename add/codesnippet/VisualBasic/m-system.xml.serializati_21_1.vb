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