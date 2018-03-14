' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class DinoComparer
    Implements IComparer(Of String)

    Public Function Compare(ByVal x As String, _
        ByVal y As String) As Integer _
        Implements IComparer(Of String).Compare

        If x Is Nothing Then
            If y Is Nothing Then 
                ' If x is Nothing and y is Nothing, they're
                ' equal. 
                Return 0
            Else
                ' If x is Nothing and y is not Nothing, y
                ' is greater. 
                Return -1
            End If
        Else
            ' If x is not Nothing...
            '
            If y Is Nothing Then
                ' ...and y is Nothing, x is greater.
                Return 1
            Else
                ' ...and y is not Nothing, compare the 
                ' lengths of the two strings.
                '
                Dim retval As Integer = _
                    x.Length.CompareTo(y.Length)

                If retval <> 0 Then 
                    ' If the strings are not of equal length,
                    ' the longer string is greater.
                    '
                    Return retval
                Else
                    ' If the strings are of equal length,
                    ' sort them with ordinary string comparison.
                    '
                    Return x.CompareTo(y)
                End If
            End If
        End If
    End Function
End Class

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs As New List(Of String)
        dinosaurs.Add("Pachycephalosaurus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Mamenchisaurus")
        dinosaurs.Add("Deinonychus")
        Display(dinosaurs)

        Dim dc As New DinoComparer

        Console.WriteLine(vbLf & "Sort with alternate comparer:")
        dinosaurs.Sort(dc)
        Display(dinosaurs)

        SearchAndInsert(dinosaurs, "Coelophysis", dc)
        Display(dinosaurs)

        SearchAndInsert(dinosaurs, "Oviraptor", dc)
        Display(dinosaurs)

        SearchAndInsert(dinosaurs, "Tyrannosaur", dc)
        Display(dinosaurs)

        SearchAndInsert(dinosaurs, Nothing, dc)
        Display(dinosaurs)
    End Sub

    Private Shared Sub SearchAndInsert( _
        ByVal lis As List(Of String), _
        ByVal insert As String, ByVal dc As DinoComparer)

        Console.WriteLine(vbLf & _
            "BinarySearch and Insert ""{0}"":", insert)

        Dim index As Integer = lis.BinarySearch(insert, dc)

        If index < 0 Then
            index = index Xor -1
            lis.Insert(index, insert)
        End If
    End Sub

    Private Shared Sub Display(ByVal lis As List(Of String))
        Console.WriteLine()
        For Each s As String In lis
            Console.WriteLine(s)
        Next
    End Sub
End Class

' This code example produces the following output:
'
'Pachycephalosaurus
'Amargasaurus
'Mamenchisaurus
'Deinonychus
'
'Sort with alternate comparer:
'
'Deinonychus
'Amargasaurus
'Mamenchisaurus
'Pachycephalosaurus
'
'BinarySearch and Insert "Coelophysis":
'
'Coelophysis
'Deinonychus
'Amargasaurus
'Mamenchisaurus
'Pachycephalosaurus
'
'BinarySearch and Insert "Oviraptor":
'
'Oviraptor
'Coelophysis
'Deinonychus
'Amargasaurus
'Mamenchisaurus
'Pachycephalosaurus
'
'BinarySearch and Insert "Tyrannosaur":
'
'Oviraptor
'Coelophysis
'Deinonychus
'Tyrannosaur
'Amargasaurus
'Mamenchisaurus
'Pachycephalosaurus
'
'BinarySearch and Insert "":
'
'
'Oviraptor
'Coelophysis
'Deinonychus
'Tyrannosaur
'Amargasaurus
'Mamenchisaurus
'Pachycephalosaurus
' </Snippet1>