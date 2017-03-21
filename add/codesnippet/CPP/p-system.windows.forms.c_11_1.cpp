      virtual System::Windows::Forms::CreateParams^ get() override
      {
         
         // Extend the CreateParams property of the Button class.
         System::Windows::Forms::CreateParams^ cp = __super::CreateParams;

         // Update the button Style.
         cp->Style |= 0x00000040; // BS_ICON value
         return cp;
      }