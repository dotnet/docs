

#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace ControlMembers3
{
   public ref class CustomerForm: public System::Windows::Forms::Form
   {
   public:
      String^ UserName;
   };

   public ref class Customer
   {
   public:
      String^ Name;
      int AccountNumber;
      virtual String^ ToString() override
      {
         return String::Concat( AccountNumber, "\r\n ", Name );
      }
   };

   public ref class AboutDialog: public System::Windows::Forms::Form
   {
   public:
      String^ FormText;
   };

   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::MainMenu^ mainMenu1;
      System::Windows::Forms::MenuItem^ menuItemHelp;
      System::Windows::Forms::MenuItem^ menuItemHelpAbout;
      System::Windows::Forms::Button^ buttonNewCustomer;
      System::Windows::Forms::MenuItem^ menuItemEditInsertCustomerInfo;
      System::Windows::Forms::TextBox^ textBox1;
      System::Windows::Forms::MenuItem^ menuItemEdit;
      System::Windows::Forms::MenuItem^ menuItemEditFontArial;
      System::Windows::Forms::MenuItem^ menuItemEditFontTimeNewRoman;
      System::Windows::Forms::MenuItem^ menuItemEditFont;
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         components = nullptr;
         InitializeComponent();
         Customer^ cust = gcnew Customer;
         cust->Name = "Microsoft";
         cust->AccountNumber = 123456;
         this->Tag = cust;
      }

   protected:
      ~Form1()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:
      void InitializeComponent()
      {
         this->button1 = gcnew System::Windows::Forms::Button;
         this->mainMenu1 = gcnew System::Windows::Forms::MainMenu;
         this->menuItemHelp = gcnew System::Windows::Forms::MenuItem;
         this->menuItemHelpAbout = gcnew System::Windows::Forms::MenuItem;
         this->buttonNewCustomer = gcnew System::Windows::Forms::Button;
         this->menuItemEdit = gcnew System::Windows::Forms::MenuItem;
         this->menuItemEditInsertCustomerInfo = gcnew System::Windows::Forms::MenuItem;
         this->textBox1 = gcnew System::Windows::Forms::TextBox;
         this->menuItemEditFont = gcnew System::Windows::Forms::MenuItem;
         this->menuItemEditFontArial = gcnew System::Windows::Forms::MenuItem;
         this->menuItemEditFontTimeNewRoman = gcnew System::Windows::Forms::MenuItem;
         this->SuspendLayout();

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 56, 168 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 0;
         this->button1->Text = "New Form";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

         //
         // mainMenu1
         //
         array<System::Windows::Forms::MenuItem^>^temp0 = {this->menuItemHelp,this->menuItemEdit};
         this->mainMenu1->MenuItems->AddRange( temp0 );

         //
         // menuItemHelp
         //
         this->menuItemHelp->Index = 0;
         array<System::Windows::Forms::MenuItem^>^temp1 = {this->menuItemHelpAbout};
         this->menuItemHelp->MenuItems->AddRange( temp1 );
         this->menuItemHelp->Text = "Help";

         //
         // menuItemHelpAbout 
         //
         this->menuItemHelpAbout->Index = 0;
         this->menuItemHelpAbout->Text = "About";
         this->menuItemHelpAbout->Click += gcnew System::EventHandler( this, &Form1::menuItemHelpAbout_Click );

         //
         // buttonNewCustomer
         //
         this->buttonNewCustomer->Location = System::Drawing::Point( 144, 168 );
         this->buttonNewCustomer->Name = "buttonNewCustomer";
         this->buttonNewCustomer->Size = System::Drawing::Size( 72, 24 );
         this->buttonNewCustomer->TabIndex = 1;
         this->buttonNewCustomer->Text = "New Customer";
         this->buttonNewCustomer->Click += gcnew System::EventHandler( this, &Form1::buttonNewCustomer_Click );

         //
         // menuItemEdit
         //
         this->menuItemEdit->Index = 1;
         array<System::Windows::Forms::MenuItem^>^temp2 = {this->menuItemEditInsertCustomerInfo,this->menuItemEditFont};
         this->menuItemEdit->MenuItems->AddRange( temp2 );
         this->menuItemEdit->Text = "Edit";
         this->menuItemEdit->Popup += gcnew System::EventHandler( this, &Form1::menuItemEdit_Popup );

         //
         // menuItemEditInsertCustomerInfo
         //
         this->menuItemEditInsertCustomerInfo->Enabled = false;
         this->menuItemEditInsertCustomerInfo->Index = 0;
         this->menuItemEditInsertCustomerInfo->Text = "Insert Customer Information";
         this->menuItemEditInsertCustomerInfo->Click += gcnew System::EventHandler( this, &Form1::menuItemEditInsertCustomerInfo_Click );

         //
         // textBox1
         //
         this->textBox1->Location = System::Drawing::Point( 56, 96 );
         this->textBox1->Multiline = true;
         this->textBox1->Name = "textBox1";
         this->textBox1->Size = System::Drawing::Size( 160, 64 );
         this->textBox1->TabIndex = 2;
         this->textBox1->Text = "";

         //
         // menuItemEditFont
         //
         this->menuItemEditFont->Index = 1;
         array<System::Windows::Forms::MenuItem^>^temp3 = {this->menuItemEditFontArial,this->menuItemEditFontTimeNewRoman};
         this->menuItemEditFont->MenuItems->AddRange( temp3 );
         this->menuItemEditFont->Text = "Font";

         //
         // menuItemEditFontArial
         //
         this->menuItemEditFontArial->Index = 0;
         this->menuItemEditFontArial->Text = "Arial";
         this->menuItemEditFontArial->Click += gcnew System::EventHandler( this, &Form1::menuItemEditFont_Click );

         //
         // menuItemEditFontTimeNewRoman
         //
         this->menuItemEditFontTimeNewRoman->Index = 1;
         this->menuItemEditFontTimeNewRoman->Text = "Times New Roman";
         this->menuItemEditFontTimeNewRoman->Click += gcnew System::EventHandler( this, &Form1::menuItemEditFont_Click );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^temp4 = {this->textBox1,this->buttonNewCustomer,this->button1};
         this->Controls->AddRange( temp4 );
         this->Menu = this->mainMenu1;
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         AddButtons();
      }

      // <snippet1>
   private:
      void menuItemHelpAbout_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Create and display a modeless about dialog box.
         AboutDialog^ about = gcnew AboutDialog;
         about->Show();
         
         // Draw a blue square on the form.
         /* NOTE: This is not a persistent object, it will no longer be
                     * visible after the next call to OnPaint. To make it persistent,
                     * override the OnPaint method and draw the square there */
         Graphics^ g = about->CreateGraphics();
         g->FillRectangle( Brushes::Blue, 10, 10, 50, 50 );
      }
      // </snippet1>

      // <snippet2>
   private:
      void AddButtons()
      {
         // Suspend the form layout and add two buttons.
         this->SuspendLayout();
         Button^ buttonOK = gcnew Button;
         buttonOK->Location = Point(10,10);
         buttonOK->Size = System::Drawing::Size( 75, 25 );
         buttonOK->Text = "OK";
         Button^ buttonCancel = gcnew Button;
         buttonCancel->Location = Point(90,10);
         buttonCancel->Size = System::Drawing::Size( 75, 25 );
         buttonCancel->Text = "Cancel";
         array<Control^>^temp5 = {buttonOK,buttonCancel};
         this->Controls->AddRange( temp5 );
         this->ResumeLayout();
      }
      // </snippet2>

      // <snippet3>
   private:
      void buttonNewCustomer_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         /* Create a new customer form and assign a new
                     * Customer object to the Tag property. */
         CustomerForm^ customerForm = gcnew CustomerForm;
         customerForm->Tag = gcnew Customer;
         customerForm->Show();
      }
      // </snippet3>

      // <snippet4>
   private:
      void menuItemEdit_Popup( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Disable the menu item if the text box does not have focus.
         this->menuItemEditInsertCustomerInfo->Enabled = this->textBox1->Focused;
      }
      // </snippet4>

      void menuItemEditInsertCustomerInfo_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Insert the customer information into the text box.
         this->textBox1->Text = String::Concat( this->textBox1->Text, dynamic_cast<Customer^>(this->Tag) );
      }

      void menuItemEditFont_Click( Object^ sender, System::EventArgs^ /*e*/ )
      {
         MenuItem^ menuItem = dynamic_cast<MenuItem^>(sender);
         if ( menuItem->Parent == this->menuItemEditFont )
         {
            // Uncheck all the menu items.
            IEnumerator^ myEnum = this->menuItemEditFont->MenuItems->GetEnumerator();
            while ( myEnum->MoveNext() )
            {
               MenuItem^ menu = safe_cast<MenuItem^>(myEnum->Current);
               menu->Checked = false;
            }
            
            // Check the menu item that was clicked.
            menuItem->Checked = true;
            
            // Update the font used in the text box.
            textBox1->Font = gcnew System::Drawing::Font( menuItem->Text,textBox1->Font->Size );
         }
      }
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew ControlMembers3::Form1 );
}
