    class MyDataContractResolver : DataContractResolver
    {
        private Dictionary<string, XmlDictionaryString> dictionary = new Dictionary<string, XmlDictionaryString>();
        Assembly assembly;

        // Definition of the DataContractResolver
        public MyDataContractResolver(Assembly assembly)
        {
            this.assembly = assembly;
        }

        // Used at deserialization
        // Allows users to map xsi:type name to any Type 
        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            XmlDictionaryString tName;
            XmlDictionaryString tNamespace;
            if (dictionary.TryGetValue(typeName, out tName) && dictionary.TryGetValue(typeNamespace, out tNamespace))
            {
                return this.assembly.GetType(tNamespace.Value + "." + tName.Value);
            }
            else
            {
                return null;
            }
        }
        // Used at serialization
        // Maps any Type to a new xsi:type representation
        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            string name = type.Name;
            string namesp = type.Namespace;
            typeName = new XmlDictionaryString(XmlDictionary.Empty, name, 0); 
            typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, namesp, 0);
            if (!dictionary.ContainsKey(type.Name))
            {
                dictionary.Add(name, typeName);
            }
            if (!dictionary.ContainsKey(type.Namespace))
            {
                dictionary.Add(namesp, typeNamespace);
            }
            return true;
        }
    }