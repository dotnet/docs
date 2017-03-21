private void TestDocument(string filename, Type objType)
{
   // Using a FileStream, create an XmlTextReader.
   Stream fs = new FileStream(filename, FileMode.Open);
   XmlReader reader = new XmlTextReader(fs);
   XmlSerializer serializer = new XmlSerializer(objType);
   if(serializer.CanDeserialize(reader))
      {
         Object o = serializer.Deserialize(reader);
      }
   fs.Close();
}
