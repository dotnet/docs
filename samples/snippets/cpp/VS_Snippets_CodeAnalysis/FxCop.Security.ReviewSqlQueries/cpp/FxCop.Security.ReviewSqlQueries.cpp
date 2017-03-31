//<Snippet1>
#using <System.dll>
#using <System.Data.dll>
#using <System.EnterpriseServices.dll>
#using <System.Transactions.dll>
#using <System.Xml.dll>
using namespace System;
using namespace System::Data;
using namespace System::Data::SqlClient;

namespace SecurityLibrary
{
   public ref class SqlQueries
   {
   public:
      Object^ UnsafeQuery(
         String^ connection, String^ name, String^ password)
      {
         SqlConnection^ someConnection = gcnew SqlConnection(connection);
         SqlCommand^ someCommand = gcnew SqlCommand();
         someCommand->Connection = someConnection;

         someCommand->CommandText = String::Concat(
            "SELECT AccountNumber FROM Users WHERE Username='", 
            name, "' AND Password='", password, "'");

         someConnection->Open();
         Object^ accountNumber = someCommand->ExecuteScalar();
         someConnection->Close();
         return accountNumber;
      }

      Object^ SaferQuery(
         String^ connection, String^ name, String^ password)
      {
         SqlConnection^ someConnection = gcnew SqlConnection(connection);
         SqlCommand^ someCommand = gcnew SqlCommand();
         someCommand->Connection = someConnection;

         someCommand->Parameters->Add(
            "@username", SqlDbType::NChar)->Value = name;
         someCommand->Parameters->Add(
            "@password", SqlDbType::NChar)->Value = password;
         someCommand->CommandText = "SELECT AccountNumber FROM Users "  
            "WHERE Username=@username AND Password=@password";

         someConnection->Open();
         Object^ accountNumber = someCommand->ExecuteScalar();
         someConnection->Close();
         return accountNumber;
      }
   };
}

using namespace SecurityLibrary;

void main()
{
   SqlQueries^ queries = gcnew SqlQueries();
   queries->UnsafeQuery(Environment::GetCommandLineArgs()[1], 
      "' OR 1=1 --", "anything");
   // Resultant query (which is always true): 
   // SELECT AccountNumber FROM Users WHERE Username='' OR 1=1

   queries->SaferQuery(Environment::GetCommandLineArgs()[1], 
      "' OR 1 = 1 --", "anything");
   // Resultant query (notice the additional single quote character):
   // SELECT AccountNumber FROM Users WHERE Username=''' OR 1=1 --'
   //                                   AND Password='anything'
}
//</Snippet1>
