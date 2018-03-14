
//<Snippet1>
using namespace System;
using namespace System::Security::Policy;
using namespace System::Security;
using namespace System::Security::Permissions;

[STAThread]
int main()
{

    //<Snippet2>
    GacInstalled ^ myGacInstalled = gcnew GacInstalled;
    //</Snippet2>

    //<Snippet3>
    array<Object^>^hostEvidence = {myGacInstalled};
    array<Object^>^assemblyEvidence = {};
    Evidence^ myEvidence = gcnew Evidence( hostEvidence,assemblyEvidence );
    GacIdentityPermission ^ myPerm = dynamic_cast<GacIdentityPermission^>
        (myGacInstalled->CreateIdentityPermission( myEvidence ));
    Console::WriteLine( myPerm->ToXml() );
    //</Snippet3>

    //<Snippet4>
    GacInstalled ^ myGacInstalledCopy = 
        dynamic_cast<GacInstalled^>(myGacInstalled->Copy());
    bool result = myGacInstalled->Equals( myGacInstalledCopy );
    //</Snippet4>

    //<Snippet5>
    Console::WriteLine( "Hashcode = {0}", myGacInstalled->GetHashCode() );
    //</Snippet5>

    //<Snippet6>
    Console::WriteLine( myGacInstalled->ToString() );
    //</Snippet6>
}
//</Snippet1>
