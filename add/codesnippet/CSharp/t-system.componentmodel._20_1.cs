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