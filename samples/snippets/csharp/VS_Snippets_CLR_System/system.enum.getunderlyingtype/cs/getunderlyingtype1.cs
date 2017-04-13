// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      Enum[] enumValues = { ConsoleColor.Red, DayOfWeek.Monday, 
                            MidpointRounding.ToEven, PlatformID.Win32NT, 
                            DateTimeKind.Utc, StringComparison.Ordinal };
      Console.WriteLine("{0,-10} {1, 18}   {2,15}\n", 
                        "Member", "Enumeration", "Underlying Type");
      foreach (var enumValue in enumValues)
         DisplayEnumInfo(enumValue);
   }

   static void DisplayEnumInfo(Enum enumValue)
   {
      Type enumType = enumValue.GetType();
      Type underlyingType = Enum.GetUnderlyingType(enumType);
      Console.WriteLine("{0,-10} {1, 18}   {2,15}",
                        enumValue, enumType.Name, underlyingType.Name);   
   }
}
// The example displays the following output:
//       Member            Enumeration   Underlying Type
//       
//       Red              ConsoleColor             Int32
//       Monday              DayOfWeek             Int32
//       ToEven       MidpointRounding             Int32
//       Win32NT            PlatformID             Int32
//       Utc              DateTimeKind             Int32
//       Ordinal      StringComparison             Int32
// </Snippet1>