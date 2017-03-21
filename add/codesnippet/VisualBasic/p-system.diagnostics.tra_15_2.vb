    <[Event](5, Opcode:=EventOpcode.Start, Task:=Tasks.DBQuery, Keywords:=Keywords.DataBase, Level:=EventLevel.Informational)> _
    Public Sub DBQueryStart(ByVal sqlQuery As String)
        WriteEvent(5, sqlQuery)
    End Sub 'DBQueryStart