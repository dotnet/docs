// <Snippet25>
using System;
using System.Globalization;

public class DummyProvider : IFormatProvider
{
    // Normally, GetFormat returns an object of the requested type
    // (usually itself) if it is able; otherwise, it returns Nothing. 
    public object GetFormat(Type argType)
    {
        // Display the type of argType and return null.
        Console.Write( "{0,-25}", argType.Name);
        return null;
    } 
}

public class Example
{
   public static void Main()
   {
      // Create an instance of the IFormatProvider.
      IFormatProvider provider = new DummyProvider();

      // Values to convert using DummyProvider.
      int int32A = -252645135;   
      double doubleA = 61680.3855;
      object objDouble = (object) -98765.4321;
      DateTime dayTimeA = new DateTime(2009, 9, 11, 13, 45, 0);
      bool boolA = true;
      string stringA = "Qwerty";
      char charA = '$';
      TimeSpan tSpanA = new TimeSpan(0, 18, 0);
      object objOther = provider;

      object[] objects= { int32A, doubleA, objDouble, dayTimeA, 
                          boolA, stringA, charA, tSpanA, objOther };
        
      // Call Convert.ToString(Object, provider) method for each value.
      foreach (object value in objects) 
         Console.WriteLine("{0,-20}  -->  {1,20}", 
                           value, Convert.ToString(value, provider));    
   }
}
// The example displays the following output:
//    NumberFormatInfo         -252645135            -->            -252645135
//    NumberFormatInfo         61680.3855            -->            61680.3855
//    NumberFormatInfo         -98765.4321           -->           -98765.4321
//    DateTimeFormatInfo       9/11/2009 1:45:00 PM  -->  9/11/2009 1:45:00 PM
//    True                  -->                  True
//    Qwerty                -->                Qwerty
//    $                     -->                     $
//    00:18:00              -->              00:18:00
//    DummyProvider         -->         DummyProvider
// </Snippet25>
