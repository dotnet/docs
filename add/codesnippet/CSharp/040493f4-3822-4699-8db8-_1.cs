            // Create a parent control.
            System.Windows.Forms.Control c = new System.Windows.Forms.Control();            
            c.CreateControl();            
            
            // Launch the Color Builder using the specified control 
            // parent and an initial HTML format ("RRGGBB") color string.
            System.Web.UI.Design.ColorBuilder.BuildColor(this.Component, c, "405599");