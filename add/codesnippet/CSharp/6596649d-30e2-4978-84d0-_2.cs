        // The AddClipMapping method adds a custom 
        // mapping for the Clip property.
        private void AddClipMapping()
        {
            wfHost.PropertyMap.Add(
                "Clip",
                new PropertyTranslator(OnClipChange));
        }

        // The OnClipChange method assigns an elliptical clipping 
        // region to the hosted control's Region property.
        private void OnClipChange(object h, String propertyName, object value)
        {
            WindowsFormsHost host = h as WindowsFormsHost;
            System.Windows.Forms.CheckBox cb = host.Child as System.Windows.Forms.CheckBox;

            if (cb != null)
            {
                cb.Region = this.CreateClipRegion();
            }
        }

        // The Window1_SizeChanged method handles the window's 
        // SizeChanged event. It calls the OnClipChange method explicitly 
        // to assign a new clipping region to the hosted control.
        private void Window1_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.OnClipChange(wfHost, "Clip", null);
        }

        // The CreateClipRegion method creates a Region from an
        // elliptical GraphicsPath.
        private Region CreateClipRegion()
        {   
            GraphicsPath path = new GraphicsPath();

            path.StartFigure(); 

            path.AddEllipse(new System.Drawing.Rectangle( 
                0, 
                0, 
                (int)wfHost.ActualWidth, 
                (int)wfHost.ActualHeight ) );

            path.CloseFigure(); 

            return( new Region(path) );
        }