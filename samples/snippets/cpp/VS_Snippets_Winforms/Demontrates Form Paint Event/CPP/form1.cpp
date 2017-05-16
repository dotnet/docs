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

/// <summary>
/// Summary description for Form1.
/// </summary>

public ref class Form1: public System::Windows::Forms::Form
{
private:

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
      RcDraw = Rectangle(0,0,0,0);
   }

public:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   ~Form1()
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
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 273 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->MouseDown += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::Form1_MouseDown );
      this->MouseUp += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::Form1_MouseUp );
      this->Paint += gcnew System::Windows::Forms::PaintEventHandler( this, &Form1::Form1_Paint );
   }

   //<snippet1>
private:
   Rectangle RcDraw;
   void Form1_MouseDown( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
   {
      // Determine the initial rectangle coordinates...
      RcDraw.X = e->X;
      RcDraw.Y = e->Y;
   }

   void Form1_MouseUp( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
   {
      // Determine the width and height of the rectangle...
      if ( e->X < RcDraw.X )
      {
         RcDraw.Width = RcDraw.X - e->X;
         RcDraw.X = e->X;
      }
      else
      {
         RcDraw.Width = e->X - RcDraw.X;
      }

      if ( e->Y < RcDraw.Y )
      {
         RcDraw.Height = RcDraw.Y - e->Y;
         RcDraw.Y = e->Y;
      }
      else
      {
         RcDraw.Height = e->Y - RcDraw.Y;
      }

      // Force a repaint of the region occupied by the rectangle...
      this->Invalidate( RcDraw );
   }

   void Form1_Paint( Object^ /*sender*/, System::Windows::Forms::PaintEventArgs^ e )
   {
      // Draw the rectangle...
      float PenWidth = 5;
      e->Graphics->DrawRectangle( gcnew Pen( Color::Blue,PenWidth ), RcDraw );
   }
   //</snippet1>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
