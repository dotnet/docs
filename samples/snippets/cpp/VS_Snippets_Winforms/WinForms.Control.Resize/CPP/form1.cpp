

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

namespace ResizeEvent
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         InitializeComponent();
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
         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->Resize += gcnew System::EventHandler( this, &Form1::Form1_Resize );
      }

      //<snippet1>
   private:
      void Form1_Resize( Object^ sender, System::EventArgs^ /*e*/ )
      {
         Control^ control = dynamic_cast<Control^>(sender);

         // Ensure the Form remains square (Height = Width).
         if ( control->Size.Height != control->Size.Width )
         {
            control->Size = System::Drawing::Size( control->Size.Width, control->Size.Width );
         }
      }
      //</snippet1>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew ResizeEvent::Form1 );
}
