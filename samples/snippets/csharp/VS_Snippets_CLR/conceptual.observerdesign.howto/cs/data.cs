// <Snippet1>
using System;

public struct Temperature
{
   private decimal temp;
   private DateTime tempDate;

   public Temperature(decimal temperature, DateTime dateAndTime)
   {
      this.temp = temperature;
      this.tempDate = dateAndTime;
   }

   public decimal Degrees
   { get { return this.temp; } }

   public DateTime Date
   { get { return this.tempDate; } }
}
// </Snippet1>
