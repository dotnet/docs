public:
   void MyHandle()
   {
      // Gets the current input language.
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;
      
      // Gets a handle for the language and prints the number.
      IntPtr myHandle = myCurrentLanguage->Handle;
      textBox1->Text = String::Format( "The handle number is: {0}", myHandle );
   }