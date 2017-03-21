        Console::WriteLine("Hello World");
        FileStream^ fs = gcnew FileStream("Test.txt", FileMode::Create);
        // First, save the standard output.
        TextWriter^ tmp = Console::Out;
        StreamWriter^ sw = gcnew StreamWriter(fs);
        Console::SetOut(sw);
        Console::WriteLine("Hello file");
        Console::SetOut(tmp);
        Console::WriteLine("Hello World");
        sw->Close();