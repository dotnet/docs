' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Runtime.CompilerServices

Public Class Utility
   <MethodImplAttribute(MethodImplOptions.NoInlining)>
   Public Shared Function GetCalendarName(cal As Calendar) As String
      Return cal.ToString().Replace("System.Globalization.", "").Replace("Calendar", "")
   End Function
End Class
' </Snippet1>
