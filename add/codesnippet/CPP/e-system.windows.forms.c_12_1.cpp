   private:
      void Form1_Resize( Object^ sender, System::EventArgs^ /*e*/ )
      {
         Control^ control = dynamic_cast<Control^>(sender);

         // Ensure the Form remains square (Height = Width).
         if ( control->Size.Height != control->Size.Width )
         {
            control->Size = System::Drawing::Size( control->Size.Width, control->Size.Width );
         }
      }