'<Snippet1>
Imports System.Collections

Module IConvertibleProviderDemo

    ' Define the types of averaging available in the class 
    ' implementing IConvertible.
    Enum AverageType as Short
        None = 0
        GeometricMean = 1
        ArithmeticMean = 2
        Median = 3
    End Enum

    ' Pass an instance of this class to methods that require an 
    ' IFormatProvider. The class instance determines the type of 
    ' average to calculate.
    Public Class AverageInfo
        Implements IFormatProvider

        Protected  AvgType      As AverageType

        ' Specify the type of averaging in the constructor.
        Public Sub New( avgType As AverageType )
            Me.AvgType = avgType
        End Sub

        ' This method returns a reference to the containing object 
        ' if an object of AverageInfo type is requested. 
        Public Function GetFormat( argType As Type ) As Object _
            Implements IFormatProvider.GetFormat

            If argType Is GetType( AverageInfo ) Then
                Return Me
            Else
                Return Nothing
            End If
        End Function 

        ' Use this property to set or get the type of averaging.
        Public Property TypeOfAverage( ) As AverageType
            Get
                Return Me.AvgType
            End Get
            Set( ByVal value as AverageType )
                Me.AvgType = value
            End Set
        End Property
    End Class 

    ' This class encapsulates an array of Double values and implements 
    ' the IConvertible interface. Most of the IConvertible methods 
    ' return an average of the array elements in one of three types: 
    ' arithmetic mean, geometric mean, or median. 
    Public Class DataSet
        Implements IConvertible

        Protected data              As ArrayList
        Protected defaultProvider   As AverageInfo
           
        ' Construct the object and add an initial list of values.
        ' Create a default format provider.
        Public Sub New( ParamArray values( ) As Double )
            data = New ArrayList( values )
            defaultProvider = New AverageInfo( _
                AverageType.ArithmeticMean )  
        End Sub
           
        ' Add additional values with this method.
        Public Function Add( value As Double ) As Integer
            data.Add( value )
            Return data.Count
        End Function
           
        ' Get, set, and add values with this indexer property.
        Default Public Property Item(index As Integer) As Double
            Get
                If index >= 0 AndAlso index < data.Count Then
                    Return System.Convert.ToDouble( data( index ) )
                Else
                    Throw New InvalidOperationException( _
                        "[DataSet.get] Index out of range." )
                End If
            End Get
            Set
                If index >= 0 AndAlso index < data.Count Then
                    data( index ) = value
                 
                ElseIf index = data.Count Then
                    data.Add( value )
                Else
                    Throw New InvalidOperationException( _
                        "[DataSet.set] Index out of range." )
                End If
            End Set
        End Property
          
        ' This property returns the number of elements in the object.
        Public ReadOnly Property Count( ) As Integer
            Get
                Return data.Count
            End Get
        End Property

        ' This method calculates the average of the object's elements.
        Protected Function Average( ByVal avgType As AverageType ) As Double

            Dim SumProd As Double 
            Dim Index   As Integer

            If data.Count = 0 Then Return 0.0

            Select Case avgType
                
                Case AverageType.GeometricMean

                    SumProd = 1.0
                    For Index = 0 To data.Count - 1
                        SumProd *= data( Index )
                    Next Index
                    
                    ' This calculation will not fail with negative 
                    ' elements.
                    Return Math.Sign( SumProd ) * Math.Pow( _
                        Math.Abs( SumProd ), 1.0 / data.Count )

                Case AverageType.ArithmeticMean

                    SumProd = 0.0
                    For Index = 0 To data.Count - 1
                        SumProd += data( Index )
                    Next Index

                    Return SumProd / data.Count 

                Case AverageType.Median

                    If data.Count Mod 2 = 0 Then
                        Return ( data( data.Count \ 2 ) + _
                            data( data.Count \ 2 - 1 ) ) / 2.0
                    Else
                        Return data( data.Count \ 2 ) 
                    End If
            End Select
        End Function

        ' Get the AverageInfo object from the caller's format 
        ' provider, or use the local default.
        Protected Function GetAverageInfo( _
            provider As IFormatProvider ) As AverageInfo

            Dim avgInfo As AverageInfo = Nothing

            If Not provider Is Nothing Then
                avgInfo = provider.GetFormat( GetType( AverageInfo ) )
            End If

            Return IIf( avgInfo Is Nothing, defaultProvider, avgInfo )
            
        End Function           

        ' Calculate the average and limit the range.
        Protected Function CalcNLimitAverage( min As Double, _
            max As Double, provider as IFormatProvider ) As Double

            ' Get the format provider and calculate the average.
            Dim avgInfo As AverageInfo = GetAverageInfo( provider )
            Dim avg As Double = Average( avgInfo.TypeOfAverage )

            ' Limit the range, based on the minimum and maximum values 
            ' for the type.
            Return IIf( avg > max, max, IIf( avg < min, min, avg ) )

        End Function

        ' The following elements are required by IConvertible.

        ' None of these conversion functions throw exceptions. When
        ' the data is out of range for the type, the appropriate
        ' MinValue or MaxValue is used.
        Public Function GetTypeCode( ) As TypeCode _
            Implements IConvertible.GetTypeCode
            Return TypeCode.Object
        End Function

        Function ToBoolean( ByVal provider As IFormatProvider ) As _
            Boolean Implements IConvertible.ToBoolean

            ' ToBoolean is false if the dataset is empty.
            If data.Count <= 0 Then
                Return False

            ' For median averaging, ToBoolean is true if any 
            ' non-discarded elements are nonzero.
            ElseIf AverageType.Median = _
                GetAverageInfo( provider ).TypeOfAverage Then

                If data.Count Mod 2 = 0 Then
                    Return ( data( data.Count \ 2 ) <> 0.0 Or _
                        data( data.Count \ 2 - 1 ) <> 0.0 )
                Else
                    Return data( data.Count \ 2 ) <> 0.0
                End If

            ' For arithmetic or geometric mean averaging, ToBoolean is 
            ' true if any element of the dataset is nonzero.  
            Else
                Dim Index As Integer
                For Index = 0 To data.Count - 1
                    If data( Index ) <> 0.0 Then Return True
                Next Index
                Return False
            End If
        End Function

        Function ToByte( ByVal provider As IFormatProvider ) As Byte _
            Implements IConvertible.ToByte
            Return Convert.ToByte( CalcNLimitAverage( _
                Byte.MinValue, Byte.MaxValue, provider ) )
        End Function

        Function ToChar( ByVal provider As IFormatProvider ) As Char _
            Implements IConvertible.ToChar
            Return Convert.ToChar( Convert.ToUInt16( _
                CalcNLimitAverage( 0.0, &HFFFF, provider ) ) )
        End Function

        ' Convert to DateTime by adding the calculated average as 
        ' seconds to the current date and time. A valid DateTime is 
        ' always returned.
        Function ToDateTime( ByVal provider As IFormatProvider ) As _
            DateTime Implements IConvertible.ToDateTime
            Dim seconds As Double = Average( _
                GetAverageInfo( provider ).TypeOfAverage )
            Try
                Return DateTime.Now.AddSeconds( seconds )
            Catch ex As ArgumentOutOfRangeException 
                Return IIf( seconds < 0.0, DateTime.MinValue, _
                    DateTime.MaxValue )
            End Try
        End Function

        Function ToDecimal( ByVal provider As IFormatProvider ) As _
            Decimal Implements IConvertible.ToDecimal

            ' The Double conversion rounds Decimal.MinValue and
            ' Decimal.MaxValue to invalid Decimal values, so the 
            ' following limits must be used.
            Return Convert.ToDecimal( CalcNLimitAverage( _
                -79228162514264330000000000000.0, _
                79228162514264330000000000000.0, provider ) )
        End Function

        Function ToDouble( ByVal provider As IFormatProvider) As _
            Double Implements IConvertible.ToDouble
            Return Average( GetAverageInfo( provider ).TypeOfAverage )
        End Function

        Function ToInt16( ByVal provider As IFormatProvider ) As _
            Short Implements IConvertible.ToInt16
            Return Convert.ToInt16( CalcNLimitAverage( _
                Int16.MinValue, Int16.MaxValue, provider ) )
        End Function

        Function ToInt32( ByVal provider As IFormatProvider ) As _
            Integer Implements IConvertible.ToInt32
            Return Convert.ToInt32( CalcNLimitAverage( _
                Int32.MinValue, Int32.MaxValue, provider ) )
        End Function

        Function ToInt64( ByVal provider As IFormatProvider ) As Long _
            Implements IConvertible.ToInt64

            ' The Double conversion rounds Int64.MinValue and 
            ' Int64.MaxValue to invalid Long values, so the following 
            ' limits must be used.
            Return Convert.ToInt64( CalcNLimitAverage( _
                -9223372036854775000, 9223372036854775000, provider ) )
        End Function

        Function ToSByte( ByVal provider As IFormatProvider ) As _
            SByte Implements IConvertible.ToSByte

            ' SByte.MinValue and SByte.MaxValue are not defined in
            ' Visual Basic.
            Return Convert.ToSByte( CalcNLimitAverage( _
                -128, 127, provider ) )
        End Function

        Function ToSingle( ByVal provider As IFormatProvider ) As _
            Single Implements IConvertible.ToSingle
            Return Convert.ToSingle( CalcNLimitAverage( _
                Single.MinValue, Single.MaxValue, provider ) )
        End Function

        Function ToUInt16( ByVal provider As IFormatProvider ) As _
            UInt16 Implements IConvertible.ToUInt16

            ' UInt16.MinValue and UInt16.MaxValue are not defined in 
            ' Visual Basic.
            Return Convert.ToUInt16( CalcNLimitAverage( _
                0, &HFFFF, provider ) )
        End Function

        Function ToUInt32( ByVal provider As IFormatProvider ) As _
            UInt32 Implements IConvertible.ToUInt32

            ' UInt32.MinValue and UInt32.MaxValue are not defined in 
            ' Visual Basic.
            Return Convert.ToUInt32( CalcNLimitAverage( _
                0, 4294967295, provider ) )
        End Function

        Function ToUInt64( ByVal provider As IFormatProvider ) As _
            UInt64 Implements IConvertible.ToUInt64

            ' UInt64.MinValue and UInt64.MaxValue are not defined in 
            ' Visual Basic. The Double conversion would have rounded 
            ' UInt64.MaxValue, so the following limit must be used.
            Return Convert.ToUInt64( CalcNLimitAverage( _
                0, 18446744073709550000.0, provider ) )
        End Function

        Function ToType( ByVal conversionType As Type, _
            ByVal provider As IFormatProvider) As Object _
            Implements IConvertible.ToType
            Return Convert.ChangeType( Average( GetAverageInfo( _
                provider ).TypeOfAverage ), conversionType )
        End Function

        Overloads Function ToString( ByVal provider As IFormatProvider _
            ) As String Implements IConvertible.ToString
            Dim avgType as AverageType = _
                GetAverageInfo( provider ).TypeOfAverage
            Return String.Format( "( {0}: {1:G10} )", avgType, _
                Average( avgType ) )
        End Function
    End Class
   
    ' Display a DataSet with three different format providers.
    Sub DisplayDataSet( ds As DataSet )

        Dim fmt    As String      = "{0,-12}{1,20}{2,20}{3,20}"
        Dim median As AverageInfo = New AverageInfo( AverageType.Median )
        Dim geMean As AverageInfo = _
            New AverageInfo( AverageType.GeometricMean )
        Dim iX     As Integer

        ' Display the dataset elements.
        If ds.Count > 0 Then
            Console.Write( vbCrLf & "DataSet: [{0}", ds( 0 ) )
            For iX = 1 To ds.Count - 1
                Console.Write( ", {0}", ds( iX ) )
            Next iX
            Console.WriteLine( "]" & vbCrLf )
        End If

        Console.WriteLine( fmt, "Convert.", "Default", _
            "Geometric Mean", "Median" )
        Console.WriteLine( fmt, "--------", "-------", _
            "--------------", "------" )
        Console.WriteLine( fmt, "ToBoolean", _
            Convert.ToBoolean( ds, Nothing ), _
            Convert.ToBoolean( ds, geMean ), _
            Convert.ToBoolean( ds, median ) )
        Console.WriteLine( fmt, "ToByte", _
            Convert.ToByte( ds, Nothing ), _
            Convert.ToByte( ds, geMean ), _
            Convert.ToByte( ds, median ) )
        Console.WriteLine( fmt, "ToChar", _
            Convert.ToChar( ds, Nothing ), _
            Convert.ToChar( ds, geMean ), _
            Convert.ToChar( ds, median ) )
        Console.WriteLine( "{0,-12}{1,20:yyyy-MM-dd HH:mm:ss}" & _
            "{2,20:yyyy-MM-dd HH:mm:ss}{3,20:yyyy-MM-dd HH:mm:ss}", _
            "ToDateTime", Convert.ToDateTime( ds, Nothing ), _
            Convert.ToDateTime( ds, geMean ), _
            Convert.ToDateTime( ds, median ) )
        Console.WriteLine( fmt, "ToDecimal", _
            Convert.ToDecimal( ds, Nothing ), _
            Convert.ToDecimal( ds, geMean ), _
            Convert.ToDecimal( ds, median ) )
        Console.WriteLine( fmt, "ToDouble", _
            Convert.ToDouble( ds, Nothing ), _
            Convert.ToDouble( ds, geMean ), _
            Convert.ToDouble( ds, median ) )
        Console.WriteLine( fmt, "ToInt16", _
            Convert.ToInt16( ds, Nothing ), _
            Convert.ToInt16( ds, geMean ), _
            Convert.ToInt16( ds, median ) )
        Console.WriteLine( fmt, "ToInt32", _
            Convert.ToInt32( ds, Nothing ), _
            Convert.ToInt32( ds, geMean ), _
            Convert.ToInt32( ds, median ) )
        Console.WriteLine( fmt, "ToInt64", _
            Convert.ToInt64( ds, Nothing ), _
            Convert.ToInt64( ds, geMean ), _
            Convert.ToInt64( ds, median ) )
        Console.WriteLine( fmt, "ToSByte", _
            Convert.ToSByte( ds, Nothing ), _
            Convert.ToSByte( ds, geMean ), _
            Convert.ToSByte( ds, median ) )
        Console.WriteLine( fmt, "ToSingle", _
            Convert.ToSingle( ds, Nothing ), _
            Convert.ToSingle( ds, geMean ), _
            Convert.ToSingle( ds, median ) )
        Console.WriteLine( fmt, "ToUInt16", _
            Convert.ToUInt16( ds, Nothing ), _
            Convert.ToUInt16( ds, geMean ), _
            Convert.ToUInt16( ds, median ) )
        Console.WriteLine( fmt, "ToUInt32", _
            Convert.ToUInt32( ds, Nothing ), _
            Convert.ToUInt32( ds, geMean ), _
            Convert.ToUInt32( ds, median ) )
        Console.WriteLine( fmt, "ToUInt64", _
            Convert.ToUInt64( ds, Nothing ), _
            Convert.ToUInt64( ds, geMean ), _
            Convert.ToUInt64( ds, median ) )
    End Sub
   
    Sub Main( )
        Console.WriteLine( _
            "This example of the Convert.To<Type>( Object, " & _
            "IFormatProvider ) methods " & vbCrLf & "generates " & _
            "the following output. The example displays the " & _
            "values " & vbCrLf & "returned by the methods, " & _
            "using several IFormatProvider objects." & vbCrLf )
          
        Dim ds1 As New DataSet( 10.5, 22.2, 45.9, 88.7, 156.05, 297.6 )
        DisplayDataSet( ds1 )
          
        Dim ds2 As New DataSet( _
            359999.95, 425000, 499999.5, 775000, 1695000 )
        DisplayDataSet( ds2 )
    End Sub 
