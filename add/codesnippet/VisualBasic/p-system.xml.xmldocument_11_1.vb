        Dim doc1 As New XmlDocument()
        doc1.Load("books.xml")
        Dim doc2 As XmlDocument = doc1.Implementation.CreateDocument()