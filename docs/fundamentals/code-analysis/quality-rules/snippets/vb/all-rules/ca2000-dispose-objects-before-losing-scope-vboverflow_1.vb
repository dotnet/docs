Imports System.IO

Class CA2000
    Public Function CreateReader1(ByVal x As Integer) As StreamReader
        Dim local As New StreamReader("C:\Temp.txt")
        x += 1
        Return local
    End Function


    Public Function CreateReader2(ByVal x As Integer) As StreamReader
        Dim local As StreamReader = Nothing
        Dim localTemp As StreamReader = Nothing
        Try
            localTemp = New StreamReader("C:\Temp.txt")
            x += 1
            local = localTemp
            localTemp = Nothing
        Finally
            If (Not (localTemp Is Nothing)) Then
                localTemp.Dispose()
            End If
        End Try
        Return local
    End Function
End Class
