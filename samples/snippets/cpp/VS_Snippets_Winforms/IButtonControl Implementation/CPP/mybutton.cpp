

// <snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;

public ref class MyButton: public ButtonBase, public IButtonControl
{
private:
   System::Windows::Forms::DialogResult myDialogResult;

public:
   MyButton()
   {
      // Make the button White and a Popup style
      // so it can be distinguished on the form.
      this->FlatStyle = ::FlatStyle::Popup;
      this->BackColor = Color::White;
   }

   property System::Windows::Forms::DialogResult DialogResult 
   {
      // Add implementation to the IButtonControl.DialogResult property.
      virtual System::Windows::Forms::DialogResult get()
      {
         return this->myDialogResult;
      }

      virtual void set( System::Windows::Forms::DialogResult value )
      {
         if ( Enum::IsDefined( System::Windows::Forms::DialogResult::typeid, value ) )
         {
            this->myDialogResult = value;
         }
      }
   }

   // Add implementation to the IButtonControl.NotifyDefault method.
   virtual void NotifyDefault( bool value )
   {
      if ( this->IsDefault != value )
      {
         this->IsDefault = value;
      }
   }

   // Add implementation to the IButtonControl.PerformClick method.
   virtual void PerformClick()
   {
      if ( this->CanSelect )
      {
         this->OnClick( EventArgs::Empty );
      }
   }
};
// </snippet1>
