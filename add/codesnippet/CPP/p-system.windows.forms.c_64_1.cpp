   // This method initializes CheckedListBox1 with a list of all 
   // the controls on the form. It sets the selection mode
   // to single selection and allows selection with a single click.
   // It adds itself to the list before adding itself to the form.
internal:
   System::Windows::Forms::CheckedListBox^ CheckedListBox1;

private:
   void InitializeCheckedListBox()
   {
      this->CheckedListBox1 = gcnew CheckedListBox;
      this->CheckedListBox1->Location = System::Drawing::Point( 40, 90 );
      this->CheckedListBox1->CheckOnClick = true;
      this->CheckedListBox1->Name = "CheckedListBox1";
      this->CheckedListBox1->Size = System::Drawing::Size( 120, 94 );
      this->CheckedListBox1->TabIndex = 1;
      this->CheckedListBox1->SelectionMode = SelectionMode::One;
      this->CheckedListBox1->ThreeDCheckBoxes = true;
      System::Collections::IEnumerator^ myEnum = this->Controls->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Control^ aControl = safe_cast<Control^>(myEnum->Current);
         this->CheckedListBox1->Items->Add( aControl, false );
      }

      this->CheckedListBox1->DisplayMember = "Name";
      this->CheckedListBox1->Items->Add( CheckedListBox1 );
      this->Controls->Add( this->CheckedListBox1 );
   }