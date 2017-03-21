 Public Sub MyHandle()
    ' Gets the current input language.
    Dim myCurrentLanguage As InputLanguage = InputLanguage.CurrentInputLanguage
        
    ' Gets a handle for the language  and prints the number.
    Dim myHandle As IntPtr = myCurrentLanguage.Handle
    textBox1.Text = "The handle number is: " & myHandle.ToString()
 End Sub
