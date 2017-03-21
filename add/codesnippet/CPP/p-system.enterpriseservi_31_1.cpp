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