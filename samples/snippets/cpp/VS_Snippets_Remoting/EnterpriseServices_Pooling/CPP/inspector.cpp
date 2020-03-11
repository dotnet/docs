

// <snippet0>
#using <System.Windows.Forms.dll>
#using <System.Transactions.dll>
#using <System.EnterpriseServices.dll>

using namespace System;
using namespace System::EnterpriseServices;
using namespace System::Windows::Forms;

// <snippet1>

[assembly:ApplicationName("ObjectInspector")];
[assembly:ApplicationActivation(ActivationOption::Server)];
[assembly:System::Reflection::AssemblyKeyFile("Inspector.snk")];
[JustInTimeActivation]
[ObjectPooling(MinPoolSize=2,MaxPoolSize=100,CreationTimeout=1000)]
public ref class ObjectInspector: public ServicedComponent
{
   // <snippet2>
public:
   String^ IdentifyObject( Object^ obj )
   {
      // Return this object to the pool after use.
      ContextUtil::DeactivateOnReturn = true;

      // Get the supplied object's type.        
      Type^ objType = obj->GetType();

      // Return its name.
      return (objType->FullName);
   }
   // </snippet2>

   // <snippet3>
protected:
   virtual void Activate() override
   {
      MessageBox::Show( String::Format( "Now entering...\nApplication: {0}\nInstance: {1}\nContext: {2}\n", ContextUtil::ApplicationId.ToString(), ContextUtil::ApplicationInstanceId.ToString(), ContextUtil::ContextId.ToString() ) );
   }
   // </snippet3>

   // <snippet4>
   virtual void Deactivate() override
   {
      MessageBox::Show( "Bye Bye!" );
   }
   // </snippet4>

   // <snippet5>
   // This object can be pooled.
   virtual bool CanBePooled() override
   {
      return (true);
   }
   // </snippet5>
};
// </snippet1>
// </snippet0>
