

#using <System.EnterpriseServices.dll>
#using <System.Transactions.dll>

using namespace System;
using namespace System::EnterpriseServices;

// <snippet1>

[assembly:System::Reflection::AssemblyKeyFile("Transaction.snk")];
[Transaction]
public ref class TransactionalComponent: public ServicedComponent
{
public:
   void TransactionalMethod( String^ data )
   {
      ContextUtil::DeactivateOnReturn = true;
      ContextUtil::MyTransactionVote = TransactionVote::Abort;
      
      // do work with data
      ContextUtil::MyTransactionVote = TransactionVote::Commit;
   }

};

// </snippet1>
