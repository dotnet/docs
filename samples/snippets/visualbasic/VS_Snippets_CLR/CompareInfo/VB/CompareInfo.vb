' Types:System.Globalization.CompareInfo Vendor: Richter
'<snippet1>
Imports System
Imports System.Text
Imports System.Globalization

NotInheritable Public Class App
    Shared Sub Main(ByVal args() As String) 
        Dim sign() As String = {"<", "=", ">"}
        
        ' The code below demonstrates how strings compare 
        ' differently for different cultures.
        Dim s1 As String = "Coté"
        Dim s2 As String = "coté"
        Dim s3 As String = "côte"
        
        ' Set sort order of strings for French in France.
        Dim ci As CompareInfo = New CultureInfo("fr-FR").CompareInfo
        Console.WriteLine("The LCID for {0} is {1}.", ci.Name, ci.LCID)
        
        ' Display the result using fr-FR Compare of Coté = coté.  	
        Console.WriteLine("fr-FR Compare: {0} {2} {1}", _
                          s1, s2, sign((ci.Compare(s1, s2, CompareOptions.IgnoreCase) + 1)))
        
        ' Display the result using fr-FR Compare of coté > côte.
        Console.WriteLine("fr-FR Compare: {0} {2} {1}", _
                          s2, s3, sign((ci.Compare(s2, s3, CompareOptions.None) + 1)))
        
        ' Set sort order of strings for Japanese as spoken in Japan.
        ci = New CultureInfo("ja-JP").CompareInfo
        Console.WriteLine("The LCID for {0} is {1}.", ci.Name, ci.LCID)
        
        ' Display the result using ja-JP Compare of coté < côte. 
        Console.WriteLine("ja-JP Compare: {0} {2} {1}", _
                          s2, s3, sign((ci.Compare(s2, s3) + 1)))
    End Sub 'Main
End Class 'App

' This code produces the following output.
' 
' The LCID for fr-FR is 1036.
' fr-FR Compare: Coté = coté
' fr-FR Compare: coté > côte
' The LCID for ja-JP is 1041.
' ja-JP Compare: coté < côte
'</snippet1>