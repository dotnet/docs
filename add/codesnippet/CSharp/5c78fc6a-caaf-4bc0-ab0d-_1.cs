public object GetObjectToSerialize(object obj, Type targetType)
{ 
        Console.WriteLine("GetObjectToSerialize Invoked");
        Console.WriteLine("\t type name: {0}", obj.ToString());
        Console.WriteLine("\t target type: {0}", targetType.Name);
        // This method is called on serialization.
        // If Person is not being serialized...
        if (obj is Person )
        {
            Console.WriteLine("\t returning PersonSurrogated");
            // ... use the XmlSerializer to perform the actual serialization.
            PersonSurrogated  ps = new PersonSurrogated();
            XmlSerializer xs = new XmlSerializer(typeof(Person));
            StringWriter sw = new StringWriter();
            xs.Serialize(sw, (Person)obj );
            ps.xmlData = sw.ToString();
            return ps;
        }
        return obj;

    }