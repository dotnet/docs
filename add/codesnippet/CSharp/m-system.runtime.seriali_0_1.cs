    private void DisplaySerializationInfo(SerializationInfo info)
    {
        SerializationInfoEnumerator e = info.GetEnumerator();
        Console.WriteLine("Values in the SerializationInfo:");
        while (e.MoveNext())
        {
            Console.WriteLine("Name={0}, ObjectType={1}, Value={2}", e.Name, e.ObjectType, e.Value);
        }
    }