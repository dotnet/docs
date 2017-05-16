// The following example wraps an array in a read-only IList.
#using <System.dll>

// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

namespace Samples
{
    public ref class SamplesArray
    {
    public:
        static void Work()
        {

            // Create and initialize a new string array.
            array <String^>^ textArray = 
                {"The", "quick", "brown", "fox"};

            // Display the values of the array.
            Console::WriteLine("The string array initially contains "
                "the following values:");
            PrintIndexAndValues(textArray);

            // Create a read-only IList wrapper around the array.
            IList <String^>^ textList = Array::AsReadOnly(textArray);

            // Display the values of the read-only IList.
            Console::WriteLine("The read-only IList contains " 
                "the following values:");
            PrintIndexAndValues(textList);

            // Attempt to change a value through the wrapper.
            try
            {
                textList[3] = "CAT";
            }
            catch (NotSupportedException^ ex) 
            {
                Console::WriteLine("{0} - {1}", ex->GetType(), 
                    ex->Message);
                Console::WriteLine();
            }


            // Change a value in the original array.
            textArray[2] = "RED";

            // Display the values of the array.
            Console::WriteLine("After changing the third element," 
                "the string array contains the following values:");
            PrintIndexAndValues(textArray);

            // Display the values of the read-only IList.
            Console::WriteLine("After changing the third element, the" 
                " read-only IList contains the following values:");
            PrintIndexAndValues(textList);
        }

        static void PrintIndexAndValues(array<String^>^ textArray)
        {
            for (int i = 0; i < textArray->Length; i++)
            {
                Console::WriteLine("   [{0}] : {1}", i, textArray[i]);
            }
            Console::WriteLine();
        }

        static void PrintIndexAndValues(IList<String^>^ textList)
        {
            for (int i = 0; i < textList->Count; i++)
            {
                Console::WriteLine("   [{0}] : {1}", i, textList[i]);
            }
            Console::WriteLine();
        }
    };
}

int main()
{
    Samples::SamplesArray::Work();

}

/* 
This code produces the following output.

The string array initially contains the following values:
[0] : The
[1] : quick
[2] : brown
[3] : fox

The read-only IList contains the following values:
[0] : The
[1] : quick
[2] : brown
[3] : fox

System.NotSupportedException - Collection is read-only.

After changing the third element, the string array contains the following values:
[0] : The
[1] : quick
[2] : RED
[3] : fox

After changing the third element, the read-only IList contains the following values:
[0] : The
[1] : quick
[2] : RED
[3] : fox

*/
// </Snippet1>
