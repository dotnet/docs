using System.Collections.ObjectModel;
using System.Security;

[assembly: CLSCompliant(true)]

public class TZExamples
{
    public static void Main()
    {
        // tze.IterateTimeZones();
        // tze.SelectTimeZone();
        ShowDaylightStatus();
        Console.WriteLine("\nShowLocalAndUtcTime:");
        TZExamples.ShowLocalAndUtcTime();
        TZExamples.ConvertToArbitraryTime();
        Console.WriteLine("**ConvertTimeToUtc***");
        TZExamples.ConvertToUtc();
        Console.WriteLine("ConvertEasternToUtc:");
        TZExamples.ConvertEasternToUtc();
        Console.WriteLine("\nConvertUtcToCentral:");
        ConvertUtcToCentral();
        Console.WriteLine("\nConvertHawaiianToLocal:");
        ConvertHawaiianToLocal();
        Console.WriteLine("Resolving ambiguous times:");
        Console.WriteLine(TZExamples.ResolveAmbiguousTime(new DateTime(2006, 10, 29, 02, 03, 15)));
        Console.WriteLine(TZExamples.ResolveAmbiguousTime(DateTime.Now));
        Console.WriteLine();

        TZExamples tze = new();
        tze.GetUserDateInput();
    }

    private static void IterateTimeZones()
    {
        // <Snippet1>
        ReadOnlyCollection<TimeZoneInfo> tzCollection;
        tzCollection = TimeZoneInfo.GetSystemTimeZones();
        // </Snippet1>

        Console.WriteLine($"Listing {tzCollection.Count} time zones found on the system:");
        // <Snippet12>
        foreach (TimeZoneInfo timeZone in tzCollection)
            Console.WriteLine($"   {timeZone.Id}: {timeZone.DisplayName}");
        // </Snippet12>
    }

    private static void SelectTimeZone()
    {
        TZListForm frm = new TZListForm();
        frm.ShowDialog();
    }

    private static void ShowDaylightStatus()
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

    private static void ShowLocalAndUtcTime()
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

    private static void ConvertToArbitraryTime()
    {
        // <Snippet5>
        DateTime timeNow = DateTime.Now;
        try
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTimeNow = TimeZoneInfo.ConvertTime(
                timeNow,
                TimeZoneInfo.Local,
                easternZone
                );
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

    private static void ConvertToUtc()
    {
        // <Snippet6>
        DateTime dateNow = DateTime.Now;
        Console.WriteLine($"The date and time are {TimeZoneInfo.ConvertTimeToUtc(dateNow)} UTC.");
        // </Snippet6>
    }

    private static void ConvertEasternToUtc()
    {
        // <Snippet7>
        DateTime easternTime = new DateTime(2007, 01, 02, 12, 16, 00);
        string easternZoneId = "Eastern Standard Time";
        try
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById(easternZoneId);
            Console.WriteLine($"The date and time are {TimeZoneInfo.ConvertTimeToUtc(easternTime, easternZone)} UTC.");
        }
        catch (TimeZoneNotFoundException)
        {
            Console.WriteLine($"Unable to find the {easternZoneId} zone in the registry.");
        }
        catch (InvalidTimeZoneException)
        {
            Console.WriteLine($"Registry data on the {easternZoneId} zone has been corrupted.");
        }
        // </Snippet7>
    }

    private static void ConvertUtcToCentral()
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

    private static void ConvertHawaiianToLocal()
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
    private static DateTime ResolveAmbiguousTime(DateTime ambiguousTime)
    {
        // Time is not ambiguous
        if (!TimeZoneInfo.Local.IsAmbiguousTime(ambiguousTime))
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
                Console.WriteLine($"{ctr}.) {offsets[ctr].Hours} hours, {offsets[ctr].Minutes} minutes");
            }
            Console.Write("> ");
            int selection = Convert.ToInt32(Console.ReadLine());

            // Convert local time to UTC, and set Kind property to DateTimeKind.Utc
            utcDate = DateTime.SpecifyKind(inputDate - offsets[selection], DateTimeKind.Utc);

            Console.WriteLine($"{inputDate} local time corresponds to {utcDate} {utcDate.Kind.ToString()}.");
        }
        else
        {
            utcDate = inputDate.ToUniversalTime();
            Console.WriteLine($"{inputDate} local time corresponds to {utcDate} {utcDate.Kind.ToString()}.");
        }
    }

    private static DateTime GetUserDateTime()
    {
        // Flag to exit loop if date is valid.
        bool exitFlag = false;
        string? dateString;
        DateTime inputDate = DateTime.MinValue;

        Console.Write("Enter a local date and time: ");
        while (!exitFlag)
        {
            dateString = Console.ReadLine();
            if (dateString?.ToUpper() == "E")
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
    private ListBox _timeZoneList;
    private Button _okButton;

    public TZListForm()
    {
        _timeZoneList = new ListBox();
        _okButton = new Button();
        SuspendLayout();
        //
        // timeZoneList
        //
        _timeZoneList.FormattingEnabled = true;
        _timeZoneList.Location = new Point(12, 12);
        _timeZoneList.Name = "timeZoneList";
        _timeZoneList.Size = new Size(250, 212);
        _timeZoneList.TabIndex = 0;
        //
        // OkButton
        //
        _okButton.Location = new Point(186, 231);
        _okButton.Name = "OkButton";
        _okButton.Size = new Size(75, 23);
        _okButton.TabIndex = 1;
        _okButton.Text = "&OK";
        _okButton.UseVisualStyleBackColor = true;
        _okButton.Click += new EventHandler(OkButton_Click);
        //
        // Form1
        //
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(292, 266);
        Controls.Add(_okButton);
        Controls.Add(_timeZoneList);
        Name = "Form1";
        Text = "Form1";
        Load += new EventHandler(Form1_Load);
        ResumeLayout(false);
    }

    // <Snippet2>
    private void Form1_Load(object sender, EventArgs e)
    {
        ReadOnlyCollection<TimeZoneInfo> tzCollection;
        tzCollection = TimeZoneInfo.GetSystemTimeZones();
        _timeZoneList.DataSource = tzCollection;
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        TimeZoneInfo? selectedTimeZone = (TimeZoneInfo?)_timeZoneList.SelectedItem;
        MessageBox.Show($"You selected the {selectedTimeZone?.ToString()} time zone.");
    }
    // </Snippet2>

    private static void ShowLocalAndUtc()
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
            Console.WriteLine("The {timeZoneName} zone cannot be found in the registry.");
        }
        catch (InvalidTimeZoneException)
        {
            Console.WriteLine("The registry contains invalid data for the {timeZoneName} zone.");
        }

        // The example produces the following output to the console:
        //    At 1/1/2007 12:00:00 AM (UTC-05:00) Eastern Time (US & Canada), the local time is 1/1/2007 12:00:00 AM Eastern Standard Time.
        //    At 1/1/2007 12:00:00 AM (UTC-05:00) Eastern Time (US & Canada), the time is 1/1/2007 5:00:00 AM UTC.

        // </Snippet13>
    }
}
