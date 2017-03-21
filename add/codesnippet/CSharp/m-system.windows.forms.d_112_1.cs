        IUIService UIservice = (IUIService)this.GetService( 
            typeof( System.Windows.Forms.Design.IUIService ) );
        if( UIservice != null )            
            UIservice.ShowToolWindow(StandardToolWindows.TaskList);