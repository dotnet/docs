reader.ReadToFollowing("book");
string isbn = reader.GetAttribute("ISBN");
Console.WriteLine("The ISBN value: " + isbn);