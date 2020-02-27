using System;
using System.Collections;
using Microsoft.Win32;

class Sample 
{
    public static void Main() 
    {
        // Environment variable names for default, process, user, and machine targets.
        string defaultEnvVar = nameof(defaultEnvVar);
        string processEnvVar = nameof(processEnvVar);
        string userEnvVar = nameof(userEnvVar);
        string machineEnvVar = nameof(machineEnvVar);

        string dft = nameof(dft);
        string process = nameof(process);
        string user = nameof(user);
        string machine = nameof(machine);

        // Set the environment variable for each target.
        Console.WriteLine("Setting environment variables for each target...\n");
        // The default target (the current process).
        Environment.SetEnvironmentVariable(defaultEnvVar, dft);
        // The current process.
        Environment.SetEnvironmentVariable(processEnvVar, process, 
                                           EnvironmentVariableTarget.Process);
        // The current user.
        Environment.SetEnvironmentVariable(userEnvVar, user, 
                                           EnvironmentVariableTarget.User);
        // The local machine.
        Environment.SetEnvironmentVariable(machineEnvVar, machine, 
                                           EnvironmentVariableTarget.Machine);

        // Define an array of environment variables.
        string[] envVars = { defaultEnvVar,processEnvVar, userEnvVar, machineEnvVar };
        
        // Try to get the environment variables from each target.
        // The default (no specified target).
        Console.WriteLine("Retrieving environment variables from the default target:");
        foreach (var envVar in envVars)
        {
          var value = Environment.GetEnvironmentVariable(envVar) ?? "(none)";
          Console.WriteLine($"   {envVar}: {value}");
        }
        // The process block.
        Console.WriteLine("\nRetrieving environment variables from the Process target:");
        foreach (var envVar in envVars)
        {
          var value = Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.Process) ?? "(none)";
          Console.WriteLine($"   {envVar}: {value}");
        }
        // The user block.
        Console.WriteLine("\nRetrieving environment variables from the User target:");
        foreach (var envVar in envVars)
        {
          var value = Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.User) ?? "(none)";
          Console.WriteLine($"   {envVar}: {value}");
        }
        // The machine block.
        Console.WriteLine("\nRetrieving environment variables from the Machine target:");
        foreach (var envVar in envVars)
        {
          var value = Environment.GetEnvironmentVariable(envVar, EnvironmentVariableTarget.Machine) ?? "(none)";
          Console.WriteLine($"   {envVar}: {value}");
        }

        // Delete the environment variable for each target.
        Console.WriteLine("\nDeleting environment variables for each target...\n");
        // The default target (the current process).
        Environment.SetEnvironmentVariable(defaultEnvVar, null);
        // The current process.
        Environment.SetEnvironmentVariable(processEnvVar, null, 
                                           EnvironmentVariableTarget.Process);
        // The current user.
        Environment.SetEnvironmentVariable(userEnvVar, null, 
                                           EnvironmentVariableTarget.User);
        // The local machine.
        Environment.SetEnvironmentVariable(machineEnvVar, null, 
                                           EnvironmentVariableTarget.Machine);
    }
}
// The example displays the following output if run on a Windows system:
//      Setting environment variables for each target...
//
//      Retrieving environment variables from the default target:
//        defaultEnvVar: dft
//        processEnvVar: process
//        userEnvVar: user
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the Process target:
//        defaultEnvVar: dft
//        processEnvVar: process
//        userEnvVar: user
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the User target:
//        defaultEnvVar: (none)
//        processEnvVar: (none)
//        userEnvVar: user
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the Machine target:
//        defaultEnvVar: (none)
//        processEnvVar: (none)
//        userEnvVar: (none)
//        machineEnvVar: machine
//
//      Deleting environment variables for each target...
//
// The example displays the following output if run on a Unix-based system:
//
//      Setting environment variables for each target...
//
//      Retrieving environment variables from the default target:
//        defaultEnvVar: dft
//        processEnvVar: process
//        userEnvVar: (none)
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the Process target:
//        defaultEnvVar: dft
//        processEnvVar: process
//        userEnvVar: (none)
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the User target:
//        defaultEnvVar: (none)
//        processEnvVar: (none)
//        userEnvVar: (none)
//        machineEnvVar: (none)
//
//      Retrieving environment variables from the Machine target:
//        defaultEnvVar: (none)
//        processEnvVar: (none)
//        userEnvVar: (none)
//        machineEnvVar: (none)
//
//      Deleting environment variables for each target...