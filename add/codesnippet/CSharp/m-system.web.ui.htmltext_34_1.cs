        // Override the OutputTabs method to set the tab to
        // the number of spaces defined by the Indent variable.      
        protected override void OutputTabs()
        {
            // Output the DefaultTabString for the number
            // of times specified in the Indent property.
            for (int i = 0; i < Indent; i++)
                Write(DefaultTabString);
            base.OutputTabs();
        }