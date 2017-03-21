   // Computes a week one month from today.
   void ShowAWeeksVacationOneMonthFromToday()
   {
      System::DateTime today = this->MonthCalendar1->TodayDate;
      int vacationMonth = today.Month + 1;
      int vacationYear = today.Year;

      if ( today.Month == 12 )
      {
         vacationMonth = 1;
         ++vacationYear;
      }
      
      // Select the week using SelectionStart and SelectionEnd.
      this->MonthCalendar1->SelectionStart =
         System::DateTime( today.Year, vacationMonth, today.Day - 1 );
      this->MonthCalendar1->SelectionEnd =
         System::DateTime( today.Year, vacationMonth, today.Day + 6 );
   }