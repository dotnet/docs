Imports System.Deployment.Application

Module Example
   Public Sub Main()
      Dim ver As Version = ApplicationDeployment.CurrentDeployment.CurrentVersion
      Console.WriteLine("ClickOnce Publish Version: {0}", ver)
   End Sub
End Module