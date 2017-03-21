public:
   void InitMyForm()
   {
      // Adds a label to the form.
      Label^ label1 = gcnew Label;
      label1->Location = System::Drawing::Point( 54, 128 );
      label1->Name = "label1";
      label1->Size = System::Drawing::Size( 220, 80 );
      label1->Text = "Start position information";
      this->Controls->Add( label1 );
      
      // Moves the start position to the center of the screen.
      StartPosition = FormStartPosition::CenterScreen;
      
      // Displays the position information.
      label1->Text = String::Format( "The start position is {0}", StartPosition );
   }