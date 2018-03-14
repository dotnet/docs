    Dim books = 
        XDocument.Load(My.Application.Info.DirectoryPath & 
                       "\..\..\Data\books.xml")
    Console.WriteLine(books)