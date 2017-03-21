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