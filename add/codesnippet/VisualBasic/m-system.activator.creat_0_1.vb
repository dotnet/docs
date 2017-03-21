    Public Shared Function Factory(Of T As New)() As T
        Return New T()
    End Function