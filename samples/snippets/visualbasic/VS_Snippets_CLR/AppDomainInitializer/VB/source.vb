'<Snippet1>
Imports System
Imports System.Security.Policy

Public Class Example

    Public Shared Sub Main()

        ' Get a reference to the default application domain.
        '
        Dim current As AppDomain = AppDomain.CurrentDomain

        ' Create the AppDomainSetup that will be used to set up the child
        ' AppDomain.
        Dim ads As New AppDomainSetup()

        ' Use the evidence from the default application domain to
        ' create evidence for the child application domain.
        '
        Dim ev As Evidence = New Evidence(current.Evidence)

        ' Create an AppDomainInitializer delegate that represents the 
        ' callback method, AppDomainInit. Assign this delegate to the
        ' AppDomainInitializer property of the AppDomainSetup object.
        '
        Dim adi As New AppDomainInitializer(AddressOf AppDomainInit)
        ads.AppDomainInitializer = adi

        ' Create an array of strings to pass as arguments to the callback
        ' method. Assign the array to the AppDomainInitializerArguments
        ' property.
        Dim initArgs() As String = {"String1", "String2"}
        ads.AppDomainInitializerArguments = initArgs

        ' Create a child application domain named "ChildDomain", using 
        ' the evidence and the AppDomainSetup object.
        '
        Dim ad As AppDomain = _
            AppDomain.CreateDomain("ChildDomain", ev, ads)

        Console.WriteLine("Press the Enter key to exit the example program.")
        Console.ReadLine()
    End Sub

    ' The callback method invoked when the child application domain is
    ' initialized. The method simply displays the arguments that were
    ' passed to it.
    '
    Public Shared Sub AppDomainInit(ByVal args() As String)
        Console.WriteLine("AppDomain ""{0}"" is initialized with these arguments:", _
            AppDomain.CurrentDomain.FriendlyName)
        For Each arg As String In args
            Console.WriteLine("    {0}", arg)
        Next
    End Sub
End Class

' This code example produces the following output:
'
'AppDomain "ChildDomain" is initialized with these arguments:
'    String1
'    String2
'</Snippet1>