'<snippet1>
Imports System.Globalization

Module Module1
    Public Sub Main()
        ' Get and enumerate all cultures.
        Dim allCultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
         For Each ci In allCultures
            ' Display the name of each culture.
            Console.Write($"{ci.EnglishName} ({ci.Name}): ")
            ' Indicate the culture type. 
            If ci.CultureTypes.HasFlag(CultureTypes.NeutralCultures) Then
               Console.Write(" NeutralCulture")
            End If   
            If ci.CultureTypes.HasFlag(CultureTypes.SpecificCultures) Then
               Console.Write(" SpecificCulture")
            End If   
            Console.WriteLine()
        Next
    End Sub  
End Module
' The following is a portion of the output from this example.
'            Tajik (tg):  NeutralCulture
'            Tajik (Cyrillic) (tg-Cyrl):  NeutralCulture
'            Tajik (Cyrillic, Tajikistan) (tg-Cyrl-TJ):  SpecificCulture
'            Thai (th):  NeutralCulture
'            Thai (Thailand) (th-TH):  SpecificCulture
'            Tigrinya (ti):  NeutralCulture
'            Tigrinya (Eritrea) (ti-ER):  SpecificCulture
'            Tigrinya (Ethiopia) (ti-ET):  SpecificCulture
'            Tigre (tig):  NeutralCulture
'            Tigre (Eritrea) (tig-ER):  SpecificCulture
'            Turkmen (tk):  NeutralCulture
'            Turkmen (Turkmenistan) (tk-TM):  SpecificCulture
'            Setswana (tn):  NeutralCulture
'            Setswana (Botswana) (tn-BW):  SpecificCulture
'            Setswana (South Africa) (tn-ZA):  SpecificCulture
' </snippet1>
