    Declare Function GetUserName Lib "advapi32.dll" Alias "GetUserNameA" (
        ByVal lpBuffer As String,
        ByRef nSize As Integer) As Integer