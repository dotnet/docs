string xmlData ="<item productID='124390'>" +
                        "<price>5.95</price>" +
                        "</item>";

// Create the XmlReader object.
XmlReader reader = XmlReader.Create(new StringReader(xmlData));