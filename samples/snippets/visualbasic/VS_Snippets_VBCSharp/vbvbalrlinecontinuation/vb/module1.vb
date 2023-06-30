Imports System.Diagnostics
Imports System.Collections.Generic

Public Module Module1

    Sub Main()
        'RunAll()
    End Sub

    '<Snippet1>
    Public Function GetUsername(ByVal username As String,
                                ByVal delimiter As Char,
                                ByVal position As Integer) As String

        Return username.Split(delimiter)(position)
    End Function
    '</Snippet1>

    Private Sub RunAll()
        '<Snippet2>
        Dim username = GetUsername(
            Security.Principal.WindowsIdentity.GetCurrent().Name,
            CChar("\"),
            1
          )
        '</Snippet2>

        '<Snippet3>
        Dim customer = New Customer With {
          .Name = "Terry Adams",
          .Company = "Adventure Works",
          .Email = "terry@www.adventure-works.com"
        }
        '</Snippet3>

        '<Snippet4>
        Dim customerXml = <Customer>
                              <Name>
                                  <%=
                                      customer.Name
                                  %>
                              </Name>
                              <Email>
                                  <%=
                                      customer.Email
                                  %>
                              </Email>
                          </Customer>
        '</Snippet4>

        Dim filePath = "file path"
        Try
            '<Snippet5>
            Dim fileStream =
              My.Computer.FileSystem.
                OpenTextFileReader(filePath)
            '</Snippet5>


            '<Snippet14>
            ' Not allowed:
            ' Dim aType = New With { .
            '    PropertyName = "Value"

            ' Allowed:
            Dim aType = New With {.PropertyName =
                "Value"}



            Dim log As New EventLog()

            ' Not allowed:
            ' With log
            '    .
            '      Source = "Application"
            ' End With

            ' Allowed:
            With log
                .Source =
                  "Application"
            End With
            '</Snippet14>
        Catch
        End Try

        '<Snippet7>
        Dim memoryInUse =
          My.Computer.Info.TotalPhysicalMemory +
          My.Computer.Info.TotalVirtualMemory -
          My.Computer.Info.AvailablePhysicalMemory -
          My.Computer.Info.AvailableVirtualMemory
        '</Snippet7>

        Dim inStream As New Object
        '<Snippet8>
        If TypeOf inStream Is 
          IO.FileStream AndAlso
          inStream IsNot
          Nothing Then

            ReadFile(inStream)

        End If
        '</Snippet8>

        '<Snippet9>
        Dim customerName = customerXml.
          <Name>.Value

        Dim customerEmail = customerXml...
          <Email>.Value
        '</Snippet9>

        '<Snippet11>
        Dim vsProcesses = From proc In
                            Process.GetProcesses
                          Where proc.MainWindowTitle.Contains("Visual Studio")
                          Select proc.ProcessName, proc.Id,
                                 proc.MainWindowTitle
        '</Snippet11>

        Console.WriteLine(username)
        Console.WriteLine(customerXml)
        Console.WriteLine(memoryInUse / 1000000)

        '<Snippet12>
        For Each p In
          vsProcesses

            Console.WriteLine("{0}" & vbTab & "{1}" & vbTab & "{2}",
              p.ProcessName,
              p.Id,
              p.MainWindowTitle)
        Next
        '</Snippet12>

        '<Snippet13>
        Dim days = New List(Of String) From
          {
           "Mo", "Tu", "We", "Th", "F", "Sa", "Su"
          }
        '</Snippet13>
    End Sub

    Sub ReadFile(ByVal inStream As Object)

    End Sub
End Module

'<Snippet10>
<
Serializable()
>
Public Class Customer
    Public Property Name As String
    Public Property Company As String
    Public Property Email As String
End Class
'</Snippet10>
