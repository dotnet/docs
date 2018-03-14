'<Snippet1>
Imports System

Namespace DesignLibrary

   Public Enum TraceLevel
      Off     = 0
      AnError = 1
      Warning = 2
      Info    = 3
      Verbose = 4
   End Enum

   <Flags> _
   Public Enum TraceOptions
      None         =    0
      CallStack    = &H01
      LogicalStack = &H02
      DateTime     = &H04
      Timestamp    = &H08
   End Enum

   <Flags> _
   Public Enum BadTraceOptions
      CallStack    =    0
      LogicalStack = &H01
      DateTime     = &H02
      Timestamp    = &H04
   End Enum

   Class UseBadTraceOptions

      Shared Sub Main()

         ' Set the flags.
         Dim badOptions As BadTraceOptions = _
            BadTraceOptions.LogicalStack Or BadTraceOptions.Timestamp

         ' Check whether CallStack is set.
         If((badOptions And BadTraceOptions.CallStack) = _
             BadTraceOptions.CallStack)
            ' This 'If' statement is always true.
         End If

      End Sub
         
   End Class

End Namespace
'</Snippet1>
