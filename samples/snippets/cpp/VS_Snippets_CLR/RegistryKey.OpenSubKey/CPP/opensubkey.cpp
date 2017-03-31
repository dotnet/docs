//<Snippet1>
#using <Microsoft.VisualBasic.dll>

using namespace System;
using namespace Microsoft::Win32;
using namespace Microsoft::VisualBasic;

int main()
{
    // Delete and recreate the test key.
    Registry::CurrentUser->DeleteSubKey( L"RegistryOpenSubKeyExample", false );
    RegistryKey ^ rk = Registry::CurrentUser->CreateSubKey( L"RegistryOpenSubKeyExample" );
    rk->Close();

    // Obtain an instance of RegistryKey for the CurrentUser registry
    // root.
    RegistryKey ^ rkCurrentUser = Registry::CurrentUser;

    // Obtain the test key (read-only) and display it.
    RegistryKey ^ rkTest = rkCurrentUser->OpenSubKey( L"RegistryOpenSubKeyExample" );
    Console::WriteLine( L"Test key: {0}", rkTest );
    rkTest->Close();
    rkCurrentUser->Close();

    // Obtain the test key in one step, using the CurrentUser registry
    // root.
    rkTest = Registry::CurrentUser->OpenSubKey( L"RegistryOpenSubKeyExample" );
    Console::WriteLine( L"Test key: {0}", rkTest );
    rkTest->Close();

    // Open the test key in read/write mode.
    rkTest = Registry::CurrentUser->OpenSubKey( L"RegistryOpenSubKeyExample", true );
    rkTest->SetValue( L"TestName", L"TestValue" );
    Console::WriteLine( L"Test value for TestName: {0}", rkTest->GetValue( L"TestName" ) );
    rkTest->Close();

    return 0;
} //Main
//</Snippet1>


