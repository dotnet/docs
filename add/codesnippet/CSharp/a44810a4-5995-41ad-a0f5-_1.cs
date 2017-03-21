        public override void Initialize(IComponent component)
        {
            // Ensure that only a MyMenu can be created in this designer.
            if (!(component is MyMenu))
                throw new ArgumentException(
                    "The component is not a MyMenu control.");
            
            base.Initialize(component);

        } // Initialize