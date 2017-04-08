// Console.SetError.cpp : main project file.

// <Snippet1>
using namespace System;
using namespace System::IO;
using namespace System::Reflection;

ref class RedirectStdErr;

void main()
{
   // Define file to receive error stream.
   DateTime appStart = DateTime::Now;
   String^ fn = "c:\\temp\\errlog" + appStart.ToString("yyyyMMddHHmm") + ".log";
   TextWriter^ errStream = gcnew StreamWriter(fn);
   String^ appName = Assembly::GetExecutingAssembly()->Location;
   appName = appName->Substring(appName->LastIndexOf('\\') + 1);
   // Redirect standard error stream to file.
   Console::SetError(errStream);
   // Write file header.
   Console::Error->WriteLine("Error Log for Application {0}", appName);
   Console::Error->WriteLine();
   Console::Error->WriteLine("Application started at {0}.", appStart);
   Console::Error->WriteLine();
   //
   // Application code along with error output 
   //
   // Close redirected error stream.
   Console::Error->Close();
}
// </Snippet1>

