//<Snippet1>
using System;
using System.Collections;

// Define the types of averaging available in the class 
// implementing IConvertible.
public enum AverageType : short
{
    None = 0,
    GeometricMean = 1,
    ArithmeticMean = 2,
    Median = 3
};

// Pass an instance of this class to methods that require an 
// IFormatProvider. The class instance determines the type of 
// average to calculate.
public class AverageInfo : IFormatProvider
{
    protected AverageType AvgType;

    // Specify the type of averaging in the constructor.
    public AverageInfo( AverageType avgType )
    {
        this.AvgType = avgType;
    }

    // This method returns a reference to the containing object 
    // if an object of AverageInfo type is requested. 
    public object GetFormat( Type argType )
    {
        if ( argType == typeof( AverageInfo ) )
            return this;
        else
            return null;
    }

    // Use this property to set or get the type of averaging.
    public AverageType TypeOfAverage        
    {
        get { return this.AvgType; }
        set { this.AvgType = value; }
    }
}

// This class encapsulates an array of double values and implements 
// the IConvertible interface. Most of the IConvertible methods 
// return an average of the array elements in one of three types: 
// arithmetic mean, geometric mean, or median. 
public class DataSet : IConvertible
{
    protected ArrayList     data;
    protected AverageInfo   defaultProvider;
        
    // Construct the object and add an initial list of values.
    // Create a default format provider.
    public DataSet( params double[ ] values )
    {
        data = new ArrayList( values );
        defaultProvider = 
            new AverageInfo( AverageType.ArithmeticMean );
    }
        
    // Add additional values with this method.
    public int Add( double value )
    {
        data.Add( value );
        return data.Count;
    }
        
    // Get, set, and add values with this indexer property.
    public double this[ int index ]        
    {
        get
        {
            if( index >= 0 && index < data.Count )
                return (double)data[ index ];
            else
                throw new InvalidOperationException(
                    "[DataSet.get] Index out of range." );
        }
        set
        {
            if( index >= 0 && index < data.Count )
                data[ index ] = value;

            else if( index == data.Count )
                data.Add( value );
            else
                throw new InvalidOperationException(
                    "[DataSet.set] Index out of range." );
        }
    }
        
    // This property returns the number of elements in the object.
    public int Count        
    {
        get { return data.Count; }
    }

    // This method calculates the average of the object's elements.
    protected double Average( AverageType avgType )
    {
        double  SumProd;

        if( data.Count == 0 ) 
            return 0.0;

        switch( avgType )
        {
            case AverageType.GeometricMean:

                SumProd = 1.0;
                for( int Index = 0; Index < data.Count; Index++ )
                    SumProd *= (double)data[ Index ];
                
                // This calculation will not fail with negative 
                // elements.
                return Math.Sign( SumProd ) * Math.Pow( 
                    Math.Abs( SumProd ), 1.0 / data.Count );

            case AverageType.ArithmeticMean:

                SumProd = 0.0;
                for( int Index = 0; Index < data.Count; Index++ )
                    SumProd += (double)data[ Index ];

                return SumProd / data.Count;

            case AverageType.Median:

                if( data.Count % 2 == 0 )
                    return ( (double)data[ data.Count / 2 ] + 
                        (double)data[ data.Count / 2 - 1 ] ) / 2.0;
                else
                    return (double)data[ data.Count / 2 ];

            default:
                return 0.0;
        }
    }

    // Get the AverageInfo object from the caller's format provider,
    // or use the local default.
    protected AverageInfo GetAverageInfo( IFormatProvider provider )
    {
        AverageInfo avgInfo = null;

        if( provider != null )
            avgInfo = (AverageInfo)provider.GetFormat( 
                typeof( AverageInfo ) );

        if ( avgInfo == null )
            return defaultProvider;
        else
            return avgInfo;
    }

