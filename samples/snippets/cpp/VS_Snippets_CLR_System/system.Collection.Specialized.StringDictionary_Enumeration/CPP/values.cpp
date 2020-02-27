// The following code example enumerates the elements of a StringDictionary.

// <snippet2>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Specialized;

public ref class SamplesStringDictionary
{
public:
    static void Main()
    {
        // Creates and initializes a new StringDictionary.
        StringDictionary^ myCol = gcnew StringDictionary();
        myCol->Add( "red", "rojo" );
        myCol->Add( "green", "verde" );
        myCol->Add( "blue", "azul" );

        Console::WriteLine("VALUES");
        for each (String^ val in myCol->Values)
        {
            Console::WriteLine(val);
        }
    }
};

int main()
{
    SamplesStringDictionary::Main();
}
// This code produces the following output.
// VALUE
// verde
// rojo
// azul
// </snippet2>
