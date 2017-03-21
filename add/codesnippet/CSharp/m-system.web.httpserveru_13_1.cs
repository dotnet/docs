String TestString = "This is a <Test String>.";
StringWriter writer = new StringWriter();
Server.UrlEncode(TestString, writer);
String EncodedString = writer.ToString();
   