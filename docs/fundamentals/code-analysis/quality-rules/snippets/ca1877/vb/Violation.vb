Imports System.IO

Class Example
    ' <Violation>
    Public Function GetFilePath(folder As String, subfolder As String, filename As String) As String
        ' Violation.
        Dim temp As String = Path.Combine(folder, subfolder)
        Return Path.Combine(temp, filename)
    End Function

    Public Function GetLogPath(baseDir As String, [date] As String, category As String) As String
        ' Violation.
        Return Path.Join(Path.Join(baseDir, [date]), category)
    End Function
    ' </Violation>
End Class
