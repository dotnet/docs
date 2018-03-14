// <Snippet1>
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;
using namespace System::ComponentModel;

// Opens the Internet Explorer application.
void OpenApplication(String^ myFavoritesPath)
{
    // Start Internet Explorer. Defaults to the home page.
    Process::Start("IExplore.exe");

    // Display the contents of the favorites folder in the browser.
    Process::Start(myFavoritesPath);
}

// Opens urls and .html documents using Internet Explorer.
void OpenWithArguments()
{
    // url's are not considered documents. They can only be opened
    // by passing them as arguments.
    Process::Start("IExplore.exe", "www.northwindtraders.com");

    // Start a Web page using a browser associated with .html and .asp files.
    Process::Start("IExplore.exe", "C:\\myPath\\myFile.htm");
    Process::Start("IExplore.exe", "C:\\myPath\\myFile.asp");
}

// Uses the ProcessStartInfo class to start new processes,
// both in a minimized mode.
void OpenWithStartInfo()
{
    ProcessStartInfo^ startInfo = gcnew ProcessStartInfo("IExplore.exe");
    startInfo->WindowStyle = ProcessWindowStyle::Minimized;
    Process::Start(startInfo);
    startInfo->Arguments = "www.northwindtraders.com";
    Process::Start(startInfo);
}

int main()
{
    // Get the path that stores favorite links.
    String^ myFavoritesPath = Environment::GetFolderPath(Environment::SpecialFolder::Favorites);
    OpenApplication(myFavoritesPath);
    OpenWithArguments();
    OpenWithStartInfo();
}
// </Snippet1>
// <Snippet2>
// Place the following code into a console project called StartArgsEcho. It depends on the
// console application named argsecho.exe.

using namespace System;
using namespace System::Diagnostics;

int main()
{
    ProcessStartInfo^ startInfo = gcnew ProcessStartInfo("argsecho.exe");
    startInfo->WindowStyle = ProcessWindowStyle::Normal;

    // Start with one argument.
    // Output of ArgsEcho:
    //  [0]=/a            
    startInfo->Arguments = "/a";
    Process::Start(startInfo);

    // Start with multiple arguments separated by spaces.
    // Output of ArgsEcho:
    //  [0] = /a
    //  [1] = /b
    //  [2] = c:\temp
    startInfo->Arguments = "/a /b c:\\temp";
    Process::Start(startInfo);

    // An argument with spaces inside quotes is interpreted as multiple arguments.
    // Output of ArgsEcho:
    //  [0] = /a
    //  [1] = literal string arg
    startInfo->Arguments = "/a \"literal string arg\"";
    Process::Start(startInfo);

    // An argument inside double quotes is interpreted as if the quote weren't there,
    // that is, as separate arguments. 
    // Output of ArgsEcho:
    //  [0] = /a
    //  [1] = /b:string
    //  [2] = in
    //  [3] = double
    //  [4] = quotes
    startInfo->Arguments = "/a /b:\"\"string in double quotes\"\"";
    Process::Start(startInfo);

    // Triple-escape quotation marks to include the character in the final argument received
    // by the target process.
    //  [0] = /a
    //  [1] = /b:"quoted string"
    startInfo->Arguments = "/a /b:\"\"\"quoted string\"\"\"";
    Process::Start(startInfo);

    return 0;
}
// </Snippet2>
// <Snippet3>
// Place this code into a console project called ArgsEcho to build the argsecho.exe target

using namespace System;

int main(array<System::String ^> ^args)
{
    Console::WriteLine("Received the following arguments:\n");

    for (int i = 0; i < args->Length; i++)
    {
        Console::WriteLine("[" + i + "] = " + args[i]);
    }

    Console::WriteLine("\nPress any key to exit");
    Console::ReadLine();
    return 0;
}
// </Snippet3>