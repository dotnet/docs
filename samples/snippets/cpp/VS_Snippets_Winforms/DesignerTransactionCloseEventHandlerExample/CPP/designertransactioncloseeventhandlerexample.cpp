#using <system.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;

namespace MiscCompModSamples
{
   public ref class DesignerTransactionCloseEventHandlerExample
   {
   private:
      DesignerTransactionCloseEventHandlerExample()
      {
      }

      //<Snippet1>
   public:
      void LinkDesignerTransactionCloseEvent( IDesignerHost^ host )
      {
         // Registers an event handler for the designer TransactionClosing and TransactionClosed events.
         host->TransactionClosing += gcnew DesignerTransactionCloseEventHandler(
            this, &DesignerTransactionCloseEventHandlerExample::OnTransactionClose );
         host->TransactionClosed += gcnew DesignerTransactionCloseEventHandler(
            this, &DesignerTransactionCloseEventHandlerExample::OnTransactionClose );
      }

   private:
      void OnTransactionClose( Object^ sender, DesignerTransactionCloseEventArgs^ e )
      {
         // Displays transaction close information on the console.
         if ( e->TransactionCommitted )
         {
            Console::WriteLine( "Transaction has been committed." );
         }
         else
         {
            Console::WriteLine( "Transaction has not yet been committed." );
         }
      }
      //</Snippet1>
   };
}
