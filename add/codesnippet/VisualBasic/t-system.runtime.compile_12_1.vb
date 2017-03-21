Imports System.Globalization
Imports System.Runtime.CompilerServices

Public Class Utility
   <MethodImplAttribute(MethodImplOptions.NoInlining)>
   Public Shared Function GetCalendarName(cal As Calendar) As String
      Return cal.ToString().Replace("System.Globalization.", "").Replace("Calendar", "")
   End Function
End Class