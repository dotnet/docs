'<Snippet1>
Imports System
Imports System.Runtime.InteropServices

<Assembly: ComVisibleAttribute(False)>
Namespace InteroperabilityLibrary

   <ComVisibleAttribute(False)> _ 
   Public Class BaseClass

      Sub SomeSub(valueOne As Integer)
      End Sub

   End Class

   ' This class violates the rule.
   <ComVisibleAttribute(True)> _ 
   Public Class DerivedClass
      Inherits BaseClass

      Sub AnotherSub(valueOne As Integer, valueTwo As Integer)
      End Sub

   End Class

End Namespace
'</Snippet1>
