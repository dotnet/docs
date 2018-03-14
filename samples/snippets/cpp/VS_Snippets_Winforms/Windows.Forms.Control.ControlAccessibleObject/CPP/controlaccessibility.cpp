

// <snippet1>
#using <Accessibility.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;

namespace MyCustomControls
{
   public ref class MyCheckBox: public CheckBox
   {
   public:
      MyCheckBox()
      {
         // Make the check box appear like a toggle button.
         this->Appearance = ::Appearance::Button;

         // Center the text on the button.
         this->TextAlign = ContentAlignment::MiddleCenter;

         // Set the AccessibleDescription text.
         this->AccessibleDescription = "A toggle style button.";
      }

   protected:

      // Create an instance of the AccessibleObject
      // defined for the 'MyCheckBox' control
      virtual AccessibleObject^ CreateAccessibilityInstance() override;
   };

   // Accessible Object* for use with the 'MyCheckBox' control.
   private ref class MyCheckBoxAccessibleObject: public Control::ControlAccessibleObject
   {
   public:
      MyCheckBoxAccessibleObject( MyCheckBox^ owner )
         : ControlAccessibleObject( owner )
      {}

      property String^ DefaultAction 
      {
         virtual String^ get() override
         {
            // Return the DefaultAction based upon
            // the state of the control.
            if ( (dynamic_cast<MyCheckBox^>(Owner))->Checked )
            {
               return "Toggle button up";
            }
            else
            {
               return "Toggle button down";
            }
         }
      }

      property String^ Name 
      {
         virtual String^ get() override
         {
            // Return the Text property of the control
            // if the AccessibleName is 0.
            String^ name = Owner->AccessibleName;
            if ( name != nullptr )
            {
               return name;
            }

            return (dynamic_cast<MyCheckBox^>(Owner))->Text;
         }

         virtual void set( String^ value ) override
         {
            ControlAccessibleObject::Name = value;
         }
      }

      property AccessibleRole Role 
      {
         virtual AccessibleRole get() override
         {
            // Since the check box appears like a button,
            // make the Role the same as a button.
            return AccessibleRole::PushButton;
         }
      }
   };

   AccessibleObject^ MyCheckBox::CreateAccessibilityInstance()
   {
      return gcnew MyCheckBoxAccessibleObject( this );
   }
}
// </snippet1>

namespace ControlAccessibility
{
   public ref class MyForm: public System::Windows::Forms::Form
   {
   private:
      System::ComponentModel::Container^ components;

   protected:
      ~MyForm()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:
      void InitializeComponent()
      {
         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         this->Name = "Form1";
         this->Text = "Form1";
      }

      // <snippet2>
   public:
      MyForm()
      {
         // Create a 'MyCheckBox' control and
         // display an image on it.
         MyCustomControls::MyCheckBox^ myCheckBox = gcnew MyCustomControls::MyCheckBox;
         myCheckBox->Location = Point(5,5);
         myCheckBox->Image = Image::FromFile( String::Concat( Application::CommonAppDataPath, "\\Preview.jpg" ) );
         
         // Set the AccessibleName property
         // since there is no Text displayed.
         myCheckBox->AccessibleName = "Preview";
         myCheckBox->AccessibleDescription = "A toggle button used to show the document preview.";
         this->Controls->Add( myCheckBox );
      }
      // </snippet2>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew ControlAccessibility::MyForm );
}
