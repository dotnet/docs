//<snippet1>
#using <System.dll>

using namespace System;
using namespace System::IO;
using namespace System::Diagnostics;

ref class IORedirExample
{
public:
    static void Main()
    {
        array<String^>^ args = Environment::GetCommandLineArgs();
        if (args->Length > 1)
        {
            // This is the code for the spawned process
            Console::WriteLine("Hello from the redirected process!");
        }
        else
        {
            // This is the code for the base process
            Process^ myProcess = gcnew Process();
            // Start a new instance of this program but specify the 'spawned' version.
            ProcessStartInfo^ myProcessStartInfo = gcnew ProcessStartInfo(args[0], "spawn");
            myProcessStartInfo->UseShellExecute = false;
            myProcessStartInfo->RedirectStandardOutput = true;
            myProcess->StartInfo = myProcessStartInfo;
            myProcess->Start();
            StreamReader^ myStreamReader = myProcess->StandardOutput;
            // Read the standard output of the spawned process.
            String^ myString = myStreamReader->ReadLine();
            Console::WriteLine(myString);

            myProcess->WaitForExit();
            myProcess->Close();
        }
    }
};

int main()
{
    IORedirExample::Main();
}
//</snippet1>
//<snippet2>
using namespace System;
using namespace System::IO;
using namespace System::Diagnostics;

int main()
{
    Process^ process = gcnew Process();
    process->StartInfo->FileName = "ipconfig.exe";
    process->StartInfo->UseShellExecute = false;
    process->StartInfo->RedirectStandardOutput = true;
    process->Start();

    // Synchronously read the standard output of the spawned process-> 
    StreamReader^ reader = process->StandardOutput;
    String^ output = reader->ReadToEnd();

    // Write the redirected output to this application's window.
    Console::WriteLine(output);

    process->WaitForExit();
    process->Close();

    Console::WriteLine("\n\nPress any key to exit");
    Console::ReadLine();
    return 0;
}
//</snippet2>