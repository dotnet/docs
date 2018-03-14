using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{
	public class DesignerTransactionCloseEventHandlerExample
	{
		public DesignerTransactionCloseEventHandlerExample()
		{
		}

        //<Snippet1>
        public void LinkDesignerTransactionCloseEvent(IDesignerHost host)
        {                       
            // Registers an event handler for the designer TransactionClosing and TransactionClosed events.
            host.TransactionClosing += new DesignerTransactionCloseEventHandler(this.OnTransactionClose);
            host.TransactionClosed += new DesignerTransactionCloseEventHandler(this.OnTransactionClose);
        }

        private void OnTransactionClose(object sender, DesignerTransactionCloseEventArgs e)
        {
            // Displays transaction close information on the console.           
            if( e.TransactionCommitted )            
                Console.WriteLine("Transaction has been committed.");
            else
                Console.WriteLine("Transaction has not yet been committed.");
        }
        //</Snippet1>
	}
}