        public static async Task<bool> ReadToNextSiblingAsync(this XmlReader reader, string localName, string namespaceURI)
        {
            if (localName == null || localName.Length == 0)
            {
                throw new ArgumentException("localName is empty or null");
            }
            if (namespaceURI == null)
            {
                throw new ArgumentNullException("namespaceURI");
            }

            // atomize local name and namespace
            localName = reader.NameTable.Add(localName);
            namespaceURI = reader.NameTable.Add(namespaceURI);

            // find the next sibling
            XmlNodeType nt;
            do
            {
                await reader.SkipAsync();
                if (reader.ReadState != ReadState.Interactive)
                    break;
                nt = reader.NodeType;
                if (nt == XmlNodeType.Element &&
                     ((object)localName == (object)reader.LocalName) &&
                     ((object)namespaceURI ==(object)reader.NamespaceURI))
                {
                    return true;
                }
            } while (nt != XmlNodeType.EndElement && !reader.EOF);
            
            return false;
        }