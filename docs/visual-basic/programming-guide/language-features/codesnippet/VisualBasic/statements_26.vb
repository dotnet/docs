        For Each p In
          vsProcesses

            Console.WriteLine("{0}" & vbTab & "{1}" & vbTab & "{2}",
              p.ProcessName,
              p.Id,
              p.MainWindowTitle)
        Next