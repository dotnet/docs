internal:
   // Declare ComboBox1
   System::Windows::Forms::ComboBox^ ComboBox1;

private:
   // Initialize ComboBox1.
   void InitializeComboBox()
   {
      this->ComboBox1 = gcnew ComboBox;
      this->ComboBox1->Location = System::Drawing::Point( 128, 48 );
      this->ComboBox1->Name = "ComboBox1";
      this->ComboBox1->Size = System::Drawing::Size( 100, 21 );
      this->ComboBox1->TabIndex = 0;
      this->ComboBox1->Text = "Typical";
      array<String^>^ installs = {"Typical","Compact","Custom"};
      ComboBox1->Items->AddRange( installs );
      this->Controls->Add( this->ComboBox1 );
      
      // Hook up the event handler.
      this->ComboBox1->DropDown += gcnew System::EventHandler(
         this, &Form1::ComboBox1_DropDown );
   }

   // Handles the ComboBox1 DropDown event. If the user expands the  
   // drop-down box, a message box will appear, recommending the
   // typical installation.
   void ComboBox1_DropDown( Object^ sender, System::EventArgs^ e )
   {
      MessageBox::Show( "Typical installation is strongly recommended.",
         "Install information", MessageBoxButtons::OK,
         MessageBoxIcon::Information );
   }