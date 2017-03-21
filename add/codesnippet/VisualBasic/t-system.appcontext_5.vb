Imports System.Reflection

<Assembly: AssemblyVersion("2.0.0.0")>

Public Class StringLibrary
   Public Shared Function SubstringStartsAt(fullString As String, substr As String) As Integer
      Dim flag As Boolean
      If AppContext.TryGetSwitch("StringLibrary.DoNotUseCultureSensitiveComparison", flag) AndAlso flag = True Then
         Return fullString.IndexOf(substr, StringComparison.Ordinal)
      Else
         Return fullString.IndexOf(substr, StringComparison.CurrentCulture)
      End If   
   End Function
End Class