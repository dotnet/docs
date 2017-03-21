    protected void Command1_Click(object sender, EventArgs e)
    {
        int currentDay = Calendar1.VisibleDate.Day;
        int currentMonth = Calendar1.VisibleDate.Month;
        int currentYear = Calendar1.VisibleDate.Year;
        Calendar1.SelectedDates.Clear();

        // Add all Wednesdays to the collection.
        for (int i = 1; i <= System.DateTime.DaysInMonth(currentYear,
               currentMonth); i++)
        {
            DateTime targetDate = new DateTime(currentYear, currentMonth, i);
            if (targetDate.DayOfWeek == DayOfWeek.Wednesday)
                Calendar1.SelectedDates.Add(targetDate);
        }
        TextView1.Text = "Selection Count ="
           + Calendar1.SelectedDates.Count.ToString();
    }