Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks

Public Class FindFilesProgressInfo
End Class

Module Examples
    ' <CancellationParameter>
    Public Function ReadAsync(buffer As Byte(), offset As Integer, count As Integer,
                              cancellationToken As CancellationToken) As Task
    ' </CancellationParameter>
        Return Task.Run(Sub() Thread.Sleep(1), cancellationToken)
    End Function

    ' <ProgressParameter>
    Public Function ReadAsync(buffer As Byte(), offset As Integer, count As Integer,
                              progress As IProgress(Of Long)) As Task
    ' </ProgressParameter>
        Return Task.Run(Sub() Thread.Sleep(1))
    End Function

    ' <ProgressTupleParameter>
    Public Function FindFilesAsync(
        pattern As String,
        progress As IProgress(Of Tuple(Of Double, ReadOnlyCollection(Of List(Of FileInfo))))) As Task(Of ReadOnlyCollection(Of FileInfo))
    ' </ProgressTupleParameter>
        Return Task.FromResult(New ReadOnlyCollection(Of FileInfo)(Array.Empty(Of FileInfo)()))
    End Function

    ' <ProgressInfoParameter>
    Public Function FindFilesAsync(
        pattern As String,
        progress As IProgress(Of FindFilesProgressInfo)) As Task(Of ReadOnlyCollection(Of FileInfo))
    ' </ProgressInfoParameter>
        Return Task.FromResult(New ReadOnlyCollection(Of FileInfo)(Array.Empty(Of FileInfo)()))
    End Function
End Module

Module Program
    Sub Main(args As String())
    End Sub
End Module
