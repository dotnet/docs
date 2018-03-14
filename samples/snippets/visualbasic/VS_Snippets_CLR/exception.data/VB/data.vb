' <Snippet1>
Imports System.Collections

Module Example
   Public Sub Main()
      Console.WriteLine()
      Console.WriteLine("Exception with some extra information...")
      RunTest(False)
      Console.WriteLine()
      Console.WriteLine("Exception with all extra information...")
      RunTest(True)
   End Sub

   Public Sub RunTest(displayDetails As Boolean)
      Try
         NestedRoutine1(displayDetails)
      Catch e As Exception
         Console.WriteLine("An exception was thrown.")
         Console.WriteLine(e.Message)
         If e.Data.Count > 0 Then
            Console.WriteLine("  Extra details:")
            For Each de As DictionaryEntry In e.Data
               Console.WriteLine("    Key: {0,-20}      Value: {1}",
                                 "'" + de.Key.ToString() + "'", de.Value)
            Next
         End If 
      End Try 
   End Sub 

   Public Sub NestedRoutine1(displayDetails As Boolean)
      Try
         NestedRoutine2(displayDetails)
      Catch e As Exception
         e.Data("ExtraInfo") = "Information from NestedRoutine1."
         e.Data.Add("MoreExtraInfo", "More information from NestedRoutine1.")
         Throw e
      End Try 
   End Sub

   Public Sub NestedRoutine2(displayDetails As Boolean)
      Dim e As New Exception("This statement is the original exception message.")
      If displayDetails Then 
         Dim s As String = "Information from NestedRoutine2." 
         Dim i As Integer = -903
         Dim dt As DateTime = DateTime.Now
         e.Data.Add("stringInfo", s)
         e.Data("IntInfo") = i
         e.Data("DateTimeInfo") = dt
      End If 
      Throw e
   End Sub 
End Module
' This example displays the following output: 
'    Exception with some extra information...
'    An exception was thrown.
'    This statement is the original exception message.
'      Extra details:
'        Key: 'ExtraInfo'               Value: Information from NestedRoutine1.
'        Key: 'MoreExtraInfo'           Value: More information from NestedRoutine1.
'    
'    Exception with all extra information...
'    An exception was thrown.
'    This statement is the original exception message.
'      Extra details:
'        Key: 'stringInfo'              Value: Information from NestedRoutine2.
'        Key: 'IntInfo'                 Value: -903
'        Key: 'DateTimeInfo'            Value: 7/29/2013 10:50:13 AM
'        Key: 'ExtraInfo'               Value: Information from NestedRoutine1.
'        Key: 'MoreExtraInfo'           Value: More information from NestedRoutine1. 
' </Snippet1>
