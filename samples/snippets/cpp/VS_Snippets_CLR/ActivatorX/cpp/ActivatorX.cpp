//Types:System.Activator Vendor: Richter (xlated to cpp by glennha)
//<snippet1>
using namespace System;
using namespace System::Reflection;
using namespace System::Text;

public ref class SomeType
{
public:
    void DoSomething(int x)
    {
        Console::WriteLine("100 / {0} = {1}", x, 100 / x);
    }
};

void main()
{
    //<snippet2> 
    // Create an instance of the StringBuilder type using 
    // Activator.CreateInstance.
    Object^ o = Activator::CreateInstance(StringBuilder::typeid);

    // Append a string into the StringBuilder object and display the 
    // StringBuilder.
    StringBuilder^ sb = (StringBuilder^) o;
    sb->Append("Hello, there.");
    Console::WriteLine(sb);
    //</snippet2>

    //<snippet3>
    // Create an instance of the SomeType class that is defined in this 
    // assembly.
    System::Runtime::Remoting::ObjectHandle^ oh = 
        Activator::CreateInstanceFrom(Assembly::GetEntryAssembly()->CodeBase, 
                                      SomeType::typeid->FullName);

    // Call an instance method defined by the SomeType type using this object.
    SomeType^ st = (SomeType^) oh->Unwrap();

    st->DoSomething(5);
    //</snippet3>
};

/* This code produces the following output:
 
Hello, there.
100 / 5 = 20
 */
//</snippet1>