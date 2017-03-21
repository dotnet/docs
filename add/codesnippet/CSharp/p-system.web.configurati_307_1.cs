// Get the current SerializeAs property value.
Console.WriteLine(
    "Current SerializeAs value: '{0}'", profilePropertySettings.SerializeAs);

// Set the SerializeAs property to SerializationMode.Binary.
profilePropertySettings.SerializeAs = SerializationMode.Binary;