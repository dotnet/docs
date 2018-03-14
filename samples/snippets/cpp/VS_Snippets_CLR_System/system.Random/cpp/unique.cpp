// <Snippet13>
using namespace System;
using namespace System::Threading;

void main()
{
   Console::WriteLine("Instantiating two random number generators...");
   Random^ rnd1 = gcnew Random();
   Thread::Sleep(2000);
   Random^ rnd2 = gcnew Random();
   
   Console::WriteLine("\nThe first random number generator:");
   for (int ctr = 1; ctr <= 10; ctr++)
      Console::WriteLine("   {0}", rnd1->Next());

   Console::WriteLine("\nThe second random number generator:");
   for (int ctr = 1; ctr <= 10; ctr++)
      Console::WriteLine("   {0}", rnd2->Next());
}
// The example displays output like the following:
//       Instantiating two random number generators...
//       
//       The first random number generator:
//          643164361
//          1606571630
//          1725607587
//          2138048432
//          496874898
//          1969147632
//          2034533749
//          1840964542
//          412380298
//          47518930
//       
//       The second random number generator:
//          1251659083
//          1514185439
//          1465798544
//          517841554
//          1821920222
//          195154223
//          1538948391
//          1548375095
//          546062716
//          897797880
// </Snippet13>

