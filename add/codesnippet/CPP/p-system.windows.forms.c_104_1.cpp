      // Create three buttons and place them on a form using
      // several size and location related properties.
      void AddOKCancelButtons()
      {
         
         // Set the button size and location using
         // the Size and Location properties.
         Button^ buttonOK = gcnew Button;
         buttonOK->Location = Point(136,248);
         buttonOK->Size = System::Drawing::Size( 75, 25 );
         
         // Set the Text property and make the
         // button the form's default button.
         buttonOK->Text = "&OK";
         this->AcceptButton = buttonOK;
         
         // Set the button size and location using the Top,
         // Left, Width, and Height properties.
         Button^ buttonCancel = gcnew Button;
         buttonCancel->Top = buttonOK->Top;
         buttonCancel->Left = buttonOK->Right + 5;
         buttonCancel->Width = buttonOK->Width;
         buttonCancel->Height = buttonOK->Height;
         
         // Set the Text property and make the
         // button the form's cancel button.
         buttonCancel->Text = "&Cancel";
         this->CancelButton = buttonCancel;
         
         // Set the button size and location using
         // the Bounds property.
         Button^ buttonHelp = gcnew Button;
         buttonHelp->Bounds = Rectangle(10,10,75,25);
         
         // Set the Text property of the button.
         buttonHelp->Text = "&Help";
         
         // Add the buttons to the form.
         array<Control^>^temp1 = {buttonOK,buttonCancel,buttonHelp};
         this->Controls->AddRange( temp1 );
      }