    // Calculate the average and limit the range.
    protected double CalcNLimitAverage( double min, double max, 
        IFormatProvider provider )
    {
        // Get the format provider and calculate the average.
        AverageInfo avgInfo = GetAverageInfo( provider );
        double avg = Average( avgInfo.TypeOfAverage );

        // Limit the range, based on the minimum and maximum values 
        // for the type.
        return avg > max ? max : avg < min ? min : avg;

    }

    // The following elements are required by IConvertible.

    // None of these conversion functions throw exceptions. When
    // the data is out of range for the type, the appropriate
    // MinValue or MaxValue is used.
    public TypeCode GetTypeCode( )
    {
        return TypeCode.Object;
    }

    public bool ToBoolean( IFormatProvider provider )
    {
        // ToBoolean is false if the dataset is empty.
        if( data.Count <= 0 )
            return false;

        // For median averaging, ToBoolean is true if any 
        // non-discarded elements are nonzero.
        else if( AverageType.Median == 
            GetAverageInfo( provider ).TypeOfAverage )
        {
            if (data.Count % 2 == 0 )
                return ( (double)data[ data.Count / 2 ] != 0.0 || 
                    (double)data[ data.Count / 2 - 1 ] != 0.0 );
            else
                return (double)data[ data.Count / 2 ] != 0.0;
        }

        // For arithmetic or geometric mean averaging, ToBoolean is 
        // true if any element of the dataset is nonzero.  
        else
        {
            for( int Index = 0; Index < data.Count; Index++ )
                if( (double)data[ Index ] != 0.0 ) 
                    return true;
            return false;
        }
    }

    public byte ToByte( IFormatProvider provider )
    {
        return Convert.ToByte( CalcNLimitAverage( 
            Byte.MinValue, Byte.MaxValue, provider ) );
    }

    public char ToChar( IFormatProvider provider )
    {
        return Convert.ToChar( Convert.ToUInt16( CalcNLimitAverage( 
            Char.MinValue, Char.MaxValue, provider ) ) );
    }

    // Convert to DateTime by adding the calculated average as 
    // seconds to the current date and time. A valid DateTime is 
    // always returned.
    public DateTime ToDateTime( IFormatProvider provider )
    {
        double seconds = 
            Average( GetAverageInfo( provider ).TypeOfAverage );
        try
        {
            return DateTime.Now.AddSeconds( seconds );
        }
        catch( ArgumentOutOfRangeException )
        {
            return seconds < 0.0 ? DateTime.MinValue : DateTime.MaxValue;
        }
    }

    public decimal ToDecimal( IFormatProvider provider )
    {
        // The Double conversion rounds Decimal.MinValue and 
        // Decimal.MaxValue to invalid Decimal values, so the 
        // following limits must be used.
        return Convert.ToDecimal( CalcNLimitAverage( 
            -79228162514264330000000000000.0, 
            79228162514264330000000000000.0, provider ) );
    }

    public double ToDouble( IFormatProvider provider )
    {
        return Average( GetAverageInfo(provider).TypeOfAverage );
    }

    public short ToInt16( IFormatProvider provider )
    {
        return Convert.ToInt16( CalcNLimitAverage( 
            Int16.MinValue, Int16.MaxValue, provider ) );
    }

    public int ToInt32( IFormatProvider provider )
    {
        return Convert.ToInt32( CalcNLimitAverage( 
            Int32.MinValue, Int32.MaxValue, provider ) );
    }

    public long ToInt64( IFormatProvider provider )
    {
        // The Double conversion rounds Int64.MinValue and 
        // Int64.MaxValue to invalid Int64 values, so the following 
        // limits must be used.
        return Convert.ToInt64( CalcNLimitAverage( 
            -9223372036854775000, 9223372036854775000, provider ) );
    }

    public SByte ToSByte( IFormatProvider provider )
    {
        return Convert.ToSByte( CalcNLimitAverage( 
            SByte.MinValue, SByte.MaxValue, provider ) );
    }

