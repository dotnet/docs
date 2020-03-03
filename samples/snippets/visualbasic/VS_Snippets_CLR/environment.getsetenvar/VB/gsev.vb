Imports System.Collections
Imports Microsoft.Win32

Module Sample 
    Public Sub Main() 
        ' Environment variable names for default, process, user, and machine targets.
        Dim defaultEnvVar As String = NameOf(defaultEnvVar)
        Dim processEnvVar As String = NameOf(processEnvVar)
        Dim userEnvVar As String = NameOf(userEnvVar)
        Dim machineEnvVar As String = NameOf(machineEnvVar)

        Dim dft As String = NameOf(dft)
        Dim process As String = NameOf(process)
        Dim user As String = NameOf(user)
        Dim machine As String = NameOf(machine)

        ' Set the environment variable for each target.
        Console.WriteLine("Setting environment variables for each target...")
        ' The default target (the current process).
        Environment.SetEnvironmentVariable(defaultEnvVar, dft)
        ' The current process.
        Environment.SetEnvironmentVariable(processEnvVar, process, 
                                           EnvironmentVariableTarget.Process)
        ' The current user.
        Environment.SetEnvironmentVariable(userEnvVar, user, 
                                           EnvironmentVariableTarget.User)
        ' The local machine.
        Environment.SetEnvironmentVariable(machineEnvVar, machine, 
                                           EnvironmentVariableTarget.Machine)
        Console.WriteLine()

        ' Define an array of environment variables.
        Dim envVars As String() = { defaultEnvVar, processEnvVar, userEnvVar, machineEnvVar }
        
        ' Try to get the environment variables from each target.
        ' The default (no specified target).
        Console.WriteLine("Retrieving environment variables from the default target:")
        For Each envVar in envVars
          Dim value = Environment.GetEnvironmentVariable(envVar)
          Console.WriteLine($"   {envVar}: {If(value IsNot Nothing, value, "(none)")}")
        Next
        Console.WriteLine()
        ' The process block.
        Console.WriteLine("Retrieving environment variables from the Process target:")
        For Each envVar in envVars
          Dim value = Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.Process)
          Console.WriteLine($"   {envVar}: {If(value IsNot Nothing, value, "(none)")}")
        Next
        Console.WriteLine()
        ' The user block.
        Console.WriteLine("Retrieving environment variables from the User target:")
        For Each envVar in envVars
          Dim value = Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.User)
          Console.WriteLine($"   {envVar}: {value}")
        Next
        Console.WriteLine()
        ' The machine block.
        Console.WriteLine("Retrieving environment variables from the Machine target:")
        For Each envVar in envVars
          Dim value = Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.Machine)
          Console.WriteLine($"   {envVar}: {value}")
        Next
        Console.WriteLine()

        ' Delete the environment variable for each target.
        Console.WriteLine("Deleting environment variables for each target...")
        ' The default target (the current process).
        Environment.SetEnvironmentVariable(defaultEnvVar, Nothing)
        ' The current process.
        Environment.SetEnvironmentVariable(processEnvVar, Nothing, 
                                           EnvironmentVariableTarget.Process)
        ' The current user.
        Environment.SetEnvironmentVariable(userEnvVar, Nothing, 
                                           EnvironmentVariableTarget.User)
        ' The local machine.
        Environment.SetEnvironmentVariable(machineEnvVar, Nothing, 
                                           EnvironmentVariableTarget.Machine)
    End Sub
End Module
' The example displays the following output if run on a Windows system:
'      Setting environment variables for each target...
'
'      Retrieving environment variables from the default target:
'        defaultEnvVar: dft
'        processEnvVar: process
'        userEnvVar: user
'        machineEnvVar: (none)
'
'      Retrieving environment variables from the Process target:
'        defaultEnvVar: dft
'        processEnvVar: process
'        userEnvVar: user
'        machineEnvVar: (none)
'
'      Retrieving environment variables from the User target:
'        defaultEnvVar: (none)
'        processEnvVar: (none)
'        userEnvVar: user
'        machineEnvVar: (none)
'
'      Retrieving environment variables from the Machine target:
'        defaultEnvVar: (none)
'        processEnvVar: (none)
'        userEnvVar: (none)
'        machineEnvVar: machine
'
'      Deleting environment variables for each target...
'
' The example displays the following output if run on a Unix-based system:
'
'      Setting environment variables for each target...
'
'      Retrieving environment variables from the default target:
'        defaultEnvVar: dft
'        processEnvVar: process
'        userEnvVar: (none)
'        machineEnvVar: (none)
'
'      Retrieving environment variables from the Process target:
'        defaultEnvVar: dft
'        processEnvVar: process
'        userEnvVar: (none)
'        machineEnvVar: (none)
'
'      Retrieving environment variables from the User target:
'        defaultEnvVar: (none)
'        processEnvVar: (none)
'        userEnvVar: (none)
'        machineEnvVar: (none)
'
'      Retrieving environment variables from the Machine target:
'        defaultEnvVar: (none)
'        processEnvVar: (none)
'        userEnvVar: (none)
'        machineEnvVar: (none)
'
'      Deleting environment variables for each target...