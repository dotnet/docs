// <Snippet12>
using namespace System;
using namespace System::IO;

ref class RandomMethods
{
internal:
   static void ShowRandomNumbers(int seed)
   {
      Random^ rnd = gcnew Random(seed);
      for (int ctr = 0; ctr <= 20; ctr++)
         Console::WriteLine(rnd->NextDouble());
   }
   
   static void PersistSeed(int seed)
   {
      FileStream^ fs = gcnew FileStream(".\\seed.dat", FileMode::Create);
      BinaryWriter^ bin = gcnew BinaryWriter(fs);
      bin->Write(seed);
      bin->Close();
   }
   
   static void DisplayNewRandomNumbers()
   {
      FileStream^ fs = gcnew FileStream(".\\seed.dat", FileMode::Open);
      BinaryReader^ bin = gcnew BinaryReader(fs);
      int seed = bin->ReadInt32();
      bin->Close();
      
      Random^ rnd = gcnew Random(seed);
      for (int ctr = 0; ctr <= 20; ctr++)
         Console::WriteLine(rnd->NextDouble());
   }
};

void main()
{
   int seed = 100100;
   RandomMethods::ShowRandomNumbers(seed);
   Console::WriteLine();

   RandomMethods::PersistSeed(seed);

   RandomMethods::DisplayNewRandomNumbers();
}
// The example displays output like the following:
//       0.500193602172748
//       0.0209461245783354
//       0.465869495396442
//       0.195512794514891
//       0.928583675496552
//       0.729333720509584
//       0.381455668891527
//       0.0508996467343064
//       0.019261200921266
//       0.258578445417145
//       0.0177532266908107
//       0.983277184415272
//       0.483650274334313
//       0.0219647376900375
//       0.165910115077118
//       0.572085966622497
//       0.805291457942357
//       0.927985211335116
//       0.4228545699375
//       0.523320379910674
//       0.157783938645285
//       
//       0.500193602172748
//       0.0209461245783354
//       0.465869495396442
//       0.195512794514891
//       0.928583675496552
//       0.729333720509584
//       0.381455668891527
//       0.0508996467343064
//       0.019261200921266
//       0.258578445417145
//       0.0177532266908107
//       0.983277184415272
//       0.483650274334313
//       0.0219647376900375
//       0.165910115077118
//       0.572085966622497
//       0.805291457942357
//       0.927985211335116
//       0.4228545699375
//       0.523320379910674
//       0.157783938645285
// </Snippet12>


