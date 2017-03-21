  using (XmlReader reader = XmlReader.Create("dataFile_2.xml")) {
        reader.ReadToDescendant("item");
        do {
            reader.MoveToAttribute("sale-item");
            Boolean onSale = reader.ReadContentAsBoolean();
            if (onSale) {
               Console.WriteLine(reader["productID"]);
            }
        } while (reader.ReadToNextSibling("item"));	
  }