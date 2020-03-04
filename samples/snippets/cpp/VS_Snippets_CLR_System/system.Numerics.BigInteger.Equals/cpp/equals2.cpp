// Equals2.cpp : Defines the entry point for the console application.
//

// <Snippet2>
#using <System.Numerics.dll>

using namespace System;
using namespace System::Numerics;


void main()
{
   const Int64 LIGHT_YEAR = 5878625373183;

   BigInteger altairDistance = 17 * LIGHT_YEAR;
   BigInteger epsilonIndiDistance = 12 * LIGHT_YEAR;
   BigInteger ursaeMajoris47Distance = 46 * LIGHT_YEAR;
   Int64 tauCetiDistance = 12 * LIGHT_YEAR;
   UInt64 procyon2Distance = 12 * LIGHT_YEAR;
   Object^ wolf424ABDistance = 14 * LIGHT_YEAR;

   Console::WriteLine("Approx. equal distances from Epsilon Indi to:");
   Console::WriteLine("   Altair: {0}",
      epsilonIndiDistance.Equals(altairDistance));
   Console::WriteLine("   Ursae Majoris 47: {0}",
      epsilonIndiDistance.Equals(ursaeMajoris47Distance));
   Console::WriteLine("   TauCeti: {0}",
      epsilonIndiDistance.Equals(tauCetiDistance));
   Console::WriteLine("   Procyon 2: {0}",
      epsilonIndiDistance.Equals(procyon2Distance));
   Console::WriteLine("   Wolf 424 AB: {0}",
      epsilonIndiDistance.Equals(wolf424ABDistance));
}
/*
The example displays output like the following:
      Approx. equal distances from Epsilon Indi to:
      Altair: False
      Ursae Majoris 47: False
      TauCeti: True
      Procyon 2: True
      Wolf 424 AB: False
*/
// </Snippet2>