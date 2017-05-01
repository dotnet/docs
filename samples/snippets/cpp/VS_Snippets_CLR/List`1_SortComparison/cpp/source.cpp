// REDMOND\glennha
// <Snippet1>
using namespace System;
using namespace System::Collections::Generic;

int CompareDinosByLength(String^ x, String^ y)
{
    if (x == nullptr)
    {
        if (y == nullptr)
        {
            // If x is null and y is null, they're
            // equal. 
            return 0;
        }
        else
        {
            // If x is null and y is not null, y
            // is greater. 
            return -1;
        }
    }
    else
    {
        // If x is not null...
        //
        if (y == nullptr)
            // ...and y is null, x is greater.
        {
            return 1;
        }
        else
        {
            // ...and y is not null, compare the 
            // lengths of the two strings.
            //
            int retval = x->Length.CompareTo(y->Length);

            if (retval != 0)
            {
                // If the strings are not of equal length,
                // the longer string is greater.
                //
                return retval;
            }
            else
            {
                // If the strings are of equal length,
                // sort them with ordinary string comparison.
                //
                return x->CompareTo(y);
            }
        }
    }
};

void Display(List<String^>^ list)
{
    Console::WriteLine();
    for each(String^ s in list)
    {
        if (s == nullptr)
            Console::WriteLine("(null)");
        else
            Console::WriteLine("\"{0}\"", s);
    }
};

void main()
{
    List<String^>^ dinosaurs = gcnew List<String^>();
    dinosaurs->Add("Pachycephalosaurus");
    dinosaurs->Add("Amargasaurus");
    dinosaurs->Add("");
    dinosaurs->Add(nullptr);
    dinosaurs->Add("Mamenchisaurus");
    dinosaurs->Add("Deinonychus");
    Display(dinosaurs);

    Console::WriteLine("\nSort with generic Comparison<String^> delegate:");
    dinosaurs->Sort(
        gcnew Comparison<String^>(CompareDinosByLength));
    Display(dinosaurs);

}

/* This code example produces the following output:

"Pachycephalosaurus"
"Amargasaurus"
""
(null)
"Mamenchisaurus"
"Deinonychus"

Sort with generic Comparison<String^> delegate:

(null)
""
"Deinonychus"
"Amargasaurus"
"Mamenchisaurus"
"Pachycephalosaurus"
 */
// </Snippet1>


