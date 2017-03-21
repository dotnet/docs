       // Ensure the current control has children,
       // then get or set the Text property.
        public int Value {
           get {
               this.EnsureChildControls();
               return Int32.Parse(((TextBox)Controls[1]).Text);
           }
           set {
               this.EnsureChildControls();
               ((TextBox)Controls[1]).Text = value.ToString();
           }
        }
