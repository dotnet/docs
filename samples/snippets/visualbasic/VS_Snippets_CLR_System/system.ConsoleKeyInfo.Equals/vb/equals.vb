'<snippet1>
' This example demonstrates the ConsoleKeyInfo.Equals() method.
Imports System
Imports System.Text

Class Sample
    Public Shared Sub Main() 
        Dim k1 As String = vbCrLf & "Enter a key ......... "
        Dim k2 As String = vbCrLf & "Enter another key ... "
        Dim key1 As String = ""
        Dim key2 As String = ""
        Dim areKeysEqual As String = "The {0} and {1} keys are {2}equal."
        Dim equalValue As String = ""
        Dim prompt As String = "Press the escape key (ESC) to quit, " & _
                               "or any other key to continue."
        Dim cki1 As ConsoleKeyInfo
        Dim cki2 As ConsoleKeyInfo
        
        '
        ' The Console.TreatControlCAsInput property prevents this example from
        ' ending if you press CTL+C, however all other operating system keys and 
        ' shortcuts, such as ALT+TAB or the Windows Logo key, are still in effect. 
        '
        Console.TreatControlCAsInput = True
        
        ' Request that the user enter two key presses. A key press and any 
        ' combination shift, CTRL, and ALT modifier keys is permitted.
        Do
            Console.Write(k1)
            cki1 = Console.ReadKey(False)
            Console.Write(k2)
            cki2 = Console.ReadKey(False)
            Console.WriteLine()
            '
            key1 = KeyCombination(cki1)
            key2 = KeyCombination(cki2)
            If cki1.Equals(cki2) Then
                equalValue = ""
            Else
                equalValue = "not "
            End If
            Console.WriteLine(areKeysEqual, key1, key2, equalValue)
            '
            Console.WriteLine(prompt)
            cki1 = Console.ReadKey(True)
        Loop While cki1.Key <> ConsoleKey.Escape
    
    End Sub 'Main
    ' Note: This example requires the Escape (Esc) key.
    
    ' The KeyCombination() method creates a string that specifies what 
    ' key and what combination of shift, CTRL, and ALT modifier keys 
    ' were pressed simultaneously.
    Protected Shared Function KeyCombination(ByVal sourceCki As ConsoleKeyInfo) As String 
        Dim sb As New StringBuilder()
        sb.Length = 0
        Dim keyCombo As String
        If sourceCki.Modifiers <> 0 Then
            If(sourceCki.Modifiers And ConsoleModifiers.Alt) <> 0 Then
                sb.Append("ALT+")
            End If
            If(sourceCki.Modifiers And ConsoleModifiers.Shift) <> 0 Then
                sb.Append("SHIFT+")
            End If
            If(sourceCki.Modifiers And ConsoleModifiers.Control) <> 0 Then
                sb.Append("CTL+")
            End If
        End If
        sb.Append(sourceCki.Key.ToString())
        keyCombo = sb.ToString()
        Return keyCombo
    
    End Function 'KeyCombination
End Class 'Sample

'
'This example produces results similar to the following output:
'
'Enter a key ......... a
'Enter another key ... a
'The A and A keys are equal.
'Press the escape key (ESC) to quit, or any other key to continue.
'
'Enter a key ......... a
'Enter another key ... A
'The A and SHIFT+A keys are not equal.
'Press the escape key (ESC) to quit, or any other key to continue.
'
'Enter a key ......... S
'Enter another key ...
'The ALT+SHIFT+S and ALT+CTL+F keys are not equal.
'Press the escape key (ESC) to quit, or any other key to continue.
'
'Enter a key .........
'Enter another key ...
'The UpArrow and UpArrow keys are equal.
'Press the escape key (ESC) to quit, or any other key to continue.
'
'</snippet1>