    public float ToSingle( IFormatProvider provider )
    {
        return Convert.ToSingle( CalcNLimitAverage( 
            Single.MinValue, Single.MaxValue, provider ) );
    }

    public UInt16 ToUInt16( IFormatProvider provider )
    {
        return Convert.ToUInt16( CalcNLimitAverage( 
            UInt16.MinValue, UInt16.MaxValue, provider ) );
    }

    public UInt32 ToUInt32( IFormatProvider provider )
    {
        return Convert.ToUInt32( CalcNLimitAverage( 
            UInt32.MinValue, UInt32.MaxValue, provider ) );
    }

    public UInt64 ToUInt64( IFormatProvider provider )
    {
        // The Double conversion rounds UInt64.MaxValue to an invalid
        // UInt64 value, so the following limit must be used.
        return Convert.ToUInt64( CalcNLimitAverage( 
            0, 18446744073709550000.0, provider ) );
    }

    public object ToType( Type conversionType, 
        IFormatProvider provider )
    {
        return Convert.ChangeType( Average( 
            GetAverageInfo( provider ).TypeOfAverage ), 
            conversionType );
    }

    public string ToString( IFormatProvider provider )
    {
        AverageType avgType = GetAverageInfo( provider ).TypeOfAverage;
        return String.Format( "( {0}: {1:G10} )", avgType, 
            Average( avgType ) );
    }
}
   
class IConvertibleProviderDemo
{
    // Display a DataSet with three different format providers.
    public static void DisplayDataSet( DataSet ds )
    {
        string      fmt    = "{0,-12}{1,20}{2,20}{3,20}";
        AverageInfo median = new AverageInfo( AverageType.Median );
        AverageInfo geMean = 
            new AverageInfo( AverageType.GeometricMean );

         // Display the dataset elements.
        if( ds.Count > 0 )
        {
            Console.Write( "\nDataSet: [{0}", ds[ 0 ] );
            for( int iX = 1; iX < ds.Count; iX++ )
                Console.Write( ", {0}", ds[ iX ] );
            Console.WriteLine( "]\n" );
        }

        Console.WriteLine( fmt, "Convert.", "Default", 
            "Geometric Mean", "Median");
        Console.WriteLine( fmt, "--------", "-------", 
            "--------------", "------");
        Console.WriteLine( fmt, "ToBoolean", 
            Convert.ToBoolean( ds, null ), 
            Convert.ToBoolean( ds, geMean ), 
            Convert.ToBoolean( ds, median ) );
        Console.WriteLine( fmt, "ToByte", 
            Convert.ToByte( ds, null ), 
            Convert.ToByte( ds, geMean ), 
            Convert.ToByte( ds, median ) );
        Console.WriteLine( fmt, "ToChar", 
            Convert.ToChar( ds, null ), 
            Convert.ToChar( ds, geMean ), 
            Convert.ToChar( ds, median ) );
        Console.WriteLine( "{0,-12}{1,20:yyyy-MM-dd HH:mm:ss}" +
            "{2,20:yyyy-MM-dd HH:mm:ss}{3,20:yyyy-MM-dd HH:mm:ss}", 
            "ToDateTime", Convert.ToDateTime( ds, null ), 
            Convert.ToDateTime( ds, geMean ), 
            Convert.ToDateTime( ds, median ) );
        Console.WriteLine( fmt, "ToDecimal", 
            Convert.ToDecimal( ds, null ), 
            Convert.ToDecimal( ds, geMean ), 
            Convert.ToDecimal( ds, median ) );
        Console.WriteLine( fmt, "ToDouble", 
            Convert.ToDouble( ds, null ), 
            Convert.ToDouble( ds, geMean ), 
            Convert.ToDouble( ds, median ) );
        Console.WriteLine( fmt, "ToInt16", 
            Convert.ToInt16( ds, null ), 
            Convert.ToInt16( ds, geMean ), 
            Convert.ToInt16( ds, median ) );
        Console.WriteLine( fmt, "ToInt32", 
            Convert.ToInt32( ds, null ), 
            Convert.ToInt32( ds, geMean ), 
            Convert.ToInt32( ds, median ) );
        Console.WriteLine( fmt, "ToInt64", 
            Convert.ToInt64( ds, null ), 
            Convert.ToInt64( ds, geMean ), 
            Convert.ToInt64( ds, median ) );
        Console.WriteLine( fmt, "ToSByte", 
            Convert.ToSByte( ds, null ), 
            Convert.ToSByte( ds, geMean ), 
            Convert.ToSByte( ds, median ) );
        Console.WriteLine( fmt, "ToSingle", 
            Convert.ToSingle( ds, null ), 
            Convert.ToSingle( ds, geMean ), 
            Convert.ToSingle( ds, median ) );
        Console.WriteLine( fmt, "ToUInt16", 
            Convert.ToUInt16( ds, null ), 
            Convert.ToUInt16( ds, geMean ), 
            Convert.ToUInt16( ds, median ) );
        Console.WriteLine( fmt, "ToUInt32", 
            Convert.ToUInt32( ds, null ), 
            Convert.ToUInt32( ds, geMean ), 
            Convert.ToUInt32( ds, median ) );
        Console.WriteLine( fmt, "ToUInt64", 
            Convert.ToUInt64( ds, null ), 
            Convert.ToUInt64( ds, geMean ), 
            Convert.ToUInt64( ds, median ) );
    }
   
