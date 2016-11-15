        Dim memoryInUse =
          My.Computer.Info.TotalPhysicalMemory +
          My.Computer.Info.TotalVirtualMemory -
          My.Computer.Info.AvailablePhysicalMemory -
          My.Computer.Info.AvailableVirtualMemory