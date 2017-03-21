   public:
      void ControlSetFocus( Control^ control )
      {
         
         // Set focus to the control, if it can receive focus.
         if ( control->CanFocus )
         {
            control->Focus();
         }
      }