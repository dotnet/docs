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
        End Sub

        ' Opens URLs and .html documents using Internet Explorer.
        Sub OpenWithArguments()
            ' URLs are not considered documents. They can only be opened
            ' by passing them as arguments.
            Process.Start("IExplore.exe", "www.northwindtraders.com")

            ' Start a Web page using a browser associated with .html and .asp files.
            Process.Start("IExplore.exe", "C:\myPath\myFile.htm")
            Process.Start("IExplore.exe", "C:\myPath\myFile.asp")
        End Sub

        ' Uses the ProcessStartInfo class to start new processes,
        ' both in a minimized mode.
        Sub OpenWithStartInfo()
            Dim startInfo As New ProcessStartInfo("IExplore.exe")
            startInfo.WindowStyle = ProcessWindowStyle.Minimized

            Process.Start(startInfo)

            startInfo.Arguments = "www.northwindtraders.com"

            Process.Start(startInfo)
        End Sub

        Shared Sub Main()
            ' Get the path that stores favorite links.
            Dim myFavoritesPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Favorites)

            Dim myProcess As New MyProcess()

            myProcess.OpenApplication(myFavoritesPath)
            myProcess.OpenWithArguments()
            myProcess.OpenWithStartInfo()
        End Sub
    End Class
End Namespace 'MyProcessSample