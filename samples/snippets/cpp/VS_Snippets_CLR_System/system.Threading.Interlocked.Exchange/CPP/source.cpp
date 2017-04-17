
// <Snippet1>
using namespace System;
using namespace System::Threading;
ref class AtomicExchange
{
private:
   ref class SomeType{};


   // To use Interlocked::Exchange, someType1 
   // must be declared as type Object*.
   Object^ someType1;
   SomeType^ someType2;

public:
   AtomicExchange()
   {
      someType1 = gcnew SomeType;
      someType2 = gcnew SomeType;
   }

   void Switch()
   {
      someType2 = dynamic_cast<SomeType^>(Interlocked::Exchange( someType1, dynamic_cast<Object^>(someType2) ));
   }

};

int main()
{
   AtomicExchange^ atomicExchange = gcnew AtomicExchange;
   Thread^ firstThread = gcnew Thread( gcnew ThreadStart( atomicExchange, &AtomicExchange::Switch ) );
   firstThread->Start();
}

// </Snippet1>
