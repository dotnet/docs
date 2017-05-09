

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
   System::Windows::Forms::MonthCalendar^ monthCalendar1;
   System::Windows::Forms::TextBox^ textBox1;
   System::Windows::Forms::TextBox^ textBox2;
   System::Windows::Forms::Label ^ label1;
   System::Windows::Forms::Label ^ label2;
   System::Windows::Forms::Button^ button1;

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
   }


protected:

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
   /// Required method for Designer support; do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->monthCalendar1 = gcnew System::Windows::Forms::MonthCalendar;
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->textBox2 = gcnew System::Windows::Forms::TextBox;
      this->label1 = gcnew System::Windows::Forms::Label;
      this->label2 = gcnew System::Windows::Forms::Label;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();
      
      //
      // monthCalendar1
      //
      this->monthCalendar1->Location = System::Drawing::Point( 10, 8 );
      this->monthCalendar1->Name = "monthCalendar1";
      this->monthCalendar1->TabIndex = 0;
      this->monthCalendar1->DateChanged += gcnew System::Windows::Forms::DateRangeEventHandler( this, &Form1::monthCalendar1_DateChanged );
      
      //
      // textBox1
      //
      this->textBox1->Location = System::Drawing::Point( 96, 176 );
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 104, 20 );
      this->textBox1->TabIndex = 1;
      this->textBox1->Text = "";
      
      //
      // textBox2
      //
      this->textBox2->Location = System::Drawing::Point( 96, 208 );
      this->textBox2->Name = "textBox2";
      this->textBox2->Size = System::Drawing::Size( 104, 20 );
      this->textBox2->TabIndex = 2;
      this->textBox2->Text = "";
      
      //
      // label1
      //
      this->label1->Location = System::Drawing::Point( 24, 176 );
      this->label1->Name = "label1";
      this->label1->Size = System::Drawing::Size( 72, 23 );
      this->label1->TabIndex = 3;
      this->label1->Text = "Start";
      
      //
      // label2
      //
      this->label2->Location = System::Drawing::Point( 24, 208 );
      this->label2->Name = "label2";
      this->label2->Size = System::Drawing::Size( 72, 23 );
      this->label2->TabIndex = 4;
      this->label2->Text = "End";
      
      //
      // button1
      //
      this->button1->Location = System::Drawing::Point( 72, 248 );
      this->button1->Name = "button1";
      this->button1->TabIndex = 5;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
      
      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 216, 277 );
      array<System::Windows::Forms::Control^>^temp0 = {this->button1,this->label2,this->label1,this->textBox2,this->textBox1,this->monthCalendar1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Create a SelectionRange object and set its Start and End properties.
      SelectionRange^ sr = gcnew SelectionRange;
      sr->Start = DateTime::Parse( this->textBox1->Text );
      sr->End = DateTime::Parse( this->textBox2->Text );
      
      /* Assign the SelectionRange object to the
            SelectionRange property of the MonthCalendar control. */
      this->monthCalendar1->SelectionRange = sr;
   }

   void monthCalendar1_DateChanged( Object^ /*sender*/, DateRangeEventArgs^ /*e*/ )
   {
      /* Display the Start and End property values of
            the SelectionRange object in the text boxes. */
      this->textBox1->Text = monthCalendar1->SelectionRange->Start.Date.ToShortDateString();
      this->textBox2->Text = monthCalendar1->SelectionRange->End.Date.ToShortDateString();
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
