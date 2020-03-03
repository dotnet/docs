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
    // URLs are not considered documents. They can only be opened
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