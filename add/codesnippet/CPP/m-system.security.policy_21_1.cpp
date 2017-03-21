
static void DisplayConnectionAccessRules(NetCodeGroup^ group)
{
    array<System::Collections::DictionaryEntry>^ rules = 
        group->GetConnectAccessRules();
    for each (System::Collections::DictionaryEntry^ o in rules)
    {
        String^ key = (String^)(o->Key);
        array<CodeConnectAccess^>^ values = (array<CodeConnectAccess^>^)(o->Value);
        Console::WriteLine("Origin scheme: {0}", key);
        for each (CodeConnectAccess^ c in values)
        {
            Console::WriteLine("Scheme {0} Port: {1}", c->Scheme, c->Port);
        }
        Console::WriteLine("__________________________");
    }
}