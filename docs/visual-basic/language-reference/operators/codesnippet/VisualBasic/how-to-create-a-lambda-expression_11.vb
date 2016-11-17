    Sub Main()

        Dim filteredQuery = From proc In Diagnostics.Process.GetProcesses
                            Where proc.Threads.Count = 1
                            Select proc

        For Each proc In filteredQuery
            MsgBox(proc.ProcessName)
        Next
    End Sub