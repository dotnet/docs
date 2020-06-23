Imports System.Diagnostics

Public Class Class1


  '<Snippet8>
  Declare Function GetWindowRect Lib "user32" (
      ByVal hwnd As Integer, ByRef lpRect As RECT) As Integer
  '</Snippet8>

  '<Snippet9>

  Public Structure RECT
      Public Left As Integer
      Public Top As Integer
      Public Right As Integer
      Public Bottom As Integer
  End Structure
  '</Snippet9>

  '<Snippet10>

  Const ERROR_INVALID_WINDOW_HANDLE As Long = 1400
  Const ERROR_INVALID_WINDOW_HANDLE_DESCR As String = 
      "Invalid window handle."
  '</Snippet10>


'****************************************************************************
'<Snippet20>
Public Sub OnErrorDemo()
   On Error GoTo ErrorHandler   ' Enable error-handling routine.
   Dim x As Integer = 32
   Dim y As Integer = 0
   Dim z As Integer
   z = x / y   ' Creates a divide by zero error
   On Error GoTo 0   ' Turn off error trapping.
   On Error Resume Next   ' Defer error trapping.
   z = x / y   ' Creates a divide by zero error again
   If Err.Number = 6 Then
      ' Tell user what happened. Then clear the Err object.
      Dim Msg As String
      Msg = "There was an error attempting to divide by zero!"
      MsgBox(Msg, , "Divide by zero error")
      Err.Clear() ' Clear Err object fields.
   End If
Exit Sub      ' Exit to avoid handler.
ErrorHandler:  ' Error-handling routine.
   Select Case Err.Number   ' Evaluate error number.
      Case 6   ' Divide by zero error
         MsgBox("You attempted to divide by zero!")
         ' Insert code to handle this error
      Case Else
         ' Insert code to handle other situations here...
   End Select
   Resume Next  ' Resume execution at the statement immediately 
                ' following the statement where the error occurred.
End Sub
'</Snippet20>


'****************************************************************************
'<Snippet18>
Public Sub InitializeMatrix(ByVal Var1 As Object, ByVal Var2 As Object)
   On Error GoTo ErrorHandler
   ' Insert code that might generate an error here
   Exit Sub
ErrorHandler:
   ' Insert code to handle the error here
   Resume Next
End Sub
'</Snippet18>


'****************************************************************************
Shared Sub DoSomeMath()
'<Snippet17>
    On Error GoTo Handler
    Throw New DivideByZeroException()
Handler:
    If (TypeOf Err.GetException() Is DivideByZeroException) Then
    ' Code for handling the error is entered here.
    End If
'</Snippet17>
End Sub


'****************************************************************************
'<Snippet16>
Sub ResumeStatementDemo()
  On Error GoTo ErrorHandler   ' Enable error-handling routine.
  Dim x As Integer = 32
  Dim y As Integer = 0
  Dim z As Integer
  z = x / y   ' Creates a divide by zero error
  Exit Sub   ' Exit Sub to avoid error handler.
ErrorHandler:     ' Error-handling routine.
  Select Case Err.Number   ' Evaluate error number.
      Case 6   ' "Divide by zero" error.
        y = 1 ' Sets the value of y to 1 and tries the calculation again.
      Case Else
        ' Handle other situations here....
  End Select
  Resume   ' Resume execution at same line
  ' that caused the error.
End Sub
'</Snippet16>


 '****************************************************************************
  '<Snippet15>
  Public Class Class1
    Public Sub MySub()
        On Error Resume Next
        Err.Raise(60000, "Class1")
        MsgBox(Err.Source & " caused an error of type " & Err.Number)
    End Sub
  End Class
  '</Snippet15>

    '****************************************************************************
    '<Snippet12>
    ' Typical use of Number property.
Sub test()
  On Error GoTo out

  Dim x, y As Integer
  x = 1 / y   ' Create division by zero error.
  Exit Sub
out:
  MsgBox(Err.Number)
  MsgBox(Err.Description)
  ' Check for division by zero error.
  If Err.Number = 11 Then
      y = y + 1
  End If
  Resume Next
End Sub
'</Snippet12>



  '****************************************************************************
  '<Snippet11>
  Private Sub PrintWindowCoordinates(ByVal hwnd As Integer)
  ' Prints left, right, top, and bottom positions
  ' of a window in pixels.

    Dim rectWindow As RECT

    ' Pass in window handle and empty the data structure.
    ' If function returns 0, an error occurred.
    If GetWindowRect(hwnd, rectWindow) = 0 Then
        ' Check LastDllError and display a dialog box if the error
        ' occurred because an invalid handle was passed.
        If Err.LastDllError = ERROR_INVALID_WINDOW_HANDLE Then
            MsgBox(ERROR_INVALID_WINDOW_HANDLE_DESCR, Title:="Error!")
        End If
    Else
        Debug.Print(rectWindow.Bottom)
        Debug.Print(rectWindow.Left)
        Debug.Print(rectWindow.Right)
        Debug.Print(rectWindow.Top)
    End If
  End Sub
  '</Snippet11>


  '****************************************************************************
  Shared Sub TestHelp()
    '<Snippet7>
    Dim Msg As String
    Err.Clear()
    On Error Resume Next   ' Suppress errors for demonstration purposes.
    Err.Raise(6)   ' Generate "Overflow" error.
    If Err.Number <> 0 Then
      Msg = "Press F1 or HELP to see " & Err.HelpFile & " topic for" & 
      " the following HelpContext: " & Err.HelpContext
      MsgBox(Msg, , "Error:")
    End If
    '</Snippet7>
  End Sub


  '****************************************************************************
  Shared Sub TestErl()
