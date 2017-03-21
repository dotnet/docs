        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.OmitXmlDeclaration = true;
        using (XmlWriter writer = XmlWriter.Create(Console.Out, settings))
        {
            writer.WriteStartElement("root");
            writer.WriteAttributeString("xmlns", "x", null, "urn:abc");
            writer.WriteStartElement("item");
            writer.WriteStartAttribute("href", null);
            writer.WriteString("#");
            writer.WriteQualifiedName("test", "urn:abc");
            writer.WriteEndAttribute();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }