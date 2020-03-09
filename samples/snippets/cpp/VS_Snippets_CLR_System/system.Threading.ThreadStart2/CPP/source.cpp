
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class Work
{
public:
   static void DoWork()
   {
      Console::WriteLine( "Static thread procedure." );
   }

   int Data;
   void DoMoreWork()
   {
      Console::WriteLine( "Instance thread procedure. Data={0}", Data );
   }

};

int main()
{
   
   // To start a thread using an instance method for the thread 
   // procedure, specify the object as the first argument of the
   // ThreadStart constructor.
   //
   Work^ w = gcnew Work;
   w->Data = 42;
   ThreadStart^ threadDelegate = gcnew ThreadStart( w, &Work::DoMoreWork );
   Thread^ newThread = gcnew Thread( threadDelegate );
   newThread->Start();
   
   // To start a thread using a static thread procedure, specify
   // only the address of the procedure. This is a change from 
   // earlier versions of the .NET Framework, which required 
   // two arguments, the first of which was null (0).
   //
   threadDelegate = gcnew ThreadStart( &Work::DoWork );
   newThread = gcnew Thread( threadDelegate );
   newThread->Start();
}

/* This code example produces the following output (the order 
   of the lines might vary):
Static thread procedure.
Instance thread procedure. Data=42
 */
// </Snippet1>
