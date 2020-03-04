//<Snippet2>
using namespace System;

void main()
{
   Random^ rnd = gcnew Random();

   Console::WriteLine("\n20 random integers from -100 to 100:");
   for (int ctr = 1; ctr <= 20; ctr++) 
   {
      Console::Write("{0,6}", rnd->Next(-100, 101));
      if (ctr % 5 == 0) Console::WriteLine();
   }
   
   Console::WriteLine("\n20 random integers from 1000 to 10000:");      
   for (int ctr = 1; ctr <= 20; ctr++) 
   {
      Console::Write("{0,8}", rnd->Next(1000, 10001));
      if (ctr % 5 == 0) Console::WriteLine();
   }
   
   Console::WriteLine("\n20 random integers from 1 to 10:");
   for (int ctr = 1; ctr <= 20; ctr++) 
   {
      Console::Write("{0,6}", rnd->Next(1, 11));
      if (ctr % 5 == 0) Console::WriteLine();
   }
}
// The example displays output similar to the following:
//       20 random integers from -100 to 100:
//           65   -95   -10    90   -35
//          -83   -16   -15   -19    41
//          -67   -93    40    12    62
//          -80   -95    67   -81   -21
//       
//       20 random integers from 1000 to 10000:
//           4857    9897    4405    6606    1277
//           9238    9113    5151    8710    1187
//           2728    9746    1719    3837    3736
//           8191    6819    4923    2416    3028
//       
//       20 random integers from 1 to 10:
//            9     8     5     9     9
//            9     1     2     3     8
//            1     4     8    10     5
//            9     7     9    10     5
// </Snippet2>
