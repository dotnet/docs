//<Snippet4>
using namespace System;
using namespace System::IO;
using namespace System::Diagnostics;
using namespace System::Text;

ref class StandardAsyncOutputExample
{
private:
    static int lineCount = 0;
    static StringBuilder^ output = nullptr;

public:
    static void Run()
    {
        Process^ process = gcnew Process();
        process->StartInfo->FileName = "ipconfig.exe";
        process->StartInfo->UseShellExecute = false;
        process->StartInfo->RedirectStandardOutput = true;
        output = gcnew StringBuilder();
        process->OutputDataReceived += gcnew DataReceivedEventHandler(OutputHandler);
        process->Start();

        // Asynchronously read the standard output of the spawned process. 
        // This raises OutputDataReceived events for each line of output.
        process->BeginOutputReadLine();
        process->WaitForExit();

        // Write the redirected output to this application's window.
        Console::WriteLine(output);

        process->WaitForExit();
        process->Close();

        Console::WriteLine("\n\nPress any key to exit");
        Console::ReadLine();
    }

private:
    static void OutputHandler(Object^ sender, DataReceivedEventArgs^ e)
    {
        // Prepend line numbers to each line of the output.
        if (!String::IsNullOrEmpty(e->Data))
        {
            lineCount++;
            output->Append("\n[" + lineCount + "]: " + e->Data);
        }
    }
};

int main()
{
    StandardAsyncOutputExample::Run();
}
//</Snippet4>