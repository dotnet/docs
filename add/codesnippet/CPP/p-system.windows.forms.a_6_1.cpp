private:
   void PrintCompanyName()
   {
      textBox1->Text = String::Format( "The company name is: {0}",
         Application::CompanyName );
   }