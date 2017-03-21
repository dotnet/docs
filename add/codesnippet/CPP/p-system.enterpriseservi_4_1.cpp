[Synchronization(SynchronizationOption::Required)]
public ref class ContextUtil_ActivityId: public ServicedComponent
{
public:
   void Example()
   {
      // Display the ActivityID associated with the current COM+ context.
      Console::WriteLine( "Activity ID: {0}", ContextUtil::ActivityId );
   }
};