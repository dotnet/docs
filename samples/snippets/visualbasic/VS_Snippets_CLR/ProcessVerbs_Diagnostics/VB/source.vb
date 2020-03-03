' <Snippet1>
' <Snippet3>
Imports System.ComponentModel
Imports System.IO
Imports System.Diagnostics
Imports System.Windows.Forms

Module ProcessInformation
    Public Shared Sub Main()
        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True
        openFileDialog1.CheckFileExists = True

        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim fileName = openFileDialog1.FileName

            ' <Snippet4>
            Dim i = 0
            Dim startInfo = New ProcessStartInfo(fileName)

            Dim verb As String
            For Each verb In startInfo.Verbs
                ' Display the possible verbs.
                Console.WriteLine($"  {i}. {verb}")
                i += 1
            Next

            Console.Write("Select the index of the verb: ")
            Dim indexInput = Console.ReadLine()
            Dim index As Integer
            If Int32.TryParse(indexInput, index) Then
                If index < 0 OrElse index >= i Then
                    Console.WriteLine("Invalid index value.")
                    Return
                End If

                Dim verbToUse = startInfo.Verbs(Convert.ToInt32(index))

                startInfo.Verb = verbToUse
                If verbToUse.ToLower().IndexOf("printto") >= 0 Then
                    ' printto implies a specific printer.  Ask for the network address.
                    ' The address must be in the form \\server\printer.
                    Console.Write("Enter the network address of the target printer: ")
                    Dim arguments = Console.ReadLine()
                    startInfo.Arguments = arguments
                End If
                ' </Snippet4>

                Try
                    Using newProcess As New Process
                        newProcess.StartInfo = startInfo
                        newProcess.Start()

                        Console.WriteLine($"{newProcess.ProcessName} for file {fileName} " +
                                          $"started successfully with verb '{startInfo.Verb}'!")
                    End Using
                Catch e As Win32Exception
                    Console.WriteLine("  Win32Exception caught!")
                    Console.WriteLine($"  Win32 error = {e.Message}")
                Catch e As InvalidOperationException
                    Console.WriteLine($"Unable to start '{fileName}' with verb {verbToUse}")
                End Try
            Else
                Console.WriteLine("You did not enter a number.")
            End If
        End If
    End Sub
End Module
' </Snippet3>
' </Snippet1>
