

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

namespace ControlProperties
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::ImageList^ imageList1;
      System::Windows::Forms::Button^ button2;
      System::ComponentModel::IContainer^ components;

   public:
      Form1()
      {
         InitializeComponent();
         
         //this->AddMyGroupBox();
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
         this->components = gcnew System::ComponentModel::Container;
         System::Resources::ResourceManager^ resources = gcnew System::Resources::ResourceManager( Form1::typeid );
         this->imageList1 = gcnew System::Windows::Forms::ImageList( this->components );
         this->button2 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();

         //
         // imageList1
         //
         this->imageList1->ColorDepth = System::Windows::Forms::ColorDepth::Depth8Bit;
         this->imageList1->ImageSize = System::Drawing::Size( 16, 16 );
         this->imageList1->ImageStream = (dynamic_cast<System::Windows::Forms::ImageListStreamer^>(resources->GetObject( "imageList1.ImageStream" )));
         this->imageList1->TransparentColor = System::Drawing::Color::Transparent;

         //
         // button2
         //
         this->button2->Location = System::Drawing::Point( 40, 232 );
         this->button2->Name = "button2";
         this->button2->TabIndex = 0;
         this->button2->Text = "button1";
         this->button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );

         //
         // Form1
         //
         this->BackColor = System::Drawing::Color::FromArgb( ((System::Byte)(0)) ),((System::Byte)(64)),((System::Byte)(0));
         this->ClientSize = System::Drawing::Size( 408, 405 );
         array<System::Windows::Forms::Control^>^temp0 = {this->button2};
         this->Controls->AddRange( temp0 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      //<snippet3>
      // Add a button to a form and set some of its common properties.
   private:
      void AddMyButton()
      {
         // Create a button and add it to the form.
         Button^ button1 = gcnew Button;

         // Anchor the button to the bottom right corner of the form
         button1->Anchor = static_cast<AnchorStyles>(AnchorStyles::Bottom | AnchorStyles::Right);

         // Assign a background image.
         button1->BackgroundImage = imageList1->Images[ 0 ];

         // Specify the layout style of the background image. Tile is the default.
         button1->BackgroundImageLayout = ImageLayout::Center;

         // Make the button the same size as the image.
         button1->Size = button1->BackgroundImage->Size;

         // Set the button's TabIndex and TabStop properties.
         button1->TabIndex = 1;
         button1->TabStop = true;

         // Add a delegate to handle the Click event.
         button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

         // Add the button to the form.
         this->Controls->Add( button1 );
      }
      // </snippet3>

      //<snippet2>
      // Add a GroupBox to a form and set some of its common properties.
   private:
      void AddMyGroupBox()
      {
         // Create a GroupBox and add a TextBox to it.
         GroupBox^ groupBox1 = gcnew GroupBox;
         TextBox^ textBox1 = gcnew TextBox;
         textBox1->Location = Point(15,15);
         groupBox1->Controls->Add( textBox1 );

         // Set the Text and Dock properties of the GroupBox.
         groupBox1->Text = "MyGroupBox";
         groupBox1->Dock = DockStyle::Top;

         // Disable the GroupBox (which disables all its child controls)
         groupBox1->Enabled = false;

         // Add the Groupbox to the form.
         this->Controls->Add( groupBox1 );
      }
      // </snippet2>

      // <snippet1>
      // Reset all the controls to the user's default Control color.
   private:
      void ResetAllControlsBackColor( Control^ control )
      {
         control->BackColor = SystemColors::Control;
         control->ForeColor = SystemColors::ControlText;
         if ( control->HasChildren )
         {
            // Recursively call this method for each child control.
            IEnumerator^ myEnum = control->Controls->GetEnumerator();
            while ( myEnum->MoveNext() )
            {
               Control^ childControl = safe_cast<Control^>(myEnum->Current);
               ResetAllControlsBackColor( childControl );
            }
         }
      }
      // </snippet1>

      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->ResetAllControlsBackColor( this );
      }

      void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->AddMyButton();
      }
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew ControlProperties::Form1 );
}
