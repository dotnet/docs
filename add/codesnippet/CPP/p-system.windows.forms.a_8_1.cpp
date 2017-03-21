private:
   void PrintCurrentInputLanguage()
   {
      textBox1->Text = "The current input language is: {0}",
         Application::CurrentInputLanguage->Culture->EnglishName;
   }