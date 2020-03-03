

//<Snippet1>
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
   System::Windows::Forms::Panel^ panel1;
   System::Windows::Forms::TrackBar^ trackBar1;
   System::Windows::Forms::TrackBar^ trackBar2;
   System::Windows::Forms::TrackBar^ trackBar3;
   System::Windows::Forms::Label ^ label1;
   System::Windows::Forms::Label ^ label3;
   System::Windows::Forms::Label ^ label2;

public:

   /// <summary>
   /// Required designer variable.
   /// </summary>
   Form1()
   {
      
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      
      //
      // TODO: Add any constructor code after InitializeComponent call
      //
      //<Snippet2>
      trackBar2->Orientation = Orientation::Vertical;
      trackBar3->Orientation = Orientation::Vertical;
      trackBar1->Maximum = 255;
      trackBar2->Maximum = 255;
      trackBar3->Maximum = 255;
      trackBar1->Width = 400;
      trackBar2->Height = trackBar1->Width;
      trackBar3->Height = trackBar1->Width;
      trackBar1->LargeChange = 16;
      trackBar2->LargeChange = 16;
      trackBar3->LargeChange = 16;
      
      //</Snippet2>
   }


private:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->trackBar1 = gcnew System::Windows::Forms::TrackBar;
      this->trackBar2 = gcnew System::Windows::Forms::TrackBar;
      this->trackBar3 = gcnew System::Windows::Forms::TrackBar;
      this->panel1 = gcnew System::Windows::Forms::Panel;
      this->label1 = gcnew System::Windows::Forms::Label;
      this->label2 = gcnew System::Windows::Forms::Label;
      this->label3 = gcnew System::Windows::Forms::Label;
      
      //<Snippet4>
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar1))->BeginInit();
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar2))->BeginInit();
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar3))->BeginInit();
      this->SuspendLayout();
      
      // 
      // trackBar1
      // 
      this->trackBar1->Location = System::Drawing::Point( 160, 400 );
      this->trackBar1->Name = "trackBar1";
      this->trackBar1->TabIndex = 1;
      this->trackBar1->Scroll += gcnew System::EventHandler( this, &Form1::trackBar_Scroll );
      
      // 
      // trackBar2
      // 
      this->trackBar2->Location = System::Drawing::Point( 608, 40 );
      this->trackBar2->Name = "trackBar2";
      this->trackBar2->TabIndex = 2;
      this->trackBar2->Scroll += gcnew System::EventHandler( this, &Form1::trackBar_Scroll );
      
      // 
      // trackBar3
      // 
      this->trackBar3->Location = System::Drawing::Point( 56, 40 );
      this->trackBar3->Name = "trackBar3";
      this->trackBar3->TabIndex = 3;
      this->trackBar3->Scroll += gcnew System::EventHandler( this, &Form1::trackBar_Scroll );
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar1))->EndInit();
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar2))->EndInit();
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->trackBar3))->EndInit();
      
      //</Snippet4>
      // 
      // panel1
      // 
      this->panel1->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      this->panel1->Location = System::Drawing::Point( 128, 32 );
      this->panel1->Name = "panel1";
      this->panel1->Size = System::Drawing::Size( 464, 352 );
      this->panel1->TabIndex = 0;
      
      // 
      // label1
      // 
      this->label1->Location = System::Drawing::Point( 288, 448 );
      this->label1->Name = "label1";
      this->label1->TabIndex = 4;
      
      // 
      // label2
      // 
      this->label2->Location = System::Drawing::Point( 8, 16 );
      this->label2->Name = "label2";
      this->label2->Size = System::Drawing::Size( 120, 16 );
      this->label2->TabIndex = 5;
      
      // 
      // label3
      // 
      this->label3->Location = System::Drawing::Point( 600, 16 );
      this->label3->Name = "label3";
      this->label3->Size = System::Drawing::Size( 120, 16 );
      this->label3->TabIndex = 6;
      
      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 728, 477 );
      array<System::Windows::Forms::Control^>^temp1 = {this->label3,this->label2,this->label1,this->trackBar3,this->trackBar2,this->trackBar1,this->panel1};
      this->Controls->AddRange( temp1 );
      this->Name = "Form1";
      this->Text = "Color builder";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->ResumeLayout( false );
   }

   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      showColorValueLabels();
   }


   //<Snippet3>
   void showColorValueLabels()
   {
      label1->Text = String::Format( "Red value is : {0}", trackBar1->Value );
      label3->Text = String::Format( "Green Value is : {0}", trackBar2->Value );
      label2->Text = String::Format( "Blue Value is : {0}", trackBar3->Value );
   }

   void trackBar_Scroll( Object^ sender, System::EventArgs^ /*e*/ )
   {
      System::Windows::Forms::TrackBar^ myTB;
      myTB = dynamic_cast<System::Windows::Forms::TrackBar^>(sender);
      panel1->BackColor = Color::FromArgb( trackBar1->Value, trackBar2->Value, trackBar3->Value );
      myTB->Text = String::Format( "Value is {0}", myTB->Value );
      showColorValueLabels();
   }

   //</Snippet3>
};


/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

//</Snippet1>
