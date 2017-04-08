

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

//<Snippet1>
using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::TrackBar^ trackBar1;
   System::Windows::Forms::TextBox^ textBox1;

public:
   Form1()
   {
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->trackBar1 = gcnew System::Windows::Forms::TrackBar;
      
      // TextBox for TrackBar::Value update.
      this->textBox1->Location = System::Drawing::Point( 240, 16 );
      this->textBox1->Size = System::Drawing::Size( 48, 20 );
      
      // Set up how the form should be displayed and add the controls to the form.
      this->ClientSize = System::Drawing::Size( 296, 62 );
      array<System::Windows::Forms::Control^>^formControls = {this->textBox1,this->trackBar1};
      this->Controls->AddRange( formControls );
      this->Text = "TrackBar Example";
      
      // Set up the TrackBar.
      this->trackBar1->Location = System::Drawing::Point( 8, 8 );
      this->trackBar1->Size = System::Drawing::Size( 224, 45 );
      this->trackBar1->Scroll += gcnew System::EventHandler( this, &Form1::trackBar1_Scroll );
      
      // The Maximum property sets the value of the track bar when
      // the slider is all the way to the right.
      trackBar1->Maximum = 30;
      
      // The TickFrequency property establishes how many positions
      // are between each tick-mark.
      trackBar1->TickFrequency = 5;
      
      // The LargeChange property sets how many positions to move
      // if the bar is clicked on either side of the slider.
      trackBar1->LargeChange = 3;
      
      // The SmallChange property sets how many positions to move
      // if the keyboard arrows are used to move the slider.
      trackBar1->SmallChange = 2;
   }


private:
   void trackBar1_Scroll( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Display the trackbar value in the text box.
      textBox1->Text = String::Concat( "", trackBar1->Value );
   }

};


[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

//</Snippet1>
