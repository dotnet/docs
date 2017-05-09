
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class Work
{
private:
   Work(){}


public:
   static void DoWork(){}

};

int main()
{
   Thread^ newThread = gcnew Thread( gcnew ThreadStart( &Work::DoWork ) );
   newThread->Start();
}

// </Snippet1>
