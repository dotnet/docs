    try
    {
        // Attempt to access a static AnotherField field defined in the App class.
        // However, because the App class does not define this field,
        // a MissingFieldException is thrown.
        App::typeid->InvokeMember("AnotherField", BindingFlags::Static |
            BindingFlags::GetField, nullptr, nullptr, nullptr);
    }
    catch (MissingMemberException^ ex)
    {
        // Notice that this code is catching MissingMemberException which is the
        // base class of MissingMethodException and MissingFieldException.
        // Show the user that the AnotherField field cannot be accessed.
        Console::WriteLine("Unable to access the AnotherField field: {0}",
            ex->Message);
    }