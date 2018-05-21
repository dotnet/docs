        ' Using explicit typing.
        Dim pList1() As Process = Process.GetProcesses()

        ' Using local type inference.
        Dim pList2 = Process.GetProcesses()