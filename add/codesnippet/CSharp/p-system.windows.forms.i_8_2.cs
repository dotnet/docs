        // The ExtendBackgroundMapping method adds a property
        // translator if a mapping already exists.
        private void ExtendBackgroundMapping()
        {
            if (wfHost.PropertyMap["Background"] != null)
            {
                wfHost.PropertyMap["Background"] += new PropertyTranslator(OnBackgroundChange);
            }
        }

        // The OnBackgroundChange method assigns a specific image 
        // to the hosted control's BackgroundImage property.
        private void OnBackgroundChange(object h, String propertyName, object value)
        {
            WindowsFormsHost host = h as WindowsFormsHost;
            System.Windows.Forms.CheckBox cb = host.Child as System.Windows.Forms.CheckBox;
            ImageBrush b = value as ImageBrush;

            if (b != null)
            {
                cb.BackgroundImage = new System.Drawing.Bitmap(@"C:\WINDOWS\Santa Fe Stucco.bmp");
            }
        }