    public static void Main( )
    {
        Console.WriteLine( "This example of " +
            "the Convert.To<Type>( object, IFormatProvider ) methods " +
            "\ngenerates the following output. The example " +
            "displays the values \nreturned by the methods, " +
            "using several IFormatProvider objects.\n" );
          
        DataSet ds1 = new DataSet( 
            10.5, 22.2, 45.9, 88.7, 156.05, 297.6 );
        DisplayDataSet( ds1 );
          
        DataSet ds2 = new DataSet( 
            359999.95, 425000, 499999.5, 775000, 1695000 );
        DisplayDataSet( ds2 );
    }
}

/*
This example of the Convert.To<Type>( object, IFormatProvider ) methods
generates the following output. The example displays the values
returned by the methods, using several IFormatProvider objects.

DataSet: [10.5, 22.2, 45.9, 88.7, 156.05, 297.6]

Convert.                 Default      Geometric Mean              Median
--------                 -------      --------------              ------
ToBoolean                   True                True                True
ToByte                       103                  59                  67
ToChar                         g                   ;                   C
ToDateTime   2003-05-13 15:04:12 2003-05-13 15:03:28 2003-05-13 15:03:35
ToDecimal       103.491666666667    59.4332135445164                67.3
ToDouble        103.491666666667    59.4332135445164                67.3
ToInt16                      103                  59                  67
ToInt32                      103                  59                  67
ToInt64                      103                  59                  67
ToSByte                      103                  59                  67
ToSingle                103.4917            59.43321                67.3
ToUInt16                     103                  59                  67
ToUInt32                     103                  59                  67
ToUInt64                     103                  59                  67

DataSet: [359999.95, 425000, 499999.5, 775000, 1695000]

Convert.                 Default      Geometric Mean              Median
--------                 -------      --------------              ------
ToBoolean                   True                True                True
ToByte                       255                 255                 255
ToChar                         ?                   ?                   ?
ToDateTime   2003-05-22 07:39:08 2003-05-20 22:28:45 2003-05-19 09:55:48
ToDecimal              750999.89    631577.237188435            499999.5
ToDouble               750999.89    631577.237188435            499999.5
ToInt16                    32767               32767               32767
ToInt32                   751000              631577              500000
ToInt64                   751000              631577              500000
ToSByte                      127                 127                 127
ToSingle                750999.9            631577.3            499999.5
ToUInt16                   65535               65535               65535
ToUInt32                  751000              631577              500000
ToUInt64                  751000              631577              500000
*/
//</Snippet1>
