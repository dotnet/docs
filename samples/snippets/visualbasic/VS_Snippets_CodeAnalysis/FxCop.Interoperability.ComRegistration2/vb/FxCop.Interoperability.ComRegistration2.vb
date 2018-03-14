'<Snippet1>
Imports System
Imports System.Runtime.InteropServices

<Assembly: ComVisibleAttribute(True)>
Namespace InteroperabilityLibrary

   Public Class ClassToRegister
   End Class

   Public Class ComRegistration

      <ComRegisterFunctionAttribute> _ 
      Public Shared Sub RegisterFunction(typeToRegister As Type)
      End Sub

      <ComUnregisterFunctionAttribute> _ 
      Public Shared Sub UnregisterFunction(typeToRegister As Type)
      End Sub

   End Class

End Namespace
'</Snippet1>
