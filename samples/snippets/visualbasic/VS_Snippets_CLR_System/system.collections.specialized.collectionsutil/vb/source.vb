'<snippet1>
Imports System
Imports System.Collections
Imports System.Collections.Specialized

Class TestCollectionsUtils
    Public Shared Sub Main()
        Dim population1 As Hashtable = CollectionsUtil.CreateCaseInsensitiveHashtable()

        population1("Trapperville") = 15
        population1("Doggerton") = 230
        population1("New Hollow") = 1234
        population1("McHenry") = 185

        ' Select cities from the table using mixed case.
        Console.WriteLine("Case insensitive hashtable results:" + vbNewLine)
        Console.WriteLine("{0}'s population is: {1}", "Trapperville", population1("trapperville"))
        Console.WriteLine("{0}'s population is: {1}", "Doggerton", population1("DOGGERTON"))
        Console.WriteLine("{0}'s population is: {1}", "New Hollow", population1("New hoLLow"))
        Console.WriteLine("{0}'s population is: {1}", "McHenry", population1("MchenrY"))

        Dim population2 As SortedList = CollectionsUtil.CreateCaseInsensitiveSortedList()

        For Each city As String In population1.Keys
            population2.Add(city, population1(city))
        Next city

        ' Select cities from the sorted list using mixed case.
        Console.WriteLine(vbNewLine + "Case insensitive sorted list results:" + vbNewLine)
        Console.WriteLine("{0}'s population is: {1}", "Trapperville", population2("trapPeRVille"))
        Console.WriteLine("{0}'s population is: {1}", "Doggerton", population2("dOGGeRtON"))
        Console.WriteLine("{0}'s population is: {1}", "New Hollow", population2("nEW hOLLOW"))
        Console.WriteLine("{0}'s population is: {1}", "McHenry", population2("MchEnrY"))
    End Sub
End Class

' This program displays the following output to the console
'
' Case insensitive hashtable results:
'
' Trapperville's population is: 15
' Doggerton's population is: 230
' New Hollow's population is: 1234
' McHenry's population is: 185
'
' Case insensitive sorted list results:
'
' Trapperville's population is: 15
' Doggerton's population is: 230
' New Hollow's population is: 1234
' McHenry's population is: 185
'</snippet1>
