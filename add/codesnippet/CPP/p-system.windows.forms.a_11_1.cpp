private:
   void PrintStartupPath()
   {
      textBox1->Text = String::Concat( "The path for the executable file",
        " that started the application is: ", Application::StartupPath );
   }