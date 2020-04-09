// <snippet0>
#using <System.EnterpriseServices.dll>

using namespace System;
using namespace System::EnterpriseServices;

// References:
// System.EnterpriseServices

// <snippet1>

// Note: Access checks must be performed at the component level to allow access
// to private components.
[assembly: ApplicationAccessControl(false,
AccessChecksLevel=AccessChecksLevelOption::ApplicationComponent)];

[PrivateComponent]
public ref class PrivateComponentAttributeExample : public ServicedComponent
{
public:
    void DisplayMessage()
    {
        // Display some output.
        Console::WriteLine("Private component called successfully.");
    }
};
// </snippet1>

public ref class PrivateComponentAttributeTest : public ServicedComponent
{
public:
    static void Test()
    {
        // Create a new instance of the example class.
        PrivateComponentAttributeExample^ example =
            gcnew PrivateComponentAttributeExample();

        // Call a method on the class.
        example->DisplayMessage();
    }
};


// </snippet0>
 