End Module 

' This example of the Convert.To<Type>( Object, IFormatProvider ) methods
' generates the following output. The example displays the values
' returned by the methods, using several IFormatProvider objects.
' 
' DataSet: [10.5, 22.2, 45.9, 88.7, 156.05, 297.6]
' 
' Convert.                 Default      Geometric Mean              Median
' --------                 -------      --------------              ------
' ToBoolean                   True                True                True
' ToByte                       103                  59                  67
' ToChar                         g                   ;                   C
' ToDateTime   2003-05-13 14:52:53 2003-05-13 14:52:09 2003-05-13 14:52:17
' ToDecimal       103.491666666667    59.4332135445164                67.3
' ToDouble        103.491666666667    59.4332135445164                67.3
' ToInt16                      103                  59                  67
' ToInt32                      103                  59                  67
' ToInt64                      103                  59                  67
' ToSByte                      103                  59                  67
' ToSingle                103.4917            59.43321                67.3
' ToUInt16                     103                  59                  67
' ToUInt32                     103                  59                  67
' ToUInt64                     103                  59                  67
' 
' DataSet: [359999.95, 425000, 499999.5, 775000, 1695000]
' 
' Convert.                 Default      Geometric Mean              Median
' --------                 -------      --------------              ------
' ToBoolean                   True                True                True
' ToByte                       255                 255                 255
' ToChar                         ?                   ?                   ?
' ToDateTime   2003-05-22 07:27:49 2003-05-20 22:17:27 2003-05-19 09:44:29
' ToDecimal              750999.89    631577.237188435            499999.5
' ToDouble               750999.89    631577.237188435            499999.5
' ToInt16                    32767               32767               32767
' ToInt32                   751000              631577              500000
' ToInt64                   751000              631577              500000
' ToSByte                      127                 127                 127
' ToSingle                750999.9            631577.3            499999.5
' ToUInt16                   65535               65535               65535
' ToUInt32                  751000              631577              500000
' ToUInt64                  751000              631577              500000
'</Snippet1>
