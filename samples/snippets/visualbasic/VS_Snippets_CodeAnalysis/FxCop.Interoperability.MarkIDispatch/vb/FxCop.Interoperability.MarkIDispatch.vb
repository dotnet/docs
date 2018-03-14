'<Snippet1>
Imports Microsoft.VisualBasic
Imports System
Imports System.Runtime.InteropServices

<Assembly: ComVisibleAttribute(True)>
Namespace InteroperabilityLibrary

   ' This violates the rule for type EventSource.
   <InterfaceType(ComInterfaceType.InterfaceIsDual)> _ 
   Public Interface IEventsInterface
      Sub EventOne
      Sub EventTwo
   End Interface

   ' This satisfies the rule.
   <InterfaceType(ComInterfaceType.InterfaceIsIDispatch)> _ 
   Public Interface IMoreEventsInterface
      Sub EventThree
      Sub EventFour
   End Interface

   <ComSourceInterfaces( _
      "InteroperabilityLibrary.IEventsInterface" & _ 
      ControlChars.NullChar & _ 
      "InteroperabilityLibrary.IMoreEventsInterface")> _
   Public Class EventSource
      ' Event and method declarations.
   End Class

End Namespace
'</Snippet1>
