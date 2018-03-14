// <Snippet4>
using System;

[Serializable] public struct DateTimeTZI
{
  DateTime Date;
  TimeZoneInfo TimeZone;
   
  public DateTimeTZI(DateTime date, TimeZoneInfo tz)
  {
     this.Date = date;
     this.TimeZone = tz;
  }

   public override string ToString()
   {
     return String.Format("{0:dd/MM/yyyy hh:mm:ss tt} {1}", 
                          Date, TimeZone.StandardName);
   }
}
// </Snippet4>
