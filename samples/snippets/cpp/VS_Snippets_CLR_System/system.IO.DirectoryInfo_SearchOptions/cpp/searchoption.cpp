//<snippet00>
using namespace System;
using namespace System::IO;

ref class App
{
public:
    static void Main()
    {
        // Specify the directory you want to manipulate.
        String^ path = "c:\\";
        String^ searchPattern = "c*";

        DirectoryInfo^ di = gcnew DirectoryInfo(path);
        array<DirectoryInfo^>^ directories =
            di->GetDirectories(searchPattern, SearchOption::TopDirectoryOnly);

        array<FileInfo^>^ files =
            di->GetFiles(searchPattern, SearchOption::TopDirectoryOnly);

        Console::WriteLine(
            "Directories that begin with the letter \"c\" in {0}", path);
        for each (DirectoryInfo^ dir in directories)
        {
            Console::WriteLine(
                "{0,-25} {1,25}", dir->FullName, dir->LastWriteTime);
        }

        Console::WriteLine();
        Console::WriteLine(
            "Files that begin with the letter \"c\" in {0}", path);
        for each (FileInfo^ file in files)
        {
            Console::WriteLine(
                "{0,-25} {1,25}", file->Name, file->LastWriteTime);
        }
    } // Main()
}; // App()

int main()
{
    App::Main();
}
//</snippet00>