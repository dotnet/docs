'<snippet1>
' This example demonstrates the System.Globalization.Culture-
' AndRegionInfoBuilder Register method.
' Compile this code example with a reference to sysglobl.dll.

Imports System
Imports System.Globalization

Class Sample
    Public Shared Sub Main() 
        Dim cib As CultureAndRegionInfoBuilder = Nothing
        Try
            ' Create a CultureAndRegionInfoBuilder object named "x-en-US-sample".
            Console.WriteLine("Create and explore the CultureAndRegionInfoBuilder..." & vbCrLf)
            cib = New CultureAndRegionInfoBuilder("x-en-US-sample", CultureAndRegionModifiers.None)
            
            ' Populate the new CultureAndRegionInfoBuilder object with culture information.
            Dim ci As New CultureInfo("en-US")
            cib.LoadDataFromCultureInfo(ci)
            
            ' Populate the new CultureAndRegionInfoBuilder object with region information.
            Dim ri As New RegionInfo("US")
            cib.LoadDataFromRegionInfo(ri)
            
            ' Display some of the properties of the CultureAndRegionInfoBuilder object.
            Console.WriteLine("CultureName:. . . . . . . . . . {0}", cib.CultureName)
            Console.WriteLine("CultureEnglishName: . . . . . . {0}", cib.CultureEnglishName)
            Console.WriteLine("CultureNativeName:. . . . . . . {0}", cib.CultureNativeName)
            Console.WriteLine("GeoId:. . . . . . . . . . . . . {0}", cib.GeoId)
            Console.WriteLine("IsMetric: . . . . . . . . . . . {0}", cib.IsMetric)
            Console.WriteLine("ISOCurrencySymbol:. . . . . . . {0}", cib.ISOCurrencySymbol)
            Console.WriteLine("RegionEnglishName:. . . . . . . {0}", cib.RegionEnglishName)
            Console.WriteLine("RegionName: . . . . . . . . . . {0}", cib.RegionName)
            Console.WriteLine("RegionNativeName: . . . . . . . {0}", cib.RegionNativeName)
            Console.WriteLine("ThreeLetterISOLanguageName: . . {0}", cib.ThreeLetterISOLanguageName)
            Console.WriteLine("ThreeLetterISORegionName: . . . {0}", cib.ThreeLetterISORegionName)
            Console.WriteLine("ThreeLetterWindowsLanguageName: {0}", cib.ThreeLetterWindowsLanguageName)
            Console.WriteLine("ThreeLetterWindowsRegionName: . {0}", cib.ThreeLetterWindowsRegionName)
            Console.WriteLine("TwoLetterISOLanguageName: . . . {0}", cib.TwoLetterISOLanguageName)
            Console.WriteLine("TwoLetterISORegionName: . . . . {0}", cib.TwoLetterISORegionName)
            Console.WriteLine()
            
            ' Register the custom culture.
            Console.WriteLine("Register the custom culture...")
            cib.Register()
            
            ' Display some of the properties of the custom culture.
            Console.WriteLine("Create and explore the custom culture..." & vbCrLf)
            ci = New CultureInfo("x-en-US-sample")
            
            Console.WriteLine("Name: . . . . . . . . . . . . . {0}", ci.Name)
            Console.WriteLine("EnglishName:. . . . . . . . . . {0}", ci.EnglishName)
            Console.WriteLine("NativeName: . . . . . . . . . . {0}", ci.NativeName)
            Console.WriteLine("TwoLetterISOLanguageName: . . . {0}", ci.TwoLetterISOLanguageName)
            Console.WriteLine("ThreeLetterISOLanguageName: . . {0}", ci.ThreeLetterISOLanguageName)
            Console.WriteLine("ThreeLetterWindowsLanguageName: {0}", ci.ThreeLetterWindowsLanguageName)
            
            Console.WriteLine(vbCrLf & "Note:" & vbCrLf & "Use the example in the " & _
                              "Unregister method topic to remove the custom culture.")
        Catch e As Exception
            Console.WriteLine(e)
        End Try
    
    End Sub 'Main
End Class 'Sample

'This code example produces the following results:
'
'Create and explore the CultureAndRegionInfoBuilder...
'
'CultureName:. . . . . . . . . . x-en-US-sample
'CultureEnglishName: . . . . . . English (United States)
'CultureNativeName:. . . . . . . English (United States)
'GeoId:. . . . . . . . . . . . . 244
'IsMetric: . . . . . . . . . . . False
'ISOCurrencySymbol:. . . . . . . USD
'RegionEnglishName:. . . . . . . United States
'RegionName: . . . . . . . . . . x-en-US-sample
'RegionNativeName: . . . . . . . United States
'ThreeLetterISOLanguageName: . . eng
'ThreeLetterISORegionName: . . . USA
'ThreeLetterWindowsLanguageName: ENU
'ThreeLetterWindowsRegionName: . USA
'TwoLetterISOLanguageName: . . . en
'TwoLetterISORegionName: . . . . US
'
'Register the custom culture...
'Create and explore the custom culture...
'
'Name: . . . . . . . . . . . . . x-en-US-sample
'EnglishName:. . . . . . . . . . English (United States)
'NativeName: . . . . . . . . . . English (United States)
'TwoLetterISOLanguageName: . . . en
'ThreeLetterISOLanguageName: . . eng
'ThreeLetterWindowsLanguageName: ENU
'
'Note:
'Use the example in the Unregister method topic to remove the custom culture.
'
'</snippet1>