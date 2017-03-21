// Create the XmlNodeReader object.
XmlDocument doc = new XmlDocument();
doc.Load("books.xml");
XmlNodeReader nodeReader = new XmlNodeReader(doc);

// Set the validation settings.
XmlReaderSettings settings = new XmlReaderSettings();
settings.ValidationType = ValidationType.Schema;
settings.Schemas.Add("urn:bookstore-schema", "books.xsd");
settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);

// Create a validating reader that wraps the XmlNodeReader object.
XmlReader reader = XmlReader.Create(nodeReader, settings);
// Parse the XML file.
while (reader.Read());
