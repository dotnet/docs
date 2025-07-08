// <Snippet3>
using System;
using System.Globalization;

public class InterfaceEx
{
    public static void Main()
    {
        var culture = CultureInfo.InvariantCulture;
        IFormatProvider provider = culture;

        DateTimeFormatInfo dt = (DateTimeFormatInfo)provider;
    }
}
// The example displays the following output:
//    Unhandled Exception: System.InvalidCastException:
//       Unable to cast object of type //System.Globalization.CultureInfo// to
//           type //System.Globalization.DateTimeFormatInfo//.
//       at Example.Main()
// </Snippet3>
