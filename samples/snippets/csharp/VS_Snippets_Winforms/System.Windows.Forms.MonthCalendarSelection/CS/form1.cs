using System.Windows.Forms;

public class Form1:
	System.Windows.Forms.Form

{
	public Form1() : base()
	{        
		InitializeComponent();
		ShowAWeeksVacationOneMonthFromToday();
	}

	internal System.Windows.Forms.MonthCalendar MonthCalendar1;

	private void InitializeComponent()
	{
		this.MonthCalendar1 = new System.Windows.Forms.MonthCalendar();
		this.SuspendLayout();
		this.MonthCalendar1.Location = new System.Drawing.Point(56, 32);
		this.MonthCalendar1.Name = "MonthCalendar1";
		this.MonthCalendar1.TabIndex = 0;
		this.ClientSize = new System.Drawing.Size(292, 266);
		this.Controls.Add(this.MonthCalendar1);
		this.Name = "Form1";
		this.Text = "Form1";
		this.ResumeLayout(false);
	}

	//<snippet1>
	// Computes a week one month from today.
	private void ShowAWeeksVacationOneMonthFromToday()
	{
		System.DateTime today = this.MonthCalendar1.TodayDate;
		int vacationMonth = today.Month + 1;
		int vacationYear = today.Year;

		if (today.Month == 12)
		{
			vacationMonth = 1;
			++vacationYear;
		}

		// Select the week using SelectionStart and SelectionEnd.
		this.MonthCalendar1.SelectionStart = 
			new System.DateTime(today.Year, vacationMonth, today.Day-1);
		this.MonthCalendar1.SelectionEnd = 
			new System.DateTime(today.Year, vacationMonth, today.Day+6);
	}
	//</snippet1>
	public static void Main()
	{
		Application.Run(new Form1());
	}
}



