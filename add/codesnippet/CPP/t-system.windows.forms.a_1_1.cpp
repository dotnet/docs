public ref class Form1: public System::Windows::Forms::Form
{
private:
   Button^ button1;
   ListBox^ listBox1;

public:
   Form1()
   {
      button1 = gcnew Button;
      button1->Left = 200;
      button1->Text =  "Exit";
      button1->Click += gcnew EventHandler( this, &Form1::button1_Click );
      listBox1 = gcnew ListBox;
      this->Controls->Add( button1 );
      this->Controls->Add( listBox1 );
   }

private:
   void Form1::button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      int count = 1;
      
      // Check to see whether the user wants to exit 
      // the application. If not, add a number to the list box.
      while ( MessageBox::Show(  "Exit application?",  "", MessageBoxButtons::YesNo ) == ::DialogResult::No )
      {
         listBox1->Items->Add( count );
         count += 1;
      }

      
      // The user wants to exit the application. 
      // Close everything down.
      Application::Exit();
   }

};

int main()
{
   
   // Starts the application.
   Application::Run( gcnew Form1 );
}
