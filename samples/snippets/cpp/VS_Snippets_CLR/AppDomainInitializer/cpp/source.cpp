//<Snippet1>
using namespace System;
using namespace System::Security::Policy;

public ref class AppDomainInitializerExample
{
    // The callback method invoked when the child application domain is
    // initialized. The method simply displays the arguments that were
    // passed to it.
    //
public:
    static void AppDomainInit(array<String^>^ args)
    {
        Console::WriteLine("AppDomain \"{0}\" is initialized with these " +
            "arguments:", AppDomain::CurrentDomain->FriendlyName);
        for each (String^ arg in args)
        {
            Console::WriteLine("    {0}", arg);
        }
    }
};

int main()
{
    // Get a reference to the default application domain.
    //
    AppDomain^ currentDomain = AppDomain::CurrentDomain;
    
    // Create the AppDomainSetup that will be used to set up the child
    // AppDomain.
    AppDomainSetup^ domainSetup = gcnew AppDomainSetup();

    // Use the evidence from the default application domain to
    // create evidence for the child application domain.
    //
    Evidence^ evidence = gcnew Evidence(currentDomain->Evidence);

    // Create an AppDomainInitializer delegate that represents the
    // callback method, AppDomainInit. Assign this delegate to the
    // AppDomainInitializer property of the AppDomainSetup object.
    //
    AppDomainInitializer^ domainInitializer =
        gcnew AppDomainInitializer(AppDomainInitializerExample::AppDomainInit);
    domainSetup->AppDomainInitializer = domainInitializer;

    // Create an array of strings to pass as arguments to the callback
    // method. Assign the array to the AppDomainInitializerArguments
    // property.
    array<String^>^ initialArguments = {"String1", "String2"};
    domainSetup->AppDomainInitializerArguments = initialArguments;

    // Create a child application domain named "ChildDomain", using
    // the evidence and the AppDomainSetup object.
    //
    AppDomain^ appDomain = AppDomain::CreateDomain("ChildDomain",
        evidence, domainSetup);

    Console::WriteLine("Press the Enter key to exit the example program.");
    Console::ReadLine();
}

/* This code example produces the following output:

AppDomain "ChildDomain" is initialized with these arguments:
String1
String2
*/
//</Snippet1>
