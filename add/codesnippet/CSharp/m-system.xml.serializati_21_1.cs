   private void CreateBook(string filename)
   {
      try
      {
         // Create instance of XmlSerializerNamespaces and add the namespaces.
         XmlSerializerNamespaces myNameSpaces = new XmlSerializerNamespaces();
         myNameSpaces.Add("BookName", "http://www.cpandl.com");
      
         // Create instance of XmlSerializer and specify the type of object
         // to be serialized.
         XmlSerializer mySerializerObject = 
            new XmlSerializer(typeof(MyBook));

         TextWriter myWriter = new StreamWriter(filename);
         // Create object to be serialized.
         MyBook myXMLBook = new MyBook();
      
         myXMLBook.Author = "XMLAuthor";
         myXMLBook.BookName = "DIG THE XML";
         myXMLBook.Description = "This is a XML Book";

         MyPriceClass myBookPrice = new MyPriceClass();
         myBookPrice.Price = (decimal) 45.89;
         myBookPrice.Units = "$";
         myXMLBook.BookPrice = myBookPrice;

         // Serialize the object.
         mySerializerObject.Serialize(myWriter, myXMLBook,myNameSpaces);
         myWriter.Close();
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception :" + e.Message + "Occured");
      }
   }