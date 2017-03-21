        // This method override returns an type array containing the type of 
        // each component editor page to display.
        protected override Type[] GetComponentEditorPages()
        { 
            return new Type[] { typeof(ExampleComponentEditorPage), 
                                typeof(ExampleComponentEditorPage) }; 
        }