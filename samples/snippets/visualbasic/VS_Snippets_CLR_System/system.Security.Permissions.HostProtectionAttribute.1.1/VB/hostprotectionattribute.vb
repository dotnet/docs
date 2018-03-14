'<Snippet1>
Imports System
Imports System.IO
Imports System.Threading
Imports System.Security
Imports System.Security.Policy
Imports System.Security.Principal
Imports System.Security.Permissions
Imports System.Diagnostics
Imports System.ComponentModel
Imports System.Windows.Forms


' If this application is run on a server that implements host protection, the
' HostProtectionAttribute attribute is applied. If the application is run on 
' a server that is not host-protected, the attribute evaporates; it is not  
' detected and therefore not applied. Host protection can be configured with  
' members of the HostProtectionResource enumeration to customize the  
' protection offered. 
' The primary intent of this sample is to show situations in which the 
' HostProtectionAttribute attribute might be meaningfully used.  The 
' environment required to demonstrate a particular behavior is too 
' complex to invoke within the scope of this sample.

Class HostProtectionExample
    Public Shared Success As Integer = 100

    '<Snippet2>
    ' Use the enumeration flags to indicate that this method exposes 
    ' shared state and self-affecting process management.
    ' Either of the following attribute statements can be used to set the 
    ' resource flags.
    <HostProtectionAttribute(SharedState := True, _
        SelfAffectingProcessMgmt := True), _
        HostProtectionAttribute( _
        Resources := HostProtectionResource.SharedState Or _
        HostProtectionResource.SelfAffectingProcessMgmt)> _
    Private Shared Sub [Exit](ByVal Message As String, ByVal Code As Integer)

        ' Exit the sample when an exception is thrown.
        Console.WriteLine((ControlChars.Lf & "FAILED: " & Message & " " & _
            Code.ToString()))
        Environment.ExitCode = Code
        Environment.Exit(Code)
    End Sub 'Exit
    '</Snippet2>

    '<Snippet3>
    ' Use the enumeration flags to indicate that this method exposes shared
    ' state, self-affecting process management, and self-affecting threading.
    <HostProtectionAttribute(SharedState := True, _
        SelfAffectingProcessMgmt := True, _
        SelfAffectingThreading := True, UI := True)> _
    Private Shared Sub ExecuteBreak()

        ' This method allows the user to quit the sample.
        Console.WriteLine("Executing Debugger.Break.")
        Debugger.Break()
        Debugger.Log(1, "info", "test message")
    End Sub 'ExecuteBreak
    '</Snippet3>

    '<Snippet4>
    ' Use the enumeration flags to indicate that this method exposes shared  
    ' state, self-affecting threading, and the security infrastructure.
    <HostProtectionAttribute(SharedState := True, _
        SelfAffectingThreading := True, _
        SecurityInfrastructure := True)> _
    Private Shared Function ApplyIdentity() As Integer

        ' ApplyIdentity sets the current identity.
        Dim roles(1) As String
        Try
            Dim mAD As AppDomain = AppDomain.CurrentDomain
            Dim mGenPr As _
                New GenericPrincipal(WindowsIdentity.GetCurrent(), roles)
            mAD.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
            mAD.SetThreadPrincipal(mGenPr)
            Return Success
        Catch e As Exception
            [Exit](e.ToString(), 5)
        End Try
        Return 0
    End Function 'ApplyIdentity
    '</Snippet4>

    ' The following method is started on a separate thread.
    Public Shared Sub WatchFileEvents()
        Try
            Console.WriteLine("In the child thread.")
            Dim watcher As New FileSystemWatcher()
            watcher.Path = "C:\Temp"

            ' Watch for changes in LastAccess and LastWrite times, and 
            ' name changes to files or directories. 
            watcher.NotifyFilter = NotifyFilters.LastAccess Or _
                NotifyFilters.LastWrite Or NotifyFilters.FileName Or _
                NotifyFilters.DirectoryName

            ' Watch only text files.
            watcher.Filter = "*.txt"

            ' Add event handlers.
            AddHandler watcher.Changed, AddressOf OnChanged
            AddHandler watcher.Created, AddressOf OnChanged
            AddHandler watcher.Deleted, AddressOf OnChanged

            ' Begin watching.
            watcher.EnableRaisingEvents = True

            ' Wait for the user to quit the program.
            Console.WriteLine("Event handlers have been enabled.")
            While Console.ReadLine() <> "q"c
            End While
        Catch e As Exception
            Console.WriteLine(e.Message)
        End Try
    End Sub 'WatchFileEvents

    '<Snippet6>
    ' Use the enumeration flags to indicate that this method exposes  
    ' synchronization and external threading.
    <HostProtectionAttribute(Synchronization := True, _
        ExternalThreading := True)> _
    Private Shared Sub StartThread()
        Dim t As New Thread(New ThreadStart(AddressOf WatchFileEvents))

        ' Start the new thread. On a uniprocessor, the thread is not given 
        ' any processor time until the main thread yields the processor.  
        t.Start()

        ' Give the new thread a chance to execute.
        Thread.Sleep(1000)
    End Sub 'StartThread
    '</Snippet6>

    ' Call methods that show the use of the HostProtectionResource enumeration.
    <HostProtectionAttribute(Resources := HostProtectionResource.All)> _
    Overloads Shared Function Main(ByVal args() As String) As Integer
        Try
            ' Show use of the HostProtectionResource.SharedState,
            ' HostProtectionResource.SelfAffectingThreading, and
            ' HostProtectionResource.Security enumeration values.
            ApplyIdentity()
            Directory.CreateDirectory("C:\Temp")

            ' Show use of the HostProtectionResource.Synchronization and
            ' HostProtectionResource.ExternalThreading enumeration values.
            StartThread()
            Console.WriteLine("In the main thread.")
            Console.WriteLine("Deleting and creating 'MyTestFile.txt'.")
            If File.Exists("C:\Temp\MyTestFile.txt") Then
                File.Delete("C:\Temp\MyTestFile.txt")
            End If

            Dim sr As StreamWriter = File.CreateText("C:\Temp\MyTestFile.txt")
            sr.WriteLine("This is my file.")
            sr.Close()
            Thread.Sleep(1000)

            ' Show use of the HostProtectionResource.SharedState, 
            ' HostProtectionResource.SelfProcessMgmt,
            ' HostProtectionResource.SelfAffectingThreading, and
            ' HostProtectionResource.UI enumeration values.
            ExecuteBreak()

            ' Show the use of the 
            ' HostProtectionResource.ExternalProcessManagement 
            ' enumeration value.
            Dim myControl As New MyControl()
            Console.WriteLine("Enter 'q' to quit the sample.")
            Return 100
        Catch e As Exception
            [Exit](e.ToString(), 0)
            Return 0
        End Try
    End Function 'Main

    ' Define the event handlers.
    Private Shared Sub OnChanged(ByVal [source] As Object, _
        ByVal e As FileSystemEventArgs)

        ' Specify whether a file is changed, created, or deleted.
        Console.WriteLine("In the OnChanged event handler.")
        Console.WriteLine(("File: " & e.FullPath & " " & _
            e.ChangeType.ToString()))
    End Sub 'OnChanged
End Class 'HostProtectionExample 

'<Snippet5>
' The following class is an example of code that exposes 
' external process management.
' Add the LicenseProviderAttribute to the control.
<LicenseProvider(GetType(LicFileLicenseProvider))> _
Public Class MyControl
    Inherits System.Windows.Forms.Control

    ' Create a new, null license.
    Private license As License = Nothing

    <HostProtectionAttribute(ExternalProcessMgmt := True)> _
    Public Sub New()

        ' Determine if a valid license can be granted.
        Dim isValid As Boolean = LicenseManager.IsValid(GetType(MyControl))
        Console.WriteLine(("The result of the IsValid method call is " & _
            isValid.ToString()))
    End Sub 'New

    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (license Is Nothing) Then
                license.Dispose()
                license = Nothing
            End If
        End If
    End Sub 'Dispose
End Class 'MyControl
'</Snippet5>
'</Snippet1>
