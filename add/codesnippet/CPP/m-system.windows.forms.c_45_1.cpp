   private:
      void button1_Click( Object^ sender, System::EventArgs^ /*e*/ )
      {
         /* If the CTRL key is pressed when the
            * control is clicked, hide the control. */
         if ( Control::ModifierKeys == Keys::Control )
         {
            (dynamic_cast<Control^>(sender))->Hide();
         }
      }