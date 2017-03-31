// <Snippet6>
using namespace System;

void main()
{
   String^ s1 = "We went to a bookstore, ";
   String^ s2 = "a movie, ";
   String^ s3 = "and a restaurant.";

   String^ s = String::Concat(s1, s2, s3);
   Console::WriteLine(s);
}
// The example displays the following output:
//      We went to a bookstore, a movie, and a restaurant. 
// </Snippet6>
