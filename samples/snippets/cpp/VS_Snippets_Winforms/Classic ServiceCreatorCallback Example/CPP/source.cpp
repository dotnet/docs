#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

// Class added so sample will compile
public ref class myService{};

public ref class Sample
{
public:
   void SampleMethod()
   {
      ServiceContainer^ serviceContainer = gcnew ServiceContainer;
      
      // <Snippet1>
      // The following code shows how to publish a service using a callback function.
      // Creates a service creator callback.
      ServiceCreatorCallback^ callback1 =
         gcnew ServiceCreatorCallback( this, &Sample::myCallBackMethod );
      
      // Adds the service using its type and the service creator callback.
      serviceContainer->AddService( myService::typeid, callback1 );
      // </Snippet1>
   }

   // Method added so class will compile
   Object^ myCallBackMethod( IServiceContainer^ container, Type^ serviceType )
   {
      return gcnew Object;
   }
};
