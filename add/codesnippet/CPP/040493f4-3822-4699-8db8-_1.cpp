      // Create a parent control.
      System::Windows::Forms::Control^ c = gcnew System::Windows::Forms::Control;
      c->CreateControl();
      
      // Launch the Color Builder using the specified control
      // parent and an initial HTML format (S"RRGGBB") color String*.
      System::Web::UI::Design::ColorBuilder::BuildColor( this->Component, c, "405599" );