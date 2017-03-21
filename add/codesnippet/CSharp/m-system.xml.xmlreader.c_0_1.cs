// Set the validation settings.
XmlReaderSettings settings = new XmlReaderSettings();
settings.DtdProcessing = DtdProcessing.Parse;
settings.ValidationType = ValidationType.DTD;
settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
 
 // Create the XmlReader object.
XmlReader reader = XmlReader.Create("itemDTD.xml", settings);

// Parse the file. 
while (reader.Read()) {}