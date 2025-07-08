' Visual Basic .NET Document
Option Strict On

' <Snippet8>
Imports System.Collections.Generic
Imports System.Runtime.CompilerServices

Public Module StringExtensions
   <Extension()>
   Public Function ToString2(Of T)(l As List(Of T)) As String
      Dim retVal As String = ""
      For Each item As T In l
         retVal += String.Format("{0}{1}", If(String.IsNullOrEmpty(retVal),
                                                     "", ", "),
                                  item)
      Next
      Return If(String.IsNullOrEmpty(retVal), "{}", "{ " + retVal + " }")
   End Function

   <Extension()>
   Public Function ToString(Of T)(l As List(Of T), fmt As String) As String
      Dim retVal As String = String.Empty
      For Each item In l
         Dim ifmt As IFormattable = TryCast(item, IFormattable)
         If ifmt IsNot Nothing Then
            retVal += String.Format("{0}{1}",
                                    If(String.IsNullOrEmpty(retval),
                                       "", ", "), ifmt.ToString(fmt, Nothing))
         Else
            retVal += ToString2(l)
         End If
      Next
      Return If(String.IsNullOrEmpty(retVal), "{}", "{ " + retVal + " }")
   End Function
End Module

Module Example2
    Public Sub Main()
        Dim list As New List(Of Integer)
        list.Add(1000)
        list.Add(2000)
        Console.WriteLine(list.ToString2())
        Console.WriteLine(list.ToString("N0"))
    End Sub
End Module
' The example displays the following output:
'       { 1000, 2000 }
'       { 1,000, 2,000 }
' </Snippet8>
