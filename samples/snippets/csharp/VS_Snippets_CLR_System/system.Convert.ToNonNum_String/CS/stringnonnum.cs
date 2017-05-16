//<Snippet2>
using System;
using System.Globalization;

public class DummyProvider : IFormatProvider
{
    // Normally, GetFormat returns an object of the requested type
    // (usually itself) if it is able; otherwise, it returns Nothing. 
    public object GetFormat(Type argType)
    {
        // Here, GetFormat displays the name of argType, after removing 
        // the namespace information. GetFormat always returns null.
        string argStr = argType.ToString( );
        if( argStr == "" ) 
            argStr = "Empty";
        argStr = argStr.Substring( argStr.LastIndexOf( '.' ) + 1 );

        Console.Write( "{0,-20}", argStr );
        return null;
    }
}

class ConvertNonNumericProviderDemo
{
    public static void Main( )
    {
        // Create an instance of IFormatProvider.
        DummyProvider provider = new DummyProvider( );
        string format   = "{0,-17}{1,-17}{2}";

        // Convert these values using DummyProvider.
        string Int32A   = "-252645135";
        string DoubleA  = "61680.3855";
        string DayTimeA = "2001/9/11 13:45";

        string BoolA    = "True";
        string StringA  = "Qwerty";
        string CharA    = "$";

        Console.WriteLine( "This example of selected " +
            "Convert.To<Type>( String, IFormatProvider ) \nmethods " +
            "generates the following output. The example displays " +
            "the \nprovider type if the IFormatProvider is called." );
        Console.WriteLine( "\nNote: For the " +
            "ToBoolean, ToString, and ToChar methods, the \n" +
            "IFormatProvider object is not referenced." );

        // The format provider is called for the following conversions.
        Console.WriteLine( );
        Console.WriteLine( format, "ToInt32", Int32A, 
            Convert.ToInt32( Int32A, provider ) );
        Console.WriteLine( format, "ToDouble", DoubleA, 
            Convert.ToDouble( DoubleA, provider ) );
        Console.WriteLine( format, "ToDateTime", DayTimeA, 
            Convert.ToDateTime( DayTimeA, provider ) );

        // The format provider is not called for these conversions.
        Console.WriteLine( );
        Console.WriteLine( format, "ToBoolean", BoolA, 
            Convert.ToBoolean( BoolA, provider ) );
        Console.WriteLine( format, "ToString", StringA, 
            Convert.ToString( StringA, provider ) );
        Console.WriteLine( format, "ToChar", CharA, 
            Convert.ToChar( CharA, provider ) );
    }
}

/*
This example of selected Convert.To<Type>( String, IFormatProvider )
methods generates the following output. The example displays the
provider type if the IFormatProvider is called.

Note: For the ToBoolean, ToString, and ToChar methods, the
IFormatProvider object is not referenced.

NumberFormatInfo    ToInt32          -252645135       -252645135
NumberFormatInfo    ToDouble         61680.3855       61680.3855
DateTimeFormatInfo  ToDateTime       2001/9/11 13:45  9/11/2001 1:45:00 PM

ToBoolean        True             True
ToString         Qwerty           Qwerty
ToChar           $                $
*/ 
//</Snippet2>
