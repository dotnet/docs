'<Snippet2>
' Example of Convert.ToString( non-numeric types, IFormatProvider ).
Imports System
Imports System.Globalization
Imports Microsoft.VisualBasic

' An instance of this class can be passed to methods that require 
' an IFormatProvider.
Public Class DummyProvider
    Implements IFormatProvider

    ' Normally, GetFormat returns an object of the requested type
    ' (usually itself) if it is able; otherwise, it returns Nothing. 
    Public Function GetFormat( argType As Type ) As Object _
        Implements IFormatProvider.GetFormat

        ' Here, the type of argType is displayed, and GetFormat
        ' always returns Nothing.
        Console.Write( "{0,-40}", argType.ToString( ) )
        Return Nothing

    End Function 
End Class

Module ConvertNonNumericProviderDemo

    Sub Main( )

        ' Create an instance of the IFormatProvider.
        Dim provider    As New DummyProvider( )
        Dim converted   As String

        ' Convert these values using DummyProvider.
        Dim Int32A      As Integer  = -252645135   
        Dim DoubleA     As Double   = 61680.3855
        Dim ObjDouble   As Object   = CType( -98765.4321, Object )
        Dim DayTimeA    As DateTime = _
                            new DateTime( 2001, 9, 11, 13, 45, 0 )

        Dim BoolA       As Boolean  = True
        Dim StringA     As String   = "Qwerty"
        Dim CharA       As Char     = "$"c
        Dim TSpanA      As TimeSpan = New TimeSpan( 0, 18, 0 )
        Dim ObjOther    As Object   = CType( provider, Object )

        Console.WriteLine( "This example of " & _
            "Convert.ToString( non-numeric, IFormatProvider ) " & _
            vbCrLf & "generates the following output. The " & _
            "provider type, argument type, " & vbCrLf & "and " & _
            "argument value are displayed." )
        Console.WriteLine( vbCrLf & _
            "Note: The IFormatProvider object is not called for " & _
            "Boolean, String, " & vbCrLf & "Char, TimeSpan, " & _
            "and non-numeric Object." )

        ' The format provider is called for these conversions.
        Console.WriteLine( )
        converted =  Convert.ToString( Int32A, provider )
        Console.WriteLine( "Int32    {0}", converted )
        converted =  Convert.ToString( DoubleA, provider )
        Console.WriteLine( "Double   {0}", converted )
        converted =  Convert.ToString( ObjDouble, provider )
        Console.WriteLine( "Object   {0}", converted )
        converted =  Convert.ToString( DayTimeA, provider )
        Console.WriteLine( "DateTime {0}", converted )

        ' The format provider is not called for these conversions.
        Console.WriteLine( )
        converted =  Convert.ToString( BoolA, provider )
        Console.WriteLine( "Boolean  {0}", converted )
        converted =  Convert.ToString( StringA, provider )
        Console.WriteLine( "String   {0}", converted )
        converted =  Convert.ToString( CharA, provider )
        Console.WriteLine( "Char     {0}", converted )
        converted =  Convert.ToString( TSpanA, provider )
        Console.WriteLine( "TimeSpan {0}", converted )
        converted =  Convert.ToString( ObjOther, provider )
        Console.WriteLine( "Object   {0}", converted )

    End Sub
End Module

' This example of Convert.ToString( non-numeric, IFormatProvider )
' generates the following output. The provider type, argument type,
' and argument value are displayed.
'
' Note: The IFormatProvider object is not called for Boolean, String,
' Char, TimeSpan, and non-numeric Object.
' 
' System.Globalization.NumberFormatInfo   Int32    -252645135
' System.Globalization.NumberFormatInfo   Double   61680.3855
' System.Globalization.NumberFormatInfo   Object   -98765.4321
' System.Globalization.DateTimeFormatInfo DateTime 9/11/2001 1:45:00 PM
' 
' Boolean  True
' String   Qwerty
' Char     $
' TimeSpan 00:18:00
' Object   DummyProvider
'</Snippet2>