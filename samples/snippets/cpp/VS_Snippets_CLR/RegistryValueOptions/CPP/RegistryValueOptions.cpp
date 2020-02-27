// <Snippet1>
#using <Microsoft.VisualBasic.dll>

using namespace System;
using namespace Microsoft::Win32;
using namespace Microsoft::VisualBasic;

int main()
{
    // Delete and recreate the test key.
    Registry::CurrentUser->DeleteSubKey( L"RegistryValueOptionsExample", false );
    RegistryKey ^ rk = 
        Registry::CurrentUser->CreateSubKey( L"RegistryValueOptionsExample" );
   
    // Add a value that contains an environment variable.
    rk->SetValue( L"ExpandValue", L"The path is %PATH%", 
        RegistryValueKind::ExpandString );
   
    // Retrieve the value, first without expanding the environment
    // variable and then expanding it.
    Console::WriteLine( L"Unexpanded: \"{0}\"", 
                        rk->GetValue( L"ExpandValue", 
                        L"No Value", 
                        RegistryValueOptions::DoNotExpandEnvironmentNames ) );
    Console::WriteLine( L"Expanded: \"{0}\"", rk->GetValue( L"ExpandValue" ) );
 
    return 0;
} //Main
// </Snippet1>

