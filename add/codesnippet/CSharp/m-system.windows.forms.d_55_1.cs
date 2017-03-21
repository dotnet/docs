        IUIService UIservice = (IUIService)this.GetService( 
            typeof( System.Windows.Forms.Design.IUIService ) );
        if( UIservice != null )            
            UIservice.ShowDialog(new ExampleForm());