#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

/// <summary>
/// Summary description for form.
/// </summary>

// The following example shows how to wrap a control
// using ToolStripControlHost.
//<snippet13>
//Declare a class that inherits from ToolStripControlHost.
public ref class ToolStripMonthCalendar: public ToolStripControlHost
{
public:
   //<snippet10>
   // Call the base constructor passing in a MonthCalendar instance.
   ToolStripMonthCalendar() : ToolStripControlHost( gcnew MonthCalendar ) {}
   //</snippet10>

   //<snippet11>
   property MonthCalendar^ MonthCalendarControl 
   {
      MonthCalendar^ get()
      {
         return static_cast<MonthCalendar^>(Control);
      }
   }
   //</snippet11>
   //<snippet12>
   property Day FirstDayOfWeek 
   {
      // Expose the MonthCalendar.FirstDayOfWeek as a property.
      Day get()
      {
         return MonthCalendarControl->FirstDayOfWeek;
      }

      void set( Day value )
      {
         MonthCalendarControl->FirstDayOfWeek = value;
      }
   }

   // Expose the AddBoldedDate method.
   void AddBoldedDate( DateTime dateToBold )
   {
      MonthCalendarControl->AddBoldedDate( dateToBold );
   }
   //</snippet12>

protected:
   // Subscribe and unsubscribe the control events you wish to expose.
   //<snippet16>
   //<snippet14>
   void OnSubscribeControlEvents( System::Windows::Forms::Control^ c )
   {
      // Call the base so the base events are connected.
      __super::OnSubscribeControlEvents( c );
      
      // Cast the control to a MonthCalendar control.
      MonthCalendar^ monthCalendarControl = (MonthCalendar^)c;
      
      // Add the event.
      monthCalendarControl->DateChanged += gcnew DateRangeEventHandler( this, &ToolStripMonthCalendar::HandleDateChanged );
   }
   //</snippet14>

   //<snippet15>
   void OnUnsubscribeControlEvents( System::Windows::Forms::Control^ c )
   {
      
      // Call the base method so the basic events are unsubscribed.
      __super::OnUnsubscribeControlEvents( c );
      
      // Cast the control to a MonthCalendar control.
      MonthCalendar^ monthCalendarControl = (MonthCalendar^)c;
      
      // Remove the event.
      monthCalendarControl->DateChanged -= gcnew DateRangeEventHandler( this, &ToolStripMonthCalendar::HandleDateChanged );
   }
   //</snippet15>
   //</snippet16>

public:
   event DateRangeEventHandler^ DateChanged;

private:
   //<snippet17>
   // Declare the DateChanged event.
   // Raise the DateChanged event.
   void HandleDateChanged( Object^ sender, DateRangeEventArgs^ e )
   {
      if ( DateChanged != nullptr )
      {
         DateChanged( this, e );
      }
   }
   //</snippet17>
};
//</snippet13>

public ref class Form1: public System::Windows::Forms::Form
{
private:
   /// <summary>
   /// Required designer variable.
   /// </summary>
   static System::ComponentModel::IContainer^ components = nullptr;
   static ToolStripTextBox^ textbox1;

public:
   Form1()
   {
      InitializeComponent();
      InitializeDropDownMonthCalendar();
      textbox1 = gcnew ToolStripTextBox;
      textbox1->Width = 70;
      toolStrip1->Items->Add( textbox1 );
      InitializeDateTimePickerHost();
   }

   static void Main()
   {
      Application::Run( gcnew Form1 );
   }

private:
   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->toolStrip1 = gcnew System::Windows::Forms::ToolStrip;
      this->raftingContainer1 = gcnew System::Windows::Forms::RaftingContainer;
      this->raftingContainer2 = gcnew System::Windows::Forms::RaftingContainer;
      this->raftingContainer3 = gcnew System::Windows::Forms::RaftingContainer;
      this->raftingContainer4 = gcnew System::Windows::Forms::RaftingContainer;
      this->SuspendLayout();
      
      //
      // toolStrip1
      //
      this->toolStrip1->Anchor = System::Windows::Forms::AnchorStyles::Right;
      this->toolStrip1->Dock = System::Windows::Forms::DockStyle::None;
      this->toolStrip1->Location = System::Drawing::Point( 0, 0 );
      this->toolStrip1->Name = L"toolStrip1";
      this->toolStrip1->Raft = System::Windows::Forms::RaftingSides::Top;
      this->toolStrip1->TabIndex = 1;
      this->toolStrip1->Text = L"toolStrip1";
      this->toolStrip1->Visible = true;
      
      //
      // raftingContainer1
      //
      this->raftingContainer1->AutoSize = true;
      this->raftingContainer1->Dock = System::Windows::Forms::DockStyle::Top;
      this->raftingContainer1->Location = System::Drawing::Point( 9, 9 );
      this->raftingContainer1->Name = L"raftingContainer1";
      this->raftingContainer1->Orientation = System::Windows::Forms::Orientation::Horizontal;
      this->raftingContainer1->RowMargin = System::Windows::Forms::Padding( 0 );
      this->raftingContainer1->Size = System::Drawing::Size( 274, 25 );
      this->raftingContainer1->TabIndex = 0;
      this->raftingContainer1->Text = L"RaftingContainerRaftingContainerTop";
      this->raftingContainer1->Join( this->toolStrip1 );
      
      //
      // raftingContainer2
      //
      this->raftingContainer2->AutoSize = true;
      this->raftingContainer2->Dock = System::Windows::Forms::DockStyle::Bottom;
      this->raftingContainer2->Location = System::Drawing::Point( 9, 257 );
      this->raftingContainer2->Name = L"raftingContainer2";
      this->raftingContainer2->Orientation = System::Windows::Forms::Orientation::Horizontal;
      this->raftingContainer2->RowMargin = System::Windows::Forms::Padding( 0 );
      this->raftingContainer2->Size = System::Drawing::Size( 274, 0 );
      this->raftingContainer2->TabIndex = 1;
      this->raftingContainer2->Text = L"RaftingContainerRaftingContainerBottom";
      
      //
      // raftingContainer3
      //
      this->raftingContainer3->AutoSize = true;
      this->raftingContainer3->Dock = System::Windows::Forms::DockStyle::Left;
      this->raftingContainer3->Location = System::Drawing::Point( 9, 9 );
      this->raftingContainer3->Name = L"raftingContainer3";
      this->raftingContainer3->Orientation = System::Windows::Forms::Orientation::Vertical;
      this->raftingContainer3->RowMargin = System::Windows::Forms::Padding( 0 );
      this->raftingContainer3->Size = System::Drawing::Size( 0, 248 );
      this->raftingContainer3->TabIndex = 2;
      this->raftingContainer3->Text = L"RaftingContainerRaftingContainerLeft";
      
      //
      // raftingContainer4
      //
      this->raftingContainer4->AutoSize = true;
      this->raftingContainer4->Dock = System::Windows::Forms::DockStyle::Right;
      this->raftingContainer4->Location = System::Drawing::Point( 283, 9 );
      this->raftingContainer4->Name = L"raftingContainer4";
      this->raftingContainer4->Orientation = System::Windows::Forms::Orientation::Vertical;
      this->raftingContainer4->RowMargin = System::Windows::Forms::Padding( 0 );
      this->raftingContainer4->Size = System::Drawing::Size( 0, 248 );
      this->raftingContainer4->TabIndex = 3;
      this->raftingContainer4->Text = L"RaftingContainerRaftingContainerRight";
      
      //
      // Form1
      //
      this->AutoSize = true;
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->raftingContainer1 );
      this->Controls->Add( this->raftingContainer2 );
      this->Controls->Add( this->raftingContainer3 );
      this->Controls->Add( this->raftingContainer4 );
      this->Name = L"Form1";
      this->Padding = System::Windows::Forms::Padding( 9 );
      this->Text = L"Form1";
      this->ResumeLayout( false );
      this->PerformLayout();
   }

