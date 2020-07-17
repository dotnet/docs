// Class1.cpp
#include "pch.h"
#include "Class1.h"
#include <string>

using namespace ExceptionTest;
using namespace Platform;
using namespace Windows::Storage;
using namespace concurrency;

Class1::Class1()
{
}

//<snippet01>
String^ Class1::MyMethod(String^ argument)
{
    
    if (argument->Length() == 0) 
    { 
        auto e = ref new Exception(-1, "I'm Zork bringing you this message from across the ABI.");
        //throw ref new InvalidArgumentException();
        throw e;
    }
    
    return MyMethodInternal(argument);
}
//</snippet01>

//<snippet02>
void Class2::ProcessString(String^ input)
{
    String^ result = nullptr;    
    auto obj = ref new Class1();

    try 
    {
        result = obj->MyMethod(input);
    }

    catch (/*InvalidArgument*/Exception^ e)
    {
        // Handle the exception in a way that's appropriate 
        // for your particular scenario. Assume
        // here that this string enables graceful
        // recover-and-continue. Why not?
        result = ref new String(L"forty two");
        
        // You can use Exception data for logging purposes.
        Windows::Globalization::Calendar calendar;
        LogMyErrors(calendar.GetDateTime(), e->HResult, e->Message);
    }

    // Execution continues here in both cases.
    //#include <string>
    std::wstring ws(result->Data());
    //...
}
//</snippet02>

void Class2::LogMyErrors(Windows::Foundation::DateTime dt, HRESULT hr, Platform::String^ message)
{
    auto storageFolder = KnownFolders::DocumentsLibrary;
    auto str = dt.ToString();
    create_task(storageFolder->CreateFileAsync("UnhandledException.txt")).then([message](StorageFile^ file)
    {
        FileIO::WriteTextAsync(file, message);
    });
}