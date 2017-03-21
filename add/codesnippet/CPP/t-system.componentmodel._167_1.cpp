   public:
      // This example method creates a DesignerTransactionCloseEventArgs using the specified argument.
      // Typically, this type of event args is created by a design mode subsystem.
      DesignerTransactionCloseEventArgs^ CreateDesignerTransactionCloseEventArgs( bool commit )
      {
         // Creates a component changed event args with the specified arguments.
         DesignerTransactionCloseEventArgs^ args = gcnew DesignerTransactionCloseEventArgs( commit );

         // Whether the transaction has been committed:  args.TransactionCommitted

         return args;
      }