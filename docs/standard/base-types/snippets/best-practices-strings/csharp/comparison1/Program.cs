using System.Globalization;

// Words to sort
string[] values= { "able", "ångström", "apple", "Æble",
                    "Windows", "Visual Studio" };

// Current culture
Array.Sort(values);
DisplayArray(values);

// Change culture to Swedish (Sweden)
string originalCulture = CultureInfo.CurrentCulture.Name;
Thread.CurrentThread.CurrentCulture = new CultureInfo("sv-SE");
Array.Sort(values);
DisplayArray(values);

// Restore the original culture
Thread.CurrentThread.CurrentCulture = new CultureInfo(originalCulture);

static void DisplayArray(string[] values)
{
    Console.WriteLine($"Sorting using the {CultureInfo.CurrentCulture.Name} culture:");
    
    foreach (string value in values)
        Console.WriteLine($"   {value}");

    Console.WriteLine();
}

// The example displays the following output:
//     Sorting using the en-US culture:
//        able
//        Æble
//        ångström
//        apple
//        Visual Studio
//        Windows
//
//     Sorting using the sv-SE culture:
//        able
//        apple
//        Visual Studio
//        Windows
//        ångström
//        Æble
