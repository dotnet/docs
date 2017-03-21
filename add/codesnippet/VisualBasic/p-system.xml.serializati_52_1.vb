public class Group
	<XmlAttribute(DataType := "string")> _
	public Name As string 

	<XmlAttribute (DataType := "base64Binary")> _
	public Hex64Code () As byte 
End Class
