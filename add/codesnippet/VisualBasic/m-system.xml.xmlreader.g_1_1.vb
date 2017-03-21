reader.ReadToFollowing("book")
Dim isbn As String = reader.GetAttribute("ISBN")
Console.WriteLine("The ISBN value: " + isbn)