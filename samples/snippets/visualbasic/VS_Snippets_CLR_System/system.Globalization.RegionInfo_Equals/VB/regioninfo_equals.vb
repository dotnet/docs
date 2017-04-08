' The following code example compares two instances of RegionInfo that were created differently.

' <snippet1>
Imports System
Imports System.Globalization


Public Class SamplesRegionInfo   

   Public Shared Sub Main()

      ' Creates a RegionInfo using the ISO 3166 two-letter code.
      Dim myRI1 As New RegionInfo("US")

      ' Creates a RegionInfo using a CultureInfo.LCID.
      Dim myRI2 As New RegionInfo(New CultureInfo("en-US", False).LCID)

      ' Compares the two instances.
      If myRI1.Equals(myRI2) Then
         Console.WriteLine("The two RegionInfo instances are equal.")
      Else
         Console.WriteLine("The two RegionInfo instances are NOT equal.")
      End If 

   End Sub 'Main

End Class 'SamplesRegionInfo 


'This code produces the following output.
'
'The two RegionInfo instances are equal.

' </snippet1>
