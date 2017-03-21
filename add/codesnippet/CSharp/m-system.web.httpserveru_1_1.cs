String EncodedString = "This is a &ltTest String&gt.";
StringWriter writer = new StringWriter();
Server.HtmlDecode(EncodedString, writer);
String DecodedString = writer.ToString();
   