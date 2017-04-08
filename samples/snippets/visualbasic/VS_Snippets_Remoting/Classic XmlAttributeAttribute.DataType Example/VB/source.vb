Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization


' <Snippet1>
public class Group
	<XmlAttribute(DataType := "string")> _
	public Name As string 

	<XmlAttribute (DataType := "base64Binary")> _
	public Hex64Code () As byte 
End Class

' </Snippet1>
