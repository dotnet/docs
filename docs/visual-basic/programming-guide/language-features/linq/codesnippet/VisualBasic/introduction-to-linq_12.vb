        ' Returns a combined collection of all of the 
        ' processes currently running and a descriptive
        ' name for the process taken from a list of 
        ' descriptive names.
        Dim processes = From proc In Process.GetProcesses
                        Join desc In processDescriptions
                          On proc.ProcessName Equals desc.ProcessName
                        Select proc.ProcessName, proc.Id, desc.Description