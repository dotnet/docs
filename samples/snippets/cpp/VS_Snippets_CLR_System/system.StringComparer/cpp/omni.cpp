//<snippet1>
// This example demonstrates members of the
// System::StringComparer class.

using namespace System;
using namespace System::Collections;
using namespace System::Collections::Generic;
using namespace System::Globalization;
using namespace System::Threading;

void Display(List<String^>^ stringList, String^ title)
{
    Char firstChar;
    int codePoint;
    Console::WriteLine(title);
    for each (String^ s in stringList)
    {
        firstChar = s[0];
        codePoint = Convert::ToInt32(firstChar);
        Console::WriteLine("0x{0:x}", codePoint);
    }
    Console::WriteLine();
}

int main()
{
    // Create a list of string.
    List<String^>^ stringList = gcnew List<String^>();

    // Get the tr-TR (Turkish-Turkey) culture.
    CultureInfo^ turkishCulture = gcnew CultureInfo("tr-TR");

    // Get the culture that is associated with the current thread.
    CultureInfo^ currentCulture = Thread::CurrentThread->CurrentCulture;

    // Get the standard StringComparers.
    StringComparer^ invariant = StringComparer::InvariantCulture;
    StringComparer^ invariantIgnoreCase =
        StringComparer::InvariantCultureIgnoreCase;
    StringComparer^ current = StringComparer::CurrentCulture;
    StringComparer^ currentIgnoreCase =
        StringComparer::CurrentCultureIgnoreCase;
    StringComparer^ ordinal = StringComparer::Ordinal;
    StringComparer^ ordinalIgnoreCase = StringComparer::OrdinalIgnoreCase;

    // Create a StringComparer that uses the Turkish culture and ignores
    // case.
    StringComparer^ turkishIgnoreCase =
        StringComparer::Create(turkishCulture, true);

    // Define three strings consisting of different versions of the
    // letter I. LATIN CAPITAL LETTER I (U+0049)
    String^ capitalLetterI = "I";

    // LATIN SMALL LETTER I (U+0069)
    String^ smallLetterI = "i";

    // LATIN SMALL LETTER DOTLESS I (U+0131)
    String^ smallLetterDotlessI = L"\u0131";

    // Add the three strings to the list.
    stringList->Add(capitalLetterI);
    stringList->Add(smallLetterI);
    stringList->Add(smallLetterDotlessI);

    // Display the original list order.
    Display(stringList, "The original order of the list entries...");

    // Sort the list using the invariant culture.
    stringList->Sort(invariant);
    Display(stringList, "Invariant culture...");
    stringList->Sort(invariantIgnoreCase);
    Display(stringList, "Invariant culture, ignore case...");

    // Sort the list using the current culture.
    Console::WriteLine("The current culture is \"{0}\".",
        currentCulture->Name);
    stringList->Sort(current);
    Display(stringList, "Current culture...");
    stringList->Sort(currentIgnoreCase);
    Display(stringList, "Current culture, ignore case...");

    // Sort the list using the ordinal value of the character code points.
    stringList->Sort(ordinal);
    Display(stringList, "Ordinal...");
    stringList->Sort(ordinalIgnoreCase);
    Display(stringList, "Ordinal, ignore case...");

    // Sort the list using the Turkish culture, which treats LATIN SMALL
    // LETTER DOTLESS I differently than LATIN SMALL LETTER I.
    stringList->Sort(turkishIgnoreCase);
    Display(stringList, "Turkish culture, ignore case...");
}
/*
This code example produces the following results:

The original order of the list entries...
0x49
0x69
0x131

Invariant culture...
0x69
0x49
0x131

Invariant culture, ignore case...
0x49
0x69
0x131

The current culture is "en-US".
Current culture...
0x69
0x49
0x131

Current culture, ignore case...
0x49
0x69
0x131

Ordinal...
0x49
0x69
0x131

Ordinal, ignore case...
0x69
0x49
0x131

Turkish culture, ignore case...
0x131
0x49
0x69

*/
//</snippet1>
