public ref class MyUserControlHost: public System::Windows::Forms::Form
{
private:

   // Create the controls.
   System::ComponentModel::IContainer^ components;
   System::Windows::Forms::Panel^ panel1;
   UserControls::MyCustomerInfoUserControl^ myUserControl;

public:

   // Define the constructor.
   MyUserControlHost()
   {
      this->InitializeComponent();
   }


private:

   // Add a Panel control to a Form and host the UserControl in the Panel.
   void InitializeComponent()
   {
      components = gcnew System::ComponentModel::Container;
      panel1 = gcnew System::Windows::Forms::Panel;
      myUserControl = gcnew UserControls::MyCustomerInfoUserControl;
      
      // Set the DockStyle of the UserControl to Fill.
      myUserControl->Dock = System::Windows::Forms::DockStyle::Fill;
      
      // Make the Panel the same size as the UserControl and give it a border.
      panel1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
      panel1->Size = myUserControl->Size;
      panel1->Location = System::Drawing::Point( 5, 5 );
      
      // Add the user control to the Panel.
      panel1->Controls->Add( myUserControl );
      
      // Size the Form to accommodate the Panel.
      this->ClientSize = System::Drawing::Size( panel1->Size.Width + 10, panel1->Size.Height + 10 );
      this->Text = "Please enter the information below...";
      
      // Add the Panel to the Form.
      this->Controls->Add( panel1 );
   }
};
// End Class

[System::STAThreadAttribute]
int main()
{
   System::Windows::Forms::Application::Run( gcnew MyUserControlHost );
}