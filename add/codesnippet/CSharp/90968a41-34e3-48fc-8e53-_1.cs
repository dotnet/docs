    public Type GetDataContractType(Type type) 
{
        Console.WriteLine("GetDataContractType invoked");
        Console.WriteLine("\t type name: {0}", type.Name);
        // "Person" will be serialized as "PersonSurrogated"
        // This method is called during serialization,
        // deserialization, and schema export.
        if (typeof(Person).IsAssignableFrom(type)) 
{
Console.WriteLine("\t returning PersonSurrogated");
            return typeof(PersonSurrogated);
        }
        return type;

    }