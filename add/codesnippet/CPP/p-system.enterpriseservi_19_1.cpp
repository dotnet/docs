
[assembly:ApplicationName("ObjectInspector")];
[assembly:ApplicationActivation(ActivationOption::Server)];
[assembly:System::Reflection::AssemblyKeyFile("Inspector.snk")];
[JustInTimeActivation]
[ObjectPooling(MinPoolSize=2,MaxPoolSize=100,CreationTimeout=1000)]
public ref class ObjectInspector: public ServicedComponent
{
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

protected:
   virtual void Activate() override
   {
      MessageBox::Show( String::Format( "Now entering...\nApplication: {0}\nInstance: {1}\nContext: {2}\n", ContextUtil::ApplicationId.ToString(), ContextUtil::ApplicationInstanceId.ToString(), ContextUtil::ContextId.ToString() ) );
   }

   virtual void Deactivate() override
   {
      MessageBox::Show( "Bye Bye!" );
   }

   // This object can be pooled.
   virtual bool CanBePooled() override
   {
      return (true);
   }
};