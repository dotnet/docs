//<SNIPPET1>
using namespace System;
using namespace System::IO;

namespace PathExample
{
    public ref class GetCharExample
    {
    public:
        static void Main()
        {
            // Get a list of invalid path characters.
            array<Char>^ invalidPathChars = Path::GetInvalidPathChars();

            Console::WriteLine("The following characters are invalid in a path:");
            ShowChars(invalidPathChars);
            Console::WriteLine();

            // Get a list of invalid file characters.
            array<Char>^ invalidFileChars = Path::GetInvalidFileNameChars();

            Console::WriteLine("The following characters are invalid in a filename:");
            ShowChars(invalidFileChars);
        }

        static void ShowChars(array<Char>^ charArray)
        {
            Console::WriteLine("Char\tHex Value");
            // Display each invalid character to the console.
            for each (Char someChar in charArray)
            {
                if (Char::IsWhiteSpace(someChar))
                {
                    Console::WriteLine(",\t{0:X4}", (Int16)someChar);
                }
                else
                {
                    Console::WriteLine("{0:c},\t{1:X4}", someChar, (Int16)someChar);
                }
            }
        }
    };
};

int main()
{
    PathExample::GetCharExample::Main();
}
// Note: Some characters may not be displayable on the console.
// The output will look something like:
//
// The following characters are invalid in a path:
// Char    Hex Value
// ",      0022
// <,      003C
// >,      003E
// |,      007C
// ...
//
// The following characters are invalid in a filename:
// Char    Hex Value
// ",      0022
// <,      003C
// >,      003E
// |,      007C
// ...
//</SNIPPET1>