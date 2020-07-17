' Visual Basic .NET Document
Option Strict On

' <Snippet5>
Imports System.Globalization

Module Example
    Public Sub Main()
        ' Get all custom cultures.
        Dim custom() As CultureInfo = CultureInfo.GetCultures(CultureTypes.UserCustomCulture)
        If custom.Length = 0 Then
            Console.WriteLine("There are no user-defined custom cultures.")
        Else
            Console.WriteLine("Custom cultures:")
            For Each culture In custom
                Console.WriteLine("   {0} -- {1}", culture.Name, culture.DisplayName)
            Next
        End If
        Console.WriteLine()

        ' Get all replacement cultures.
        Dim replacements() As CultureInfo = CultureInfo.GetCultures(CultureTypes.ReplacementCultures)
        If replacements.Length = 0 Then
            Console.WriteLine("There are no replacement cultures.")
        Else
            Console.WriteLine("Replacement cultures:")
            For Each culture in replacements
                Console.WriteLine("   {0} -- {1}", culture.Name, culture.DisplayName)
            Next
        End If
        Console.WriteLine()
    End Sub
End Module
' The example displays output like the following:
'     Custom cultures:
'        x-en-US-sample -- English (United States)
'        fj-FJ -- Boumaa Fijian (Viti)
'     
'     There are no replacement cultures.
' </Snippet5>
