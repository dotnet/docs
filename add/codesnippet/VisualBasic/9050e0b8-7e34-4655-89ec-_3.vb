
Imports System.Runtime.CompilerServices

<assembly: InternalsVisibleTo("Friend2")>

Namespace Utilities.StringUtilities
   Public Class StringLib
      Friend Shared Function IsFirstLetterUpperCase(s As String) As Boolean
         Dim first As String = s.Substring(0, 1)
         Return first = first.ToUpper()
      End Function
   End Class
End Namespace