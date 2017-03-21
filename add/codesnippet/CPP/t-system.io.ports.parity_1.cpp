    static Parity SetPortParity(Parity defaultPortParity)
    {
        String^ parity;

        Console::WriteLine("Available Parity options:");
        for each (String^ s in Enum::GetNames(Parity::typeid))
        {
            Console::WriteLine("   {0}", s);
        }
		
        Console::Write("Enter Parity value (Default: {0}):", defaultPortParity.ToString());
        parity = Console::ReadLine();

        if (parity == "")
        {
            parity = defaultPortParity.ToString();
        }

        return (Parity)Enum::Parse(Parity::typeid, parity);
    }