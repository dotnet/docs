//<Snippet1>
using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Runtime::InteropServices;

int main()
{
    Console::WriteLine( "Welcome to the CPP ZoneIdentityPermission sample\n");

    typedef ZoneIdentityPermission ZIP, ^pZIP;
    pZIP  z1 = gcnew ZIP(SecurityZone::Intranet),
          z2 = gcnew ZIP(SecurityZone::MyComputer),
          z3 = gcnew ZIP(SecurityZone::Untrusted);

    Console::WriteLine( "Zone1 = \"{0}\", Zone2 = \"{1}\", "
                        "Zone3 = \"{2}\"\n", z1->SecurityZone, z2->SecurityZone, z3->SecurityZone);

    Console::WriteLine( "Subset:       Zone1->IsSubsetOf(Zone2): {0}", z1->IsSubsetOf(z2)?"yes":"no");

    z3 = (pZIP)z1->Union(z2);
    Console::WriteLine( "Union:        Zone1->Union(Zone2): {0}", z3->SecurityZone);

    z3 = (pZIP)z1->Intersect(z2);
    Console::WriteLine( "Intersection: Zone1->Intersect(Zone2): {0}\n", z3?z3->SecurityZone.ToString():"null" );

    z3 = (pZIP)z1->Copy();
    Console::WriteLine( "Copy: Zone1 to Zone3: Zone3->SecurityZone = {0}\n", z3->SecurityZone );

    SecurityElement ^ pSE = z1->ToXml();
    String ^ xml = pSE->ToString();

    Console::WriteLine( "Convert Zone1 to a SecurityElement pointer: pSE = z1->ToXml()\n\n"
                        "Display the XML string:  pSE->ToString(): {0}", xml);

    z2->FromXml(pSE);
    Console::WriteLine( "Load from XML: Zone2->FromXml(pSE)");
    Console::WriteLine( "Zone2 has a new security zone: Zone2->SecurityZone = {0}", z2->SecurityZone);

    Console::WriteLine("\nPress the enter key to exit");
    Console::ReadLine();
}

// </Snippet1>