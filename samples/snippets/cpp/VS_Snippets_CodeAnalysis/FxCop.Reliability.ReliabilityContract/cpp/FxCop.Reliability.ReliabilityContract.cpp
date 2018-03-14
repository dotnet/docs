//<Snippet1>
using namespace System;
using namespace System::Runtime::ConstrainedExecution;

[assembly:ReliabilityContractAttribute(
   Consistency::MayCorruptInstance, Cer::None)];
namespace ReliabilityLibrary
{
   class SomeClass {};
}
//</Snippet1>