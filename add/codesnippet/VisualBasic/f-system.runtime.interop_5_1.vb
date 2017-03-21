    <DllImport("My.dll", CharSet := CharSet.Ansi, _
                   BestFitMapping := false, _
                   ThrowOnUnmappableChar := true)> _
    Public Shared Function SomeFuncion2(parm As Integer) As Integer
    End Function