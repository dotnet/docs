using namespace System;
using namespace System::Security::Policy;
using namespace System::Security;
using namespace System::Security::Permissions;

[STAThread]
int main()
{

    GacInstalled ^ myGacInstalled = gcnew GacInstalled;

    array<Object^>^hostEvidence = {myGacInstalled};
    array<Object^>^assemblyEvidence = {};
    Evidence^ myEvidence = gcnew Evidence( hostEvidence,assemblyEvidence );
    GacIdentityPermission ^ myPerm = dynamic_cast<GacIdentityPermission^>
        (myGacInstalled->CreateIdentityPermission( myEvidence ));
    Console::WriteLine( myPerm->ToXml() );

    GacInstalled ^ myGacInstalledCopy = 
        dynamic_cast<GacInstalled^>(myGacInstalled->Copy());
    bool result = myGacInstalled->Equals( myGacInstalledCopy );

    Console::WriteLine( "Hashcode = {0}", myGacInstalled->GetHashCode() );

    Console::WriteLine( myGacInstalled->ToString() );
}