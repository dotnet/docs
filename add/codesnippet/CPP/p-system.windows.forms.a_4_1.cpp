private:
   void PrintCurrentCulture()
   {
      textBox1->Text = "The current culture is: {0}",
         Application::CurrentCulture->EnglishName;
   }