        // Initialize the designer.
        public override void Initialize(IComponent component)
        {
            // Ensure that only a MyPanelContainer can be created 
            // in this designer.
            if (!(component is MyPanelContainer))
                throw new ArgumentException();
            
            base.Initialize(component);

        } // Initialize