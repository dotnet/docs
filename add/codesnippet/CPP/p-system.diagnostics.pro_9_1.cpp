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