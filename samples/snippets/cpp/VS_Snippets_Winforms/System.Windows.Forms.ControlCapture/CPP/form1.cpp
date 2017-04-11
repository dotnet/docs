//
//This code examples shows a use of the Control.Capture property.
//

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class CaptureForm: public System::Windows::Forms::Form
{
public:
   CaptureForm() : Form()
   {
      InitializeComponent();
      this->MouseDown += gcnew MouseEventHandler( this, &CaptureForm::Control_MouseDown );
      this->listbox1->MouseDown += gcnew MouseEventHandler( this, &CaptureForm::Control_MouseDown );
      this->listbox2->MouseDown += gcnew MouseEventHandler( this, &CaptureForm::Control_MouseDown );
      this->label1->MouseDown += gcnew MouseEventHandler( this, &CaptureForm::Control_MouseDown );
   }

internal:
   System::Windows::Forms::Label ^ label1;
   System::Windows::Forms::ListBox^ listbox1;
   System::Windows::Forms::ListBox^ listbox2;

private:
   void InitializeComponent()
   {
      this->label1 = gcnew System::Windows::Forms::Label;
      this->listbox1 = gcnew System::Windows::Forms::ListBox;
      this->listbox2 = gcnew System::Windows::Forms::ListBox;
      this->SuspendLayout();
      
      //
      //Label1
      //
      this->label1->Location = System::Drawing::Point( 168, 72 );
      this->label1->Name = "Label1";
      this->label1->Size = System::Drawing::Size( 104, 72 );
      this->label1->TabIndex = 4;
      this->label1->Text =
         "Click around the form to see what control has captured  the mouse.";
      
      //
      //LunchBox
      //
      this->listbox2->AllowDrop = true;
      array<Object^>^ temp0 = { "Sandwich", "Chips", "Soda", "Soup", "Salad" };
      this->listbox2->Items->AddRange( temp0 );
      this->listbox2->Location = System::Drawing::Point( 296, 64 );
      this->listbox2->Name = "LunchBox";
      this->listbox2->Size = System::Drawing::Size( 120, 95 );
      this->listbox2->TabIndex = 5;
      
      //
      //BreakfastBox
      //
      this->listbox1->AllowDrop = true;
      array<Object^>^ temp1 =
         { "Bagels", "Pancakes", "Donuts", "Eggs", "Hashbrowns", "Orange Juice" };
      this->listbox1->Items->AddRange( temp1 );
      this->listbox1->Location = System::Drawing::Point( 24, 64 );
      this->listbox1->Name = "BreakfastBox";
      this->listbox1->Size = System::Drawing::Size( 120, 95 );
      this->listbox1->TabIndex = 6;
      
      //
      //CaptureForm
      //
      this->ClientSize = System::Drawing::Size( 440, 266 );
      this->Controls->Add( this->listbox1 );
      this->Controls->Add( this->listbox2 );
      this->Controls->Add( this->label1 );
      this->Name = "CaptureForm";
      this->Text = "CaptureForm";
      this->ResumeLayout( false );
   }


   //<snippet1>
   // This method handles the mouse down event for all the controls on the form.  
   // When a control has captured the mouse
   // the control's name will be output on label1.
   void Control_MouseDown( System::Object^ sender,
      System::Windows::Forms::MouseEventArgs^ /*e*/ )
   {
      Control^ control = (Control^)(sender);
      if ( control->Capture )
      {
         label1->Text = control->Name + " has captured the mouse";
      }
   }
   //</snippet1>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew CaptureForm );
}
