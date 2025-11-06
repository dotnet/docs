Imports System.IO

Class Example
    ' <Fix>
    Public Function GetFilePath(folder As String, subfolder As String, filename As String) As String
        ' No violation.
        Return Path.Combine(folder, subfolder, filename)
    End Function

    Public Function GetLogPath(baseDir As String, [date] As String, category As String) As String
        ' No violation.
        Return Path.Join(baseDir, [date], category)
    End Function
    ' </Fix>
End Class
