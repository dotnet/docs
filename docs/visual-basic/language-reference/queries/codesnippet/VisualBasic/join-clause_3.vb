Imports System.Diagnostics
Imports System.Security.Permissions

Public Class JoinSample2

  <SecurityPermission(SecurityAction.Demand)>
  Public Sub ListProcesses()
    Dim processDescriptions As New List(Of ProcessDescription2)

    ' 8 = Normal priority, 13 = High priority
    processDescriptions.Add(New ProcessDescription2 With {
                                .ProcessName = "explorer",
                                .Description = "Windows Explorer",
                                .Priority = 8})
    processDescriptions.Add(New ProcessDescription2 With {
                                .ProcessName = "winlogon",
                                .Description = "Windows Logon",
                                .Priority = 13})
    processDescriptions.Add(New ProcessDescription2 With {
                                .ProcessName = "cmd",
                                .Description = "Command Window",
                                .Priority = 8})
    processDescriptions.Add(New ProcessDescription2 With {
                                .ProcessName = "iexplore",
                                .Description = "Internet Explorer",
                                .Priority = 8})

    Dim processes = From proc In Process.GetProcesses
                    Join desc In processDescriptions
                      On proc.ProcessName Equals desc.ProcessName And 
                         proc.BasePriority Equals desc.Priority
                    Select proc.ProcessName, proc.Id, desc.Description,
                           desc.Priority

    For Each proc In processes
      Console.WriteLine("{0} ({1}), {2}, Priority = {3}",
                        proc.ProcessName,
                        proc.Id,
                        proc.Description,
                        proc.Priority)
    Next
  End Sub

End Class

Public Class ProcessDescription2
  Public ProcessName As String
  Public Description As String
  Public Priority As Integer
End Class