    <DllImport("KERNEL32.DLL", EntryPoint:="MoveFileW", SetLastError:=True,
        CharSet:=CharSet.Unicode, ExactSpelling:=True,
        CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function MoveFile(
        ByVal src As String,
        ByVal dst As String) As Boolean
        ' Leave the body of the function empty.
    End Function