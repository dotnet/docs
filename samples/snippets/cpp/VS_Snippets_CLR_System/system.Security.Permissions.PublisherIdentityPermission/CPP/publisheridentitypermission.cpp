//<Snippet1>
// To execute this sample you will need two certification files, MyCert1.cer and MyCert2.cer.
// The certification files can be created using the Certification Creation Tool, MakeCert.exe,
// which runs from the command line.  Usage:  MakeCert MyCert1.cer

using namespace System;
using namespace System::Security;
using namespace System::Security::Permissions;
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::IO;

// Demonstrate all methods.
void main()
{
    Console::WriteLine("Welcome to the PublisherIdentityPermission CPP sample\n");

    array<X509Certificate^>^publisherCertificate = gcnew array<X509Certificate^>(2);
    PublisherIdentityPermission ^ publisherPerm1;
    PublisherIdentityPermission ^ publisherPerm2;

    // Initialize the PublisherIdentityPermissions for use in the sample
//<Snippet8>
    FileStream ^ fs1 = gcnew FileStream("MyCert1.cer", FileMode::Open);
    array<Byte>^certSBytes1 = gcnew array<Byte>((int)fs1->Length);
    fs1->Read(certSBytes1, 0, (int)fs1->Length);
    publisherCertificate[0] = gcnew X509Certificate(certSBytes1);
    fs1->Close();

    FileStream ^ fs2 = gcnew FileStream("MyCert2.cer", FileMode::Open);
    array<Byte>^certSBytes2 = gcnew array<Byte>((int)fs2->Length);
    fs2->Read(certSBytes2, 0, (int)fs2->Length);
    publisherCertificate[1] = gcnew X509Certificate(certSBytes2);
    fs2->Close();
//</Snippet8>

    publisherPerm1 = gcnew PublisherIdentityPermission(publisherCertificate[0]);
    publisherPerm2 = gcnew PublisherIdentityPermission(publisherCertificate[1]);

//<Snippet2>
    Console::WriteLine("\n********************  IsSubsetOf DEMO  ********************\n");
    // IsSubsetOf determines whether the current permission is a subset of the specified permission.
    if (publisherPerm2->IsSubsetOf(publisherPerm1))
            Console::WriteLine(publisherPerm2->Certificate->Subject + " is a subset of " +
                publisherPerm1->Certificate->Subject);
     else
            Console::WriteLine(publisherPerm2->Certificate->Subject + " is not a subset of " +
                publisherPerm1->Certificate->Subject);
//</Snippet2>

//<Snippet5>
    Console::WriteLine("\n********************  Copy DEMO  ********************\n");
    // Copy creates and returns an identical copy of the current permission.
//<Snippet7>
    // Create an empty PublisherIdentityPermission to serve as the target of the copy.
    publisherPerm2 = gcnew PublisherIdentityPermission(PermissionState::None);
    publisherPerm2 = (PublisherIdentityPermission^)publisherPerm1->Copy();
    Console::WriteLine("Result of copy = " + publisherPerm2);
//</Snippet7>
//</Snippet5>


//<Snippet3>
    Console::WriteLine("\n********************  Union DEMO  ********************\n");
    PublisherIdentityPermission ^ publisherPerm3 = (PublisherIdentityPermission ^)publisherPerm1->Union(publisherPerm2);

    if (publisherPerm3 == nullptr)
         Console::WriteLine("The union of " + publisherPerm1 + " and " +
                  publisherPerm2->Certificate->Subject + " is null.");
    else
         Console::WriteLine("The union of " + publisherPerm1->Certificate->Subject + " and " +
                  publisherPerm2->Certificate->Subject + " = " +
                  publisherPerm3->Certificate->Subject);
//</Snippet3>


//<Snippet4>
    // Intersect creates and returns a new permission that is the intersection of the current
    // permission and the permission specified.
    Console::WriteLine("\n********************  Intersect DEMO  ********************\n");
    publisherPerm3 = (PublisherIdentityPermission^)publisherPerm1->Intersect(publisherPerm2);
    if (publisherPerm3 != nullptr)
         Console::WriteLine("The intersection of " + publisherPerm1->Certificate->Subject +
                " and " + publisherPerm2->Certificate->Subject + " = " +
                publisherPerm3->Certificate->Subject);
    else
         Console::WriteLine("The intersection of " + publisherPerm1->Certificate->Subject + " and " +
                publisherPerm2->Certificate->Subject + " is null.");
    //</Snippet4>


//<Snippet6>
// ToXml creates an XML encoding of the permission and its current state;
// FromXml reconstructs a permission with the specified state from the XML encoding.
    Console::WriteLine("\n********************  ToXml DEMO  ********************\n");
    publisherPerm2 = gcnew PublisherIdentityPermission(PermissionState::None);
    publisherPerm2->FromXml(publisherPerm1->ToXml());
    Console::WriteLine("Result of ToFromXml = " + publisherPerm2);
//</Snippet6>

    Console::WriteLine("Press Enter to return");
    Console::ReadLine();
}

