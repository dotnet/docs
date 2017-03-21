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