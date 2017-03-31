
Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms



Shared Class Program
    
    '/ <summary>
    '/ The main entry point for the application.
    '/ </summary>
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
End Class 'Program