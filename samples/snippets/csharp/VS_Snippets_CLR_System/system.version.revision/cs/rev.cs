//<snippet1>
// This example demonstrates the Version.Revision,
// MajorRevision, and MinorRevision properties.
using System;

class Sample 
{
    public static void Main() 
    {

    string fmtStd = "Standard version:\n" +
                    "  major.minor.build.revision = {0}.{1}.{2}.{3}";
    string fmtInt = "Interim version:\n" +
                    "  major.minor.build.majRev/minRev = {0}.{1}.{2}.{3}/{4}";

    Version std = new Version(2, 4, 1128, 2);
    Version interim = new Version(2, 4, 1128, (100 << 16) + 2);

    Console.WriteLine(fmtStd, std.Major, std.Minor, std.Build, std.Revision);
    Console.WriteLine(fmtInt, interim.Major, interim.Minor, interim.Build, 
                              interim.MajorRevision, interim.MinorRevision);
    }
}
/*
This code example produces the following results:

Standard version:
  major.minor.build.revision = 2.4.1128.2
Interim version:
  major.minor.build.majRev/minRev = 2.4.1128.100/2

*/
//</snippet1>