/*
Expected output:

Welcome to the PublisherIdentityPermission CPP sample


********************  IsSubsetOf DEMO  ********************

CN=Joe's-Software-Emporium is not a subset of CN=Joe's-Software-Emporium

********************  Copy DEMO  ********************

Result of copy = <IPermission class="System.Security.Permissions.PublisherIdenti
tyPermission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c5
61934e089"
version="1"
X509v3Certificate="308201C730820171A003020102021006EC2474BF2489AB4AA453927C93421
1300D06092A864886F70D01010405003016311430120603550403130B526F6F74204167656E63793
01E170D3037313030323230333232335A170D3339313233313233353935395A30223120301E06035
5040313174A6F6527732D536F6674776172652D456D706F7269756D30819F300D06092A864886F70
D010101050003818D0030818902818100B2987B627918013BF3AC153D8868E35E2640F5190F10207
E9A1792755F818AC9940F4112E8ADA911EA23542AE9758606A78A1C90C03433B4254BDD226290532
DAAC87AFA5FBCAD42FE2CA17FD471D7C95644AD3C76BA91F07339B278CC4B92FC8FE134E17E09F60
52F390E7C2A471246C8288B76FE80A7F805764A2B986917350203010001A34B304930470603551D0
10440303E801012E4092D061D1D4F008D6121DC166463A1183016311430120603550403130B526F6
F74204167656E6379821006376C00AA00648A11CFB8D4AA5C35F4300D06092A864886F70D0101040
50003410072906C0A0B42FE4A77CAC283CDECFCA0707B4E8D596BD27D2E8ECD9A1C1C6A9E7CD5CA1
362C9884A0062F9CDFAF26DB901A490DD0DE17D55B27B0C5520E247E2"/>


********************  Union DEMO  ********************

The union of CN=Joe's-Software-Emporium and CN=Joe's-Software-Emporium = CN=Joe'
s-Software-Emporium

********************  Intersect DEMO  ********************

The intersection of CN=Joe's-Software-Emporium and CN=Joe's-Software-Emporium =
CN=Joe's-Software-Emporium

********************  ToXml DEMO  ********************

Result of ToFromXml = <IPermission class="System.Security.Permissions.PublisherI
dentityPermission, mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b7
7a5c561934e089"
version="1"
X509v3Certificate="308201C730820171A003020102021006EC2474BF2489AB4AA453927C93421
1300D06092A864886F70D01010405003016311430120603550403130B526F6F74204167656E63793
01E170D3037313030323230333232335A170D3339313233313233353935395A30223120301E06035
5040313174A6F6527732D536F6674776172652D456D706F7269756D30819F300D06092A864886F70
D010101050003818D0030818902818100B2987B627918013BF3AC153D8868E35E2640F5190F10207
E9A1792755F818AC9940F4112E8ADA911EA23542AE9758606A78A1C90C03433B4254BDD226290532
DAAC87AFA5FBCAD42FE2CA17FD471D7C95644AD3C76BA91F07339B278CC4B92FC8FE134E17E09F60
52F390E7C2A471246C8288B76FE80A7F805764A2B986917350203010001A34B304930470603551D0
10440303E801012E4092D061D1D4F008D6121DC166463A1183016311430120603550403130B526F6
F74204167656E6379821006376C00AA00648A11CFB8D4AA5C35F4300D06092A864886F70D0101040
50003410072906C0A0B42FE4A77CAC283CDECFCA0707B4E8D596BD27D2E8ECD9A1C1C6A9E7CD5CA1
362C9884A0062F9CDFAF26DB901A490DD0DE17D55B27B0C5520E247E2"/>

Press Enter to return
*/

//</Snippet1>