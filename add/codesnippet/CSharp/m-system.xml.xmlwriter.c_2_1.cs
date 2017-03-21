XmlWriterSettings settings = new XmlWriterSettings();
settings.OmitXmlDeclaration = true;
settings.ConformanceLevel = ConformanceLevel.Fragment;
settings.CloseOutput = false;

// Create the XmlWriter object and write some content.
MemoryStream strm = new MemoryStream();
XmlWriter writer = XmlWriter.Create(strm, settings);
writer.WriteElementString("orderID", "1-456-ab");
writer.WriteElementString("orderID", "2-36-00a");
writer.Flush();
writer.Close();

// Do additonal processing on the stream.