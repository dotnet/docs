
using namespace System;
using namespace System::Runtime::InteropServices;

//This namespace is a placeholder for the ECFSRV32Lib - since
// this library may not exist on the build machine we place
// a dummy namespace with dummy classes to keep the compiler
// happy.
namespace ECFSRV32Lib
{
   public ref class BaseComponent{};

   public interface class IObjectActivator
   {
      int CreateBaseComponent( int Aggregator );
   };

   public ref class ObjectActivator: public IObjectActivator
   {
   public:
      virtual int CreateBaseComponent( int Aggregator )
      {
         return 0;
      }
   };
}

// <Snippet1>
public ref class CallBack
{
public:
   IntPtr Activate( IntPtr Aggregator )
   {
      ECFSRV32Lib::ObjectActivator^ oCOM = gcnew ECFSRV32Lib::ObjectActivator;
      ECFSRV32Lib::IObjectActivator^ itf = dynamic_cast<ECFSRV32Lib::IObjectActivator^>(oCOM);
      return (IntPtr)itf->CreateBaseComponent( (int)Aggregator );
   }
};

//
// The EcfInner class. First .NET class derived directly from COM class.
//
public ref class EcfInner: public ECFSRV32Lib::BaseComponent
{
private:
   static CallBack^ callbackInner;
   static void RegisterInner()
   {
      callbackInner = gcnew CallBack;
      System::Runtime::InteropServices::ExtensibleClassFactory::RegisterObjectCreationCallback( gcnew System::Runtime::InteropServices::ObjectCreationDelegate( callbackInner, &CallBack::Activate ) );
   }

   //This is the static initializer.    
   static EcfInner()
   {
      RegisterInner();
   }
};
// </Snippet1>
