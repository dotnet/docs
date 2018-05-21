    <DllImportAttribute("kernel32.dll", EntryPoint:="MoveFileW",
        SetLastError:=True, CharSet:=CharSet.Unicode,
        ExactSpelling:=True,
        CallingConvention:=CallingConvention.StdCall)>
    Public Shared Function moveFile(ByVal src As String,
      ByVal dst As String) As Boolean
        ' This function copies a file from the path src to the path dst.
        ' Leave this function empty. The DLLImport attribute forces calls
        ' to moveFile to be forwarded to MoveFileW in KERNEL32.DLL.
    End Function