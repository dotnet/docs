

//<Snippet1>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Design.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Reflection;
using namespace System::Text;
using namespace System::Windows::Forms;
using namespace System::Windows::Forms::Design;
using namespace System::Security::Permissions;

namespace ITypeResolutionServiceExample
{
   // Since this example provides a control-based user interface
   // in design mode, this designer passes window messages to the
   // controls at design time.
   public ref class WindowMessageDesigner: public System::Windows::Forms::Design::ControlDesigner
   {
   public:
      WindowMessageDesigner(){}

   protected:

      // Window procedure override passes events to the control.

      [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
      virtual void WndProc( System::Windows::Forms::Message% m ) override
      {
         if ( m.HWnd == this->Control->Handle )
                  ControlDesigner::WndProc( m );
         else
                  this->DefWndProc( m );
      }

   public:
      virtual void DoDefaultAction() override {}

   };

   // This control provides an example design-time user interface to
   // the ITypeResolutionService.

   [DesignerAttribute(WindowMessageDesigner::typeid,IDesigner::typeid)]
   public ref class ITypeResolutionServiceControl: public System::Windows::Forms::UserControl
   {
   private:

      // Reference to a type resolution service interface, or null
      // if not obtained.
      ITypeResolutionService^ rs;

      // Textbox for input of assembly and type names.
      System::Windows::Forms::TextBox^ entryBox;

      // Textbox for output of assembly, type, and status information.
      System::Windows::Forms::TextBox^ infoBox;

      // Panel to contain the radio buttons used to select the
      // method to InvokeMethod.
      System::Windows::Forms::Panel^ panel1;
      System::Windows::Forms::RadioButton^ radioButton1;
      System::Windows::Forms::RadioButton^ radioButton2;
      System::Windows::Forms::RadioButton^ radioButton3;
      System::Windows::Forms::RadioButton^ radioButton4;

      // Label to display textbox entry information.
      System::Windows::Forms::Label ^ label1;

      // Button to InvokeMethod command.
      System::Windows::Forms::Button^ button1;

   public:
      ITypeResolutionServiceControl()
      {
         InitializeComponent();
         rs = nullptr;
         
         // Attaches event handlers for control clicked events.
         radioButton1->CheckedChanged += gcnew EventHandler( this, &ITypeResolutionServiceControl::GetAssembly );
         radioButton2->CheckedChanged += gcnew EventHandler( this, &ITypeResolutionServiceControl::GetPathToAssembly );
         radioButton3->CheckedChanged += gcnew EventHandler( this, &ITypeResolutionServiceControl::GetInstanceOfType );
         radioButton4->CheckedChanged += gcnew EventHandler( this, &ITypeResolutionServiceControl::ReferenceAssembly );
         button1->Click += gcnew EventHandler( this, &ITypeResolutionServiceControl::InvokeMethod );
         entryBox->KeyUp += gcnew KeyEventHandler( this, &ITypeResolutionServiceControl::InvokeOnEnterKeyHandler );
      }

   protected:

      // Displays example control name and status information.
      virtual void OnPaint( System::Windows::Forms::PaintEventArgs^ e ) override
      {
         e->Graphics->DrawString( "ITypeResolutionService Interface Control", gcnew System::Drawing::Font( FontFamily::GenericMonospace,9 ), gcnew SolidBrush( Color::Blue ), 5, 5 );
         if ( this->DesignMode )
                  e->Graphics->DrawString( "Currently in Design Mode", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::DarkGreen ), 350, 2 );
         else
                  e->Graphics->DrawString( "Requires Design Mode", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Red ), 350, 2 );

         if ( rs != nullptr )
                  e->Graphics->DrawString( "Type Resolution Service Obtained", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::DarkGreen ), 350, 12 );
         else
                  e->Graphics->DrawString( "Type Resolution Service Not Obtained", gcnew System::Drawing::Font( FontFamily::GenericMonospace,8 ), gcnew SolidBrush( Color::Red ), 350, 12 );
      }

   private:

      // InvokeMethods the currently selected method, if any, when
      // the InvokeMethod button is pressed.
      void InvokeMethod( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // If the GetAssembly or GetPathofAssembly radio button
         // is selected.
         if ( this->radioButton1->Checked || this->radioButton2->Checked || this->radioButton4->Checked )
         {
            if ( this->entryBox->Text->Length == 0 )
            {
               // If there is no assembly name specified, display status message.
               this->infoBox->Text = "You must enter the name of the assembly to retrieve.";
            }
            else
            if ( rs != nullptr )
            {
               // Create a System.Reflection.AssemblyName
               // for the entered text.
               AssemblyName^ name = gcnew AssemblyName;
               name->Name = this->entryBox->Text->Trim();

               // If the GetAssembly radio button is checked...
               if ( this->radioButton1->Checked )
               {
                  // Use the ITypeResolutionService to attempt to
                  // resolve an assembly reference.
                  Assembly^ a = rs->GetAssembly( name, false );

                  // If an assembly matching the specified name was not
                  // located in the GAC or local project references,
                  // display a message.
                  if ( a == nullptr )
                                    this->infoBox->Text = String::Format( "The {0} assembly could not be located.", this->entryBox->Text );
                  else
                  {
                     // An assembly matching the specified name was located.
                     // Builds a list of types.
                     array<Type^>^types = a->GetTypes();
                     StringBuilder^ sb = gcnew StringBuilder;
                     for ( int i = 0; i < types->Length; i++ )
                        sb->Append( String::Concat( types[ i ]->FullName, "\r\n" ) );
                     String^ path = rs->GetPathOfAssembly( name );
                     
                     // Displays assembly information and a list of types contained in the assembly.
                     this->infoBox->Text = String::Format( "Assembly located:\r\n\r\n{0}\r\n  at: {1}\r\n\r\nAssembly types:\r\n\r\n{2}", a->FullName, path, sb );
                  }
               }
               else
               if ( this->radioButton2->Checked )
               {
                  String^ path = rs->GetPathOfAssembly( name );
                  if ( path != nullptr )
                                    this->infoBox->Text = String::Format( "Assembly located at:\r\n{0}", path );
                  else
                                    this->infoBox->Text = "Assembly was not located.";
               }
               else
               if ( this->radioButton4->Checked )
               {
                  Assembly^ a = nullptr;
                  try
                  {
                     // Add a reference to the assembly to the
                     // current project.
                     rs->ReferenceAssembly( name );
                     
                     // Use the ITypeResolutionService to attempt
                     // to resolve an assembly reference.
                     a = rs->GetAssembly( name, false );
                  }
                  catch ( Exception^ ) 
                  {
                     // Catch this exception so that the exception
                     // does not interrupt control behavior.
                  }

                  // If an assembly matching the specified name was not
                  // located in the GAC or local project references,
                  // display a message.
                  if ( a == nullptr )
                                    this->infoBox->Text = String::Format( "The {0} assembly could not be located.", this->entryBox->Text );
                  else
                                    this->infoBox->Text = String::Format( "A reference to the {0} assembly has been added to the project's referenced assemblies.", a->FullName );
               }
            }
         }
         else
         if ( this->radioButton3->Checked )
         {
            if ( this->entryBox->Text->Length == 0 )
            {
               // If there is no type name specified, display a
               // status message.
               this->infoBox->Text = "You must enter the name of the type to retrieve.";
            }
            else
            if ( rs != nullptr )
            {
               Type^ type = nullptr;
               try
               {
                  type = rs->GetType( this->entryBox->Text, false, true );
               }
               catch ( Exception^ ) 
               {
                  // Consume exceptions raised during GetType call
               }

               if ( type != nullptr )
               {
                  // Display type information.
                  this->infoBox->Text = String::Format( "Type: {0} located.\r\n  Namespace: {1}\r\n{2}", type->FullName, type->Namespace, type->AssemblyQualifiedName );
               }
               else
                              this->infoBox->Text = "Type not located.";
            }
         }
      }

      void GetAssembly( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         if ( this->radioButton1->Checked )
                  this->label1->Text = "Enter the assembly name:";
      }

      void GetPathToAssembly( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         if ( this->radioButton2->Checked )
                  this->label1->Text = "Enter the assembly name:";
      }

      void GetInstanceOfType( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         if ( this->radioButton3->Checked )
                  this->label1->Text = "Enter the type name:";
      }

      void ReferenceAssembly( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         if ( this->radioButton4->Checked )
                  this->label1->Text = "Enter the assembly name:";
      }

      void InvokeOnEnterKeyHandler( Object^ sender, KeyEventArgs^ e )
      {
         if ( e->KeyCode == Keys::Enter )
                  this->InvokeMethod( sender, gcnew EventArgs );
      }

   public:

      property System::ComponentModel::ISite^ Site 
      {
         virtual System::ComponentModel::ISite^ get() override
         {
            return __super::Site;
         }

         virtual void set( System::ComponentModel::ISite^ value ) override
         {
            __super::Site = value;
            
            // Attempts to obtain ITypeResolutionService interface.
            rs = dynamic_cast<ITypeResolutionService^>(this->GetService( ITypeResolutionService::typeid ));
         }

      }

   private:
      void InitializeComponent()
      {
         this->entryBox = gcnew System::Windows::Forms::TextBox;
         this->infoBox = gcnew System::Windows::Forms::TextBox;
         this->panel1 = gcnew System::Windows::Forms::Panel;
         this->radioButton1 = gcnew System::Windows::Forms::RadioButton;
         this->radioButton2 = gcnew System::Windows::Forms::RadioButton;
         this->radioButton3 = gcnew System::Windows::Forms::RadioButton;
         this->radioButton4 = gcnew System::Windows::Forms::RadioButton;
         this->label1 = gcnew System::Windows::Forms::Label;
         this->button1 = gcnew System::Windows::Forms::Button;
         this->panel1->SuspendLayout();
         this->SuspendLayout();

         // entryBox
         this->entryBox->Location = System::Drawing::Point( 176, 80 );
         this->entryBox->Name = "entryBox";
         this->entryBox->Size = System::Drawing::Size( 320, 20 );
         this->entryBox->TabIndex = 0;
         this->entryBox->Text = "";

         // infoBox
         this->infoBox->Anchor = static_cast<AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom) | System::Windows::Forms::AnchorStyles::Left) | System::Windows::Forms::AnchorStyles::Right);
         this->infoBox->Location = System::Drawing::Point( 16, 111 );
         this->infoBox->Multiline = true;
         this->infoBox->Name = "infoBox";
         this->infoBox->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
         this->infoBox->Size = System::Drawing::Size( 592, 305 );
         this->infoBox->TabIndex = 1;
         this->infoBox->Text = "";

         // panel1
         array<System::Windows::Forms::Control^>^temp0 = {this->radioButton4,this->radioButton3,this->radioButton2,this->radioButton1};
         this->panel1->Controls->AddRange( temp0 );
         this->panel1->Location = System::Drawing::Point( 16, 32 );
         this->panel1->Name = "panel1";
         this->panel1->Size = System::Drawing::Size( 480, 40 );
         this->panel1->TabIndex = 2;

         // radioButton1
         this->radioButton1->Location = System::Drawing::Point( 8, 8 );
         this->radioButton1->Name = "radioButton1";
         this->radioButton1->Size = System::Drawing::Size( 96, 24 );
         this->radioButton1->TabIndex = 0;
         this->radioButton1->Text = "GetAssembly";

         // radioButton2
         this->radioButton2->Location = System::Drawing::Point( 112, 8 );
         this->radioButton2->Name = "radioButton2";
         this->radioButton2->Size = System::Drawing::Size( 128, 24 );
         this->radioButton2->TabIndex = 1;
         this->radioButton2->Text = "GetPathToAssembly";

         // radioButton3
         this->radioButton3->Location = System::Drawing::Point( 248, 8 );
         this->radioButton3->Name = "radioButton3";
         this->radioButton3->Size = System::Drawing::Size( 80, 24 );
         this->radioButton3->TabIndex = 2;
         this->radioButton3->Text = "GetType";

         // radioButton4
         this->radioButton4->Location = System::Drawing::Point( 344, 8 );
         this->radioButton4->Name = "radioButton4";
         this->radioButton4->Size = System::Drawing::Size( 128, 24 );
         this->radioButton4->TabIndex = 3;
         this->radioButton4->Text = "ReferenceAssembly";

         // label1
         this->label1->Location = System::Drawing::Point( 18, 83 );
         this->label1->Name = "label1";
         this->label1->Size = System::Drawing::Size( 150, 16 );
         this->label1->TabIndex = 3;

         // button1
         this->button1->Location = System::Drawing::Point( 519, 41 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 4;
         this->button1->Text = "Invoke";

         // ITypeResolutionServiceControl
         this->BackColor = System::Drawing::Color::White;
         array<System::Windows::Forms::Control^>^temp1 = {this->button1,this->label1,this->panel1,this->infoBox,this->entryBox};
         this->Controls->AddRange( temp1 );
         this->Name = "ITypeResolutionServiceControl";
         this->Size = System::Drawing::Size( 624, 432 );
         this->panel1->ResumeLayout( false );
         this->ResumeLayout( false );
      }
   };
}
//</Snippet1>
