    public sealed class ShowWriteStartObject
    {

        public static void WriteObjectData(string path)
        {
            // Create the object to serialize.
            Person p = new Person("Lynn", "Tsoflias", 9876);

            // Create the writer.
            FileStream fs = new FileStream(path, FileMode.Create);
            XmlDictionaryWriter writer =
                XmlDictionaryWriter.CreateTextWriter(fs);

            NetDataContractSerializer ser =
                new NetDataContractSerializer();

            // Use the writer to start a document.
            writer.WriteStartDocument(true);

            // Use the serializer to write the start of the 
            // object data. Use it again to write the object
            // data. 
            ser.WriteStartObject(writer, p);
            ser.WriteObjectContent(writer, p);

            // Use the serializer to write the end of the 
            // object data. Then use the writer to write the end
            // of the document.
            ser.WriteEndObject(writer);
            writer.WriteEndDocument();

            Console.WriteLine("Done");

            // Close and release the writer resources.
            writer.Flush();
            fs.Flush();
            fs.Close();
        }