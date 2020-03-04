// <Snippet5>
using namespace System;

void main()
{
   Console::Write("Number of random numbers to generate: ");
   String^ line = Console::ReadLine();
   unsigned int numbers = 0;
   Random^ rnd = gcnew Random();
   
   if (! UInt32::TryParse(line, numbers))
      numbers = 10;
   
   for (unsigned int ctr = 1; ctr <= numbers; ctr++)
      Console::WriteLine("{0,15:N0}", rnd->Next());
}
// The example displays output like the following when asked to generate
// 15 random numbers:
//       Number of random numbers to generate: 15
//         1,733,189,596
//           566,518,090
//         1,166,108,546
//         1,931,426,514
//         1,341,108,291
//         1,012,698,049
//           890,578,409
//         1,377,589,722
//         2,108,384,181
//         1,532,939,448
//           762,207,767
//           815,074,920
//         1,521,208,785
//         1,950,436,671
//         1,266,596,666
// </Snippet5>
