//<Snippet1>
using namespace System::Threading;
using namespace System::Security::Permissions;

public ref class MyUtility
{
public:
   [SecurityPermissionAttribute(SecurityAction::Demand, ControlThread=true)]
   void PerformTask()
   {
      // Code that does not have thread affinity goes here.
      //
      Thread::BeginThreadAffinity();
      //
      // Code that has thread affinity goes here.
      //
      Thread::EndThreadAffinity();
      //
      // More code that does not have thread affinity.
   }
};
//</Snippet1>

int main() {}
