//<snippet1>
// This code example demonstrates the DateTime Kind, Now, and
// UtcNow properties, and the SpecifyKind(), ToLocalTime(), 
// and ToUniversalTime() methods.

using System;

class Sample 
{
    public static void Main() 
    {
// Get the date and time for the current moment, adjusted 
// to the local time zone.

    DateTime saveNow = DateTime.Now;

// Get the date and time for the current moment expressed 
// as coordinated universal time (UTC).

    DateTime saveUtcNow = DateTime.UtcNow;
    DateTime myDt;

// Display the value and Kind property of the current moment 
// expressed as UTC and local time.

    DisplayNow("UtcNow: ..........", saveUtcNow);
    DisplayNow("Now: .............", saveNow);
    Console.WriteLine();

// Change the Kind property of the current moment to 
// DateTimeKind.Utc and display the result.

    myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Utc);
    Display("Utc: .............", myDt);

// Change the Kind property of the current moment to 
// DateTimeKind.Local and display the result.

    myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Local);
    Display("Local: ...........", myDt);

// Change the Kind property of the current moment to 
// DateTimeKind.Unspecified and display the result.

    myDt = DateTime.SpecifyKind(saveNow, DateTimeKind.Unspecified);
    Display("Unspecified: .....", myDt);
    }

// Display the value and Kind property of a DateTime structure, the 
// DateTime structure converted to local time, and the DateTime 
// structure converted to universal time. 

    public static string datePatt = @"M/d/yyyy hh:mm:ss tt";
    public static void Display(string title, DateTime inputDt)
    {
    DateTime dispDt = inputDt;
    string dtString;

// Display the original DateTime.

    dtString = dispDt.ToString(datePatt);
    Console.WriteLine("{0} {1}, Kind = {2}", 
                      title, dtString, dispDt.Kind);

// Convert inputDt to local time and display the result. 
// If inputDt.Kind is DateTimeKind.Utc, the conversion is performed.
// If inputDt.Kind is DateTimeKind.Local, the conversion is not performed.
// If inputDt.Kind is DateTimeKind.Unspecified, the conversion is 
// performed as if inputDt was universal time.

    dispDt = inputDt.ToLocalTime();
    dtString = dispDt.ToString(datePatt);
    Console.WriteLine("  ToLocalTime:     {0}, Kind = {1}", 
                      dtString, dispDt.Kind);

// Convert inputDt to universal time and display the result. 
// If inputDt.Kind is DateTimeKind.Utc, the conversion is not performed.
// If inputDt.Kind is DateTimeKind.Local, the conversion is performed.
// If inputDt.Kind is DateTimeKind.Unspecified, the conversion is 
// performed as if inputDt was local time.

    dispDt = inputDt.ToUniversalTime();
    dtString = dispDt.ToString(datePatt);
    Console.WriteLine("  ToUniversalTime: {0}, Kind = {1}", 
                      dtString, dispDt.Kind);
    Console.WriteLine();
    }

// Display the value and Kind property for DateTime.Now and DateTime.UtcNow.

    public static void DisplayNow(string title, DateTime inputDt)
    {
    string dtString = inputDt.ToString(datePatt);
    Console.WriteLine("{0} {1}, Kind = {2}", 
                      title, dtString, inputDt.Kind);
    }
}

/*
This code example produces the following results:

UtcNow: .......... 5/6/2005 09:34:42 PM, Kind = Utc
Now: ............. 5/6/2005 02:34:42 PM, Kind = Local

Utc: ............. 5/6/2005 02:34:42 PM, Kind = Utc
  ToLocalTime:     5/6/2005 07:34:42 AM, Kind = Local
  ToUniversalTime: 5/6/2005 02:34:42 PM, Kind = Utc

Local: ........... 5/6/2005 02:34:42 PM, Kind = Local
  ToLocalTime:     5/6/2005 02:34:42 PM, Kind = Local
  ToUniversalTime: 5/6/2005 09:34:42 PM, Kind = Utc

Unspecified: ..... 5/6/2005 02:34:42 PM, Kind = Unspecified
  ToLocalTime:     5/6/2005 07:34:42 AM, Kind = Local
  ToUniversalTime: 5/6/2005 09:34:42 PM, Kind = Utc

*/
//</snippet1>