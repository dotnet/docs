        IUIService UIservice = (IUIService)this.GetService( 
            typeof( System.Windows.Forms.Design.IUIService ) );
        if( UIservice != null )            
            UIservice.ShowError( new Exception(
                "This is a message in a test exception, " + 
                "displayed by the IUIService", 
                 new ArgumentException("Test inner exception")));