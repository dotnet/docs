        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.NewLineOnAttributes = true;
        XmlWriter writer = XmlWriter.Create("books.xml", settings);