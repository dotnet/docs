//<Snippet1>
using namespace System;

public interface class ITest
{
    void Test(String^ greeting);
};

public ref class MarshallableExample : MarshalByRefObject, ITest
{
public:
    virtual void Test(String^ greeting)
    {
        Console::WriteLine("{0} from '{1}'!", greeting,
            AppDomain::CurrentDomain->FriendlyName);
    }
};

void main()
{
    // Construct a path to the current assembly.
    String^ assemblyPath = Environment::CurrentDirectory + "\\" +
        MarshallableExample::typeid->Assembly->GetName()->Name + ".exe";

    AppDomain^ ad = AppDomain::CreateDomain("MyDomain");
 
    System::Runtime::Remoting::ObjectHandle^ oh = 
        ad->CreateInstanceFrom(assemblyPath, "MarshallableExample");

    Object^ obj = oh->Unwrap();


    // Three ways to use the newly created object, depending on how
    // much is known about the type: Late bound, early bound through 
    // a mutually known interface, or early binding of a known type.
    //
    obj->GetType()->InvokeMember("Test", 
        System::Reflection::BindingFlags::InvokeMethod, 
        Type::DefaultBinder, obj, gcnew array<Object^> { "Hello" });

    ITest^ it = (ITest^) obj;
    it->Test("Hi");

    MarshallableExample^ ex = (MarshallableExample^) obj;
    ex->Test("Goodbye");
}

/* This example produces the following output:

Hello from 'MyDomain'!
Hi from 'MyDomain'!
Goodbye from 'MyDomain'!
 */
//</Snippet1>
