    // Display parameter information.
    array<ParameterInfo^>^ parameters = hello->GetParameters();
    Console::WriteLine("\r\nParameters: name, type, ParameterAttributes");
    for each (ParameterInfo^ p in parameters)
    {
        Console::WriteLine("\t{0}, {1}, {2}", 
            p->Name, p->ParameterType, p->Attributes);
    }