        public static async Task ReadStartElementAsync(this XmlReader reader, string localname, string ns)
        {
            if (await reader.MoveToContentAsync() != XmlNodeType.Element)
            {
                throw new InvalidOperationException(reader.NodeType.ToString() + " is an invalid XmlNodeType");
            }
            if ((reader.LocalName == localname) && (reader.NamespaceURI == ns))
            {
                await reader.ReadAsync();
            }
            else
            {
                throw new InvalidOperationException("localName or namespace doesn’t match");
            }
        }