StringWriter writer = new StringWriter();
Server.UrlDecode(EncodedString, writer);
String DecodedString = writer.ToString();
   