using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      // <Snippet16>
      // Round-trip DateTime values.
      DateTime originalDate, newDate;
      string dateString;
      // Round-trip a local time.
      originalDate = DateTime.SpecifyKind(new DateTime(2008, 4, 10, 6, 30, 0), DateTimeKind.Local);
      dateString = originalDate.ToString("o");
      newDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
      Console.WriteLine($"Round-tripped {originalDate} {originalDate.Kind} to {newDate} {newDate.Kind}.");
      // Round-trip a UTC time.
      originalDate = DateTime.SpecifyKind(new DateTime(2008, 4, 12, 9, 30, 0), DateTimeKind.Utc);
      dateString = originalDate.ToString("o");
      newDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
      Console.WriteLine($"Round-tripped {originalDate} {originalDate.Kind} to {newDate} {newDate.Kind}.");
      // Round-trip time in an unspecified time zone.
      originalDate = DateTime.SpecifyKind(new DateTime(2008, 4, 13, 12, 30, 0), DateTimeKind.Unspecified);
      dateString = originalDate.ToString("o");
      newDate = DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
      Console.WriteLine($"Round-tripped {originalDate} {originalDate.Kind} to {newDate} {newDate.Kind}.");

      // Round-trip a DateTimeOffset value.
      DateTimeOffset originalDTO = new DateTimeOffset(2008, 4, 12, 9, 30, 0, new TimeSpan(-8, 0, 0));
      dateString = originalDTO.ToString("o");
      DateTimeOffset newDTO = DateTimeOffset.Parse(dateString, null, DateTimeStyles.RoundtripKind);
      Console.WriteLine($"Round-tripped {originalDTO} to {newDTO}.");
      // The example displays the following output:
      //    Round-tripped 4/10/2008 6:30:00 AM Local to 4/10/2008 6:30:00 AM Local.
      //    Round-tripped 4/12/2008 9:30:00 AM Utc to 4/12/2008 9:30:00 AM Utc.
      //    Round-tripped 4/13/2008 12:30:00 PM Unspecified to 4/13/2008 12:30:00 PM Unspecified.
      //    Round-tripped 4/12/2008 9:30:00 AM -08:00 to 4/12/2008 9:30:00 AM -08:00.
      // </Snippet16>
   }
}
