        using (XmlWriter writer = XmlWriter.Create("output.xml"))
        {
            writer.WriteStartElement("book");
            writer.WriteElementString("price", "19.95");
            writer.WriteEndElement();
            writer.Flush();
        }
