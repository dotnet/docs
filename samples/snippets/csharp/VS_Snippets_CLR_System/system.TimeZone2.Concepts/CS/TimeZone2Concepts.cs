// Note that this source code file includes a code module (modMain) and
// a WinForm. 

using System;
using System.Collections.ObjectModel;
using System.Security;
using System.Windows.Forms;

[assembly:CLSCompliant(true)]

public class TZExamples
{
   public static void Main()
   {
      TZExamples tze = new TZExamples();
//      tze.IterateTimeZones();
//      tze.SelectTimeZone();
        tze.ShowDaylightStatus();
        Console.WriteLine("\nShowLocalAndUtcTime:");
        tze.ShowLocalAndUtcTime();
        tze.ConvertToArbitraryTime();
        Console.WriteLine("**ConvertTimeToUtc***");
        tze.ConvertToUtc();
     Console.WriteLine("ConvertEasternToUtc:");
        tze.ConvertEasternToUtc();
        Console.WriteLine("\nConvertUtcToCentral:");
        tze.ConvertUtcToCentral();
      Console.WriteLine("\nConvertHawaiianToLocal:");
      tze.ConvertHawaiianToLocal();    
      Console.WriteLine("Resolving ambiguous times:");
      Console.WriteLine(tze.ResolveAmbiguousTime(new DateTime(2006, 10, 29, 02, 03, 15)));
      Console.WriteLine(tze.ResolveAmbiguousTime(DateTime.Now));
      Console.WriteLine();
      tze.GetUserDateInput();
   }

   private void IterateTimeZones()
   {
      // <Snippet1>
      ReadOnlyCollection<TimeZoneInfo> tzCollection;
      tzCollection = TimeZoneInfo.GetSystemTimeZones();
      // </Snippet1>
      
      Console.WriteLine("Listing {0} time zones found on the system:", tzCollection.Count);
      // <Snippet12>
      foreach (TimeZoneInfo timeZone in tzCollection)
         Console.WriteLine("   {0}: {1}", timeZone.Id, timeZone.DisplayName);
      // </Snippet12>   
   }

   private void SelectTimeZone()
   {
      TZListForm frm = new TZListForm();
      frm.ShowDialog();
   }

   private void ShowDaylightStatus()
   {
      // <Snippet3>
      DateTime dateToday = DateTime.Now;
      TimeSpan differenceFromUtc = TimeZoneInfo.Local.GetUtcOffset(dateToday);
      Console.WriteLine("The time is {0:t} in {1} time, {2:##.0} hours {3} universal time.", 
                        dateToday, 
                        TimeZoneInfo.Local.IsDaylightSavingTime(dateToday) ? "daylight saving" : "standard",
                        Math.Abs(differenceFromUtc.TotalHours),
                        differenceFromUtc.Hours > 0 ? "after" : "earlier than");
      // </Snippet3>
   }

   private void ShowLocalAndUtcTime()
   {
      // <Snippet4>
      DateTime timeNow = DateTime.Now;
      Console.WriteLine("It is now {0:t} {1}, or {2:t} {3}.",  
                        timeNow, 
                        TimeZoneInfo.Local.IsDaylightSavingTime(timeNow) ?
                            TimeZoneInfo.Local.DaylightName : TimeZoneInfo.Local.StandardName, 
                        TimeZoneInfo.ConvertTime(timeNow, TimeZoneInfo.Local, TimeZoneInfo.Utc), 
                        TimeZoneInfo.Utc.StandardName); 
      // </Snippet4>        
   }

