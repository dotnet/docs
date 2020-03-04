
// <Snippet1>
using namespace System;

void main()
{
   // Create a string array with 3 elements having the same value.
   array<String^>^ strings = { "the", "quick", "brown", "fox",
                               "jumps", "over", "the", "lazy", "dog",
                               "in", "the", "barn" };

   // Display the elements of the array.
   Console::WriteLine("The array contains the following values:");
   for (int i = strings->GetLowerBound(0); i <= strings->GetUpperBound(0); i++)
      Console::WriteLine("   [{0,2}]: {1}", i, strings[i]);
      
   // Search for the first occurrence of the duplicated value.
   String^ searchString =  "the";
   int index = Array::IndexOf(strings, searchString);
   Console::WriteLine("The first occurrence of \"{0}\" is at index {1}.",
                      searchString, index);

   // Search for the first occurrence of the duplicated value in the last section of the array.
   index = Array::IndexOf( strings, searchString, 4);
   Console::WriteLine("The first occurrence of \"{0}\" between index 4 and the end is at index {1}.",
                      searchString, index);

   // Search for the first occurrence of the duplicated value in a section of the array.
   int position = index + 1;
   index = Array::IndexOf(strings, searchString, position, strings->GetUpperBound(0) - position + 1);
   Console::WriteLine("The first occurrence of \"{0}\" between index {1} and index {2} is at index {3}.",
                      searchString, position, strings->GetUpperBound(0), index);
}
// The example displays the following output:
//    The array contains the following values:
//       [ 0]: the
//       [ 1]: quick
//       [ 2]: brown
//       [ 3]: fox
//       [ 4]: jumps
//       [ 5]: over
//       [ 6]: the
//       [ 7]: lazy
//       [ 8]: dog
//       [ 9]: in
//       [10]: the
//       [11]: barn
//    The first occurrence of "the" is at index 0.
//    The first occurrence of "the" between index 4 and the end is at index 6.
//    The first occurrence of "the" between index 7 and index 11 is at index 10.
// </Snippet1>
