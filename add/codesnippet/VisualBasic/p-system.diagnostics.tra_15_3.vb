    <[Event](6, Opcode:=EventOpcode.Stop, Task:=Tasks.DBQuery, Keywords:=Keywords.DataBase, Level:=EventLevel.Informational)> _
    Public Sub DBQueryStop()
        WriteEvent(6)
    End Sub 'DBQueryStop