//<snippet1>
// This example demonstrates the Version.Revision,
// MajorRevision, and MinorRevision properties.
using namespace System;

int main()
{
    String^ formatStandard = "Standard version:\n" +
        " major.minor.build.revision = {0}.{1}.{2}.{3}";
    String^ formatInterim = "Interim version:\n" +
        " major.minor.build.majRev/minRev = {0}.{1}.{2}.{3}/{4}";

    Version^ standardVersion = gcnew Version(2, 4, 1128, 2);
    Version^ interimVersion = gcnew Version(2, 4, 1128, (100 << 16) + 2);

    Console::WriteLine(formatStandard, standardVersion->Major, 
        standardVersion->Minor, standardVersion->Build, 
        standardVersion->Revision);
    Console::WriteLine(formatInterim, interimVersion->Major,
        interimVersion->Minor, interimVersion->Build, 
        interimVersion->MajorRevision, interimVersion->MinorRevision);
};
/*
This code example produces the following results:

Standard version:
major.minor.build.revision = 2.4.1128.2
Interim version:
major.minor.build.majRev/minRev = 2.4.1128.100/2

*/
//</snippet1>
