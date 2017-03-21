Imports System.Reflection

<Assembly: AssemblyVersion("2.0.0.0")>

Public Class StringLibrary
   Public Shared Function SubstringStartsAt(fullString As String, substr As String) As Integer
      Return fullString.IndexOf(substr, StringComparison.CurrentCulture)
   End Function
End Class