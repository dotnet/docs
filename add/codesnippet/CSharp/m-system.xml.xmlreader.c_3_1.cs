
FileStream fs = new FileStream(@"C:\data\books.xml", FileMode.OpenOrCreate, 
                                                                    FileAccess.Read, FileShare.Read);

// Create the XmlReader object.
XmlReader reader = XmlReader.Create(fs);