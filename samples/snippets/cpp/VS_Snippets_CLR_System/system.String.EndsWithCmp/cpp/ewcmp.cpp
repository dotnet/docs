//<snippet1>
// This example demonstrates the 
// System.String.EndsWith(String, StringComparison) method.

using namespace System;
using namespace System::Threading;

void Test(String^ testString, String^ searchString, 
     StringComparison comparison)
{
    String^ resultFormat = "\"{0}\" {1} with \"{2}\".";
    String^ resultString = "does not end";

    if (testString->EndsWith(searchString, comparison))
    {
        resultString = "ends";
    }
    Console::WriteLine(resultFormat, testString, resultString, searchString);
}

int main()
{
    String^ introMessage =
        "Determine whether a string ends with another string, " +
        "using\ndifferent values of StringComparison.";

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
    Console::WriteLine("The current culture is {0}.\n",
        Thread::CurrentThread->CurrentCulture->Name);
    // Perform two tests for each StringComparison
    for each (StringComparison stringCmp in comparisonValues)
    {
        Console::WriteLine("StringComparison.{0}:", stringCmp);
        Test("abcXYZ", "XYZ", stringCmp);
        Test("abcXYZ", "xyz", stringCmp);
        Console::WriteLine();
    }
}

/*
This code example produces the following results:

Determine whether a string ends with another string, using
different values of StringComparison.
The current culture is en-US.

StringComparison.CurrentCulture:
"abcXYZ" ends with "XYZ".
"abcXYZ" does not end with "xyz".

StringComparison.CurrentCultureIgnoreCase:
"abcXYZ" ends with "XYZ".
"abcXYZ" ends with "xyz".

StringComparison.InvariantCulture:
"abcXYZ" ends with "XYZ".
"abcXYZ" does not end with "xyz".

StringComparison.InvariantCultureIgnoreCase:
"abcXYZ" ends with "XYZ".
"abcXYZ" ends with "xyz".

StringComparison.Ordinal:
"abcXYZ" ends with "XYZ".
"abcXYZ" does not end with "xyz".

StringComparison.OrdinalIgnoreCase:
"abcXYZ" ends with "XYZ".
"abcXYZ" ends with "xyz".

*/
//</snippet1>
