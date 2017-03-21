    static Handshake SetPortHandshake(Handshake defaultPortHandshake)
    {
        String^ handshake;

        Console::WriteLine("Available Handshake options:");
        for each (String^ s in Enum::GetNames(Handshake::typeid))
        {
            Console::WriteLine("   {0}", s);
        }

        Console::Write("Enter Handshake value (Default: {0}):", defaultPortHandshake.ToString());
        handshake = Console::ReadLine();

        if (handshake == "")
        {
            handshake = defaultPortHandshake.ToString();
        }

        return (Handshake)Enum::Parse(Handshake::typeid, handshake);
    }