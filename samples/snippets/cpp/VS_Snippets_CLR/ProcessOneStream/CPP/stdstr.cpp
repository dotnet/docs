#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

void main()
{
   //<Snippet1>  
   // Run "cl.exe /cld stdstr.cpp /link /out:sample.exe". UseShellExecute is false because we're specifying
   // an executable directly and in this case depending on it being in a PATH folder. By setting
   // RedirectStandardOutput to true, the output of cl.exe is directed to the Process.StandardOutput stream
   // which is then displayed in this console window directly.    
   Process^ compiler = gcnew Process;
   compiler->StartInfo->FileName = "cl.exe";
   compiler->StartInfo->Arguments = "/clr stdstr.cpp /link /out:sample.exe";
   compiler->StartInfo->UseShellExecute = false;
   compiler->StartInfo->RedirectStandardOutput = true;
   compiler->Start();

   Console::WriteLine( compiler->StandardOutput->ReadToEnd() );

   compiler->WaitForExit();
   //</Snippet1>
}
