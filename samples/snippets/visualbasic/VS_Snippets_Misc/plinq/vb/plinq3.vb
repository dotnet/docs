Option Strict On
Imports System.Collections.Concurrent

Module Example
    Public Sub Main()
        ' <Snippet2>
        Dim arr(10000) As Integer
        Dim partitioner As Partitioner(Of Integer) = New MyArrayPartitioner(Of Integer)(arr)
        Dim query = partitioner.AsParallel().Select(Function(x) SomeFunction(x))
        ' </Snippet2>
    End Sub

    Public Function SomeFunction(x As Integer) As Integer
        Return x * x
    End Function
End Module

Public Class MyArrayPartitioner(Of T) : Inherits Partitioner(Of T)
    Private list As List(Of T) = New List(Of T)()

    Public Sub New(arr As T())
        For Each element in arr
            list.Add(element)
        Next
    End Sub

    Public Overrides Function GetPartitions(partitionCount As Integer) As IList(Of IEnumerator(Of T))
        Dim enumList = new List(Of IEnumerator(Of T))()
        enumList.Add(list.GetEnumerator())
        Return enumList
    End Function
End Class
