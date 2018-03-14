

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace SetBoundsCore
{
   public ref class MyUserControl: public System::Windows::Forms::UserControl
   {
   private:
      System::ComponentModel::Container^ components;

   public:
      MyUserControl()
      {
         InitializeComponent();
      }

   protected:
     ~MyUserControl()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         //
         // MyUserControl
         //
         this->BackColor = System::Drawing::SystemColors::Desktop;
         this->Name = "MyUserControl";
         this->Size = System::Drawing::Size( 224, 88 );
      }

      // <snippet1>
   protected:
      virtual void SetBoundsCore( int x, int y, int width, int height, BoundsSpecified specified ) override
      {
         // Set a fixed height and width for the control.
         UserControl::SetBoundsCore( x, y, 150, 75, specified );
      }
      // </snippet1>

      // <snippet2>
   protected:
      virtual void SetClientSizeCore( int x, int y ) override
      {
         // Keep the client size square.
         if ( x > y )
         {
            UserControl::SetClientSizeCore( x, x );
         }
         else
         {
            UserControl::SetClientSizeCore( y, y );
         }
      }
      // </snippet2>

      // <snippet3>
   protected:
      virtual void ScaleCore( float dx, float dy ) override
      {
         // Scale all child controls.
         this->SuspendLayout();
         System::Drawing::Size myClientSize = this->ClientSize;
         myClientSize.Height = (int)(myClientSize.Height * dx);
         myClientSize.Width = (int)(myClientSize.Width * dy);
         
         /* Scale the child controls because
               * UserControl::ScaleCore was not called. */
         System::Collections::IEnumerator^ myEnum = this->Controls->GetEnumerator();
         while ( myEnum->MoveNext() )
         {
            Control^ childControl = safe_cast<Control^>(myEnum->Current);
            childControl->Scale( dx, dy );
         }

         this->ResumeLayout();
         this->ClientSize = myClientSize;
      }
      // </snippet3>
   };
}
