public ref class MyApplication: public Form
{
private:
   MyIconButton^ myIconButton;
   Button^ stdButton;
   OpenFileDialog^ openDlg;

public:
   MyApplication()
   {
      try
      {
         
         // Create the button with the default icon.
         myIconButton = gcnew MyIconButton( gcnew System::Drawing::Icon( String::Concat( Application::StartupPath, "\\Default.ico" ) ) );
      }
      catch ( Exception^ ex ) 
      {
         
         // If the default icon does not exist, create the button without an icon.
         myIconButton = gcnew MyIconButton;
         #if defined(DEBUG)
         Debug::WriteLine( ex );
         #endif
      }
      finally
      {
         stdButton = gcnew Button;
         
         // Add the Click event handlers.
         myIconButton->Click += gcnew EventHandler( this, &MyApplication::myIconButton_Click );
         stdButton->Click += gcnew EventHandler( this, &MyApplication::stdButton_Click );
         
         // Set the location, text and width of the standard button.
         stdButton->Location = Point(myIconButton->Location.X,myIconButton->Location.Y + myIconButton->Height + 20);
         stdButton->Text = "Change Icon";
         stdButton->Width = 100;
         
         // Add the buttons to the Form.
         this->Controls->Add( stdButton );
         this->Controls->Add( myIconButton );
      }

   }


private:
   void myIconButton_Click( Object^ /*Sender*/, EventArgs^ /*e*/ )
   {
      
#undef MessageBox 
      
      // Make sure MyIconButton works.
      MessageBox::Show( "MyIconButton was clicked!" );
   }

   void stdButton_Click( Object^ /*Sender*/, EventArgs^ /*e*/ )
   {
      
      // Use an OpenFileDialog to allow the user to assign a new image to the derived button.
      openDlg = gcnew OpenFileDialog;
      openDlg->InitialDirectory = Application::StartupPath;
      openDlg->Filter = "Icon files (*.ico)|*.ico";
      openDlg->Multiselect = false;
      openDlg->ShowDialog();
      if (  !openDlg->FileName->Equals( "" ) )
      {
         myIconButton->Icon = gcnew System::Drawing::Icon( openDlg->FileName );
      }
   }

};

int main()
{
   Application::Run( gcnew MyApplication );
}
