
#using <System.dll>
#using <System.Security.dll>

using namespace System;
using namespace System::Security::Cryptography;
using namespace System::Security::Cryptography::X509Certificates;
using namespace System::IO;

int main()
{
//<SNIPPET5>
    X509Chain^ ch = gcnew X509Chain();
    ch->ChainPolicy->ApplicationPolicy->Add(gcnew Oid("1.2.1.1"));
//</SNIPPET5>
    //Output chain information about the chain.
    Console::WriteLine("Chain Information");
    ch->ChainPolicy->RevocationMode = X509RevocationMode::Online;
    Console::WriteLine("Chain revocation flag: {0}", ch->ChainPolicy->RevocationFlag);
    Console::WriteLine("Chain revocation mode: {0}", ch->ChainPolicy->RevocationMode);
    Console::WriteLine("Chain verification flag: {0}", ch->ChainPolicy->VerificationFlags);
    Console::WriteLine("Chain verification time: {0}", ch->ChainPolicy->VerificationTime);
    Console::WriteLine("Chain status length: {0}", ch->ChainStatus->Length);
    Console::WriteLine("Chain application policy count: {0}", ch->ChainPolicy->ApplicationPolicy->Count);
    Console::WriteLine("Chain certificate policy count: {0} {1}", ch->ChainPolicy->CertificatePolicy->Count, Environment::NewLine);
}
