public class Group{
   [XmlAttribute(DataType = "string")]
   public string Name;
	
   [XmlAttribute (DataType = "base64Binary")]
   public byte[] Hex64Code;
}
