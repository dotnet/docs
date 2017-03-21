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