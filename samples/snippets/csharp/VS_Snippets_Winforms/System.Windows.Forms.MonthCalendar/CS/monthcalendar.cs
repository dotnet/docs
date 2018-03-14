//<Snippet1>
using System;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : System.Windows.Forms.Form
{
    private System.Windows.Forms.MonthCalendar monthCalendar1;
    private System.Windows.Forms.TextBox textBox1;

    [STAThread]
    static void Main() 
    {
        Application.Run(new Form1());
    }

    public Form1()
    {
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.textBox1.Location = new System.Drawing.Point(48, 488);
        this.textBox1.Multiline = true;
        this.textBox1.ReadOnly = true;
        this.textBox1.Size = new System.Drawing.Size(824, 32);

        // Create the calendar.
        this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();

        // Set the calendar location.
        this.monthCalendar1.Location = new System.Drawing.Point(47, 16);

        // Change the color.
        this.monthCalendar1.BackColor = System.Drawing.SystemColors.Info;
        this.monthCalendar1.ForeColor = System.Drawing.Color.FromArgb(
                                 ((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(192)));
        this.monthCalendar1.TitleBackColor = System.Drawing.Color.Purple;
        this.monthCalendar1.TitleForeColor = System.Drawing.Color.Yellow;
        this.monthCalendar1.TrailingForeColor = System.Drawing.Color.FromArgb(
                                 ((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(0)));

        // Add dates to the AnnuallyBoldedDates array.
        this.monthCalendar1.AnnuallyBoldedDates = 
            new System.DateTime[] { new System.DateTime(2002, 4, 20, 0, 0, 0, 0),
                                    new System.DateTime(2002, 4, 28, 0, 0, 0, 0),
                                    new System.DateTime(2002, 5, 5, 0, 0, 0, 0),
                                    new System.DateTime(2002, 7, 4, 0, 0, 0, 0),
                                    new System.DateTime(2002, 12, 15, 0, 0, 0, 0),
                                    new System.DateTime(2002, 12, 18, 0, 0, 0, 0)};

        // Add dates to BoldedDates array.
        this.monthCalendar1.BoldedDates = new System.DateTime[] {new System.DateTime(2002, 9, 26, 0, 0, 0, 0)};

        // Add dates to MonthlyBoldedDates array.
        this.monthCalendar1.MonthlyBoldedDates = 
           new System.DateTime[] {new System.DateTime(2002, 1, 15, 0, 0, 0, 0),
                                  new System.DateTime(2002, 1, 30, 0, 0, 0, 0)};

        // Configure the calendar to display 3 rows by 4 columns of months.
        this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(4, 3);

        // Set week to begin on Monday.
        this.monthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Monday;

        // Set the maximum visible date on the calendar to 12/31/2010.
        this.monthCalendar1.MaxDate = new System.DateTime(2010, 12, 31, 0, 0, 0, 0);

        // Set the minimum visible date on calendar to 12/31/2010.
        this.monthCalendar1.MinDate = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);

        // Only allow 21 days to be selected at the same time.
        this.monthCalendar1.MaxSelectionCount = 21;

        // Set the calendar to move one month at a time when navigating using the arrows.
        this.monthCalendar1.ScrollChange = 1;

        // Do not show the "Today" banner.
        this.monthCalendar1.ShowToday = false;

        // Do not circle today's date.
        this.monthCalendar1.ShowTodayCircle = false;
            
        // Show the week numbers to the left of each week.
        this.monthCalendar1.ShowWeekNumbers = true;

        // Add event handlers for the DateSelected and DateChanged events
        this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
        this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);

        // Set up how the form should be displayed and add the controls to the form.
        this.ClientSize = new System.Drawing.Size(920, 566);
        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.textBox1, this.monthCalendar1});
        this.Text = "Month Calendar Example";
    }

    private void monthCalendar1_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
    {
        // Show the start and end dates in the text box.
        this.textBox1.Text = "Date Selected: Start = " +
            e.Start.ToShortDateString() + " : End = " + e.End.ToShortDateString();
    }

    private void monthCalendar1_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
    {
        // Show the start and end dates in the text box.
        this.textBox1.Text = "Date Changed: Start =  " +
            e.Start.ToShortDateString() + " : End = " + e.End.ToShortDateString();
    }
}
//</Snippet1>