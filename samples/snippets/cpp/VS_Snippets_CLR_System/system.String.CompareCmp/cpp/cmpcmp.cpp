//<snippet1>
// This example demonstrates the
// System.String.Compare(String, String, StringComparison) method.

using namespace System;
using namespace System::Threading;

void Test(int testStringIndex, int searchStringIndex, 
          StringComparison comparison, array<String^>^ testI, 
          array<String^>^ testNames)
{
    String^ resultFormat = "{0} is {1} {2}";
    String^ resultString = "equal to";
    int comparisonValue = 0;

    comparisonValue = String::Compare(testI[testStringIndex],
        testI[searchStringIndex], comparison);
    if (comparisonValue < 0)
    {
        resultString = "less than";
    }
    else if (comparisonValue > 0)
    {
        resultString = "greater than";
    }
    Console::WriteLine(resultFormat, testNames[testStringIndex], resultString,
        testNames[searchStringIndex]);
}

int main()
{
    String^ introMessage =
        "Compare three versions of the letter I using different " +
        "values of StringComparison.";

    // Define an array of strings where each element contains a version of
    // the letter I. (An array of strings is used so you can easily modify
    // this code example to test additional or different combinations of
    // strings.)

    array<String^>^ letterVariation = gcnew array<String^>(3);
    // LATIN SMALL LETTER I (U+0069)
    letterVariation[0] = "i";
    // LATIN SMALL LETTER DOTLESS I (U+0131)
    letterVariation[1] = L"\u0131";
    // LATIN CAPITAL LETTER I (U+0049)
    letterVariation[2] = "I";

    array<String^>^ unicodeNames = {
        "LATIN SMALL LETTER I (U+0069)",
        "LATIN SMALL LETTER DOTLESS I (U+0131)",
        "LATIN CAPITAL LETTER I (U+0049)"};

    array<StringComparison>^ comparisonValues = {
        StringComparison::CurrentCulture,
        StringComparison::CurrentCultureIgnoreCase,
        StringComparison::InvariantCulture,
        StringComparison::InvariantCultureIgnoreCase,
        StringComparison::Ordinal,
        StringComparison::OrdinalIgnoreCase};

    Console::Clear();
    Console::WriteLine(introMessage);

    // Display the current culture because the culture-specific comparisons
    // can produce different results with different cultures.
    Console::WriteLine("The current culture is {0}.{1}",
        Thread::CurrentThread->CurrentCulture->Name, Environment::NewLine);

    // Determine the relative sort order of three versions of the letter I.
    for each (StringComparison stringCmp in comparisonValues)
    {
        Console::WriteLine("StringComparison.{0}:", stringCmp);

        // LATIN SMALL LETTER I (U+0069) : LATIN SMALL LETTER DOTLESS I
        // (U+0131)
        Test(0, 1, stringCmp, letterVariation, unicodeNames);

        // LATIN SMALL LETTER I (U+0069) : LATIN CAPITAL LETTER I (U+0049)
        Test(0, 2, stringCmp, letterVariation, unicodeNames);

        // LATIN SMALL LETTER DOTLESS I (U+0131) : LATIN CAPITAL LETTER I
        // (U+0049)
        Test(1, 2, stringCmp, letterVariation, unicodeNames);

        Console::WriteLine();
    }
}

/*
This code example produces the following results:

Compare three versions of the letter I using different values of 
StringComparison.
The current culture is en-US.

StringComparison.CurrentCulture:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER 
  DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is less than LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN 
  CAPITAL LETTER I (U+0049)

StringComparison.CurrentCultureIgnoreCase:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER 
  DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN 
  CAPITAL LETTER I (U+0049)

StringComparison.InvariantCulture:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER 
  DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is less than LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN 
  CAPITAL LETTER I (U+0049)

StringComparison.InvariantCultureIgnoreCase:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER 
  DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN 
  CAPITAL LETTER I (U+0049)

StringComparison.Ordinal:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER 
  DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is greater than LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN 
  CAPITAL LETTER I (U+0049)

StringComparison.OrdinalIgnoreCase:
LATIN SMALL LETTER I (U+0069) is less than LATIN SMALL LETTER 
  DOTLESS I (U+0131)
LATIN SMALL LETTER I (U+0069) is equal to LATIN CAPITAL LETTER I (U+0049)
LATIN SMALL LETTER DOTLESS I (U+0131) is greater than LATIN 
  CAPITAL LETTER I (U+0049)

*/
//</snippet1>