   private void ConvertToArbitraryTime()
   {
      // <Snippet5>
      DateTime timeNow = DateTime.Now;
      try
      {
         TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
         DateTime easternTimeNow = TimeZoneInfo.ConvertTime(timeNow, TimeZoneInfo.Local, 
                                                         easternZone);
         Console.WriteLine("{0} {1} corresponds to {2} {3}.",
                           timeNow, 
                           TimeZoneInfo.Local.IsDaylightSavingTime(timeNow) ?
                                     TimeZoneInfo.Local.DaylightName : 
                                     TimeZoneInfo.Local.StandardName,
                           easternTimeNow, 
                           easternZone.IsDaylightSavingTime(easternTimeNow) ?
                                       easternZone.DaylightName : 
                                       easternZone.StandardName);
      }
      // Handle exception
      //
      // As an alternative to simply displaying an error message, an alternate Eastern
      // Standard Time TimeZoneInfo object could be instantiated here either by restoring
      // it from a serialized string or by providing the necessary data to the
      // CreateCustomTimeZone method.
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The Eastern Standard Time Zone cannot be found on the local system.");
      }  
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("The Eastern Standard Time Zone contains invalid or missing data.");
      }
      catch (SecurityException)
      {
         Console.WriteLine("The application lacks permission to read time zone information from the registry.");
      }
      catch (OutOfMemoryException)
      {
         Console.WriteLine("Not enough memory is available to load information on the Eastern Standard Time zone.");
      }
      // If we weren't passing FindSystemTimeZoneById a literal string, we also 
      // would handle an ArgumentNullException.
      // </Snippet5>
   }

   private void ConvertToUtc()
   {
      // <Snippet6>
      DateTime dateNow = DateTime.Now;
      Console.WriteLine("The date and time are {0} UTC.", 
                         TimeZoneInfo.ConvertTimeToUtc(dateNow));
      // </Snippet6>
   }

   private void ConvertEasternToUtc()
   {
      // <Snippet7>
      DateTime easternTime = new DateTime(2007, 01, 02, 12, 16, 00);
      string easternZoneId = "Eastern Standard Time";
      try
      {
         TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId);
         Console.WriteLine("The date and time are {0} UTC.", 
                           TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone));
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("Unable to find the {0} zone in the registry.", 
                           easternZoneId);
      }                           
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Registry data on the {0} zone has been corrupted.", 
                           easternZoneId);
      }
      // </Snippet7>
   }

   private void ConvertUtcToCentral()
   {
      // <Snippet8>
      DateTime timeUtc = DateTime.UtcNow;
      try
      {
         TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
         DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
         Console.WriteLine("The date and time are {0} {1}.", 
                           cstTime, 
                           cstZone.IsDaylightSavingTime(cstTime) ?
                                   cstZone.DaylightName : cstZone.StandardName);
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The registry does not define the Central Standard Time zone.");
      }                           
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Registry data on the Central Standard Time zone has been corrupted.");
      }
      // </Snippet8>
   }

   private void ConvertHawaiianToLocal()
   {
      // <Snippet9>
      DateTime hwTime = new DateTime(2007, 02, 01, 08, 00, 00);
      try
      {
         TimeZoneInfo hwZone = TimeZoneInfo.FindSystemTimeZoneById("Hawaiian Standard Time");
         Console.WriteLine("{0} {1} is {2} local time.", 
                 hwTime, 
                 hwZone.IsDaylightSavingTime(hwTime) ? hwZone.DaylightName : hwZone.StandardName, 
                 TimeZoneInfo.ConvertTime(hwTime, hwZone, TimeZoneInfo.Local));
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The registry does not define the Hawaiian Standard Time zone.");
      }                           
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("Registry data on the Hawaiian Standard Time zone has been corrupted.");
      }
      // </Snippet9>
   }

   // Map an ambiguous time to the time zone's standard time
   //  <Snippet10>
   private DateTime ResolveAmbiguousTime(DateTime ambiguousTime)
   {
      // Time is not ambiguous
      if (! TimeZoneInfo.Local.IsAmbiguousTime(ambiguousTime))
      { 
         return ambiguousTime; 
      }
      // Time is ambiguous
      else
      {
         DateTime utcTime = DateTime.SpecifyKind(ambiguousTime - TimeZoneInfo.Local.BaseUtcOffset, 
                                                 DateTimeKind.Utc);      
         Console.WriteLine("{0} local time corresponds to {1} {2}.", 
                           ambiguousTime, utcTime, utcTime.Kind.ToString());
         return utcTime;            
      }   
   }
   // </Snippet10>

   // Allow the user to resolve an ambiguous time   
   // <Snippet11>
   private void GetUserDateInput()
   {
      // Get date and time from user
      DateTime inputDate = GetUserDateTime();
      DateTime utcDate;
      
      // Exit if date has no significant value
      if (inputDate == DateTime.MinValue) return;
      
      if (TimeZoneInfo.Local.IsAmbiguousTime(inputDate))
      {
         Console.WriteLine("The date you've entered is ambiguous.");
         Console.WriteLine("Please select the correct offset from Universal Coordinated Time:");
         TimeSpan[] offsets = TimeZoneInfo.Local.GetAmbiguousTimeOffsets(inputDate);
         for (int ctr = 0; ctr < offsets.Length; ctr++)
         {
            Console.WriteLine("{0}.) {1} hours, {2} minutes", ctr, offsets[ctr].Hours, offsets[ctr].Minutes);
         }
         Console.Write("> ");
         int selection = Convert.ToInt32(Console.ReadLine());
         
         // Convert local time to UTC, and set Kind property to DateTimeKind.Utc
         utcDate = DateTime.SpecifyKind(inputDate - offsets[selection], DateTimeKind.Utc);

         Console.WriteLine("{0} local time corresponds to {1} {2}.", inputDate, utcDate, utcDate.Kind.ToString());
      }
      else
      {
         utcDate = inputDate.ToUniversalTime();
         Console.WriteLine("{0} local time corresponds to {1} {2}.", inputDate, utcDate, utcDate.Kind.ToString());    
      }
   }

   private DateTime GetUserDateTime() 
   {
      bool exitFlag = false;             // flag to exit loop if date is valid
      string dateString;  
      DateTime inputDate = DateTime.MinValue;
           
      Console.Write("Enter a local date and time: ");
      while (! exitFlag)
      {
         dateString = Console.ReadLine();
         if (dateString.ToUpper() == "E")
            exitFlag = true;
            
         if (DateTime.TryParse(dateString, out inputDate))
            exitFlag = true;
         else
            Console.Write("Enter a valid date and time, or enter 'e' to exit: ");
      }

      return inputDate;        
   }
   // </Snippet11>
}

