// <snippet0>
#using <System.Transactions.dll>
#using <System.EnterpriseServices.dll>

using namespace System;
using namespace System::EnterpriseServices;
using namespace System::Reflection;

// <snippet1>
[Synchronization(SynchronizationOption::Required)]
public ref class ContextUtil_ActivityId: public ServicedComponent
{
public:
   void Example()
   {
      // Display the ActivityID associated with the current COM+ context.
      Console::WriteLine( "Activity ID: {0}", ContextUtil::ActivityId );
   }
};
// </snippet1>

// <snippet2>
[Synchronization(SynchronizationOption::Required)]
public ref class ContextUtil_ApplicationInstanceId: public ServicedComponent
{
public:
   void Example()
   {
      // Display the ApplicationInstanceId associated with the current COM+
      // context.
      Console::WriteLine( "Application Instance ID: {0}", 
         ContextUtil::ApplicationInstanceId );
   }
};
// </snippet2>

// <snippet3>
[Transaction(TransactionOption::Required)]
public ref class ContextUtil_DisableCommit: public ServicedComponent
{
public:
   void Example()
   {
      // Set both the consistent bit and the done bit to false for the
      // current COM+ context.
      ContextUtil::DisableCommit();
   }
};
// </snippet3>

// <snippet4>
[Transaction(TransactionOption::Required)]
public ref class ContextUtil_EnableCommit: public ServicedComponent
{
public:
   void Example()
   {
      // Set the consistent bit to true and the done bit to false for the
      // current COM+ context.
      ContextUtil::EnableCommit();
   }
};
// </snippet4>

// <snippet5>
[Transaction(TransactionOption::Required)]
public ref class ContextUtil_IsInTransaction: public ServicedComponent
{
public:
   void Example()
   {
      // Display whether the current COM+ context is enlisted in a
      // transaction.
      Console::WriteLine( "Current context enlisted in transaction: {0}", 
         ContextUtil::IsInTransaction );
   }
};
// </snippet5>

// <snippet6>
[SecurityRole("Role1")]
public ref class ContextUtil_IsSecurityEnabled: public ServicedComponent
{
public:
   void Example()
   {
      // Display whether role-based security is active for the current COM+
      // context.
      Console::WriteLine( "Role-based security active in current context: {0}", 
         ContextUtil::IsSecurityEnabled );
   }
};
// </snippet6>

// <snippet7>
[Transaction(TransactionOption::Required)]
public ref class ContextUtil_TransactionId: public ServicedComponent
{
public:
   void Example()
   {
      // Display the ID of the transaction in which the current COM+ context
      // is enlisted.
      Console::WriteLine( "Transaction ID: {0}", ContextUtil::TransactionId );
   }
};
// </snippet7>
// </snippet0>
