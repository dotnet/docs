using System;

public enum ArrivalStatus { Unknown=-3, Late=-1, OnTime=0, Early=1 };

public class Example
{
   public static void Main()
   {
      // <Snippet9>
      string number = "-1";
      string name = "Early";
      
      try {
         ArrivalStatus status1 = (ArrivalStatus) Enum.Parse(typeof(ArrivalStatus), number);
         if (!(Enum.IsDefined(typeof(ArrivalStatus), status1)))
            status1 = ArrivalStatus.Unknown;
         Console.WriteLine("Converted '{0}' to {1}", number, status1);
      }
      catch (FormatException) {
         Console.WriteLine("Unable to convert '{0}' to an ArrivalStatus value.", 
                           number);
      }   
         
      ArrivalStatus status2;
      if (Enum.TryParse<ArrivalStatus>(name, out status2)) {
         if (!(Enum.IsDefined(typeof(ArrivalStatus), status2)))
            status2 = ArrivalStatus.Unknown;
         Console.WriteLine("Converted '{0}' to {1}", name, status2);
      }
      else {
         Console.WriteLine("Unable to convert '{0}' to an ArrivalStatus value.", 
                           number);
      }
      // The example displays the following output:
      //       Converted '-1' to Late
      //       Converted 'Early' to Early
      // </Snippet9>      
   }
}
