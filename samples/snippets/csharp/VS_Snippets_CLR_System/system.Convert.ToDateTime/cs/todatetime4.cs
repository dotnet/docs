// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      string[] cultureNames = { "en-US", "hu-HU", "pt-PT" };
      object[] objects = { 12, 17.2, false, new DateTime(2010, 1, 1), "today", 
                           new System.Collections.ArrayList(), 'c', 
                           "05/10/2009 6:13:18 PM", "September 8, 1899" };
      
      foreach (string cultureName in cultureNames)
      {
         Console.WriteLine("{0} culture:", cultureName);
         CustomProvider provider = new CustomProvider(cultureName);
         foreach (object obj in objects)
         {            
            try {
               DateTime dateValue = Convert.ToDateTime(obj, provider);      
               Console.WriteLine("{0} --> {1}", obj, 
                                 dateValue.ToString(new CultureInfo(cultureName)));
            }
            catch (FormatException) {
               Console.WriteLine("{0} --> Bad Format", obj);
            }   
            catch (InvalidCastException) {
               Console.WriteLine("{0} --> Conversion Not Supported", obj);
            }
         }
         Console.WriteLine();
      }
   }
}

public class CustomProvider : IFormatProvider
{
   private string cultureName;
   
   public CustomProvider(string cultureName)
   {
      this.cultureName = cultureName;
   }
   
   public object GetFormat(Type formatType)
   {
      if (formatType == typeof(DateTimeFormatInfo))
      {
         Console.Write("(CustomProvider retrieved.) ");
         return new CultureInfo(cultureName).GetFormat(formatType);
      }
      else
      {
         return null;
      }   
   }
}
// The example displays the following output:
//    en-US culture:
//    12 --> Conversion Not Supported
//    17.2 --> Conversion Not Supported
//    False --> Conversion Not Supported
//    1/1/2010 12:00:00 AM --> 1/1/2010 12:00:00 AM
//    (CustomProvider retrieved.) today --> Bad Format
//    System.Collections.ArrayList --> Conversion Not Supported
//    c --> Conversion Not Supported
//    (CustomProvider retrieved.) 05/10/2009 6:13:18 PM --> 5/10/2009 6:13:18 PM
//    (CustomProvider retrieved.) September 8, 1899 --> 9/8/1899 12:00:00 AM
//    
//    hu-HU culture:
//    12 --> Conversion Not Supported
//    17.2 --> Conversion Not Supported
//    False --> Conversion Not Supported
//    1/1/2010 12:00:00 AM --> 2010. 01. 01. 0:00:00
//    (CustomProvider retrieved.) today --> Bad Format
//    System.Collections.ArrayList --> Conversion Not Supported
//    c --> Conversion Not Supported
//    (CustomProvider retrieved.) 05/10/2009 6:13:18 PM --> 2009. 05. 10. 18:13:18
//    (CustomProvider retrieved.) September 8, 1899 --> 1899. 09. 08. 0:00:00
//    
//    pt-PT culture:
//    12 --> Conversion Not Supported
//    17.2 --> Conversion Not Supported
//    False --> Conversion Not Supported
//    1/1/2010 12:00:00 AM --> 01-01-2010 0:00:00
//    (CustomProvider retrieved.) today --> Bad Format
//    System.Collections.ArrayList --> Conversion Not Supported
//    c --> Conversion Not Supported
//    (CustomProvider retrieved.) 05/10/2009 6:13:18 PM --> 05-10-2009 18:13:18
//    (CustomProvider retrieved.) September 8, 1899 --> 08-09-1899 0:00:00
// </Snippet4>
