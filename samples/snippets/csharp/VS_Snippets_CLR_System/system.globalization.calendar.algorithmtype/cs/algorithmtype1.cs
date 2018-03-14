// <Snippet1>
using System;
using System.Collections;
using System.Globalization;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      Assembly assem = Assembly.GetAssembly(typeof(Calendar));
      Type[] types = assem.GetExportedTypes();
      Type[] calendars = Array.FindAll(types, IsValidCalendar);
      Array.Sort(calendars, new CalendarComparer());

      Console.WriteLine("{0,-30} {1}\n", "Calendar", "Algorithm Type");
      foreach (var cal in calendars) {
         // Instantiate a calendar object.
         ConstructorInfo ctor = cal.GetConstructor( new Type[] {} );
         Calendar calObj = (Calendar) ctor.Invoke( new Type[] {} ); 

         Console.WriteLine("{0,-30} {1}", 
                          cal.ToString().Replace("System.Globalization.", ""),
                          cal.InvokeMember("AlgorithmType", 
                                           BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty,
                                           null, calObj, null));
      }
   }

   private static bool IsValidCalendar(Type t)
   {
        if (t.IsSubclassOf(typeof(Calendar)))
            if (t.IsAbstract)
                return false;
            else
                return true;
        else
            return false;
   }
}

public class CalendarComparer : IComparer
{
   public int Compare(object x, object y)
   {
      Type tX = (Type) x;
      Type tY = (Type) y;

      return tX.Name.CompareTo(tY.Name);
   }
}
// The example displays the following output:
//       Calendar                       Algorithm Type
//       
//       ChineseLunisolarCalendar       LunisolarCalendar
//       GregorianCalendar              SolarCalendar
//       HebrewCalendar                 LunisolarCalendar
//       HijriCalendar                  LunarCalendar
//       JapaneseCalendar               SolarCalendar
//       JapaneseLunisolarCalendar      LunisolarCalendar
//       JulianCalendar                 SolarCalendar
//       KoreanCalendar                 SolarCalendar
//       KoreanLunisolarCalendar        LunisolarCalendar
//       PersianCalendar                SolarCalendar
//       TaiwanCalendar                 SolarCalendar
//       TaiwanLunisolarCalendar        LunisolarCalendar
//       ThaiBuddhistCalendar           SolarCalendar
//       UmAlQuraCalendar               LunarCalendar
// </Snippet1>
