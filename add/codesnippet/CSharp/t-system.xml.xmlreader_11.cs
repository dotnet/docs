        public static async Task<bool> ReadToDescendantAsync(this XmlReader reader, string localName, string namespaceURI)
        {
            if (localName == null || localName.Length == 0)
            {
                throw new ArgumentException("localName is empty or null");
            }
            if (namespaceURI == null)
            {
                throw new ArgumentNullException("namespaceURI");
            }
            // save the element or root depth
            int parentDepth = reader.Depth;
            if (reader.NodeType != XmlNodeType.Element)
            {
                // adjust the depth if we are on root node
                if (reader.ReadState == ReadState.Initial)
                {
                    parentDepth--;
                }
                else
                {
                    return false;
                }
            }
            else if (reader.IsEmptyElement)
            {
                return false;
            }

            // atomize local name and namespace
            localName = reader.NameTable.Add(localName);
            namespaceURI = reader.NameTable.Add(namespaceURI);

            // find the descendant
            while (await reader.ReadAsync() && reader.Depth > parentDepth)
            {
                if (reader.NodeType == XmlNodeType.Element && ((object)localName == (object)reader.LocalName) && ((object)namespaceURI == (object)reader.NamespaceURI))
                {
                    return true;
                }
            }
            return false;
        }