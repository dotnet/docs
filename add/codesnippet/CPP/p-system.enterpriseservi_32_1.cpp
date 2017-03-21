[Synchronization(SynchronizationOption::Required)]
public ref class ContextUtil_ApplicationInstanceId: public ServicedComponent
{
public:
   void Example()
   {
      // Display the ApplicationInstanceId associated with the current COM+
      // context.
      Console::WriteLine( "Application Instance ID: {0}", 
         ContextUtil::ApplicationInstanceId );
   }
};