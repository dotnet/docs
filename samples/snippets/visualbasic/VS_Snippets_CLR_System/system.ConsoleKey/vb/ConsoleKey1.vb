' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Text

Module ConsoleKeyExample

   Public Sub Main()
      Dim input As ConsoleKeyInfo
      Do 
         Console.WriteLine("Press a key, together with Alt, Ctrl, or Shift.")
         Console.WriteLine("Press Esc to exit.")
         input = Console.ReadKey(True)

         Dim output As New StringBuilder(String.Format("You pressed {0}", input.Key.ToString()))
         Dim modifiers As Boolean

         If (input.Modifiers And ConsoleModifiers.Alt) = ConsoleModifiers.Alt Then
            output.Append(", together with " + ConsoleModifiers.Alt.ToString())
            modifiers = True
         End If
         If (input.Modifiers And ConsoleModifiers.Control) = ConsoleModifiers.Control Then
            If modifiers Then
               output.Append(" and ")
            Else
               output.Append(", together with ")
               modifiers = True
            End If
            output.Append(ConsoleModifiers.Control.ToString)
         End If
         If (input.Modifiers And ConsoleModifiers.Shift) = ConsoleModifiers.Shift Then
            If modifiers Then
               output.Append(" and ")
            Else
               output.Append(", together with ")
            End If
            output.Append(ConsoleModifiers.Shift.ToString)
         End If
         output.Append(".")                  
         Console.WriteLine(output.ToString())
         Console.WriteLine()
      Loop While input.Key <> ConsoleKey.Escape        
   End Sub
End Module
' The output from a sample console session might appear as follows:
'       Press a key, along with Alt, Ctrl, or Shift.
'       Press Esc to exit.
'       You pressed D.
'       
'       Press a key, along with Alt, Ctrl, or Shift.
'       Press Esc to exit.
'       You pressed X, along with Shift.
'       
'       Press a key, along with Alt, Ctrl, or Shift.
'       Press Esc to exit.
'       You pressed L, along with Control and Shift.
'       
'       Press a key, along with Alt, Ctrl, or Shift.
'       Press Esc to exit.
'       You pressed P, along with Alt and Control and Shift.
'       
'       Press a key, along with Alt, Ctrl, or Shift.
'       Press Esc to exit.
'       You pressed Escape. 
' </Snippet1>

