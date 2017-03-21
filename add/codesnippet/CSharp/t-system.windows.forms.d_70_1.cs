    // This example component editor page type provides an example 
    // ComponentEditorPage implementation.
    internal class ExampleComponentEditorPage : System.Windows.Forms.Design.ComponentEditorPage
    {
        Label l1; 
        Button b1; 
        PropertyGrid pg1;

        // Base64-encoded serialized image data for the required component editor page icon.
        string icon = "AAEAAAD/////AQAAAAAAAAAMAgAAAFRTeXN0ZW0uRHJhd2luZywgVmVyc2lvbj0xLjAuNTAwMC4wLCBDdWx0dXJlPW5ldXRyYWwsIFB1YmxpY0tleVRva2VuPWIwM2Y1ZjdmMTFkNTBhM2EFAQAAABNTeXN0ZW0uRHJhd2luZy5JY29uAgAAAAhJY29uRGF0YQhJY29uU2l6ZQcEAhNTeXN0ZW0uRHJhd2luZy5TaXplAgAAAAIAAAAJAwAAAAX8////E1N5c3RlbS5EcmF3aW5nLlNpemUCAAAABXdpZHRoBmhlaWdodAAACAgCAAAAAAAAAAAAAAAPAwAAAD4BAAACAAABAAEAEBAQAAAAAAAoAQAAFgAAACgAAAAQAAAAIAAAAAEABAAAAAAAgAAAAAAAAAAAAAAAEAAAABAAAAAAAAAAAACAAACAAAAAgIAAgAAAAIAAgADExAAAgICAAMDAwAA+iPcAY77gACh9kwD/AAAAndPoADpw6wD///8AAAAAAAAAAAAHd3d3d3d3d8IiIiIiIiLHKIiIiIiIiCco///////4Jyj5mfIvIvgnKPnp////+Cco+en7u7v4Jyj56f////gnKPmZ8i8i+Cco///////4JyiIiIiIiIgnJmZmZmZmZifCIiIiIiIiwAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACw==";

        public ExampleComponentEditorPage()
        {
            // Initialize the page, which inherits from Panel, and its controls.
            this.Size = new Size( 400, 250 );            
            this.Icon = DeserializeIconFromBase64Text(icon);
            this.Text = "Example Page";
            
            b1 = new Button();
            b1.Size = new Size(200, 20);
            b1.Location = new Point(200, 0);
            b1.Text = "Set a random background color";
            b1.Click += new EventHandler(this.randomBackColor);
            this.Controls.Add( b1 );

            l1 = new Label();
            l1.Size = new Size(190, 20);
            l1.Location = new Point(4, 2);
            l1.Text = "Example Component Editor Page";
            this.Controls.Add( l1 );

            pg1 = new PropertyGrid();
            pg1.Size = new Size(400, 280);
            pg1.Location = new Point(0,30);
            this.Controls.Add( pg1 );
        }
        
        // This method indicates that the Help button should be enabled for this 
        // component editor page.
        public override bool SupportsHelp()
        { 
            return true; 
        }

        // This method is called when the Help button for this component editor page is pressed.
        // This implementation uses the IHelpService to show the Help topic for a sample keyword.
        public override void ShowHelp()
        {
            // The GetSelectedComponent method of a ComponentEditorPage retrieves the
            // IComponent associated with the WindowsFormsComponentEditor.
            IComponent selectedComponent = this.GetSelectedComponent();

            // Retrieve the Site of the component, and return if null.
            ISite componentSite = selectedComponent.Site;
            if(componentSite == null)
                return;
 
            // Acquire the IHelpService to display a help topic using a indexed keyword lookup.
            IHelpService helpService = (IHelpService)componentSite.GetService(typeof(IHelpService));
            if (helpService != null)
                helpService.ShowHelpFromKeyword("System.Windows.Forms.ComboBox");
        }

        // The LoadComponent method is raised when the ComponentEditorPage is displayed.
        protected override void LoadComponent()
        { 
            this.pg1.SelectedObject = this.Component; 
        }
    
        // The SaveComponent method is raised when the WindowsFormsComponentEditor is closing 
        // or the current ComponentEditorPage is closing.
        protected override void SaveComponent()
        {
        }

        // If the associated component is a Control, this method sets the BackColor to a random color.
        // This method is invoked by the button on this ComponentEditorPage.
        private void randomBackColor(object sender, EventArgs e)
        {
            if( typeof(System.Windows.Forms.Control).IsAssignableFrom( this.Component.GetType() ) )
            {
                // Sets the background color of the Control associated with the
                // WindowsFormsComponentEditor to a random color.
                Random rnd = new Random();
                ((System.Windows.Forms.Control)this.Component).BackColor = 
                    Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                pg1.Refresh();
            }
        }

        // This method can be used to retrieve an Icon from a block 
        // of Base64-encoded text.
        private Icon DeserializeIconFromBase64Text(string text)
        {
            Icon img = null;
            byte[] memBytes = Convert.FromBase64String(text);
            IFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream(memBytes);
            img = (Icon)formatter.Deserialize(stream);
            stream.Close();
            return img;
        }
    }