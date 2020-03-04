#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1() : Form()
   {
      InitializeComponent();
      ShowAWeeksVacationOneMonthFromToday();
   }

internal:
   System::Windows::Forms::MonthCalendar^ MonthCalendar1;

private:
   void InitializeComponent()
   {
      this->MonthCalendar1 = gcnew System::Windows::Forms::MonthCalendar;
      this->SuspendLayout();
      this->MonthCalendar1->Location = System::Drawing::Point( 56, 32 );
      this->MonthCalendar1->Name = "MonthCalendar1";
      this->MonthCalendar1->TabIndex = 0;
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->MonthCalendar1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
   // Computes a week one month from today.
   void ShowAWeeksVacationOneMonthFromToday()
   {
      DateTime today = this->MonthCalendar1->TodayDate;
      DateTime vacationStart = today.AddMonths(1);
      DateTime vacationEnd = vacationStart.AddDays(7);

      // Select the week using SelectionStart and SelectionEnd.
      this->MonthCalendar1->SelectionStart = vacationStart.AddDays(-1);
      this->MonthCalendar1->SelectionEnd = vacationEnd.AddDays(-1);
   }
   //</snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
