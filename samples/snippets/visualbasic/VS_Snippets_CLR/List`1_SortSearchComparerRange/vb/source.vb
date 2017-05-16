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
        dinosaurs.Add("Parasauralophus")
        dinosaurs.Add("Amargasaurus")
        dinosaurs.Add("Galimimus")
        dinosaurs.Add("Mamenchisaurus")
        dinosaurs.Add("Deinonychus")
        dinosaurs.Add("Oviraptor")
        dinosaurs.Add("Tyrannosaurus")

        Dim herbivores As Integer = 5
        Display(dinosaurs)

        Dim dc As New DinoComparer

        Console.WriteLine(vbLf & _
            "Sort a range with the alternate comparer:")
        dinosaurs.Sort(0, herbivores, dc)
        Display(dinosaurs)

        Console.WriteLine(vbLf & _
            "BinarySearch a range and Insert ""{0}"":", _
            "Brachiosaurus")

        Dim index As Integer = _
            dinosaurs.BinarySearch(0, herbivores, "Brachiosaurus", dc)

        If index < 0 Then
            index = index Xor -1
            dinosaurs.Insert(index, "Brachiosaurus")
            herbivores += 1
        End If

        Display(dinosaurs)

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
'Parasauralophus
'Amargasaurus
'Galimimus
'Mamenchisaurus
'Deinonychus
'Oviraptor
'Tyrannosaurus
'
'Sort a range with the alternate comparer:
'
'Galimimus
'Amargasaurus
'Mamenchisaurus
'Parasauralophus
'Pachycephalosaurus
'Deinonychus
'Oviraptor
'Tyrannosaurus
'
'BinarySearch a range and Insert "Brachiosaurus":
'
'Galimimus
'Amargasaurus
'Brachiosaurus
'Mamenchisaurus
'Parasauralophus
'Pachycephalosaurus
'Deinonychus
'Oviraptor
'Tyrannosaurus
' </Snippet1>