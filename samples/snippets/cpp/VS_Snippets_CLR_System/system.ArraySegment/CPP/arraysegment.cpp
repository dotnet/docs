// The following code example passes an ArraySegment to a method.

// <Snippet1>
using namespace System;


namespace Sample
{
    public ref class SampleArray  
    {
    public:
        static void Work()  
        {

            // Create and initialize a new string array.
            array <String^>^ words = {"The", "quick", "brown",
                "fox", "jumps", "over", "the", "lazy", "dog"};

            // Display the initial contents of the array.
            Console::WriteLine("The first array segment"
		        " (with all the array's elements) contains:");
            PrintIndexAndValues(words);

            // Define an array segment that contains the entire array.
            ArraySegment<String^> segment(words);
			
            // Display the contents of the ArraySegment.
            Console::WriteLine("The first array segment"
                " (with all the array's elements) contains:");
            PrintIndexAndValues(segment);

            // Define an array segment that contains the middle five 
            // values of the array.
            ArraySegment<String^> middle(words, 2, 5);
            
            // Display the contents of the ArraySegment.
            Console::WriteLine("The second array segment"
                " (with the middle five elements) contains:");
            PrintIndexAndValues(middle);

            // Modify the fourth element of the first array 
            // segment
            segment.Array[3] = "LION";

            // Display the contents of the second array segment 
            // middle. Note that the value of its second element 
            // also changed.
            Console::WriteLine("After the first array segment"
                " is modified,the second array segment"
                " now contains:");
            PrintIndexAndValues(middle);
            Console::ReadLine();
        }

        static void PrintIndexAndValues(ArraySegment<String^>^ segment)  
        {
            for (int i = segment->Offset; 
                i < (segment->Offset + segment->Count); i++)  
            {
                Console::WriteLine("   [{0}] : {1}", i,
                    segment->Array[i]);
            }
            Console::WriteLine();
        }

        static void PrintIndexAndValues(array<String^>^ words) 
        {
            for (int i = 0; i < words->Length; i++)  
            {
                Console::WriteLine("   [{0}] : {1}", i,
                    words[i]);
            }
            Console::WriteLine();
        }
    };
}

int main()
{
    Sample::SampleArray::Work();
    return 0; 
}


    /* 
    This code produces the following output.

    The original array initially contains:
    [0] : The
    [1] : quick
    [2] : brown
    [3] : fox
    [4] : jumps
    [5] : over
    [6] : the
    [7] : lazy
    [8] : dog

    The first array segment (with all the array's elements) contains:
    [0] : The
    [1] : quick
    [2] : brown
    [3] : fox
    [4] : jumps
    [5] : over
    [6] : the
    [7] : lazy
    [8] : dog

    The second array segment (with the middle five elements) contains:
    [2] : brown
    [3] : fox
    [4] : jumps
    [5] : over
    [6] : the

    After the first array segment is modified, the second array segment now contains:
    [2] : brown
    [3] : LION
    [4] : jumps
    [5] : over
    [6] : the

    */

    // </Snippet1>
