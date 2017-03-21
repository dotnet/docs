using (XmlReader reader = XmlReader.Create("book3.xml")) {

  // Parse the XML document.  ReadString is used to 
  // read the text content of the elements.
  reader.Read(); 
  reader.ReadStartElement("book");  
  reader.ReadStartElement("title");   
  Console.Write("The content of the title element:  ");
  Console.WriteLine(reader.ReadString());
  reader.ReadEndElement();
  reader.ReadStartElement("price");
  Console.Write("The content of the price element:  ");
  Console.WriteLine(reader.ReadString());
  reader.ReadEndElement();
  reader.ReadEndElement();

}