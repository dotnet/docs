        Dim vsProcesses = From proc In
                            Process.GetProcesses
                          Where proc.MainWindowTitle.Contains("Visual Studio")
                          Select proc.ProcessName, proc.Id,
                                 proc.MainWindowTitle