// <Snippet12>
using namespace System;

void main()
{
   String^ str = "animal";
   String^ toFind = "n";
   int index = str->IndexOf("n");
   Console::WriteLine("Found '{0}' in '{1}' at position {2}",
                        toFind, str, index);

}
// The example displays the following output:
//        Found 'n' in 'animal' at position 1
// </Snippet12>