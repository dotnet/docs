// <Snippet1>
using namespace System;
using namespace Microsoft::Win32;

public ref class RegGetDef
{
public:
    static void Main()
    {
        // Create a reference to a valid key.  In order for this code to
        // work, the indicated key must have been created previously.
        // The key name is not case-sensitive.
        RegistryKey^ rk = Registry::LocalMachine->OpenSubKey("Software\\myTestKey", false);
        // Get the value from the specified name/value pair in the key.
        String^ valueName = "myTestValue";

        Console::WriteLine("Retrieving registry value ...");
        Console::WriteLine();
        Object^ o = rk->GetValue(valueName);
        Console::WriteLine("Object Type = " + o->GetType()->FullName);
        Console::WriteLine();
        switch (rk->GetValueKind(valueName))
        {
            case RegistryValueKind::String:
            case RegistryValueKind::ExpandString:
                Console::WriteLine("Value = " + o);
                break;
            case RegistryValueKind::Binary:
                for each (Byte^ b in (array<Byte^>^)o)
                {
                    Console::Write("{0:x2} ", b);
                }
                Console::WriteLine();
                break;
            case RegistryValueKind::DWord:
                Console::WriteLine("Value = " + Convert::ToString((Int32^)o));
                break;
            case RegistryValueKind::QWord:
                Console::WriteLine("Value = " + Convert::ToString((Int64^)o));
                break;
            case RegistryValueKind::MultiString:
                for each (String^ s in (array<String^>^)o)
                {
                    Console::Write("[{0:s}], ", s);
                }
                Console::WriteLine();
                break;
            default:
                Console::WriteLine("Value = (Unknown)");
                break;
        }

        // Attempt to retrieve a value that does not exist; the specified
        // default value is returned.
        String^ def = (String^)rk->GetValue("notavalue", "The default to return");
        Console::WriteLine();
        Console::WriteLine(def);
        
        rk->Close();
    }
};

int main()
{
    RegGetDef::Main();
}
/*
Output:
Retrieving registry value ...

Object Type = System.String

Value = testData

The default to return
*/
// </Snippet1>

