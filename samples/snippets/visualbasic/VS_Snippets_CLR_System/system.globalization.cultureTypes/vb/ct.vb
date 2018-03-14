'<snippet1>
' This example demonstrates the CultureTypes enumeration 
' and the CultureInfo.CultureTypes property.

Imports System
Imports System.Globalization

Module Module1
    Public Sub Main()

        ' Create a table of most culture types. 
        Dim mostCultureTypes() As CultureTypes = { _
                CultureTypes.NeutralCultures, _
                CultureTypes.SpecificCultures, _
                CultureTypes.InstalledWin32Cultures, _
                CultureTypes.UserCustomCulture, _
                CultureTypes.ReplacementCultures, _
                CultureTypes.FrameworkCultures, _
                CultureTypes.WindowsOnlyCultures}
        Dim allCultures() As CultureInfo
        Dim combo As CultureTypes

        ' Get and enumerate all cultures.
        allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
        Dim ci As CultureInfo
        For Each ci In allCultures
            ' Display the name of each culture.
            Console.WriteLine("Culture: {0}", ci.Name)

            ' Get the culture types of each culture. 
            combo = ci.CultureTypes

            ' Display the name of each culture type flag that is set.
            Console.Write("  ")
            Dim ct As CultureTypes
            For Each ct In mostCultureTypes
                If 0 <> (ct And combo) Then
                    Console.Write("{0} ", ct)
                End If
            Next ct
            Console.WriteLine()
        Next ci

    End Sub 'Main 
End Module

'The following is a portion of the results produced by this code example.
'.
'.
'.
'Culture: tg
'  NeutralCultures InstalledWin32Cultures 
'Culture: ta
'  NeutralCultures InstalledWin32Cultures FrameworkCultures 
'Culture: te
'  NeutralCultures InstalledWin32Cultures FrameworkCultures 
'Culture: syr
'  NeutralCultures InstalledWin32Cultures FrameworkCultures 
'Culture: tg-Cyrl-TJ
'  SpecificCultures InstalledWin32Cultures 
'Culture: ta-IN
'  SpecificCultures InstalledWin32Cultures FrameworkCultures 
'Culture: te-IN
'  SpecificCultures InstalledWin32Cultures FrameworkCultures 
'Culture: syr-SY
'  SpecificCultures InstalledWin32Cultures FrameworkCultures 
'Culture: tg-Cyrl
'  NeutralCultures InstalledWin32Cultures 
'.
'.
'.
' </snippet1>
