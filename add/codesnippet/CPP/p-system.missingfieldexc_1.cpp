    try
    {
        // Attempt to access a static AField field defined in the App class.
        // However, because the App class does not define this field,
        // a MissingFieldException is thrown.
        App::typeid->InvokeMember("AField", BindingFlags::Static |
            BindingFlags::SetField, nullptr, nullptr, gcnew array<Object^>{5});
    }
    catch (MissingFieldException^ ex)
    {
        // Show the user that the AField field cannot be accessed.
        Console::WriteLine("Unable to access the AField field: {0}",
            ex->Message);
    }