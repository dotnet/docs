    Sub Main()

        ' Create an array of running processes.
        Dim procList As Process() = Diagnostics.Process.GetProcesses

        ' Return the processes that have one thread. Notice that the type
        ' of the parameter does not have to be explicitly stated.
        Dim filteredList = procList.Where(Function(p) p.Threads.Count = 1)

        ' Display the name of each selected process.
        For Each proc In filteredList
            MsgBox(proc.ProcessName)
        Next

    End Sub