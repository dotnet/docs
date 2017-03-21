        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
           writer.WriteStartElement(textTag);

           foreach (string str in bodySegment)
           {
               writer.WriteString(str);
           }
 
            writer.WriteEndElement();
        }