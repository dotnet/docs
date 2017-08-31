Imports System.Windows.Forms

Public Class Form1
    Inherits Form
End Class

Public Class Form2
    Inherits Form

    '********************************************************************  
    '<Snippet7>
    Sub SetFormIcon()
        Me.Icon = My.Resources.Form1Icon
    End Sub
    '</Snippet7>

    Sub Test()

        '********************************************************************  
        '<Snippet6>
        ' With My.Forms, you can directly call methods on the default 
        ' instance()
        My.Forms.Form1.Show()
        '</Snippet6>

        '********************************************************************  
        '<Snippet5>
        ' The old method of declaration and instantiation
        Dim myForm As New Form1
        myForm.show()
        '</Snippet5>

        '********************************************************************  
        '<Snippet3>
        ' Changes the current culture for the application to Jamaican English.
        My.Application.ChangeCulture("en-JM")
        '</Snippet3>

        '********************************************************************  
        '<Snippet2>
        ' Gets a list of subfolders in a folder
        My.Computer.FileSystem.GetDirectories(
          My.Computer.FileSystem.SpecialDirectories.MyDocuments, True, "*Logs*")
        '</Snippet2>

        '********************************************************************  
        '<Snippet1>
        ' Displays a message box that shows the full command line for the
        ' application.
        Dim args As String = ""
        For Each arg As String In My.Application.CommandLineArgs
            args &= arg & " "
        Next
        MsgBox(args)
        '</Snippet1>
    End Sub
End Class

'********************************************************************  
Namespace My
    '******************************************************
    Namespace Resources
        <Global.Microsoft.VisualBasic.HideModuleNameAttribute()> 
         Friend Module FakeResources
            Public Form1Icon As System.Drawing.Icon
        End Module
    End Namespace
End Namespace