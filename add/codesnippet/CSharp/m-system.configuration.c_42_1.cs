        // Customizes the use of CustomSection
        // by setting _ReadOnly to false.
        // Remember you must use it along with ThrowIfReadOnly.
        protected override object GetRuntimeObject()
        {
            // To enable property setting just assign true to
            // the following flag.
            _ReadOnly = true;
            return base.GetRuntimeObject();
        }
