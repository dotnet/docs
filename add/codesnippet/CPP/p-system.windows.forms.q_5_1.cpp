protected:
   // Overridden to return the custom AccessibleObject
   // for the entire chart.
   virtual AccessibleObject^ CreateAccessibilityInstance() override
   {
      return gcnew ChartControlAccessibleObject( this );
   }