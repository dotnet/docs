' Visual Basic .NET Document
Option Strict On

' <Snippet7>
Imports System.Deployment.Application

Module Example0
    Public Sub Main()
        Dim ver As Version = ApplicationDeployment.CurrentDeployment.CurrentVersion
        Console.WriteLine("ClickOnce Publish Version: {0}", ver)
    End Sub
End Module
' </Snippet7>
