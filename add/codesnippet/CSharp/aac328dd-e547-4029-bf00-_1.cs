        IUIService UIservice = (IUIService)this.GetService( 
            typeof( System.Windows.Forms.Design.IUIService ) );
        if( UIservice != null )            
            UIservice.ShowMessage("Test message", "Test caption", 
                System.Windows.Forms.MessageBoxButtons.AbortRetryIgnore);