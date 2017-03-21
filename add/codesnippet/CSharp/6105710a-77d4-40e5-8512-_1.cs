        public override void Initialize(IComponent component)
        {
            // Ensure that only a MyLoginView can be created in this designer.
            if (!(component is MyLoginView))
                throw new ArgumentException();

            // Call the base method to generate the markup.
            base.Initialize(component);

        } // Initialize