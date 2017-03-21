public:
   void SelectMyString()
   {
      // Create a string to search for the word "fox".
      String^ searchString = "fox";
      // Determine the starting location of the word "fox".
      int index = textBox1->Text->IndexOf( searchString, 16, 3 );
      // Determine if the word has been found and select it if it was.
      if ( index != -1 )
      {
         // Select the string using the index and the length of the string.
         textBox1->Select( index,searchString->Length );
      }
   }