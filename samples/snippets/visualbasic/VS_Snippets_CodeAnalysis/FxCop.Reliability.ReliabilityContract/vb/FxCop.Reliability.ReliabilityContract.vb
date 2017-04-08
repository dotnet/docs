'<Snippet1>
Imports System
Imports System.Runtime.ConstrainedExecution

<assembly:ReliabilityContractAttribute( _ 
   Consistency.MayCorruptInstance, Cer.None)> 
Namespace ReliabilityLibrary
   Class SomeClass
   End Class
End Namespace
'</Snippet1>