public class TZListForm : Form
{
   private System.Windows.Forms.ListBox timeZoneList;
   private System.Windows.Forms.Button OkButton;
   
   public TZListForm()
   {
      this.timeZoneList = new System.Windows.Forms.ListBox();
      this.OkButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // timeZoneList
      // 
      this.timeZoneList.FormattingEnabled = true;
      this.timeZoneList.Location = new System.Drawing.Point(12, 12);
      this.timeZoneList.Name = "timeZoneList";
      this.timeZoneList.Size = new System.Drawing.Size(250, 212);
      this.timeZoneList.TabIndex = 0;
      // 
      // OkButton
      // 
      this.OkButton.Location = new System.Drawing.Point(186, 231);
      this.OkButton.Name = "OkButton";
      this.OkButton.Size = new System.Drawing.Size(75, 23);
      this.OkButton.TabIndex = 1;
      this.OkButton.Text = "&OK";
      this.OkButton.UseVisualStyleBackColor = true;
      this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.OkButton);
      this.Controls.Add(this.timeZoneList);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
   }

   // <Snippet2>
   private void Form1_Load(object sender, EventArgs e)
   {
      ReadOnlyCollection<TimeZoneInfo> tzCollection; 
      tzCollection = TimeZoneInfo.GetSystemTimeZones();
      this.timeZoneList.DataSource = tzCollection;
   }

   private void OkButton_Click(object sender, EventArgs e)
   {
      TimeZoneInfo selectedTimeZone = (TimeZoneInfo) this.timeZoneList.SelectedItem;
      MessageBox.Show("You selected the " + selectedTimeZone.ToString() + " time zone.");
   }
   // </Snippet2>

   private void ShowLocalAndUtc()
   {
      // <Snippet13>
      // Create Eastern Standard Time value and TimeZoneInfo object      
      DateTime estTime = new DateTime(2007, 1, 1, 00, 00, 00);
      string timeZoneName = "Eastern Standard Time";
      try
      {
         TimeZoneInfo est = TimeZoneInfo.FindSystemTimeZoneById(timeZoneName);
   
         // Convert EST to local time
         DateTime localTime = TimeZoneInfo.ConvertTime(estTime, est, TimeZoneInfo.Local);
         Console.WriteLine("At {0} {1}, the local time is {2} {3}.", 
                 estTime, 
                 est, 
                 localTime, 
                 TimeZoneInfo.Local.IsDaylightSavingTime(localTime) ?
                           TimeZoneInfo.Local.DaylightName : 
                           TimeZoneInfo.Local.StandardName);
   
         // Convert EST to UTC
         DateTime utcTime = TimeZoneInfo.ConvertTime(estTime, est, TimeZoneInfo.Utc);
         Console.WriteLine("At {0} {1}, the time is {2} {3}.", 
                 estTime, 
                 est, 
                 utcTime, 
                 TimeZoneInfo.Utc.StandardName);
      }
      catch (TimeZoneNotFoundException)
      {
         Console.WriteLine("The {0} zone cannot be found in the registry.", 
                           timeZoneName);
      }
      catch (InvalidTimeZoneException)
      {
         Console.WriteLine("The registry contains invalid data for the {0} zone.", 
                           timeZoneName);
      }
      // </Snippet13>
   }
}
