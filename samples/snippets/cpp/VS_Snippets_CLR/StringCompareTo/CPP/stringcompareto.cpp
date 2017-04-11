
//<snippet1>
using namespace System;

String^ CompareStrings(String^ str1, String^ str2)
{
   // compare the values, using the CompareTo method on the first string
   int cmpVal = str1->CompareTo(str2);
   if (cmpVal == 0)
      // the values are the same
      return "The strings occur in the same position in the sort order.";
   else if (cmpVal < 0)
      return "The first string precedes the second in the sort order.";
   else
      return "The first string follows the second in the sort order.";
}

int main()
{
   String^ strFirst = "Goodbye";
   String^ strSecond = "Hello";
   String^ strThird = "a small String*";
   String^ strFourth = "goodbye";
   
   // Compare a string to itself.
   Console::WriteLine(CompareStrings(strFirst, strFirst));
   Console::WriteLine(CompareStrings(strFirst, strSecond));
   Console::WriteLine(CompareStrings(strFirst, strThird));
   
   // Compare a string to another string that varies only by case.
   Console::WriteLine(CompareStrings(strFirst, strFourth));
   Console::WriteLine(CompareStrings(strFourth, strFirst));
}
// The example displays the following output:
//       The strings occur in the same position in the sort order.
//       The first string precedes the second in the sort order.
//       The first string follows the second in the sort order.
//       The first string follows the second in the sort order.
//       The first string precedes the second in the sort order.
//</snippet1>
