'<SNIPPET1>
Imports System.Reflection
Imports System.Deployment.Application
Imports System.Collections.Generic
Imports Microsoft.Samples.ClickOnceOnDemand
Imports System.Security.Permissions
'</SNIPPET1>

Public Class Form1

    '<SNIPPET2>
    ' Maintain a dictionary mapping DLL names to download file groups. This is trivial for this sample,
    ' but will be important in real-world applications where a feature is spread across multiple DLLs,
    ' and you want to download all DLLs for that feature in one shot. 
    Dim DllMappingTable As New Dictionary(Of String, String)()

    <SecurityPermission(SecurityAction.Demand, ControlAppDomain:=True)> _
    Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DllMappingTable("ClickOnceLibrary") = "ClickOnceLibrary"
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf Me.CurrentDomain_AssemblyResolve
    End Sub

    Private Function CurrentDomain_AssemblyResolve(ByVal sender As Object, ByVal args As ResolveEventArgs) As System.Reflection.Assembly
        Dim NewAssembly As Assembly = Nothing

        If (ApplicationDeployment.IsNetworkDeployed) Then
            Dim Deploy As ApplicationDeployment = ApplicationDeployment.CurrentDeployment

            ' Get the DLL name from the argument.
            Dim NameParts As String() = args.Name.Split(",")
            Dim DllName As String = NameParts(0)
            Dim DownloadGroupName As String = DllMappingTable(DllName)

            Try
                Deploy.DownloadFileGroup(DownloadGroupName)
            Catch ex As Exception
                MessageBox.Show("Could not download file group from Web server. Contact administrator. Group name: " & DownloadGroupName & "; DLL name: " & args.Name)
                Throw (ex)
            End Try

            ' Load the assembly.
            ' Assembly.Load() doesn't work here, as the previous failure to load the assembly
            ' is cached by the CLR. LoadFrom() is not recommended. Use LoadFile() instead.
            Try
                NewAssembly = Assembly.LoadFile(Application.StartupPath & "\" & DllName & ".dll")
            Catch ex As Exception
                Throw (ex)
            End Try
        Else
            ' Major error - not running under ClickOnce, but missing assembly. Don't know how to recover.
            Throw New Exception("Cannot load assemblies dynamically - application is not deployed using ClickOnce.")
        End If

        Return NewAssembly
    End Function
    '</SNIPPET2>

    '<SNIPPET3>
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DC As New DynamicClass()
        MessageBox.Show("Message is " & DC.Message)
    End Sub
    '</SNIPPET3>
End Class
