//<Snippet1>
using namespace System;
using namespace Microsoft::Win32;

int main()
{   
    // The name of the key must include a valid root.
    String^ userRoot = "HKEY_CURRENT_USER";
    String^ subKey = "RegistrySetValueExample2";
    String^ keyName = String::Concat(userRoot, "\\", subKey);
    
    // An int value can be stored without specifying the
    // registry data type, but Int64 values will be stored
    // as strings unless you specify the type. Note that
    // the int is stored in the default name/value
    // pair.
    Registry::SetValue(keyName, "", 5280);
    Registry::SetValue(keyName, "TestInt64", 12345678901234, 
        RegistryValueKind::QWord);
    
    // Strings with expandable environment variables are
    // stored as ordinary strings unless you specify the
    // data type.
    Registry::SetValue(keyName, "TestExpand", "My path: %path%");
    Registry::SetValue(keyName, "TestExpand2", "My path: %path%", 
        RegistryValueKind::ExpandString);
    
    // Arrays of strings are stored automatically as 
    // MultiString. Similarly, arrays of Byte are stored
    // automatically as Binary.
    array<String^>^ strings  = {"One", "Two", "Three"};
    Registry::SetValue(keyName, "TestArray", strings);
    
    // Your default value is returned if the name/value pair
    // does not exist.
    String^ noSuch = (String^)Registry::GetValue(keyName, 
        "NoSuchName", 
        "Return this default if NoSuchName does not exist.");
    Console::WriteLine("\r\nNoSuchName: {0}", noSuch);
    
    // Retrieve the int and Int64 values, specifying 
    // numeric default values in case the name/value pairs
    // do not exist. The int value is retrieved from the
    // default (nameless) name/value pair for the key.
    int testInteger = (int)Registry::GetValue(keyName, "", -1);
    Console::WriteLine("(Default): {0}", testInteger);
    long long testInt64 = (long long)Registry::GetValue(keyName, 
        "TestInt64", System::Int64::MinValue);
    Console::WriteLine("TestInt64: {0}", testInt64);
    
    // When retrieving a MultiString value, you can specify
    // an array for the default return value. 
    array<String^>^ testArray = (array<String^>^)Registry::GetValue(
        keyName, "TestArray", 
        gcnew array<String^> {"Default if TestArray does not exist."});
    for (int i = 0; i < testArray->Length; i++)
    {
        Console::WriteLine("TestArray({0}): {1}", i, testArray[i]);
    }
    
    // A string with embedded environment variables is not
    // expanded if it was stored as an ordinary string.
    String^ testExpand = (String^)Registry::GetValue(keyName, 
        "TestExpand", "Default if TestExpand does not exist.");
    Console::WriteLine("TestExpand: {0}", testExpand);
    
    // A string stored as ExpandString is expanded.
    String^ testExpand2 = (String^)Registry::GetValue(keyName, 
        "TestExpand2", "Default if TestExpand2 does not exist.");
    Console::WriteLine(
        "TestExpand2: {0}...", testExpand2->Substring(0, 40));
    Console::WriteLine(
        "\r\nUse the registry editor to examine the key.");
    Console::WriteLine("Press the Enter key to delete the key.");
    Console::ReadLine();
    Registry::CurrentUser->DeleteSubKey(subKey);
}
//
// This code example produces output similar to the following:
//
// NoSuchName: Return this default if NoSuchName does not exist.
// (Default): 5280
// TestInt64: 12345678901234
// TestArray(0): One
// TestArray(1): Two
// TestArray(2): Three
// TestExpand: My path: %path%
// TestExpand2: My path: D:\Program Files\Microsoft.NET\...
//
// Use the registry editor to examine the key.
// Press the Enter key to delete the key.
//</Snippet1>
