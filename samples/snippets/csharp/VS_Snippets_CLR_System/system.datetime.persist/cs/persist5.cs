// <Snippet5>
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;

class Example
{
   private const string filename = @".\LeapYears.xml";
   
   public static void Main()
   {
      // Serialize the data.
      List<DateTime> leapYears = new List<DateTime>();
      for (int year = 2000; year <= 2100; year += 4) {
         if (DateTime.IsLeapYear(year)) 
            leapYears.Add(new DateTime(year, 2, 29));
      }
      DateTime[] dateArray = leapYears.ToArray();
      
      XmlSerializer serializer = new XmlSerializer(dateArray.GetType());
      TextWriter sw = new StreamWriter(filename);
      
      try {
         serializer.Serialize(sw, dateArray);
      }
      catch (InvalidOperationException e) {
         Console.WriteLine(e.InnerException.Message);         
      }
      finally {
         if (sw != null) sw.Close();
      }   

      // Deserialize the data.
      DateTime[] deserializedDates;
      using (FileStream fs = new FileStream(filename, FileMode.Open)) {
         deserializedDates = (DateTime[]) serializer.Deserialize(fs);
      } 
      
      // Display the dates.
      Console.WriteLine("Leap year days from 2000-2100 on an {0} system:",
                        Thread.CurrentThread.CurrentCulture.Name);
      int nItems = 0;
      foreach (var dat in deserializedDates) {
         Console.Write("   {0:d}     ", dat);
         nItems++;
         if (nItems % 5 == 0) 
               Console.WriteLine(); 
      }
   }
}
// The example displays the following output:
//    Leap year days from 2000-2100 on an en-GB system:
//       29/02/2000       29/02/2004       29/02/2008       29/02/2012       29/02/2016
//       29/02/2020       29/02/2024       29/02/2028       29/02/2032       29/02/2036
//       29/02/2040       29/02/2044       29/02/2048       29/02/2052       29/02/2056
//       29/02/2060       29/02/2064       29/02/2068       29/02/2072       29/02/2076
//       29/02/2080       29/02/2084       29/02/2088       29/02/2092       29/02/2096
// </Snippet5>
