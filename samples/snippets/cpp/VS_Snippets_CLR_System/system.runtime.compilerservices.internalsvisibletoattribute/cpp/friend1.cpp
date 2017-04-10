using namespace System;

ref class FileUtilities
{
    public:
       static String^ AppendDirectorySeparator(String^ dir)
      {
         if (! dir->Trim()->EndsWith(System::IO::Path::DirectorySeparatorChar.ToString()))
            return dir->Trim() + System::IO::Path::DirectorySeparatorChar;
         else
            return dir;
      }
};


// <Snippet2>
//
// The assembly that exposes its internal types to this assembly should be
// named Assembly1.dll.
//
// The public key of this assembly should correspond to the public key
// specified in the class constructor of the InternalsVisibleTo attribute in the
// Assembly1 assembly.
//
#using <Assembly1.dll> as_friend

using namespace System;

void main()
{
   String^ dir = L"C:\\Program Files";
   dir = FileUtilities::AppendDirectorySeparator(dir);
   Console::WriteLine(dir);
}
// The example displays the following output:
//       C:\Program Files\
// </Snippet2>


