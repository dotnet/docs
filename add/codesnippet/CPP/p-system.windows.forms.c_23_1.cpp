      // Reset all the controls to the user's default Control color.
   private:
      void ResetAllControlsBackColor( Control^ control )
      {
         control->BackColor = SystemColors::Control;
         control->ForeColor = SystemColors::ControlText;
         if ( control->HasChildren )
         {
            // Recursively call this method for each child control.
            IEnumerator^ myEnum = control->Controls->GetEnumerator();
            while ( myEnum->MoveNext() )
            {
               Control^ childControl = safe_cast<Control^>(myEnum->Current);
               ResetAllControlsBackColor( childControl );
            }
         }
      }