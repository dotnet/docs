        Double price = 9.95;
        DateTime date = new DateTime(2004, 5, 20);

        using (XmlWriter writer = XmlWriter.Create("data.xml"))
        {
            writer.WriteStartElement("book");
            writer.WriteStartAttribute("pub-date");
            writer.WriteValue(date);
            writer.WriteEndAttribute();

            writer.WriteStartElement("price");
            writer.WriteValue(price);
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.Flush();
        }