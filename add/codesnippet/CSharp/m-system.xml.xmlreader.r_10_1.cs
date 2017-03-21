using (XmlReader reader = XmlReader.Create("books.xml")) {
    reader.ReadToFollowing("book");
    do {
       Console.WriteLine("ISBN: {0}", reader.GetAttribute("ISBN")); 
    } while (reader.ReadToNextSibling("book"));
}