# How to: Let Users Resolve Ambiguous Times

An ambiguous time is a time that maps to more than one Coordinated Universal Time (UTC). It occurs when the clock time is adjusted back in time, such as during the transition from a time zone's daylight saving time to its standard time. When handling an ambiguous time, you can do one of the following:

* If the ambiguous time is an item of data entered by the user, you can leave it to the user to resolve the ambiguity.

* Make an assumption about how the time maps to UTC. For example, you can assume that an ambiguous time is always expressed in the time zone's standard time.

This article shows how to let a user resolve an ambiguous time.

## To let a user resolve an ambiguous time

1. Get the date and time input by the user.

2. Call the [IsAmbiguousTime(DateTime)](http://dotnet.github.io/api/System.TimeZoneInfo.html#System_TimeZoneInfo_IsAmbiguousTime_System_DateTime_) or [IsAmbiguousTime(DateTimeOffset)](http://dotnet.github.io/api/System.TimeZoneInfo.html#System_TimeZoneInfo_IsAmbiguousTime_System_DateTimeOffset_) method to determine whether the time is ambiguous.

3. Let the user select the desired offset.

4. Get the UTC date and time by subtracting the offset selected by the user from the local time.

5. Call the static `SpecifyKind` method to set the UTC date and time value's `Kind` property to `DateTimeKind.Utc`.

## Example

The following example prompts the user to enter a date and time and, if it is ambiguous, lets the user select the UTC time that the ambiguous time maps to. The example uses a `DateTime` object; you can substitute a `DateTimeOffset` object if desired.

```csharp
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
```

The core of the example code uses an array of `TimeSpan` objects to indicate possible offsets of the ambiguous time from UTC. However, these offsets are unlikely to be meaningful to the user. To clarify the meaning of the offsets, the code also notes whether an offset represents the local time zone's standard time or its daylight saving time. The code determines which time is standard and which time is daylight by comparing the offset with the value of the `BaseUtcOffset` property. This property indicates the difference between the UTC and the time zone's standard time.

## See Also

[Dates, Times, and Time Zones](essentials\datetime\DatesTimesTimezones.md)

[How to: Resolve Ambiguous Times](essentials\datetime\ResolveAmbiguousTimes.md)

