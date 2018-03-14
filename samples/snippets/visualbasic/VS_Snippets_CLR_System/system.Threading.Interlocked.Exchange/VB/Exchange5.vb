' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Imports System.Collections.Generic
Imports System.Threading
Imports System.Threading.Tasks

Public Class Widget
   Public Sub New(id As String)
      Me.Id = id
   End Sub
   
   Public Property Id As String = String.Empty
   Public Property Description As String = String.Empty
End Class


Module Example
   Public Sub Main()
      Dim firstWidget As Widget = Nothing
      Dim tasks As New List(Of Task)()
      For ctr As Integer = 0 To 10
         tasks.Add(Task.Run(Sub()
                               ' Give each task its own random number generator.
                               Dim rnd As New Random()
                               For widgetIndex = 0 To 100
                                  'Generate ten random characters from U+0041 to U+005A.
                                  Dim id As String = String.Empty
                                  For charCtr As Integer = 0 To 9
                                     id += ChrW(rnd.Next(&h0041, &h005B))
                                  Next
                                  Dim newWidget As New Widget(id)
                                  If firstWidget Is Nothing Then
                                     firstWidget = newWidget
                                  Else If newWidget.Id < firstWidget.Id Then
                                     Interlocked.Exchange(firstWidget, newWidget)
                                  End If
                                Next
                             End Sub))
      Next
      Try
         Task.WaitAll(tasks.ToArray())
         Console.WriteLine("The widget with the lowest id: {0}", firstWidget.Id)
      Catch ae As AggregateException
         For Each e In ae.InnerExceptions
            Console.WriteLine("{0}: {1}", e.GetType().Name, e.Message)
         Next
      End Try
   End Sub
End Module
' The example displays output like the following:
'   The widget with the lowest id: ACHZVFBYNU
' </Snippet2>
