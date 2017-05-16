// <snippet30>
#using "System.EnterpriseServices.dll"

using namespace System;

[assembly: System::Reflection::AssemblyKeyFile("CrmServer.key")];

int main ()
{

    // Create a new account object. The object is created in a COM+ server application.
    Account^ account = gcnew Account();

    // Transactionally debit the account.
    try
    {
        account->Filename = System::IO::Path::GetFullPath("JohnDoe");
        account->AllowCommit = true;
        account->DebitAccount(3);
    }
    finally
    {
        delete account;
    }

}
// </snippet30>
