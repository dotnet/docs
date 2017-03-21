        XmlWriterSettings settings = new XmlWriterSettings();
        settings.OmitXmlDeclaration = true;
        StringWriter sw = new StringWriter();

        using (XmlWriter writer = XmlWriter.Create(sw, settings))
        {
            writer.WriteStartElement("book");
            writer.WriteElementString("price", "19.95");
            writer.WriteEndElement();
            writer.Flush();

            String output = sw.ToString();
        }
