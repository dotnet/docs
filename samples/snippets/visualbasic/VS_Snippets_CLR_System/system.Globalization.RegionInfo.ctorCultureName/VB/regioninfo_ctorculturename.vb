' The following code example creates instances of T:System.Globalization.RegionInfo using culture names.

' <snippet1>
Imports System
Imports System.Globalization

Public Class SamplesRegionInfo

    Public Shared Sub Main()

        ' Creates an array containing culture names.
        Dim myCultures() As String = {"", "ar", "ar-DZ", "en", "en-US"}

        Dim culture As String

        ' Creates a RegionInfo for each of the culture names.
        '    Note that "ar" is the culture name for the neutral culture "Arabic",
        '    but it is also the region name for the country/region "Argentina";
        '    therefore, it does not fail as expected.
        Console.WriteLine("Without checks...")
        For Each culture In  myCultures
            Try
                Dim myRI As New RegionInfo(culture)
            Catch e As ArgumentException
                Console.WriteLine(e.ToString())
            End Try
        Next

        Console.WriteLine()

        Console.WriteLine("Checking the culture names first...")
        For Each culture In  myCultures
            If culture = "" Then
                Console.WriteLine("The culture is the invariant culture.")
            Else
                Dim myCI As New CultureInfo(culture, False)
                If myCI.IsNeutralCulture Then
                    Console.WriteLine("The culture {0} is a neutral culture.", culture)
                Else
                    Console.WriteLine("The culture {0} is a specific culture.", culture)
                    Try
                        Dim myRI As New RegionInfo(culture)
                    Catch e As ArgumentException
                        Console.WriteLine(e.ToString())
                    End Try
                End If
            End If
        Next
    End Sub  
End Class 
'The example displays the following output.
'
'Without checks...
'System.ArgumentException: Region name '' is not supported.
'Parameter name: name
'   at System.Globalization.RegionInfo..ctor(String name)
'   at SamplesRegionInfo.Main()
'System.ArgumentException: Region name 'en' is not supported.
'Parameter name: name
'   at System.Globalization.CultureTableRecord..ctor(String regionName, Boolean useUserOverride)
'   at System.Globalization.RegionInfo..ctor(String name)
'   at SamplesRegionInfo.Main()
'
'Checking the culture names first...
'The culture is the invariant culture.
'The culture ar is a neutral culture.
'The culture ar-DZ is a specific culture.
'The culture en is a neutral culture.
'The culture en-US is a specific culture.

' </snippet1>
