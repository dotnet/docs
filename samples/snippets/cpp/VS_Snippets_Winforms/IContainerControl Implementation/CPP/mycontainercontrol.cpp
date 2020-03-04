

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

// <snippet1>
using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;

public ref class MyContainer: public ScrollableControl, public IContainerControl
{
private:
   Control^ activeControl;

public:
   MyContainer()
   {
      // Make the container control Blue so it can be distinguished on the form.
      this->BackColor = Color::Blue;

      // Make the container scrollable.
      this->AutoScroll = true;
   }

   property Control^ ActiveControl 
   {
      // Add implementation to the IContainerControl.ActiveControl property.
      virtual Control^ get()
      {
         return activeControl;
      }

      virtual void set( Control^ value )
      {
         
         // Make sure the control is a member of the ControlCollection.
         if ( this->Controls->Contains( value ) )
         {
            activeControl = value;
         }
      }
   }

   // Add implementations to the IContainerControl.ActivateControl(Control) method.
   virtual bool ActivateControl( Control^ active )
   {
      if ( this->Controls->Contains( active ) )
      {
         // Select the control and scroll the control into view if needed.
         active->Select(  );
         this->ScrollControlIntoView( active );
         this->activeControl = active;
         return true;
      }

      return false;
   }
};
// </snippet1>
