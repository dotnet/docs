  // Create a validating reader.
  XmlReaderSettings settings = new XmlReaderSettings();
  settings.ValidationType = ValidationType.Schema;
  settings.Schemas.Add("urn:items", "item.xsd");	
   XmlReader reader = XmlReader.Create("item.xml", settings); 

  // Get the CLR type of the price element. 
  reader.ReadToFollowing("price");
  Console.WriteLine(reader.ValueType);

  // Return the value of the price element as Decimal object.
  Decimal price = (Decimal) reader.ReadElementContentAsObject();

  // Add 2.50 to the price.
  price = Decimal.Add(price, 2.50m);
