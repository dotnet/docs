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
      this->ClientSize = System::Drawing::Size( 376, 334 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
   }

   //<Snippet1>
   // This example creates a PictureBox control on the form and draws to it.
   // This example assumes that the Form_Load event handler method is
   // connected to the Load event of the form.
private:
   PictureBox^ pictureBox1;
   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      pictureBox1 = gcnew PictureBox;

      // Dock the PictureBox to the form and set its background to white.
      pictureBox1->Dock = DockStyle::Fill;
      pictureBox1->BackColor = Color::White;

      // Connect the Paint event of the PictureBox to the event handler method.
      pictureBox1->Paint += gcnew System::Windows::Forms::PaintEventHandler( this, &Form1::pictureBox1_Paint );

      // Add the PictureBox control to the Form.
      this->Controls->Add( pictureBox1 );
   }

   void pictureBox1_Paint( Object^ /*sender*/, System::Windows::Forms::PaintEventArgs^ e )
   {
      // Create a local version of the graphics object for the PictureBox.
      Graphics^ g = e->Graphics;

      // Draw a string on the PictureBox.
      g->DrawString( "This is a diagonal line drawn on the control",
         gcnew System::Drawing::Font( "Arial",10 ), System::Drawing::Brushes::Blue, Point(30,30) );

      // Draw a line in the PictureBox.
      g->DrawLine( System::Drawing::Pens::Red, pictureBox1->Left, pictureBox1->Top,
         pictureBox1->Right, pictureBox1->Bottom );
   }
   //</Snippet1>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
