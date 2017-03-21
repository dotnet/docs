        public override void Initialize(IComponent component)
        {
            // Initialize the base
            base.Initialize(component);
            // Turn on template editing
            SetViewFlags(ViewFlags.TemplateEditing, true);
        }