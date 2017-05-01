' Visual Basic .NET Document
Option Strict On

Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Threading
Imports System.Threading.Tasks

Module Example
   Public Sub Main()

   End Sub

   ' <Snippet1>
   Public Function ReadAsync(buffer() As Byte, offset As Integer, 
                             count As Integer, 
                             cancellationToken As CancellationToken) _ 
                             As Task
   ' </Snippet1>
      Return Task.Factory.StartNew( Sub() Thread.Sleep(100) )
   End Function
   
   ' <Snippet2>
   Public Function ReadAsync(buffer() As Byte, offset As Integer, 
                             count As Integer, 
                             progress As IProgress(Of Long)) As Task 
   ' </Snippet2>
      Return Task.Factory.StartNew( Sub() Thread.Sleep(100) )
   End Function    
   

   ' <Snippet3>
   Public Function FindFilesAsync(pattern As String, 
                                  progress As IProgress(Of Tuple(Of Double, ReadOnlyCollection(Of List(Of FileInfo))))) _
                                  As  Task(Of ReadOnlyCollection(Of FileInfo))
   ' </Snippet3>
      Return Task.Factory.StartNew( Function() 
                                       Dim fi(9) As FileInfo 
                                       Return New ReadOnlyCollection(Of FileInfo)(fi) 
                                    End Function )   
   End Function               

   ' <Snippet4>
   Public Function FindFilesAsync(pattern As String, 
                                  progress As IProgress(Of FindFilesProgressInfo)) _
                                  As Task(Of ReadOnlyCollection(Of FileInfo))
   ' </Snippet4>                     
      Return Task.Factory.StartNew( Function() 
                                       Dim fi(9) As FileInfo 
                                       Return New ReadOnlyCollection(Of FileInfo)(fi) 
                                    End Function )   
   End Function
End Module

Public Class FindFilesProgressInfo
End Class
