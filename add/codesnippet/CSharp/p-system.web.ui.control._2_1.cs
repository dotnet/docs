                // Override the ViewStateIgnoresCase property to allow the same
                // entries with different casing to be stored in the control's
                // ViewState property.
                protected override bool ViewStateIgnoresCase
                {
                        get
                        { 
                                return true; 
                        }
                }