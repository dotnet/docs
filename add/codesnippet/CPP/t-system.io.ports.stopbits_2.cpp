    static StopBits SetPortStopBits(StopBits defaultPortStopBits)
    {
        String^ stopBits;

        Console::WriteLine("Available Stop Bits options:");
        for each (String^ s in Enum::GetNames(StopBits::typeid))
        {
            Console::WriteLine("   {0}", s);
        }

        Console::Write("Enter StopBits value (None is not supported and \n" +
            "raises an ArgumentOutOfRangeException. \n (Default: {0}):", defaultPortStopBits.ToString());
        stopBits = Console::ReadLine();

        if (stopBits == "")
        {
            stopBits = defaultPortStopBits.ToString();
        }

        return (StopBits)Enum::Parse(StopBits::typeid, stopBits);
    }