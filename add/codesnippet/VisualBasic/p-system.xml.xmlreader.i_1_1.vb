reader.ReadToDescendant("book")
Dim isbn As String = reader("ISBN")
Console.WriteLine("The ISBN value: " + isbn)