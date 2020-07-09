' Visual Basic .NET Document
Option Strict On
Option Infer On

' <Snippet2>
Imports System.Collections
Imports System.Collections.Generic
Imports System.Resources

Module Example
    Public Sub Main()
        Dim resxFile As String = ".\CarResources.resx"
        Dim autos As New List(Of Automobile)
        Dim headers As New SortedList()

        Using resxReader As New ResXResourceReader(resxFile)
            For Each entry As DictionaryEntry In resxReader
                If CType(entry.Key, String).StartsWith("EarlyAuto") Then
                    autos.Add(CType(entry.Value, Automobile))
                Else If CType(entry.Key, String).StartsWith("Header") Then
                    headers.Add(CType(entry.Key, String), CType(entry.Value, String))
                End If
            Next
        End Using
        Dim headerColumns(headers.Count - 1) As String
        headers.GetValueList().CopyTo(headerColumns, 0)
        Console.WriteLine("{0,-8} {1,-10} {2,-4}   {3,-5}   {4,-9}",
                          headerColumns)
        Console.WriteLine()
        For Each auto In autos
            Console.WriteLine("{0,-8} {1,-10} {2,4}   {3,5}   {4,9}",
                              auto.Make, auto.Model, auto.Year,
                              auto.Doors, auto.Cylinders)
        Next
    End Sub
End Module
' The example displays the following output:
'       Make     Model      Year   Doors   Cylinders
'       
'       Ford     Model N    1906       0           4
'       Ford     Model T    1909       2           4
' </Snippet2>


<Serializable()> Public Class Automobile
    Private carMake As String
    Private carModel As String
    Private carYear As Integer
    Private carDoors AS Integer
    Private carCylinders As Integer

    Public Sub New(make As String, model As String, year As Integer)
        Me.New(make, model, year, 0, 0)
    End Sub

    Public Sub New(make As String, model As String, year As Integer,
                   doors As Integer, cylinders As Integer)
        Me.carMake = make
        Me.carModel = model
        Me.carYear = year
        Me.carDoors = doors
        Me.carCylinders = cylinders
    End Sub

    Public ReadOnly Property Make As String
        Get
            Return Me.carMake
        End Get
    End Property

    Public ReadOnly Property Model As String
        Get
            Return Me.carModel
        End Get
    End Property

    Public ReadOnly Property Year As Integer
        Get
            Return Me.carYear
        End Get
    End Property

    Public ReadOnly Property Doors As Integer
        Get
            Return Me.carDoors
        End Get
    End Property

    Public ReadOnly Property Cylinders As Integer
        Get
            Return Me.carCylinders
        End Get
    End Property
End Class
