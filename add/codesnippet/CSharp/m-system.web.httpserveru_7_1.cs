String TestString = "This is a <Test String>.";
StringWriter writer = new StringWriter();
Server.HtmlEncode(TestString, writer);
String EncodedString = writer.ToString();
   