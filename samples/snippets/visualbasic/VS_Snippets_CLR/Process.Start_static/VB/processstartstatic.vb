' <Snippet1>
Imports System.Diagnostics
Imports System.ComponentModel

Namespace MyProcessSample
    Class MyProcess
        ' Opens the Internet Explorer application.
        Public Sub OpenApplication(myFavoritesPath As String)
            ' Start Internet Explorer. Defaults to the home page.
            Process.Start("IExplore.exe")

            ' Display the contents of the favorites folder in the browser.
            Process.Start(myFavoritesPath)
        End Sub 'OpenApplication

        ' Opens urls and .html documents using Internet Explorer.
        Sub OpenWithArguments()
            ' url's are not considered documents. They can only be opened
            ' by passing them as arguments.
            Process.Start("IExplore.exe", "www.northwindtraders.com")

            ' Start a Web page using a browser associated with .html and .asp files.
            Process.Start("IExplore.exe", "C:\myPath\myFile.htm")
            Process.Start("IExplore.exe", "C:\myPath\myFile.asp")
        End Sub 'OpenWithArguments

        ' Uses the ProcessStartInfo class to start new processes,
        ' both in a minimized mode.
        Sub OpenWithStartInfo()
            Dim startInfo As New ProcessStartInfo("IExplore.exe")
            startInfo.WindowStyle = ProcessWindowStyle.Minimized

            Process.Start(startInfo)

            startInfo.Arguments = "www.northwindtraders.com"

            Process.Start(startInfo)
        End Sub 'OpenWithStartInfo

        Shared Sub Main()
            ' Get the path that stores favorite links.
            Dim myFavoritesPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Favorites)

            Dim myProcess As New MyProcess()

            myProcess.OpenApplication(myFavoritesPath)
            myProcess.OpenWithArguments()
            myProcess.OpenWithStartInfo()
        End Sub 'Main
    End Class 'MyProcess
End Namespace 'MyProcessSample
' </Snippet1>
' <Snippet2>
' Place this code into a console project called StartArgsEcho. It depends on the
' console application named argsecho.exe.

Module Module1
    Sub Main()
        Dim startInfo As ProcessStartInfo = New ProcessStartInfo("argsecho.exe")
        startInfo.WindowStyle = ProcessWindowStyle.Normal

        ' Start with one argument.
        ' Output of ArgsEcho:
        '  [0]=/a            
        startInfo.Arguments = "/a"
        Process.Start(startInfo)

        ' Start with multiple arguments separated by spaces.
        ' Output of ArgsEcho:
        '  [0] = /a
        '  [1] = /b
        '  [2] = c:\temp
        startInfo.Arguments = "/a /b c:\temp"
        Process.Start(startInfo)

        ' An argument with spaces inside quotes is interpreted as multiple arguments.
        ' Output of ArgsEcho:
        '  [0] = /a
        '  [1] = literal string arg
        startInfo.Arguments = "/a ""literal string arg"" "
        Process.Start(startInfo)

        ' An argument inside double quotes is interpreted as if the quote weren't there,
        ' that is, as separate arguments.
        ' Output of ArgsEcho:
        '  [0] = /a
        '  [1] = /b:string
        '  [2] = in
        '  [3] = double
        '  [4] = quotes
        startInfo.Arguments = "/a /b:""""string in double quotes"""" "
        Process.Start(startInfo)

        ' Triple-escape quotation marks to include the character in the final argument received
        ' by the target process. 
        '  [0] = /a
        '  [1] = /b:"quoted string"
        startInfo.Arguments = "/a /b:""""""quoted string"""""" "
        Process.Start(startInfo)
    End Sub
End Module
' </Snippet2>
' <Snippet3>
' Place this code into a console project called ArgsEcho to build the argsecho.exe target

Module Module1
    Sub Main()
        Dim i As Integer = 0

        For Each s As String In My.Application.CommandLineArgs
            Console.WriteLine("[" + i.ToString() + "] = " + s)
            i = i + 1
        Next

        Console.WriteLine(Environment.NewLine + "Press any key to exit")
        Console.ReadLine()
    End Sub
End Module
' </Snippet3>