protected:
   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   void Dispose( bool disposing )
   {
      if ( disposing )
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

      __super::Dispose( disposing );
   }

private:
   System::Windows::Forms::ToolStrip^ toolStrip1;
   System::Windows::Forms::RaftingContainer^ raftingContainer1;
   System::Windows::Forms::RaftingContainer^ raftingContainer2;
   System::Windows::Forms::RaftingContainer^ raftingContainer3;
   System::Windows::Forms::RaftingContainer^ raftingContainer4;

   // The following snippet demonstrates the ToolStripControlHost(Control)
   // consturctor, the ToolStripControlHost.Font, Width, DisplayStyle,
   // Text properties.
   //<snippet1>
   ToolStripControlHost^ dateTimePickerHost;
   void InitializeDateTimePickerHost()
   {
      // Create a new ToolStripControlHost, passing in a control.
      dateTimePickerHost = gcnew ToolStripControlHost( gcnew DateTimePicker );
      
      // Set the font on the ToolStripControlHost, this will affect the hosted control.
      dateTimePickerHost->Font =
         gcnew System::Drawing::Font( L"Arial",7.0F,FontStyle::Italic );
      
      // Set the Width property, this will also affect the hosted control.
      dateTimePickerHost->Width = 100;
      dateTimePickerHost->DisplayStyle = ToolStripItemDisplayStyle::Text;
      
      // Setting the Text property requires a string that converts to a
      // DateTime type since that is what the hosted control requires.
      dateTimePickerHost->Text = L"12/23/2005";
      
      // Cast the Control property back to the original type to set a
      // type-specific property.
      (dynamic_cast<DateTimePicker^>(dateTimePickerHost->Control))->Format =
         DateTimePickerFormat::Short;
      
      // Add the control host to the ToolStrip.
      toolStrip1->Items->Add( dateTimePickerHost );
   }
   //</snippet1>

   // The following example shows how to set the custom
   // ToolStripMonthCalendar control.
   //<snippet2>
   void InitializeDropDownMonthCalendar()
   {
      // Declare the drop-down button and the drop-down.
      ToolStripDropDownButton^ dropDownButton2 = gcnew ToolStripDropDownButton;
      
      // Set the image to the MonthCalendar embedded bitmap
      // image.
      dropDownButton2->Image =
         gcnew Bitmap( MonthCalendar::typeid,L"MonthCalendar.bmp" );
      
      // Add the button to the ToolStrip.
      toolStrip1->Items->Add( dropDownButton2 );
      
      // Construct a new drop-down.
      ToolStripDropDown^ dropDown = gcnew ToolStripDropDown;
      
      // Construct a new wrapped MonthCalendar control.
      ToolStripMonthCalendar^ monthCalendar = gcnew ToolStripMonthCalendar;
      
      // Set a date in boldface.
      monthCalendar->AddBoldedDate( DateTime::Today.AddDays( 7 ) );
      monthCalendar->DateChanged += gcnew DateRangeEventHandler(
         this, &Form1::monthCalendar_DateChanged );
      
      //Add the calendar to the drop-down.
      dropDown->Items->Add( monthCalendar );
      
      //Set the drop-down on the DropDownButton.
      dropDownButton2->DropDown = dropDown;
   }

private:
   void monthCalendar_DateChanged( Object^ /*sender*/, DateRangeEventArgs^ e )
   {
      textbox1->Text = e->Start.ToShortDateString();
   }
};

int main()
{
   Form1::Main();
}
//</snippet2>
