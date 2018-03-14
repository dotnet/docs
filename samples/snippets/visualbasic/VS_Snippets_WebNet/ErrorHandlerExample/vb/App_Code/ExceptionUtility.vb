'<Snippet7>
Imports System
Imports System.IO
Imports System.Web

' Create our own utility for exceptions
Public NotInheritable Class ExceptionUtility

    ' All methods are static, so this can be private
    Private Sub New()
        MyBase.New()
    End Sub

    ' Log an Exception
    Public Shared Sub LogException(ByVal exc As Exception, ByVal source As String)
        ' Include enterprise logic for logging exceptions
        ' Get the absolute path to the log file
        Dim logFile = "App_Data/ErrorLog.txt"
        logFile = HttpContext.Current.Server.MapPath(logFile)

        ' Open the log file for append and write the log
        Dim sw = New StreamWriter(logFile, True)
        sw.WriteLine("**** " & DateTime.Now & " ****")
        If exc.InnerException IsNot Nothing Then
            sw.Write("Inner Exception Type: ")
            sw.WriteLine(exc.InnerException.GetType.ToString)
            sw.Write("Inner Exception: ")
            sw.WriteLine(exc.InnerException.Message)
            sw.Write("Inner Source: ")
            sw.WriteLine(exc.InnerException.Source)
            If exc.InnerException.StackTrace IsNot Nothing Then
                sw.WriteLine("Inner Stack Trace: ")
                sw.WriteLine(exc.InnerException.StackTrace)
            End If
        End If
        sw.Write("Exception Type: ")
        sw.WriteLine(exc.GetType.ToString)
        sw.WriteLine("Exception: " & exc.Message)
        sw.WriteLine("Source: " & source)
        If exc.StackTrace IsNot Nothing Then
            sw.WriteLine("Stack Trace: ")
            sw.WriteLine(exc.StackTrace)
        End If
        sw.WriteLine()
        sw.Close()
    End Sub

    ' Notify System Operators about an exception
    Public Shared Sub NotifySystemOps(ByVal exc As Exception)
        ' Include code for notifying IT system operators
    End Sub
End Class
'</Snippet7>
