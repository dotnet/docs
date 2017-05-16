using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace MiscCompModSamples
{
	public class DesignerTransactionCloseEventArgsExample
	{
		public DesignerTransactionCloseEventArgsExample()
		{			
		}

        //<Snippet1>        
        // This example method creates a DesignerTransactionCloseEventArgs using the specified argument.
        // Typically, this type of event args is created by a design mode subsystem.            
        public DesignerTransactionCloseEventArgs CreateDesignerTransactionCloseEventArgs(bool commit)
        {            
            // Creates a component changed event args with the specified arguments.
            DesignerTransactionCloseEventArgs args = new DesignerTransactionCloseEventArgs(commit, false);

            // Whether the transaction has been committed:  args.TransactionCommitted
            
            return args;            
        }
        //</Snippet1>
	}
}
