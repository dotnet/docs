'<snippet03>
Imports System.Collections.Generic

Class Program
    Public Shared Sub Main()
        Dim allVehicles As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)
        Dim someVehicles As New List(Of String)()

        someVehicles.Add("Planes")
        someVehicles.Add("Trains")
        someVehicles.Add("Automobiles")

        ' Add in the vehicles contained in the someVehicles list.
        allVehicles.UnionWith(someVehicles)

        Console.WriteLine("The current HashSet contains:" + vbNewLine)
        For Each vehicle As String In allVehicles
            Console.WriteLine(vehicle)
        Next vehicle

        allVehicles.Add("Ships")
        allVehicles.Add("Motorcycles")
        allVehicles.Add("Rockets")
        allVehicles.Add("Helicopters")
        allVehicles.Add("Submarines")

        Console.WriteLine(vbNewLine + "The updated HashSet contains:" + vbNewLine)
        For Each vehicle As String In allVehicles
            Console.WriteLine(vehicle)
        Next vehicle

        ' Verify that the 'All Vehicles' set contains at least the vehicles in
        ' the 'Some Vehicles' list.
        If allVehicles.IsSupersetOf(someVehicles) Then
            Console.Write(vbNewLine + "The 'All' vehicles set contains everything in ")
            Console.WriteLine("'Some' vechicles list.")
        End If

        ' Check for Rockets. Here the OrdinalIgnoreCase comparer will compare
        ' True for the mixed-case vehicle type.
        If allVehicles.Contains("roCKeTs") Then
            Console.WriteLine(vbNewLine + "The 'All' vehicles set contains 'roCKeTs'")
        End If

        allVehicles.ExceptWith(someVehicles)
        Console.WriteLine(vbNewLine + "The excepted HashSet contains:" + vbNewLine)
        For Each vehicle As String In allVehicles
            Console.WriteLine(vehicle)
        Next vehicle

        ' Remove all the vehicles that are not 'super cool'.
        allVehicles.RemoveWhere(AddressOf isNotSuperCool)

        Console.WriteLine(vbNewLine + "The super cool vehicles are:" + vbNewLine)
        For Each vehicle As String In allVehicles
            Console.WriteLine(vehicle)
        Next vehicle
    End Sub

    ' Predicate to determine vehicle 'coolness'.
    Private Shared Function isNotSuperCool(vehicle As String) As Boolean
        Dim notSuperCool As Boolean = _
            (vehicle <> "Helicopters") And (vehicle <> "Motorcycles")

        Return notSuperCool
    End Function
End Class

'
' The program writes the following output to the console.
'
' The current HashSet contains:
'
' Planes
' Trains
' Automobiles
'
' The updated HashSet contains:
'
' Planes
' Trains
' Automobiles
' Ships
' Motorcycles
' Rockets
' Helicopters
' Submarines
'
' The 'All' vehicles set contains everything in 'Some' vechicles list.
'
' The 'All' vehicles set contains 'roCKeTs'
'
' The excepted HashSet contains:
'
' Ships
' Motorcycles
' Rockets
' Helicopters
' Submarines
'
' The super cool vehicles are:
'
' Motorcycles
' Helicopters
'</snippet03>
