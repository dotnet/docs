' REDMOND\glennha
' <Snippet1>
Imports System
Imports System.Collections.Generic

Public Class ReverseComparer
    Implements IComparer(Of String)

    Public Function Compare(ByVal x As String, _
        ByVal y As String) As Integer _
        Implements IComparer(Of String).Compare

        ' Compare y and x in reverse order.
        Return y.CompareTo(x)

    End Function
End Class

Public Class Example

    Public Shared Sub Main()

        Dim dinosaurs() As String = { _
            "Seismosaurus", _
            "Chasmosaurus", _
            "Coelophysis", _
            "Mamenchisaurus", _
            "Caudipteryx", _
            "Cetiosaurus"  }

        Dim dinosaurSizes() As Integer = { 40, 5, 3, 22, 1, 18 }

        Console.WriteLine()
        For i As Integer = 0 To dinosaurs.Length - 1
            Console.WriteLine("{0}: up to {1} meters long.", _
                dinosaurs(i), dinosaurSizes(i))
        Next

        Console.WriteLine(vbLf & _
            "Sort(dinosaurs, dinosaurSizes)")
        Array.Sort(dinosaurs, dinosaurSizes)

        Console.WriteLine()
        For i As Integer = 0 To dinosaurs.Length - 1
            Console.WriteLine("{0}: up to {1} meters long.", _
                dinosaurs(i), dinosaurSizes(i))
        Next

        Dim rc As New ReverseComparer()

        Console.WriteLine(vbLf & _
            "Sort(dinosaurs, dinosaurSizes, rc)")
        Array.Sort(dinosaurs, dinosaurSizes, rc)

        Console.WriteLine()
        For i As Integer = 0 To dinosaurs.Length - 1
            Console.WriteLine("{0}: up to {1} meters long.", _
                dinosaurs(i), dinosaurSizes(i))
        Next

        Console.WriteLine(vbLf & _
            "Sort(dinosaurs, dinosaurSizes, 3, 3)")
        Array.Sort(dinosaurs, dinosaurSizes, 3, 3)

        Console.WriteLine()
        For i As Integer = 0 To dinosaurs.Length - 1
            Console.WriteLine("{0}: up to {1} meters long.", _
                dinosaurs(i), dinosaurSizes(i))
        Next

        Console.WriteLine(vbLf & _
            "Sort(dinosaurs, dinosaurSizes, 3, 3, rc)")
        Array.Sort(dinosaurs, dinosaurSizes, 3, 3, rc)

        Console.WriteLine()
        For i As Integer = 0 To dinosaurs.Length - 1
            Console.WriteLine("{0}: up to {1} meters long.", _
                dinosaurs(i), dinosaurSizes(i))
        Next

    End Sub

End Class

' This code example produces the following output:
'
'Seismosaurus: up to 40 meters long.
'Chasmosaurus: up to 5 meters long.
'Coelophysis: up to 3 meters long.
'Mamenchisaurus: up to 22 meters long.
'Caudipteryx: up to 1 meters long.
'Cetiosaurus: up to 18 meters long.
'
'Sort(dinosaurs, dinosaurSizes)
'
'Caudipteryx: up to 1 meters long.
'Cetiosaurus: up to 18 meters long.
'Chasmosaurus: up to 5 meters long.
'Coelophysis: up to 3 meters long.
'Mamenchisaurus: up to 22 meters long.
'Seismosaurus: up to 40 meters long.
'
'Sort(dinosaurs, dinosaurSizes, rc)
'
'Seismosaurus: up to 40 meters long.
'Mamenchisaurus: up to 22 meters long.
'Coelophysis: up to 3 meters long.
'Chasmosaurus: up to 5 meters long.
'Cetiosaurus: up to 18 meters long.
'Caudipteryx: up to 1 meters long.
'
'Sort(dinosaurs, dinosaurSizes, 3, 3)
'
'Seismosaurus: up to 40 meters long.
'Mamenchisaurus: up to 22 meters long.
'Coelophysis: up to 3 meters long.
'Caudipteryx: up to 1 meters long.
'Cetiosaurus: up to 18 meters long.
'Chasmosaurus: up to 5 meters long.
'
'Sort(dinosaurs, dinosaurSizes, 3, 3, rc)
'
'Seismosaurus: up to 40 meters long.
'Mamenchisaurus: up to 22 meters long.
'Coelophysis: up to 3 meters long.
'Chasmosaurus: up to 5 meters long.
'Cetiosaurus: up to 18 meters long.
'Caudipteryx: up to 1 meters long.
' </Snippet1>