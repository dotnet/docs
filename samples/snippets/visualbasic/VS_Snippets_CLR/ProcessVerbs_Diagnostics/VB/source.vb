 '<Snippet1>
'<Snippet3>
Imports System
Imports System.IO
Imports System.Diagnostics
Imports System.Text
Imports System.Windows.Forms



Class ProcessInformation
    
    <STAThread()>  _
    Shared Sub Main(ByVal args() As String) 
        Dim fileName As String = ""
        Dim arguments As String = ""
        Dim verbToUse As String = ""
        Dim i As Integer = 0
        Dim startInfo As New ProcessStartInfo()
        Dim openFileDialog1 As New OpenFileDialog()
        
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True
        
        If openFileDialog1.ShowDialog() = DialogResult.OK Then
            fileName = openFileDialog1.FileName
            If Not (fileName Is Nothing) Then
                '<Snippet4>
                startInfo = New ProcessStartInfo(fileName)

                If File.Exists(fileName) Then
                    i = 0
                    Dim verb As String
                    For Each verb In startInfo.Verbs
                        ' Display the possible verbs.
                        Console.WriteLine("  {0}. {1}", i.ToString(), verb)
                        i += 1
                    Next verb
                End If
            Else
                ' Return if no file is selected.
                Return
            End If

            Console.WriteLine("Select the index of the verb.")
            Dim index As String = Console.ReadLine()
            If Convert.ToInt32(index) < i Then
                verbToUse = startInfo.Verbs(Convert.ToInt32(index))
            Else
                Return
            End If

            startInfo.Verb = verbToUse
            If verbToUse.ToLower().IndexOf("printto") >= 0 Then
                ' printto implies a specific printer.  Ask for the network address.
                ' The address must be in the form \\server\printer.
                Console.WriteLine("Enter the network address of the target printer:")
                arguments = Console.ReadLine()
                startInfo.Arguments = arguments
            End If
            '</Snippet4>
            Dim newProcess As New Process
            newProcess.StartInfo = startInfo

            Try
                newProcess.Start()

                Console.WriteLine("{0} for file {1} started successfully with verb ""{2}""!", newProcess.ProcessName, fileName, startInfo.Verb)
            Catch e As System.ComponentModel.Win32Exception
                Console.WriteLine("  Win32Exception caught!")
                Console.WriteLine("  Win32 error = {0}", e.Message)
            Catch
                ' Catch this exception if the process exits quickly, 
                ' and the properties are not accessible.
                Console.WriteLine("File {0} started with verb {1}", fileName, verbToUse)
            End Try
        End If
    
    End Sub 'Main
End Class 'ProcessInformation
' </Snippet3>
'</Snippet1>