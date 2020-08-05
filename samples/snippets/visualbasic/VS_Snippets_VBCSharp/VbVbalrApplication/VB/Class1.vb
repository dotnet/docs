Option Explicit On
Option Strict On

' <snippet4>
Imports CtrlChrs = Microsoft.VisualBasic.ControlChars
' </snippet4>

' <snippet9>
Imports LBControl = System.Windows.Forms.ListBox
Imports MyListBox = ListBoxProject.Form1.ListBox
' </snippet9>

' <snippet11>
' This namespace contains a class called Class1.
Imports MyProj1
' This namespace also contains a class called Class1.
Imports MyProj2
' </snippet11>
Namespace MyProj1
    Class Class1
    End Class
End Namespace
Namespace MyProj2
    Class Class2
    End Class
End Namespace

Class Class1
    Sub sub1()
        ' <snippet1>
        Dim pList() As System.Diagnostics.Process =
            System.Diagnostics.Process.GetProcessesByName("notepad")
        For Each proc As System.Diagnostics.Process In pList
            Dim resp As MsgBoxResult
            resp = MsgBox("Terminate " & proc.ProcessName & "?",
                MsgBoxStyle.YesNo, "Terminate?")
            If resp = MsgBoxResult.Yes Then
                proc.Kill()
            End If
        Next
        ' </snippet1>
    End Sub

    Sub sub2()
        ' <snippet2>
        Dim pList() As System.Diagnostics.Process =
            System.Diagnostics.Process.GetProcesses
        For Each proc As System.Diagnostics.Process In pList
            MsgBox(proc.ProcessName)
        Next
        ' </snippet2>
    End Sub

    Sub sub3()
        ' <snippet3>
        MsgBox("Some text" & Microsoft.VisualBasic.ControlChars.CrLf &
               "Some more text")
        ' </snippet3>
        ' <snippet5>
        MsgBox("Some text" & CtrlChrs.CrLf & "Some more text")
        ' </snippet5>
    End Sub

    Class ListBox
    End Class
    Sub sub6()
        ' <snippet6>
        Dim LBox As System.Windows.Forms.ListBox
        ' </snippet6>
        ' <snippet7>
        ' Define a new object based on your ListBox class.
        Dim LBC As New ListBox
        ' Define a new Windows.Forms ListBox control.
        Dim MyLB As New System.Windows.Forms.ListBox
        ' </snippet7>
    End Sub
End Class

Namespace ListBoxProject
    Class Form1
        Class ListBox
        End Class
    End Class
End Namespace

Class class8
    Sub sub8()
        ' <snippet8>
        Dim LBC As New ListBoxProject.Form1.ListBox
        ' </snippet8>
    End Sub
    Sub sub9()
        ' <snippet10>
        Dim LBC As LBControl
        Dim MyLB As MyListBox
        ' </snippet10>
    End Sub
End Class


