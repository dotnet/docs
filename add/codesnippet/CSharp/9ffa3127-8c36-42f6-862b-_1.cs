    public Type GetReferencedTypeOnImport(string typeName,
        string typeNamespace, object customData)
    {
        Console.WriteLine("GetReferencedTypeOnImport invoked");
        // This method is called on schema import.
        // If a PersonSurrogated data contract is 
        // in the specified namespace, do not create a new type for it 
        // because there is already an existing type, "Person".
        Console.WriteLine( "\t Type Name: {0}", typeName);
        
        if (typeName.Equals("PersonSurrogated") )
        {
            Console.WriteLine("Returning Person");
            return typeof(Person);
        }        
        return null;
    }