'<Snippet1>
Imports System
Imports System.Runtime.InteropServices

<Assembly: ComVisibleAttribute(False)>
Namespace InteroperabilityLibrary

   ' This interface violates the rule.
   <ComVisibleAttribute(True)> _ 
   Public Interface IOverloadedInterface

      Sub SomeSub(valueOne As Integer)
      Sub SomeSub(valueOne As Integer, valueTwo As Integer)

   End Interface

   ' This interface satisfies the rule.
   <ComVisibleAttribute(True)> _ 
   Public Interface INotOverloadedInterface

      Sub SomeSub(valueOne As Integer)
      Sub AnotherSub(valueOne As Integer, valueTwo As Integer)

   End Interface

End Namespace
'</Snippet1>
