        public override void Initialize(IComponent component)
        {
            // Ensure that only a SimpleRadioButtonList can be 
            // created in this designer.
            Debug.Assert( 
                component is SimpleRadioButtonList, 
                "An invalid SimpleRadioButtonList control was initialized.");

            simpleRadioButtonList = (SimpleRadioButtonList)component;
            base.Initialize(component);
        } // Initialize