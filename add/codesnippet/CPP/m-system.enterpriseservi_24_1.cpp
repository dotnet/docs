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