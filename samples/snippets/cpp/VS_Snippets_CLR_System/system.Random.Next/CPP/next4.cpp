// <Snippet4>
using namespace System;

void main()
{
   Random^ rnd = gcnew Random();
   array<String^>^ malePetNames = { "Rufus", "Bear", "Dakota", "Fido",
                                    "Vanya", "Samuel", "Koani", "Volodya",
                                    "Prince", "Yiska" };
   array<String^>^ femalePetNames = { "Maggie", "Penny", "Saya", "Princess",
                                      "Abby", "Laila", "Sadie", "Olivia",
                                      "Starlight", "Talla" };
   
   // Generate random indexes for pet names.
   int mIndex = rnd->Next(0, malePetNames->Length);
   int fIndex = rnd->Next(0, femalePetNames->Length);
   
   // Display the result.
   Console::WriteLine("Suggested pet name of the day: ");
   Console::WriteLine("   For a male:     {0}", malePetNames[mIndex]);
   Console::WriteLine("   For a female:   {0}", femalePetNames[fIndex]);
}
// The example displays the following output:
//       Suggested pet name of the day:
//          For a male:     Koani
//          For a female:   Maggie
// </Snippet4>
