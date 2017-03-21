    public object GetDeserializedObject(Object obj , Type targetType) 
    {
        Console.WriteLine("GetDeserializedObject invoked");
        // This method is called on deserialization.
        // If PersonSurrogated is being deserialized...
        if (obj is PersonSurrogated)
            {
                //... use the XmlSerializer to do the actual deserialization.
                PersonSurrogated ps = (PersonSurrogated)obj;
                XmlSerializer xs = new XmlSerializer(typeof(Person));
                return (Person)xs.Deserialize(new StringReader(ps.xmlData));
            }
            return obj;

    }