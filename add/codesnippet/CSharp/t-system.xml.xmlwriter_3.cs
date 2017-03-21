        writer.WriteStartElement("x", "root", "123");
        writer.WriteStartElement("item");
        writer.WriteAttributeString("xmlns", "x", null, "abc");
        writer.WriteEndElement();
        writer.WriteEndElement();