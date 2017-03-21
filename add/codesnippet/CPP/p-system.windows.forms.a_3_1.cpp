private:
   void PrintProductVersion()
   {
      textBox1->Text = "The product version is: {0}",
         Application::ProductVersion;
   }