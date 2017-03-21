public:
   void ViewMyTextBoxContents()
   {
      #if defined(DEBUG)
      // Create a string array and store the contents of the Lines property.
      array<String^>^ tempArray = gcnew array<String^>( textBox1->Lines->Length );
      tempArray = textBox1->Lines;
      
      // Loop through the array and send the contents of the array to debug window.
      for ( int counter = 0; counter < tempArray->Length; counter++ )
      {
         System::Diagnostics::Debug::WriteLine( tempArray[ counter ] );
      }
      #endif
   }