'<Snippet1>
' Example of the Random class constructors and Random.NextDouble( ) 
' method.
Imports System.Threading

Module RandomObjectDemo

    ' Generate random numbers from the specified Random object.
    Sub RunIntNDoubleRandoms( randObj As Random )

        ' Generate the first six random integers.
        Dim j As Integer
        For j = 0 To 5
            Console.Write( " {0,10} ", randObj.Next( ) )
        Next j
        Console.WriteLine( )
            
        ' Generate the first six random doubles.
        For j = 0 To 5
            Console.Write( " {0:F8} ", randObj.NextDouble( ) )
        Next j
        Console.WriteLine( )
    End Sub 
        
    ' Create a Random object with the specified seed.
    Sub FixedSeedRandoms( seed As Integer )

        Console.WriteLine( vbCrLf & _
            "Random numbers from a Random object with " & _
            "seed = {0}:", seed )
        Dim fixRand As New Random( seed )
            
        RunIntNDoubleRandoms( fixRand )
    End Sub 
        
    ' Create a random object with a timer-generated seed.
    Sub AutoSeedRandoms( )

        ' Wait to allow the timer to advance.
        Thread.Sleep( 1 )
            
        Console.WriteLine( vbCrLf & _
            "Random numbers from a Random object " & _ 
            "with an auto-generated seed:" )
        Dim autoRand As New Random( )
            
        RunIntNDoubleRandoms( autoRand )
    End Sub 
        
    Sub Main( )
        Console.WriteLine( _
            "This example of the Random class constructors " & _
            "and Random.NextDouble( ) " & vbCrLf & _
            "generates the following output." & vbCrLf )
        Console.WriteLine( "Create Random " & _
            "objects, and then generate and display six " & _
            "integers and " & vbCrLf & "six doubles from each." )
            
        FixedSeedRandoms( 123 )
        FixedSeedRandoms( 123 )
            
        FixedSeedRandoms( 456 )
        FixedSeedRandoms( 456 )
            
        AutoSeedRandoms( )
        AutoSeedRandoms( )
        AutoSeedRandoms( )
    End Sub
End Module 

' This example of the Random class constructors and Random.NextDouble( )
' generates the following output.
' 
' Create Random objects, and then generate and display six integers and
' six doubles from each.
' 
' Random numbers from a Random object with seed = 123:
'  2114319875  1949518561  1596751841  1742987178  1586516133   103755708
'  0.01700087  0.14935942  0.19470390  0.63008947  0.90976122  0.49519146
' 
' Random numbers from a Random object with seed = 123:
'  2114319875  1949518561  1596751841  1742987178  1586516133   103755708
'  0.01700087  0.14935942  0.19470390  0.63008947  0.90976122  0.49519146
' 
' Random numbers from a Random object with seed = 456:
'  2044805024  1323311594  1087799997  1907260840   179380355   120870348
'  0.21988117  0.21026556  0.39236514  0.42420498  0.24102703  0.47310170
' 
' Random numbers from a Random object with seed = 456:
'  2044805024  1323311594  1087799997  1907260840   179380355   120870348
'  0.21988117  0.21026556  0.39236514  0.42420498  0.24102703  0.47310170
' 
' Random numbers from a Random object with an auto-generated seed:
'  1920831619  1346865774  2006582766  1968819760   332463652   110770792
'  0.71326689  0.50383335  0.50446082  0.66312569  0.94517193  0.58059287
' 
' Random numbers from a Random object with an auto-generated seed:
'   254927927  1205531663  1984850027   110020849  1438111494  1697714106
'  0.19383387  0.52067738  0.74162783  0.35063667  0.31247720  0.38773733
' 
' Random numbers from a Random object with an auto-generated seed:
'   736507882  1064197552  1963117288   398705585   396275689  1137173773
'  0.67440084  0.53752140  0.97879483  0.03814764  0.67978248  0.19488178
'</Snippet1>

' Code added to show how to initialize Random objects with the
' same timer value that will produce unique random number sequences.
Public Class FixTimerResolution
   Public Shared Sub CreateEnginesWithSameTimer()
      ' <Snippet3>
      Dim randomInstancesToCreate As Integer = 4
      Dim randomEngines(randomInstancesToCreate - 1) As Random
      For ctr As Integer = 0 To randomInstancesToCreate - 1
         randomEngines(ctr) = New Random(CInt((DateTime.Now.Ticks >> 32) >> ctr))
      Next
      ' </Snippet3>
      For ctr As Integer = 0 To randomInstancesToCreate - 1
         Console.WriteLine(randomEngines(ctr).Next)
      Next
   End Sub
End Class
