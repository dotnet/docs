if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "price") 
 {
    _price = reader.ReadString();
 }