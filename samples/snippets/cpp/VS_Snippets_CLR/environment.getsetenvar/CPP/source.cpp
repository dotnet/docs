
//<snippet1>
// This example demonstrates the
//     Environment.GetEnvironmentVariable,
//     Environment.SetEnvironmentVariable, and
//     Environment.GetEnvironmentVariables overloaded methods.

using namespace System;
using namespace System::Collections;
using namespace Microsoft::Win32;

namespace EnvironmentVariablesSample
{
    public ref class TestEnvironmentVariables sealed
    {
    public:
        // DoTest: Test get/set environment variables
        static void DoTest()
        {     
            // Environment variable values
            String^ existsA = "exists in the default target"
                " (Process)";
            String^ existsB = "exists in Process";
            String^ existsC = "exists in User";
            String^ existsD = "exists in Machine";     
            // Messages:
            String^ messageStep1 = "Step 1:\n"
                "  Check whether the environment variables already"
                " exist in \n"
                "  the various targets...\n";
            String^ messageStep2 = "Step 2:\n"
                "  Set the environment variable for each"
                " target...\n";
            String^ messageStep3Part1 = "Step 3, part 1:\n"
                "  Display the environment variables in each"
                " target...\n";
            String^ messageStep3Part2 = "Step 3, part 2:\n"
                "  Check whether the User and Machine "
                " environment variables \n"
                "  were created in the Windows operating"
                " system registry...\n";
            String^ messageStep4Part1 = "Step 4, part 1:\n"
                "  Delete the environment variables created "
                "for this sample...\n";
            String^ messageStep4Part2 = "Step 4, part 2:\n"
                "  Check whether the environment variables were "
                "deleted \n"
                "  in each target...\n";
            String^ messageStep4Part3 = "Step 4, part 3:\n"
                "  Check whether the User and Machine environment "
                "variables \n"
                "  were deleted from the Windows operating system "
                "registry...\n";
            String^ step2Format = "  {0,9}: Set {1} = \"{2}\"";  

            // Step 1:
            // Check whether the sample environment variables already
            // exist.
            // WARNING: These variables will be deleted at the end of
            // this sample.
            Console::WriteLine(messageStep1);
            CheckVariables();
            Console::WriteLine();   

            // Step 2:
            // Set the environment variable for each target.
            // This section demonstrates
            // Environment.SetEnvironmentVariable.
            Console::WriteLine(messageStep2);     

            // Set the environment variable for the default target
            // (the current process).
            Console::WriteLine(step2Format, "(default)", VariableA,
                existsA);
            Environment::SetEnvironmentVariable(VariableA, existsA);  

            // Set the environment variable for the current process.
            Console::WriteLine(step2Format, "Process", VariableB,
                existsB);
            Environment::SetEnvironmentVariable(VariableB, existsB,
                EnvironmentVariableTarget::Process);

            // Set the environment variable for the current user.
            Console::WriteLine(step2Format, "User", VariableC,
                existsC);
            Environment::SetEnvironmentVariable(VariableC, existsC,
                EnvironmentVariableTarget::User);

            // Set the environment variable for the local machine.
            Console::WriteLine(step2Format, "Machine", VariableD,
                existsD);
            Environment::SetEnvironmentVariable(VariableD, existsD,
                EnvironmentVariableTarget::Machine);
            Console::WriteLine();      

            // Step 3, part 1:
            // Display the environment variables in each target.
            Console::WriteLine(messageStep3Part1);
            PrintVariables();
            Console::WriteLine();     

            // Step 3, part 2:
            // Check whether the User and Machine environment
            // variables were created in the Windows operating system
            // registry.
            Console::WriteLine(messageStep3Part2);
            CheckRegistryVariables();
            Console::WriteLine();

            // Step 4, part 1:
            // Delete the environment variables created for this
            // sample. This section demonstrates using 
            // Environment.SetEnvironmentVariable to delete an 
            // environment variable.
            Console::WriteLine(messageStep4Part1);
            Environment::SetEnvironmentVariable(VariableA, nullptr);
            Environment::SetEnvironmentVariable(VariableB, nullptr,
                EnvironmentVariableTarget::Process);
            Environment::SetEnvironmentVariable(VariableC, nullptr,
                EnvironmentVariableTarget::User);
            Environment::SetEnvironmentVariable(VariableD, nullptr,
                EnvironmentVariableTarget::Machine);     

            // Step 4, part 2:
            // Check whether the environment variables were deleted 
            // in each target.
            Console::WriteLine(messageStep4Part2);
            CheckVariables();

            // Step 4, part 3:
            // Check whether the User and Machine environment
            // variables were deleted from the Windows operating
            // system registry.
            Console::WriteLine(messageStep4Part3);
            CheckRegistryVariables();
        }

    protected:
        // Globals:
        literal String^ NameValueFormat = "  {0} {1}.";
        literal String^ VariableSuffix = "_GETSET_ENVAR_SAMPLE";

        // Four relatively unique environment variable names.
        // default process

        literal String^ VariableA = "A_GETSET_ENVAR_SAMPLE";

        // Current Process
        literal String^ VariableB = "B_GETSET_ENVAR_SAMPLE";

        // Current User
        literal String^ VariableC = "C_GETSET_ENVAR_SAMPLE";

        // Local Machine
        literal String^ VariableD = "D_GETSET_ENVAR_SAMPLE";

    private:
        // CheckVariablesInTarget:
        // Test whether a specific environment variable exists
        // in a target. This section demonstrates
        // Environment.GetEnvironmentVariable.
        static void CheckVariablesInTarget(String^ variable,
            EnvironmentVariableTarget target)
        {
            String^ variableName;

            // Zero means use the default target.
            if (target == (EnvironmentVariableTarget) 0)
            {
                variableName =
                    Environment::GetEnvironmentVariable(variable);
            }
            else
            {
                variableName = Environment::GetEnvironmentVariable(
                    variable, target);
            }
            Console::WriteLine(NameValueFormat, variable,
                (String::IsNullOrEmpty(variableName) ?
                "doesn't exist" : variableName));
        }

        // CheckVariable:
        // Uses CheckVariablesInTarget to test whether each
        // environment variable exists in a target.
        static void CheckVariables()
        {
            Console::WriteLine("Process:");

            // Check the default target(current process)
            CheckVariablesInTarget(VariableA,
                (EnvironmentVariableTarget) 0);
            CheckVariablesInTarget(VariableB,
                EnvironmentVariableTarget::Process);
            CheckVariablesInTarget(VariableC,
                EnvironmentVariableTarget::Process);
            CheckVariablesInTarget(VariableD,
                EnvironmentVariableTarget::Process);
            Console::WriteLine();

            Console::WriteLine("User:");
            CheckVariablesInTarget(VariableA,
                EnvironmentVariableTarget::User);
            CheckVariablesInTarget(VariableB,
                EnvironmentVariableTarget::User);
            CheckVariablesInTarget(VariableC,
                EnvironmentVariableTarget::User);
            CheckVariablesInTarget(VariableD,
                EnvironmentVariableTarget::User);
            Console::WriteLine();

            Console::WriteLine("Machine:");
            CheckVariablesInTarget(VariableA,
                EnvironmentVariableTarget::Machine);
            CheckVariablesInTarget(VariableB,
                EnvironmentVariableTarget::Machine);
            CheckVariablesInTarget(VariableC,
                EnvironmentVariableTarget::Machine);
            CheckVariablesInTarget(VariableD,
                EnvironmentVariableTarget::Machine);
            Console::WriteLine();
        }

        // PrintVariablesFromTarget: PrintVariables helper function.
        // This section demonstrates
        // Environment.GetEnvironmentVariables.
        static void PrintVariablesFromTarget(
            EnvironmentVariableTarget target)
        {
            String^ valueString;
            String^ keyString;

            for each (DictionaryEntry^ dictionary in
                Environment::GetEnvironmentVariables(target))
            {
                keyString = safe_cast<String^> (dictionary->Key);
                valueString = safe_cast<String^> (dictionary->Value);
                if (keyString->Contains(VariableSuffix))
                    Console::WriteLine(NameValueFormat, keyString,
                    valueString);
            }
            Console::WriteLine();
        }

        // PrintVariables:
        // Uses PrintVariablesFromTarget to test whether
        // each environment variable exists in a target.
        static void PrintVariables()
        {
            Console::WriteLine("Process:");
            PrintVariablesFromTarget(EnvironmentVariableTarget::Process);

            Console::WriteLine("User:");
            PrintVariablesFromTarget(EnvironmentVariableTarget::User);

            Console::WriteLine("Machine:");
            PrintVariablesFromTarget(EnvironmentVariableTarget::Machine);
        }

        // CheckRegistryVariablesForKey: CheckRegistryVariables
        // helper function. This function filters out irrelevant
        // environment variables.
        static void CheckRegistryVariablesForKey(RegistryKey^ targetKey)
        {
            bool exists = false;            

            for each (
                String^ variableName in targetKey->GetValueNames())
            {
                if (variableName->Contains(VariableSuffix))
                {
                    String^ variableValue =
                        safe_cast<String^>
                        (targetKey->GetValue(variableName));
                    Console::WriteLine(NameValueFormat, variableName,
                        variableValue);
                    exists = true;
                }
            }
            if (!exists)
            {
                Console::WriteLine(
                    "  Environment variable doesn't exist.");
            }
            Console::WriteLine();
        }

        // CheckRegistryVariables:
        // Uses CheckRegistryVariables to display the User and
        // Machine environment variables in the registry.
        static void CheckRegistryVariables()
        {
            String^ subkeyUser = "Environment";
            String^ subkeyMachine = "System\\CurrentControlSet\\"
                "Control\\Session Manager\\Environment";
            String^ subkeyFormat = "\"{0}\" key:";

            Console::WriteLine(subkeyFormat, subkeyUser);
            CheckRegistryVariablesForKey(
                Registry::CurrentUser->OpenSubKey(subkeyUser));

            Console::WriteLine(subkeyFormat, subkeyMachine);
            CheckRegistryVariablesForKey(
                Registry::LocalMachine->OpenSubKey(subkeyMachine));
        }
    };
};

using namespace EnvironmentVariablesSample;

int main()
{
    TestEnvironmentVariables::DoTest();
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


