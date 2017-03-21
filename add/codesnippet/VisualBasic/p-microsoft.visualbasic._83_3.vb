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