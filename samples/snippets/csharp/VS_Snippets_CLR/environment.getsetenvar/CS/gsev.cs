//<snippet1>
// This example demonstrates the 
//     Environment.GetEnvironmentVariable,
//     Environment.SetEnvironmentVariable, and 
//     Environment.GetEnvironmentVariables overloaded methods.

using System;
using System.Collections;
using Microsoft.Win32;

class Sample 
{
//-------------------------------------------------------------------------------------
// Globals: 
//-------------------------------------------------------------------------------------
    protected static string fmtNameValue = "  {0} {1}.";
    protected static string myVarSuffix = "_GETSET_ENVAR_SAMPLE";

// Four relatively unique environment variable names.
    protected static string myVarA = "A" + myVarSuffix; // default process
    protected static string myVarB = "B" + myVarSuffix; // Current Process
    protected static string myVarC = "C" + myVarSuffix; // Current User
    protected static string myVarD = "D" + myVarSuffix; // Local Machine
//=====================================================================================
// EachVariable: 
// Test whether a specific environment variable exists in a target.
// This section demonstrates Environment.GetEnvironmentVariable.
//-------------------------------------------------------------------------------------
    protected static void EachVariable(string var, EnvironmentVariableTarget tgt)
    {
    string str;
    //
    if (0 == tgt)          // Zero means use the default target.
        str = Environment.GetEnvironmentVariable(var);
    else
        str = Environment.GetEnvironmentVariable(var, tgt);
    Console.WriteLine(fmtNameValue, 
                      var, (String.IsNullOrEmpty(str) ? "doesn't exist" : str));
    }
//-------------------------------------------------------------------------------------
// CheckEachVariable: 
// Uses EachVariable to test whether each environment variable exists in a target.
//-------------------------------------------------------------------------------------
    protected static void CheckEachVariable()
    {
    Console.WriteLine("Process:");
    EachVariable(myVarA, 0);  // Check the default target (current process)
    EachVariable(myVarB, EnvironmentVariableTarget.Process);
    EachVariable(myVarC, EnvironmentVariableTarget.Process);
    EachVariable(myVarD, EnvironmentVariableTarget.Process);
    Console.WriteLine();

    Console.WriteLine("User:");
    EachVariable(myVarA, EnvironmentVariableTarget.User);
    EachVariable(myVarB, EnvironmentVariableTarget.User);
    EachVariable(myVarC, EnvironmentVariableTarget.User);
    EachVariable(myVarD, EnvironmentVariableTarget.User);
    Console.WriteLine();

    Console.WriteLine("Machine:");
    EachVariable(myVarA, EnvironmentVariableTarget.Machine);
    EachVariable(myVarB, EnvironmentVariableTarget.Machine);
    EachVariable(myVarC, EnvironmentVariableTarget.Machine);
    EachVariable(myVarD, EnvironmentVariableTarget.Machine);
    Console.WriteLine();
    }
//=====================================================================================
// AllVariables: CheckAllVariables helper function.
// This section demonstrates Environment.GetEnvironmentVariables.
//-------------------------------------------------------------------------------------
    private static void AllVariables(EnvironmentVariableTarget tgt)
    {
    string value;
    string key;

    foreach(DictionaryEntry de in Environment.GetEnvironmentVariables(tgt))
        {
        key   = (string)de.Key;
        value = (string)de.Value;
        if (key.Contains(myVarSuffix))
            Console.WriteLine(fmtNameValue, key, value);
        }
    Console.WriteLine();
    }
//=====================================================================================
// CheckAllVariables: 
// Uses AllVariables to test whether each environment variable exists in a target.
//-------------------------------------------------------------------------------------
    protected static void CheckAllVariables()
    {
    Console.WriteLine("Process:");
    AllVariables(EnvironmentVariableTarget.Process);

    Console.WriteLine("User:");
    AllVariables(EnvironmentVariableTarget.User);

    Console.WriteLine("Machine:");
    AllVariables(EnvironmentVariableTarget.Machine);
    }
//=====================================================================================
// ChkReg: CheckRegistry helper function.
// This function filters out irrelevant environment variables. 
//-------------------------------------------------------------------------------------
    private static void ChkReg(RegistryKey rk)
    {
    bool exists = false;
    string registryNone = "  Environment variable doesn't exist.";

    foreach (string s in rk.GetValueNames())
        {
        if (s.Contains(myVarSuffix))
            {
            Console.WriteLine(fmtNameValue, s, (string)rk.GetValue(s));
            exists = true;
            }
        }
    if (exists == false)
        Console.WriteLine(registryNone);
    Console.WriteLine();
    }
//-------------------------------------------------------------------------------------
// CheckRegistry: 
// Uses ChkReg to display the User and Machine environment variables in the registry.
//-------------------------------------------------------------------------------------
    protected static void CheckRegistry()
    {
    string subkeyU = @"Environment";
    string subkeyM = @"System\CurrentControlSet\Control\Session Manager\Environment";
    string fmtSubkey = "\"{0}\" key:";

    Console.WriteLine(fmtSubkey, subkeyU);
    ChkReg(Registry.CurrentUser.OpenSubKey(subkeyU));

    Console.WriteLine(fmtSubkey, subkeyM);
    ChkReg(Registry.LocalMachine.OpenSubKey(subkeyM));
    }
//=====================================================================================
// Main:
//-------------------------------------------------------------------------------------
    public static void Main() 
    {
//-------------------------------------------------------------------------------------
// Environment variable values
//-------------------------------------------------------------------------------------
    string existsA = "exists in the default target (Process)";
    string existsB = "exists in Process";
    string existsC = "exists in User";
    string existsD = "exists in Machine";
//-------------------------------------------------------------------------------------
// Messages:
//-------------------------------------------------------------------------------------
    string msg1  = "Step 1:\n" +
                       "  Check whether the environment variables already exist in \n" + 
                       "  the various targets...\n";
    string msg2  = "Step 2:\n" +
                       "  Set the environment variable for each target...\n";
    string msg31 = "Step 3, part 1:\n" + 
                       "  Display the environment variables in each target...\n";
    string msg32 = "Step 3, part 2:\n" +
                       "  Check whether the User and Machine environment variables \n" +
                       "  were created in the Windows operating system registry...\n";
    string msg41 = "Step 4, part 1:\n" +
                       "  Delete the environment variables created for this sample...\n";
    string msg42 = "Step 4, part 2:\n" +
                       "  Check whether the environment variables were deleted \n" +
                       "  in each target...\n";
    string msg43 = "Step 4, part 3:\n" + 
                       "  Check whether the User and Machine environment variables \n" +
                       "  were deleted from the Windows operating system registry...\n";
    string fmt2x   = "  {0,9}: Set {1} = \"{2}\"";
//-------------------------------------------------------------------------------------
// Step 1:
// Check whether the sample environment variables already exist.
// WARNING: These variables will be deleted at the end of this sample.
//-------------------------------------------------------------------------------------
    Console.WriteLine(msg1);
    CheckEachVariable();
    Console.WriteLine();
//-------------------------------------------------------------------------------------
// Step 2:
// Set the environment variable for each target.
// This section demonstrates Environment.SetEnvironmentVariable.
//-------------------------------------------------------------------------------------
    Console.WriteLine(msg2);
// Set the environment variable for the default target (the current process).
    Console.WriteLine(fmt2x, "(default)", myVarA, existsA);
    Environment.SetEnvironmentVariable(myVarA, existsA);

// Set the environment variable for the current process.
    Console.WriteLine(fmt2x, "Process", myVarB, existsB);
    Environment.SetEnvironmentVariable(myVarB, existsB, 
        EnvironmentVariableTarget.Process);

// Set the environment variable for the current user.
    Console.WriteLine(fmt2x, "User", myVarC, existsC);
    Environment.SetEnvironmentVariable(myVarC, existsC, 
        EnvironmentVariableTarget.User);

// Set the environment variable for the local machine.
    Console.WriteLine(fmt2x, "Machine", myVarD, existsD);
    Environment.SetEnvironmentVariable(myVarD, existsD, 
        EnvironmentVariableTarget.Machine);
    Console.WriteLine();
//-------------------------------------------------------------------------------------
// Step 3, part 1:
// Display the environment variables in each target.
//-------------------------------------------------------------------------------------
    Console.WriteLine(msg31);
    CheckAllVariables();
    Console.WriteLine();
//-------------------------------------------------------------------------------------
// Step 3, part 2:
// Check whether the User and Machine environment variables were created in the Windows 
// operating system registry.
//-------------------------------------------------------------------------------------
    Console.WriteLine(msg32);
    CheckRegistry();
    Console.WriteLine();
//-------------------------------------------------------------------------------------
// Step 4, part 1:
// Delete the environment variables created for this sample.
// This section demonstrates using Environment.SetEnvironmentVariable to delete an 
// environment variable.
//-------------------------------------------------------------------------------------
    Console.WriteLine(msg41);
    Environment.SetEnvironmentVariable(myVarA, null);
    Environment.SetEnvironmentVariable(myVarB, null, EnvironmentVariableTarget.Process);
    Environment.SetEnvironmentVariable(myVarC, null, EnvironmentVariableTarget.User);
    Environment.SetEnvironmentVariable(myVarD, null, EnvironmentVariableTarget.Machine);
//-------------------------------------------------------------------------------------
// Step 4, part 2:
// Check whether the environment variables were deleted in each target.
//-------------------------------------------------------------------------------------
    Console.WriteLine(msg42);
    CheckEachVariable();
//-------------------------------------------------------------------------------------
// Step 4, part 3:
// Check whether the User and Machine environment variables were deleted from the 
// Windows operating system registry.
//-------------------------------------------------------------------------------------
    Console.WriteLine(msg43);
    CheckRegistry();
    }
}
/*
This example produces the following results:

Step 1:
  Check whether the environment variables already exist in
  the various targets...

Process:
  A_GETSET_ENVAR_SAMPLE doesn't exist.
  B_GETSET_ENVAR_SAMPLE doesn't exist.
  C_GETSET_ENVAR_SAMPLE doesn't exist.
  D_GETSET_ENVAR_SAMPLE doesn't exist.

User:
  A_GETSET_ENVAR_SAMPLE doesn't exist.
  B_GETSET_ENVAR_SAMPLE doesn't exist.
  C_GETSET_ENVAR_SAMPLE doesn't exist.
  D_GETSET_ENVAR_SAMPLE doesn't exist.

Machine:
  A_GETSET_ENVAR_SAMPLE doesn't exist.
  B_GETSET_ENVAR_SAMPLE doesn't exist.
  C_GETSET_ENVAR_SAMPLE doesn't exist.
  D_GETSET_ENVAR_SAMPLE doesn't exist.


Step 2:
  Set the environment variable for each target...

  (default): Set A_GETSET_ENVAR_SAMPLE = "exists in the default target (Process)"
    Process: Set B_GETSET_ENVAR_SAMPLE = "exists in Process"
       User: Set C_GETSET_ENVAR_SAMPLE = "exists in User"
    Machine: Set D_GETSET_ENVAR_SAMPLE = "exists in Machine"

Step 3, part 1:
  Display the environment variables in each target...

Process:
  B_GETSET_ENVAR_SAMPLE exists in Process.
  A_GETSET_ENVAR_SAMPLE exists in the default target (Process).

User:
  C_GETSET_ENVAR_SAMPLE exists in User.

Machine:
  D_GETSET_ENVAR_SAMPLE exists in Machine.


Step 3, part 2:
  Check whether the User and Machine environment variables
  were created in the Windows operating system registry...

"Environment" key:
  C_GETSET_ENVAR_SAMPLE exists in User.

"System\CurrentControlSet\Control\Session Manager\Environment" key:
  D_GETSET_ENVAR_SAMPLE exists in Machine.


Step 4, part 1:
  Delete the environment variables created for this sample...

Step 4, part 2:
  Check whether the environment variables were deleted
  in each target...

Process:
  A_GETSET_ENVAR_SAMPLE doesn't exist.
  B_GETSET_ENVAR_SAMPLE doesn't exist.
  C_GETSET_ENVAR_SAMPLE doesn't exist.
  D_GETSET_ENVAR_SAMPLE doesn't exist.

User:
  A_GETSET_ENVAR_SAMPLE doesn't exist.
  B_GETSET_ENVAR_SAMPLE doesn't exist.
  C_GETSET_ENVAR_SAMPLE doesn't exist.
  D_GETSET_ENVAR_SAMPLE doesn't exist.

Machine:
  A_GETSET_ENVAR_SAMPLE doesn't exist.
  B_GETSET_ENVAR_SAMPLE doesn't exist.
  C_GETSET_ENVAR_SAMPLE doesn't exist.
  D_GETSET_ENVAR_SAMPLE doesn't exist.

Step 4, part 3:
  Check whether the User and Machine environment variables
  were deleted from the Windows operating system registry...

"Environment" key:
  Environment variable doesn't exist.

"System\CurrentControlSet\Control\Session Manager\Environment" key:
  Environment variable doesn't exist.
*/
//</snippet1>