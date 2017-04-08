//<SNIPPET1>
//The following sample uses the Cryptography class to simulate the roll of a dice.

using namespace System;
using namespace System::IO;
using namespace System::Text;
using namespace System::Security::Cryptography;

ref class RNGCSP
{
public:
    // Main method.
    static void Main()
    {
        const int totalRolls = 25000;
        array<int>^ results = gcnew array<int>(6);

        // Roll the dice 25000 times and display
        // the results to the console.
        for (int x = 0; x < totalRolls; x++)
        {
            Byte roll = RollDice((Byte)results->Length);
            results[roll - 1]++;
        }
        for (int i = 0; i < results->Length; ++i)
        {
            Console::WriteLine("{0}: {1} ({2:p1})", i + 1, results[i], (double)results[i] / (double)totalRolls);
        }
    }

    // This method simulates a roll of the dice. The input parameter is the
    // number of sides of the dice.

    static Byte RollDice(Byte numberSides)
    {
        if (numberSides <= 0)
            throw gcnew ArgumentOutOfRangeException("numberSides");
        // Create a new instance of the RNGCryptoServiceProvider.
        RNGCryptoServiceProvider^ rngCsp = gcnew RNGCryptoServiceProvider();
        // Create a byte array to hold the random value.
        array<Byte>^ randomNumber = gcnew array<Byte>(1);
        do
        {
            // Fill the array with a random value.
            rngCsp->GetBytes(randomNumber);
        }
        while (!IsFairRoll(randomNumber[0], numberSides));
        // Return the random number mod the number
        // of sides.  The possible values are zero-
        // based, so we add one.
        return (Byte)((randomNumber[0] % numberSides) + 1);
    }

private:
    static bool IsFairRoll(Byte roll, Byte numSides)
    {
        // There are MaxValue / numSides full sets of numbers that can come up
        // in a single byte.  For instance, if we have a 6 sided die, there are
        // 42 full sets of 1-6 that come up.  The 43rd set is incomplete.
        int fullSetsOfValues = Byte::MaxValue / numSides;

        // If the roll is within this range of fair values, then we let it continue.
        // In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use
        // < rather than <= since the = portion allows through an extra 0 value).
        // 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair
        // to use.
        return roll < numSides * fullSetsOfValues;
    }
};

int main()
{
    RNGCSP::Main();
}
//</SNIPPET1>