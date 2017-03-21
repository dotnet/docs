private void serializer_UnknownAttribute(
 object sender, XmlAttributeEventArgs e)
 {
    System.Xml.XmlAttribute attr = e.Attr;
         
    Console.WriteLine("Unknown Attribute Name and Value:" + 
    attr.Name + "='" + attr.Value + "'");
    Object x = e.ObjectBeingDeserialized;
    Console.WriteLine("ObjectBeingDeserialized: " + x.ToString());
 }
