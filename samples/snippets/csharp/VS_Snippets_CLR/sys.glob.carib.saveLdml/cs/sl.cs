//<snippet1>
// This example demonstrates the CultureAndRegionInfoBuilder.Save and 
// CreateFromLdml methods.
// Compile this example with a reference to sysglobl.dll.

using System;
using System.Globalization;
using System.IO;
using System.Xml;

class Sample 
{
    public static void Main() 
    {
    string savedCARIB = "mySavedCARIB.xml";
    string msg1 = "The name of the original CultureAndRegionInfoBuilder" +
                  " is \"{0}\".";
    string msg2 = "Reconstituting the CultureAndRegionInfoBuilder object " +
                  "from \"{0}\".";
    string msg3 = "The name of the reconstituted CultureAndRegionInfoBuilder" +
                  " is \"{0}\".";

// Construct a new, privately used culture that extends the en-US culture 
// provided by the .NET Framework. In this sample, the CultureAndRegion-
// Types.Specific parameter creates a minimal CultureAndRegionInfoBuilder 
// object that you must populate with culture and region information.

    CultureAndRegionInfoBuilder cib1 = null;
    CultureAndRegionInfoBuilder cib2 = null;
    try {
        cib1 = new CultureAndRegionInfoBuilder(
                           "x-en-US-sample", CultureAndRegionModifiers.None);
        }
    catch (ArgumentException ae)
        {
        Console.WriteLine(ae);
        return;
        }

// Populate the new CultureAndRegionInfoBuilder object with culture information.
    CultureInfo ci = new CultureInfo("en-US");
    cib1.LoadDataFromCultureInfo(ci);

// Populate the new CultureAndRegionInfoBuilder object with region information.
    RegionInfo  ri = new RegionInfo("US");
    cib1.LoadDataFromRegionInfo(ri);

// Display a property of the new custom culture.
    Console.Clear();
    Console.WriteLine(msg1, cib1.CultureName);

// Save the new CultureAndRegionInfoBuilder object in the specified file in
// LDML format. The file is saved in the same directory as the application 
// that calls the Save method.

    Console.WriteLine("Saving the custom culture to a file...");
    try {
        cib1.Save( savedCARIB );
        }
    catch (IOException exc)
        {
        Console.WriteLine("** I/O exception: {0}", exc.Message);
        return;
        }

// Create a new CultureAndRegionInfoBuilder object from the persisted file.
    Console.WriteLine(msg2, savedCARIB);
    try {
        cib2 = CultureAndRegionInfoBuilder.CreateFromLdml( savedCARIB );
        }
    catch (XmlException xe)
        {
        Console.WriteLine("** XML validation exception: {0}", xe.Message);
        return;
        }

// Display a property of the resonstituted custom culture.
    Console.WriteLine(msg3, cib2.CultureName);

// At this point you could call the Register method and make the reconstituted
// custom culture available to other applications. The mySavedCARIB.xml file
// remains on your computer.
    }
}

/*
This code example produces the following results:

The name of the original CultureAndRegionInfoBuilder is "x-en-US-sample".
Saving the custom culture to a file...
Reconstituting the CultureAndRegionInfoBuilder object from "mySavedCARIB.xml".
The name of the reconstituted CultureAndRegionInfoBuilder is "x-en-US-sample".

*/
//</snippet1>