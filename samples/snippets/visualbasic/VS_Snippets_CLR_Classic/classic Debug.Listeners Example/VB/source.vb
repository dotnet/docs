Imports System
Imports System.Data
Imports System.Diagnostics
Imports System.Windows.Forms



Class Form1
    Inherits Form
    Protected textBox1 As TextBox
    
    
    Protected Sub Method()
        ' <Snippet1>
        ' Create a listener that outputs to the console screen, and 
        ' add it to the debug listeners. 
        Dim myWriter As New TextWriterTraceListener(System.Console.Out)
        Debug.Listeners.Add(myWriter)
        ' </Snippet1>
    End Sub 'Method 
End Class 'Form1 
