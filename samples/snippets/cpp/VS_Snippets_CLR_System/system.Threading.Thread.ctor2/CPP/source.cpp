
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class Work
{
public:
   Work(){}

   void DoWork(){}

};

int main()
{
   Work^ threadWork = gcnew Work;
   Thread^ newThread = gcnew Thread( gcnew ThreadStart( threadWork, &Work::DoWork ) );
   newThread->Start();
}

// </Snippet1>