'<Snippet6>
10:     On Error Resume Next
20:     Err.Raise(60000)
' Returns 20.
30:     MsgBox(Erl())
'</Snippet6>
  End Sub


  '****************************************************************************
  Shared Sub TestErrDesc()
    '<Snippet5>
    On Error Resume Next
    Err.Raise(60000)
    Err.Description = "Your Widget needs a new Frob!"
    MsgBox(Err.Description)
    '</Snippet5>
  End Sub


  '****************************************************************************
  '<Snippet4>
  Sub ClearErr()
    ' Produce overflow error
    On Error Resume Next
    Dim zero As Integer = 0
    Dim result As Integer = 8 / zero
    MsgBox(Err.Description)
    Err.Clear()
    MsgBox(Err.Description)
  End Sub
  '</Snippet4>


  '****************************************************************************
  Shared Sub TestErrObject()
    '<Snippet3>
    Dim Msg As String
    ' If an error occurs, construct an error message.
    On Error Resume Next   ' Defer error handling.
    Err.Clear()
    Err.Raise(6)   ' Generate an "Overflow" error.
    ' Check for error, then show message.
    If Err.Number <> 0 Then
      Msg = "Error # " & Str(Err.Number) & " was generated by " &
            Err.Source & ControlChars.CrLf & Err.Description
      MsgBox(Msg, MsgBoxStyle.Information, "Error")
    End If
    '</Snippet3>
  End Sub


  '****************************************************************************
  Shared Sub TestErr()
    Err.Number = 53

    '<Snippet1>
    If Err.Number = 53 Then
      MsgBox("File Not Found")
    End If
    '</Snippet1>

    On Error Resume Next

    '<Snippet13>
    Err.Raise(Number:=vbObjectError + 1051, Source:="SomeClass")
    '</Snippet13>

    '<Snippet19>
    Err.Number = vbObjectError + 1052
    '</Snippet19>

    MsgBox(Err.Number)

    '<Snippet2>
    MsgBox(Err.Description)
    '</Snippet2>

    '<Snippet21>
    Throw New ApplicationException
    ' Code to react to possible causes of the exception.
    '</Snippet21>
  End Sub
End Class

'****************************************************************************
'<Snippet14>
Module Module1

    Const WidthErrorNumber As Integer = 1000
    Const WidthHelpOffset As Object = 100

    Sub Main()
        CallingProcedure()
    End Sub

    Sub TestWidth(ByVal width As Integer)
        If width > 1000 Then
            ' Replace HelpFile.hlp with the full path to an appropriate
            ' help file for the error. Notice that you add the error 
            ' number you want to use to the vbObjectError constant. 
            ' This assures that it will not conflict with a Visual
            ' Basic error.
            Err.Raise(vbObjectError + WidthErrorNumber, "ConsoleApplication1.Module1.TestWidth", 
                "Width must be less than 1000.", "HelpFile.hlp", WidthHelpOffset)
        End If
    End Sub

    Sub CallingProcedure()
        Try
            ' The error is raised in TestWidth.
            TestWidth(2000)
        Catch ex As Exception
            ' The Err object can access a number of pieces of
            ' information about the error.
            Console.WriteLine("Information available from Err object:")
            Console.WriteLine(Err.Number)
            Console.WriteLine(Err.Description)
            Console.WriteLine(Err.Source)
            Console.WriteLine(Err.HelpFile)
            Console.WriteLine(Err.HelpContext)
            Console.WriteLine(Err.GetException)

            Console.WriteLine(vbCrLf & "Information available from Exception object:")
            Console.WriteLine(ex.Message)
            Console.WriteLine(ex.ToString)

            Err.Clear()
        End Try
    End Sub
End Module

' The example produces the following output:
' Information available from Err object:
' -2147220504
' Width must be less than 1000.
' ConsoleApplication1.Module1.TestWidth
' HelpFile.hlp
' 100
' System.Exception: Width must be less than 1000.
'    at Microsoft.VisualBasic.ErrObject.Raise(Int32 Number, Object Source, Object
' Description, Object HelpFile, Object HelpContext)
'    at ConsoleApplication1.Module1.TestWidth(Int32 width) in C:\Users\example\App
' Data\Local\Temporary Projects\ConsoleApplication1\Module1.vb:line 17
'    at ConsoleApplication1.Module1.CallingProcedure() in C:\Users\example\AppData
' \Local\Temporary Projects\ConsoleApplication1\Module1.vb:line 25
'
' Information available from Exception object:
' Width must be less than 1000.
' System.Exception: Width must be less than 1000.
'    at Microsoft.VisualBasic.ErrObject.Raise(Int32 Number, Object Source, Object
' Description, Object HelpFile, Object HelpContext)
'    at ConsoleApplication1.Module1.TestWidth(Int32 width) in C:\Users\example\App
' Data\Local\Temporary Projects\ConsoleApplication1\Module1.vb:line 17
'    at ConsoleApplication1.Module1.CallingProcedure() in C:\Users\example\AppData
' \Local\Temporary Projects\ConsoleApplication1\Module1.vb:line 25
'</Snippet14>