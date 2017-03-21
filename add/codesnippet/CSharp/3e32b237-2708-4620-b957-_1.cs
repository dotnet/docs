  XmlDocument doc = new XmlDocument();
  doc.Load("books.xml");

  // Modify the XML file.
  XmlElement root = doc.DocumentElement;
  root.FirstChild.LastChild.InnerText = "12.95";

  // Create an XPathNavigator to use for the transform.
  XPathNavigator nav = root.CreateNavigator();
  
  // Transform the file.
  XslTransform xslt = new XslTransform();
  xslt.Load("output.xsl");
  XmlTextWriter writer = new XmlTextWriter("books.html", null);
  xslt.Transform(nav, null, writer, null);