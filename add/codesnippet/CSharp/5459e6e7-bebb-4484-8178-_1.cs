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