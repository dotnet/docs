    <[Event](7, Level:=EventLevel.Verbose, Keywords:=Keywords.DataBase)> _
    Public Sub Mark(ByVal ID As Integer)
        If IsEnabled() Then
            WriteEvent(7, ID)
        End If
    End Sub 'Mark