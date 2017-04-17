'<Snippet1>
Imports System
Imports System.Runtime.InteropServices

<Assembly: ComVisibleAttribute(False)>
Namespace InteroperabilityLibrary

   <ComVisibleAttribute(True)> _ 
   Public Structure SomeStructure

      Friend SomeInteger As Integer

   End Structure

End Namespace
'</Snippet1>
