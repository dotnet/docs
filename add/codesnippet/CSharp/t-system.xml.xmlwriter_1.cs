        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "\t";
        XmlWriter writer = XmlWriter.Create("books.xml", settings);