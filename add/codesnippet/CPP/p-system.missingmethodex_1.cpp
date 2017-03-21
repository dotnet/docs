    try
    {
        // Attempt to call a static DoSomething method defined in the App class.
        // However, because the App class does not define this method,
        // a MissingMethodException is thrown.
        App::typeid->InvokeMember("DoSomething", BindingFlags::Static |
            BindingFlags::InvokeMethod, nullptr, nullptr, nullptr);
    }
    catch (MissingMethodException^ ex)
    {
        // Show the user that the DoSomething method cannot be called.
        Console::WriteLine("Unable to call the DoSomething method: {0}",
            ex->Message);
    }