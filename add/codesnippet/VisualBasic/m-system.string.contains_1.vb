Imports System.Runtime.CompilerServices

Module StringExtensions
   <Extension()>
   Public Function Contains(str As String, substring As String, 
                            comp As StringComparison) As Boolean
      If substring Is Nothing Then
         Throw New ArgumentNullException("substring", 
                                         "substring cannot be null.")
      Else If Not [Enum].IsDefined(GetType(StringComparison), comp)
         Throw New ArgumentException("comp is not a member of StringComparison",
                                     "comp")
      End If                               
      Return str.IndexOf(substring, comp) >= 0                      
   End Function
End Module