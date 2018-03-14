// <Snippet5>
using namespace System;
using namespace Microsoft::Win32;

public ref class RegKeyDel
{
public:
    static void Main()
    {
        // Create a subkey named Test9999 under HKEY_CURRENT_USER.
        RegistryKey^ test9999 =
            Registry::CurrentUser->CreateSubKey("Test9999");
        // Create two subkeys under HKEY_CURRENT_USER\Test9999. The
        // keys are disposed when execution exits the using statement.
        RegistryKey^ testName = test9999->CreateSubKey("TestName");
        RegistryKey^ testSettings = test9999->CreateSubKey("TestSettings");

        // Create data for the TestSettings subkey.
        testSettings->SetValue("Language", "French");
        testSettings->SetValue("Level", "Intermediate");
        testSettings->SetValue("ID", 123);

        // delete the subkey "TestName"
        test9999->DeleteSubKey("TestName");
        // delete everything under and including "Test9999"
        Registry::CurrentUser->DeleteSubKeyTree("Test9999");
    }
};

int main()
{
    RegKeyDel::Main();
}
// </Snippet5>