//<snippet1>
using namespace System;
using namespace System::IO;

public ref class CharsFromStr
{
public:
    static void Main()
    {
        // Create a string to read characters from.
        String^ str = "Some number of characters";
        // Make a char array the size of the source string
        array<Char>^ b = gcnew array<Char>(str->Length);
        // Create an instance of StringReader and attach it to the string.
        StringReader^ sr = gcnew StringReader(str);
        // Read 13 characters into the array that holds the string,
        // starting at the third array member.
        sr->Read(b, 0, 13);
        // Display the output.
        Console::WriteLine(b);
        // Read the rest of the string from the current position in the
        // source string into the array, starting at the 6th array member.
        sr->Read(b, 5, str->Length - 13);
        // Display the output.
        Console::WriteLine(b);
        // Close the StringReader.
        sr->Close();
    }
};

int main()
{
    CharsFromStr::Main();
}
// The example has the following output:
//
// Some number o
// Some f characters
//</snippet1>
