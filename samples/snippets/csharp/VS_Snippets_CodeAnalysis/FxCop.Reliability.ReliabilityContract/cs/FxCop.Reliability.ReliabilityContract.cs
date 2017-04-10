//<Snippet1>
using System;
using System.Runtime.ConstrainedExecution;

[assembly:ReliabilityContractAttribute(
   Consistency.MayCorruptInstance, Cer.None)]
namespace ReliabilityLibrary
{
   class SomeClass {}
}
//</Snippet1>