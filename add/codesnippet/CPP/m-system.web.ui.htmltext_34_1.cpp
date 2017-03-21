   // Override the OutputTabs method to set the tab to
   // the number of spaces defined by the Indent variable.
   virtual void OutputTabs() override
   {
      
      // Output the DefaultTabString for the number
      // of times specified in the Indent property.
      for ( int i = 0; i < Indent; i++ )
         Write( DefaultTabString );
      __super::OutputTabs();
   }