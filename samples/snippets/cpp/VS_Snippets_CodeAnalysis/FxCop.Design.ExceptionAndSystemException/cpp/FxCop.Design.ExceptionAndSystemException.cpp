//<Snippet1>
using namespace System;
using namespace System::IO;

namespace DesignLibrary
{
    // Creates two violations of the rule.
    public ref class GenericExceptionsCaught
    {
        FileStream^ inStream;
        FileStream^ outStream;

    public:
        GenericExceptionsCaught(String^ inFile, String^ outFile)
        {
            try
            {
                inStream = File::Open(inFile, FileMode::Open);
            }
            catch(SystemException^ e)
            {
                Console::WriteLine("Unable to open {0}.", inFile);
            }

            try
            {
                outStream = File::Open(outFile, FileMode::Open);
            }
            catch(Exception^ e)
            {
                Console::WriteLine("Unable to open {0}.", outFile);
            }
        }
    };

    public ref class GenericExceptionsCaughtFixed
    {
        FileStream^ inStream;
        FileStream^ outStream;

    public:
        GenericExceptionsCaughtFixed(String^ inFile, String^ outFile)
        {
            try
            {
                inStream = File::Open(inFile, FileMode::Open);
            }

            // Fix the first violation by catching a specific exception.
            catch(FileNotFoundException^ e)
            {
                Console::WriteLine("Unable to open {0}.", inFile);
            }

            try
            {
                outStream = File::Open(outFile, FileMode::Open);
            }

            // Fix the second violation by re-throwing the generic 
            // exception at the end of the catch block.
            catch(Exception^ e)
            {
                Console::WriteLine("Unable to open {0}.", outFile);
                throw;
            }
        }
    };
}
//</Snippet1>
