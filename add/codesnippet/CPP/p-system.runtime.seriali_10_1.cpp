private:
    static void DisplaySerializationInfo(SerializationInfo^ info)
    {
        Console::WriteLine("Values in the SerializationInfo:");
        for each (SerializationEntry^ infoEntry in info)
        {
            Console::WriteLine("Name={0}, ObjectType={1}, Value={2}",
                infoEntry->Name, infoEntry->ObjectType, infoEntry->Value);
        }
    }