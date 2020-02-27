

#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Drawing.Design.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::Data;
using namespace System::Windows::Forms;

namespace BitmapEditorExample
{
   public ref class UserControl1: public System::Windows::Forms::UserControl
   {
   private:
      System::ComponentModel::Container^ components;

   public:

      property Bitmap^ testBitmap 
      {

         //<Snippet1>
         [EditorAttribute(System::Drawing::Design::BitmapEditor::typeid,System::Drawing::Design::UITypeEditor::typeid)]
         Bitmap^ get()
         {
            return testBmp;
         }

         void set( Bitmap^ value )
         {
            testBmp = value;
         }
      }

   private:
      Bitmap^ testBmp;
      //</Snippet1>

   public:

      UserControl1()
      {
         InitializeComponent();
      }

   private:

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         components = gcnew System::ComponentModel::Container;
      }
   };
}
