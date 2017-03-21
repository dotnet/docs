    Public Sub SearchSqlParams()
        ' ...
        ' create SqlCommand command and SqlParameter param
        ' ...
        If command.Parameters.Contains(param) Then
            command.Parameters.Remove(param)
        End If
    End Sub 'SearchSqlParams