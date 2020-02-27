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
   System::Windows::Forms::MainMenu^ mainMenu1;
   System::Windows::Forms::MenuItem^ menuItem1;
   System::Windows::Forms::MenuItem^ menuItem2;
   System::Windows::Forms::MenuItem^ menuItem3;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      components = nullptr;

      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      // Create the menu.
      CreateMyMenu();
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
   }

   void CreateMyMenu()
   {
      this->mainMenu1 = gcnew System::Windows::Forms::MainMenu;
      this->menuItem1 = gcnew System::Windows::Forms::MenuItem;
      this->menuItem2 = gcnew System::Windows::Forms::MenuItem;
      this->menuItem3 = gcnew System::Windows::Forms::MenuItem;

      //
      //
      // mainMenu1
      //
      array<System::Windows::Forms::MenuItem^>^temp0 = {this->menuItem1};
      this->mainMenu1->MenuItems->AddRange( temp0 );
      array<System::Windows::Forms::MenuItem^>^temp1 = {this->menuItem2};
      this->mainMenu1->MenuItems->AddRange( temp1 );
      array<System::Windows::Forms::MenuItem^>^temp2 = {this->menuItem3};
      this->mainMenu1->MenuItems->AddRange( temp2 );

      //
      // menuItem1
      //
      this->menuItem1->Index = 0;
      this->menuItem1->OwnerDraw = true;
      this->menuItem1->Text = "";
      this->menuItem1->DrawItem += gcnew System::Windows::Forms::DrawItemEventHandler( this, &Form1::menuItem1_DrawItem );

      //
      // menuItem2
      //
      this->menuItem2->Index = 1;
      this->menuItem2->OwnerDraw = true;
      this->menuItem2->Text = "";
      this->menuItem2->DrawItem += gcnew System::Windows::Forms::DrawItemEventHandler( this, &Form1::menuItem2_DrawItem );

      //
      // menuItem3
      //
      this->menuItem3->Index = 2;
      this->menuItem3->OwnerDraw = true;
      this->menuItem3->Text = "";
      this->menuItem3->DrawItem += gcnew System::Windows::Forms::DrawItemEventHandler( this, &Form1::menuItem3_DrawItem );
      this->Menu = this->mainMenu1;
   }

   //<snippet1>
   // The DrawItem event handler.
private:
   void menuItem1_DrawItem( Object^ /*sender*/, System::Windows::Forms::DrawItemEventArgs^ e )
   {
      String^ myCaption = "Owner Draw Item1";

      // Create a Brush and a Font with which to draw the item.
      Brush^ myBrush = System::Drawing::Brushes::AliceBlue;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( FontFamily::GenericSerif,14,FontStyle::Underline,GraphicsUnit::Pixel );
      SizeF mySizeF = e->Graphics->MeasureString( myCaption, myFont );

      // Draw the item, and then draw a Rectangle around it.
      e->Graphics->DrawString( myCaption, myFont, myBrush, (float)e->Bounds.X, (float)e->Bounds.Y );
      e->Graphics->DrawRectangle( Pens::Black, Rectangle(e->Bounds.X,e->Bounds.Y,Convert::ToInt32( mySizeF.Width ),Convert::ToInt32( mySizeF.Height )) );
   }
   //</snippet1>

   void menuItem2_DrawItem( Object^ /*sender*/, System::Windows::Forms::DrawItemEventArgs^ e )
   {
      String^ myCaption = "Owner Draw Item2";
      Brush^ myBrush = System::Drawing::Brushes::AliceBlue;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( FontFamily::GenericSerif,14,FontStyle::Underline,GraphicsUnit::Pixel );
      SizeF mySizeF = e->Graphics->MeasureString( myCaption, myFont );
      e->Graphics->DrawString( myCaption, myFont, myBrush, (float)e->Bounds.X, (float)e->Bounds.Y + 20 );
      e->Graphics->DrawRectangle( Pens::Black, Rectangle(e->Bounds.X,e->Bounds.Y + 20,Convert::ToInt32( mySizeF.Width ),Convert::ToInt32( mySizeF.Height )) );
   }

   void menuItem3_DrawItem( Object^ /*sender*/, System::Windows::Forms::DrawItemEventArgs^ e )
   {
      String^ myCaption = "Owner Draw Item3";
      Brush^ myBrush = System::Drawing::Brushes::AliceBlue;
      System::Drawing::Font^ myFont = gcnew System::Drawing::Font( FontFamily::GenericSerif,14,FontStyle::Underline,GraphicsUnit::Pixel );
      SizeF mySizeF = e->Graphics->MeasureString( myCaption, myFont );
      e->Graphics->DrawString( myCaption, myFont, myBrush, (float)e->Bounds.X, (float)e->Bounds.Y + 40 );
      e->Graphics->DrawRectangle( Pens::Black, Rectangle(e->Bounds.X,e->Bounds.Y + 40,Convert::ToInt32( mySizeF.Width ),Convert::ToInt32( mySizeF.Height )) );
   }
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
