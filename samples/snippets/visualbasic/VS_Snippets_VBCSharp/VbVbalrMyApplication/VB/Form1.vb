Option Explicit On
Option Strict On

Public Class Form1

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim start As New Threading.ThreadStart(AddressOf launch)
        Dim t As System.Threading.Thread
        t = New System.Threading.Thread(start)
        t.Start()

    End Sub

    Public Shared Sub MsgBox(ByVal s As String)
        Form1.TextBox1.Text &= s & vbCrLf
        Microsoft.VisualBasic.MsgBox(s)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        testAppInfo()
    End Sub


    Private Sub testAppInfo()
        '<snippet20>
        MsgBox("Application assembly name: " & My.Application.Info.AssemblyName)
        '</snippet20>
        '<snippet21>
        MsgBox("Application created by: " & My.Application.Info.CompanyName)
        '</snippet21>
        '<snippet22>
        MsgBox("Application copyright: " & My.Application.Info.Copyright)
        '</snippet22>
        '<snippet23>
        MsgBox("Application description: " & My.Application.Info.Description)
        '</snippet23>
        '<snippet24>
        MsgBox("Application directory path: " & My.Application.Info.DirectoryPath)
        '</snippet24>
        '<snippet25>
        ListBox1.DataSource = My.Application.Info.LoadedAssemblies
        '</snippet25>
        '<snippet26>
        MsgBox("Application product name: " & My.Application.Info.ProductName)
        '</snippet26>
        '<snippet27>
        MsgBox("Stack trace: " & My.Application.Info.StackTrace)
        '</snippet27>
        '<snippet28>
        MsgBox("Application title: " & My.Application.Info.Title)
        '</snippet28>
        '<snippet29>
        MsgBox("Application trademark: " & My.Application.Info.Trademark)
        '</snippet29>
        '<snippet30>
        MsgBox("Application version: " & My.Application.Info.Version.ToString)
        '</snippet30>
        '<snippet31>
        MsgBox("Application working set: " & My.Application.Info.WorkingSet)
        '</snippet31>

    End Sub


    '<snippet12>
    Private Sub InitializeSaveMySettingsOnExit()
        SaveMySettingsOnExit.Checked = 
            My.Application.SaveMySettingsOnExit
    End Sub
    Private Sub SaveMySettingsOnExit_CheckedChanged( 
        ByVal sender As System.Object, 
        ByVal e As System.EventArgs 
    ) Handles SaveMySettingsOnExit.CheckedChanged
        My.Application.SaveMySettingsOnExit = 
            SaveMySettingsOnExit.Checked
    End Sub
    '</snippet12>

    Private Sub TestHarnessForOpenForms()
        MsgBox("Starting the simple one")
        Dim x1 As New threading1
        x1.GetOpenFormTitlesHarness()

        MsgBox("Starting the robust one")
        Dim x2 As New threading2
        x2.GetOpenFormTitlesHarness()
    End Sub
    Public Sub launch()
        '       My.Forms.Form2.ShowDialog()
        Dim x As New Form2
        x.Text = Now.ToString
        x.ShowDialog()
    End Sub

    Class threading2
        Public Sub GetOpenFormTitlesHarness()
            GetOpenFormTitles()
        End Sub
        '<snippet11>
        Private Sub GetOpenFormTitles()
            Dim formTitles As New Collection

            Try
                For Each f As Form In My.Application.OpenForms
                    ' Use a thread-safe method to get all form titles.
                    formTitles.Add(GetFormTitle(f))
                Next
            Catch ex As Exception
                formTitles.Add("Error: " & ex.Message)
            End Try

            Form1.ListBox1.DataSource = formTitles
        End Sub

        Private Delegate Function GetFormTitleDelegate(ByVal f As Form) As String
        Private Function GetFormTitle(ByVal f As Form) As String
            ' Check if the form can be accessed from the current thread.
            If Not f.InvokeRequired Then
                ' Access the form directly.
                Return f.Text
            Else
                ' Marshal to the thread that owns the form. 
                Dim del As GetFormTitleDelegate = AddressOf GetFormTitle
                Dim param As Object() = {f}
                Dim result As System.IAsyncResult = f.BeginInvoke(del, param)
                ' Give the form's thread a chance process function.
                System.Threading.Thread.Sleep(10)
                ' Check the result.
                If result.IsCompleted Then
                    ' Get the function's return value.
                    Return "Different thread: " & f.EndInvoke(result).ToString
                Else
                    Return "Unresponsive thread"
                End If
            End If
        End Function
        '</snippet11>
    End Class
    Class threading1
        Public Sub GetOpenFormTitlesHarness()
            GetOpenFormTitles()
        End Sub
        '<snippet10>
        Private Sub GetOpenFormTitles()
            Dim formTitles As New Collection

            Try
                For Each f As Form In My.Application.OpenForms
                    If Not f.InvokeRequired Then
                        ' Can access the form directly.
                        formTitles.Add(f.Text)
                    End If
                Next
            Catch ex As Exception
                formTitles.Add("Error: " & ex.Message)
            End Try

            Form1.ListBox1.DataSource = formTitles
        End Sub
        '</snippet10>
    End Class

    ' This is called by snippet 9, the NetworkAvailabiliyChanges event.
    Public Sub SetConnectionStatus(ByVal x As Boolean)
        MsgBox("Network: " & x)
    End Sub

    '<snippet7>
    Private Sub TestGetEnvironmentVariable()
        Try
            MsgBox("PATH = " & My.Application.GetEnvironmentVariable("PATH"))
        Catch ex As System.ArgumentException
            MsgBox("Environment variable 'PATH' does not exist.")
        End Try
    End Sub
    '</snippet7>

    '<snippet6>
    Private Sub TestDoEvents()
        For i As Integer = 0 To 10000
            TextBox1.Text = i.ToString
            My.Application.DoEvents()
        Next
    End Sub
    '</snippet6>

    Class test
        '<snippet5>
        Sub CheckUpdateAvailability()
            If My.Application.IsNetworkDeployed() Then
                If My.Application.Deployment.CheckForUpdate() Then
                    MsgBox("Update is available for download")
                Else
                    MsgBox("No updates are available for download")
                End If
            Else
                MsgBox("Application is not ClickOnce deployed")
            End If
        End Sub
        '</snippet5>
    End Class

    '<snippet4>
    Sub UpdateApplication()
        If My.Application.IsNetworkDeployed Then
            My.Application.Deployment.Update()
        End If
    End Sub
    '</snippet4>

    '<snippet2>
    Private Function IsBatch() As Boolean
        For Each s As String In My.Application.CommandLineArgs
            If s.ToLower = "/batch" Then
                Return True
            End If
        Next
        Return False
    End Function
    '</snippet2>

    '<snippet3>
    Private Sub ParseCommandLineArgs()
        Dim inputArgument As String = "/input="
        Dim inputName As String = ""

        For Each s As String In My.Application.CommandLineArgs
            If s.ToLower.StartsWith(inputArgument) Then
                inputName = s.Remove(0, inputArgument.Length)
            End If
        Next

        If inputName = "" Then
            MsgBox("No input name")
        Else
            MsgBox("Input name: " & inputName)
        End If
    End Sub
    '</snippet3>


    'TODO: Update when you do My.Resources
    Private Sub TestChangeUICulture()
        My.Application.ChangeUICulture("en-US")
        '        MsgBox(My.Resources.Greeting)

        My.Application.ChangeUICulture("")
        '        MsgBox(My.Resources.Greeting)
    End Sub


    '<snippet1>
    Private Sub TestChangeCulture()
        ' Store the current culture.
        Dim currentculture As String = My.Application.Culture.Name
        MsgBox("Current culture is " & currentculture)

        Dim jan1 As New Date(2005, 1, 1, 15, 15, 15)

        My.Application.ChangeCulture("en-US")
        MsgBox("Date represented in en-US culture: " & jan1)
        ' 1/1/2005 3:15:15 PM

        My.Application.ChangeCulture("")
        MsgBox("Date represented in invariant culture" & jan1)
        ' 01/01/2005 15:15:15

        ' Restore the culture.
        My.Application.ChangeCulture(currentculture)
    End Sub
    '</snippet1>


    Class Classa1520853292b4f38b8386a7fccc44a48
        ' a1520853-292b-4f38-b838-6a7fccc44a48
        ' How to: Access Command-Line Arguments (Visual Basic)

        Public Sub Method49()
            ' <snippet49>
            For Each argument As String In My.Application.CommandLineArgs
                ' Add code here to use the argument.
            Next
            ' </snippet49>
        End Sub

    End Class

    Class Classba6a05dcbea94fcf8430766a83ae49b4
        ' ba6a05dc-bea9-4fcf-8430-766a83ae49b4
        ' My.Computer.Network.NetworkAvailabilityChanged Event

        Dim Label1 As New Label
        ' <snippet50>
        Private Sub DisplayAvailability(ByVal available As Boolean)
            Label1.Text = available.ToString
        End Sub

        Private Sub MyComputerNetwork_NetworkAvailabilityChanged( 
            ByVal sender As Object, 
            ByVal e As Devices.NetworkAvailableEventArgs)

            DisplayAvailability(e.IsNetworkAvailable)
        End Sub

        Private Sub Handle_NetworkAvailabilityChanged()
            AddHandler My.Computer.Network.NetworkAvailabilityChanged, 
               AddressOf MyComputerNetwork_NetworkAvailabilityChanged
            DisplayAvailability(My.Computer.Network.IsAvailable)
        End Sub
        ' </snippet50>

    End Class
End Class
