        // Overridden to return the custom AccessibleObject 
        // for the entire chart.
        protected override AccessibleObject CreateAccessibilityInstance() 
        {            
            return new ChartControlAccessibleObject(this);
        }