Imports System.Diagnostics
Imports System.Security.Permissions

Public Class JoinSample

  <SecurityPermission(SecurityAction.Demand)>
  Public Sub ListProcesses()
    Dim processDescriptions As New List(Of ProcessDescription)
    processDescriptions.Add(New ProcessDescription With {
                                .ProcessName = "explorer",
                                .Description = "Windows Explorer"})
    processDescriptions.Add(New ProcessDescription With {
                                .ProcessName = "winlogon",
                                .Description = "Windows Logon"})
    processDescriptions.Add(New ProcessDescription With {
                                .ProcessName = "cmd",
                                .Description = "Command Window"})
    processDescriptions.Add(New ProcessDescription With {
                                .ProcessName = "iexplore",
                                .Description = "Internet Explorer"})

    Dim processes = From proc In Process.GetProcesses
                    Join desc In processDescriptions
                      On proc.ProcessName Equals desc.ProcessName
                    Select proc.ProcessName, proc.Id, desc.Description

    For Each proc In processes
      Console.WriteLine("{0} ({1}), {2}",
                        proc.ProcessName, proc.Id, proc.Description)
    Next
  End Sub

End Class

Public Class ProcessDescription
  Public ProcessName As String
  Public Description As String
End Class