#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
int main()
{
   
   //<Snippet1>
   if (  !PerformanceCounterCategory::Exists( "Orders" ) )
   {
      CounterCreationData^ milk = gcnew CounterCreationData;
      milk->CounterName = "milk";
      milk->CounterType = PerformanceCounterType::NumberOfItems32;

      CounterCreationData^ milkPerSecond = gcnew CounterCreationData;
      milkPerSecond->CounterName = "milk orders/second";
      milkPerSecond->CounterType = PerformanceCounterType::RateOfCountsPerSecond32;

      CounterCreationDataCollection^ ccds = gcnew CounterCreationDataCollection;
      ccds->Add( milkPerSecond );
      ccds->Add( milk );
      PerformanceCounterCategory::Create( "Orders", "Number of processed orders", ccds );
   }
   //</Snippet1>
}
