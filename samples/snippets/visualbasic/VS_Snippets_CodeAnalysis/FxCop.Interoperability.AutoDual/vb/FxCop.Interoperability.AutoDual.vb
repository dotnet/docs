'<Snippet1>
Imports System
Imports System.Runtime.InteropServices

<Assembly: ComVisibleAttribute(True)>
Namespace InteroperabilityLibrary

   ' This violates the rule.
   <ClassInterfaceAttribute(ClassInterfaceType.AutoDual)> _ 
   Public Class DualInterface
      Public Sub SomeSub
      End Sub
   End Class

   Public Interface IExplicitInterface
      Sub SomeSub
   End Interface

   <ClassInterfaceAttribute(ClassInterfaceType.None)> _ 
   Public Class ExplicitInterface
      Implements IExplicitInterface

      Public Sub SomeSub Implements IExplicitInterface.SomeSub
      End Sub

   End Class

End Namespace
'</Snippet1>
