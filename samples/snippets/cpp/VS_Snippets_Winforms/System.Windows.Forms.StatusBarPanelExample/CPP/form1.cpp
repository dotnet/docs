

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeStatusBarPanels();
      
      //Add any initialization after the InitializeComponent() call
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

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

internal:

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::RichTextBox^ RichTextBox1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->RichTextBox1 = gcnew System::Windows::Forms::RichTextBox;
      this->SuspendLayout();
      
      //
      //RichTextBox1
      //
      this->RichTextBox1->Dock = System::Windows::Forms::DockStyle::Fill;
      this->RichTextBox1->Location = System::Drawing::Point( 0, 0 );
      this->RichTextBox1->Name = "RichTextBox1";
      this->RichTextBox1->Size = System::Drawing::Size( 292, 266 );
      this->RichTextBox1->TabIndex = 0;
      this->RichTextBox1->Text = " ";
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->RichTextBox1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
internal:
   System::Windows::Forms::StatusBar^ statusBar1;

private:
   void InitializeStatusBarPanels()
   {
      
      // Create a StatusBar control.
      statusBar1 = gcnew StatusBar;
      
      // Dock the status bar at the top of the form. 
      statusBar1->Dock = DockStyle::Top;
      
      // Set the SizingGrip property to false so the user cannot 
      // resize the status bar.
      statusBar1->SizingGrip = false;
      
      // Associate the event-handling method with the 
      // PanelClick event.
      statusBar1->PanelClick += gcnew StatusBarPanelClickEventHandler( this, &Form1::statusBar1_PanelClick );
      
      // Create two StatusBarPanel objects to display in statusBar1.
      StatusBarPanel^ panel1 = gcnew StatusBarPanel;
      StatusBarPanel^ panel2 = gcnew StatusBarPanel;
      
      // Set the width of panel2 explicitly and set
      // panel1 to fill in the remaining space.
      panel2->Width = 80;
      panel1->AutoSize = StatusBarPanelAutoSize::Spring;
      
      // Set the text alignment within each panel.
      panel1->Alignment = HorizontalAlignment::Left;
      panel2->Alignment = HorizontalAlignment::Right;
      
      // Display the first panel without a border and the second
      // with a raised border.
      panel1->BorderStyle = StatusBarPanelBorderStyle::None;
      panel2->BorderStyle = StatusBarPanelBorderStyle::Raised;
      
      // Set the text of the panels. The panel1 object is reserved
      // for line numbers, while panel2 is set to the current time.
      panel1->Text = "Reserved for important information.";
      panel2->Text = System::DateTime::Now.ToShortTimeString();
      
      // Set a tooltip for panel2
      panel2->ToolTipText = "Click time to display seconds";
      
      // Display panels in statusBar1 and add them to the
      // status bar's StatusBarPanelCollection.
      statusBar1->ShowPanels = true;
      statusBar1->Panels->Add( panel1 );
      statusBar1->Panels->Add( panel2 );
      
      // Add the StatusBar to the form.
      this->Controls->Add( statusBar1 );
   }

   // If the user clicks the status bar, check the text of the 
   // StatusBarPanel.  If the text equals a short time string,
   // change it to long time display.
   void statusBar1_PanelClick( Object^ /*sender*/, StatusBarPanelClickEventArgs^ e )
   {
      if ( e->StatusBarPanel->Text == System::DateTime::Now.ToShortTimeString() )
      {
         e->StatusBarPanel->Text = System::DateTime::Now.ToLongTimeString();
      }
   }
   //</snippet1>
};

[System::STAThreadAttribute]
int main()
{
   Application::Run( gcnew Form1 );
}
