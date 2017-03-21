private void button1_Click(object sender, System.EventArgs e)
{
   // Create a SelectionRange object and set its Start and End properties.
   SelectionRange sr = new SelectionRange();
   sr.Start = DateTime.Parse(this.textBox1.Text);
   sr.End = DateTime.Parse(this.textBox2.Text);
   /* Assign the SelectionRange object to the 
      SelectionRange property of the MonthCalendar control. */
   this.monthCalendar1.SelectionRange = sr;
}

private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
{
   /* Display the Start and End property values of 
      the SelectionRange object in the text boxes. */
   this.textBox1.Text = 
     monthCalendar1.SelectionRange.Start.Date.ToShortDateString();
   this.textBox2.Text = 
     monthCalendar1.SelectionRange.End.Date.ToShortDateString();
}