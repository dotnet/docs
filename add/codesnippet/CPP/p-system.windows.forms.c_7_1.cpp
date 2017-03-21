protected:
   property System::Windows::Forms::ImeMode DefaultImeMode 
   {
      virtual System::Windows::Forms::ImeMode get() override
      {
         // Disable the IME mode for the control.
         return ::ImeMode::Off;
      }

   }