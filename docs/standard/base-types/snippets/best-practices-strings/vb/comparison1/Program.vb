Imports System.Globalization
Imports System.Threading

Module Program
    Sub Main()
        ' Words to sort
        Dim values As String() = {"able", "ångström", "apple", "Æble",
                                  "Windows", "Visual Studio"}

        ' Current culture
        Array.Sort(values)
        DisplayArray(values)

        ' Change culture to Swedish (Sweden)
        Dim originalCulture As String = CultureInfo.CurrentCulture.Name
        Thread.CurrentThread.CurrentCulture = New CultureInfo("sv-SE")
        Array.Sort(values)
        DisplayArray(values)

        ' Restore the original culture
        Thread.CurrentThread.CurrentCulture = New CultureInfo(originalCulture)
    End Sub

    Sub DisplayArray(values As String())
        Console.WriteLine($"Sorting using the {CultureInfo.CurrentCulture.Name} culture:")

        For Each value As String In values
            Console.WriteLine($"   {value}")
        Next

        Console.WriteLine()
    End Sub
End Module

' The example displays the following output:
'     Sorting using the en-US culture:
'        able
'        Æble
'        ångström
'        apple
'        Visual Studio
'        Windows
'
'     Sorting using the sv-SE culture:
'        able
'        apple
'        Visual Studio
'        Windows
'        ångström
'        Æble
