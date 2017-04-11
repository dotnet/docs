// <Snippet2>
using namespace System;
using namespace System::Collections;

public class HashtableExample
{
public:
    static void Main()
    {
        // Creates and initializes a new Hashtable.
        Hashtable^ clouds = gcnew Hashtable();
        clouds->Add("Cirrus", "Castellanus");
        clouds->Add("Cirrocumulus", "Stratiformis");
        clouds->Add("Altostratus", "Radiatus");
        clouds->Add("Stratocumulus", "Perlucidus");
        clouds->Add("Stratus", "Fractus");
        clouds->Add("Nimbostratus", "Pannus");
        clouds->Add("Cumulus", "Humilis");
        clouds->Add("Cumulonimbus", "Incus");

        // Displays the keys and values of the Hashtable using GetEnumerator()

        IDictionaryEnumerator^ denum = clouds->GetEnumerator();
        DictionaryEntry dentry;

        Console::WriteLine();
        Console::WriteLine("    Cloud Type       Variation");
        Console::WriteLine("    -----------------------------");
        while (denum->MoveNext())
        {
            dentry = (DictionaryEntry) denum->Current;
            Console::WriteLine("    {0,-17}{1}", dentry.Key, dentry.Value);
        }
        Console::WriteLine();

        // Displays the keys and values of the Hashtable using foreach statement

        Console::WriteLine("    Cloud Type       Variation");
        Console::WriteLine("    -----------------------------");
        for each (DictionaryEntry de in clouds)
        {
            Console::WriteLine("    {0,-17}{1}", de.Key, de.Value);
        }
        Console::WriteLine();
    }
};

int main()
{
    HashtableExample::Main();
}

// The program displays the following output to the console:
//
//    Cloud Type       Variation
//    -----------------------------
//    Cirrocumulus     Stratiformis
//    Stratocumulus    Perlucidus
//    Cirrus           Castellanus
//    Cumulus          Humilis
//    Nimbostratus     Pannus
//    Stratus          Fractus
//    Altostratus      Radiatus
//    Cumulonimbus     Incus
//
//    Cloud Type       Variation
//    -----------------------------
//    Cirrocumulus     Stratiformis
//    Stratocumulus    Perlucidus
//    Cirrus           Castellanus
//    Cumulus          Humilis
//    Nimbostratus     Pannus
//    Stratus          Fractus
//    Altostratus      Radiatus
//    Cumulonimbus     Incus*/
// </Snippet2>