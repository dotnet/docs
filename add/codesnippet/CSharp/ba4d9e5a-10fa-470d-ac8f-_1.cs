        // This method handles the "Launch Url Builder UI" menu command.
        // Invokes the BuildUrl method of the System.Web.UI.Design.UrlBuilder.
        private void launchUrlBuilder(object sender, EventArgs e)
        {
            // Create a parent control.
            System.Windows.Forms.Control c = new System.Windows.Forms.Control();            
            c.CreateControl();            
                        
            // Launch the Url Builder using the specified control
            // parent, initial URL, empty relative base URL path,
            // window caption, filter string and URLBuilderOptions value.
            UrlBuilder.BuildUrl(
                this.Component, 
                c, 
                "http://www.example.com", 
                "Select a URL", 
                "", 
                UrlBuilderOptions.None);                      
        }        