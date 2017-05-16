//<Snippet1>
using namespace System;
using namespace System::Reflection;

public ref class Worker : MarshalByRefObject
{
public:
    void PrintDomain() 
    { 
        Console::WriteLine("Object is executing in AppDomain \"{0}\"",
            AppDomain::CurrentDomain->FriendlyName); 
    }
};
 
void main()
{
    // Create an ordinary instance in the current AppDomain
    Worker^ localWorker = gcnew Worker();
    localWorker->PrintDomain();
 
    // Create a new application domain, create an instance
    // of Worker in the application domain, and execute code
    // there.
    AppDomain^ ad = AppDomain::CreateDomain("New domain");
    Worker^ remoteWorker = (Worker^) ad->CreateInstanceAndUnwrap(
        Worker::typeid->Assembly->FullName,
        "Worker");
    remoteWorker->PrintDomain();
}

/* This code produces output similar to the following:

Object is executing in AppDomain "source.exe"
Object is executing in AppDomain "New domain"
 */
//</Snippet1>
