        public static void WriteObjectContentInDocument(string path)
        {
            // Create the object to serialize.
            Person p = new Person("Lynn", "Tsoflias", 9876);

            // Create the writer object.
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlDictionaryWriter writer =
                XmlDictionaryWriter.CreateTextWriter(fs);

            DataContractSerializer ser =
                new DataContractSerializer(typeof(Person));

            // Use the writer to start a document.
            writer.WriteStartDocument(true);

            // Use the writer to write the root element.
            writer.WriteStartElement("Company");

            // Use the writer to write an element.
            writer.WriteElementString("Name", "Microsoft");

            // Use the serializer to write the start,
            // content, and end data.
            ser.WriteStartObject(writer, p);
            ser.WriteObjectContent(writer, p);
            ser.WriteEndObject(writer);

            // Use the writer to write the end element and
            // the end of the document.
            writer.WriteEndElement();
            writer.WriteEndDocument();

            // Close and release the writer resources.
            writer.Flush();
            fs.Flush();
            fs.Close();
        }