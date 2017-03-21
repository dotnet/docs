   private:
      void AddButtons()
      {
         // Suspend the form layout and add two buttons.
         this->SuspendLayout();
         Button^ buttonOK = gcnew Button;
         buttonOK->Location = Point(10,10);
         buttonOK->Size = System::Drawing::Size( 75, 25 );
         buttonOK->Text = "OK";
         Button^ buttonCancel = gcnew Button;
         buttonCancel->Location = Point(90,10);
         buttonCancel->Size = System::Drawing::Size( 75, 25 );
         buttonCancel->Text = "Cancel";
         array<Control^>^temp5 = {buttonOK,buttonCancel};
         this->Controls->AddRange( temp5 );
         this->ResumeLayout();
      }