public:
   void CreateMyRichTextBox()
   {
      RichTextBox^ richTextBox1 = gcnew RichTextBox;
      richTextBox1->Dock = DockStyle::Fill;

      richTextBox1->LoadFile( "C:\\MyDocument.rtf" );
      richTextBox1->Find( "Text", RichTextBoxFinds::MatchCase );

      richTextBox1->SelectionFont = gcnew System::Drawing::Font(
         "Verdana", 12, FontStyle::Bold );
      richTextBox1->SelectionColor = Color::Red;

      richTextBox1->SaveFile( "C:\\MyDocument.rtf",
         RichTextBoxStreamType::RichText );

      this->Controls->Add( richTextBox1 );
   }