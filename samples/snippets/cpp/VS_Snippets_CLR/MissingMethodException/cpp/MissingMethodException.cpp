//Types:System.MissingMethodException Vendor: Richter
//Types:System.MissingMemberException Vendor: Richter
//Types:System.MissingFieldException Vendor: Richter
//<snippet1>
using namespace System;
using namespace System::Reflection;

ref class App
{
};

int main()
{
    //<snippet2>
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
    //</snippet2>

    //<snippet3>
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
    //</snippet3>

    //<snippet4>
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
    //</snippet4>
}
// This code produces the following output.
//
// Unable to call the DoSomething method: Method 'App.DoSomething' not found.
// Unable to access the AField field: Field 'App.AField' not found.
// Unable to access the AnotherField field: Field 'App.AnotherField' not found.
//</snippet1>
