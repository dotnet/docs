' <SNIPPET1>
Imports System
Imports System.Security.Principal
Imports System.Threading

Class ADPrincipal
    Overloads Shared Sub Main(ByVal args() As String)
        ' Create a new thread with a generic principal.
        Dim t As New Thread(New ThreadStart(AddressOf PrintPrincipalInformation))
        t.Start()
        t.Join()

        ' Set the principal policy to WindowsPrincipal.
        Dim currentDomain As AppDomain = AppDomain.CurrentDomain
        currentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)

        ' The new thread will have a Windows principal representing the
        ' current user.
        t = New Thread(New ThreadStart(AddressOf PrintPrincipalInformation))
        t.Start()
        t.Join()

        ' Create a principal to use for new threads.
        Dim identity = New GenericIdentity("NewUser")
        Dim principal = New GenericPrincipal(identity, Nothing)
        currentDomain.SetThreadPrincipal(principal)

        ' Create a new thread with the principal created above.
        t = New Thread(New ThreadStart(AddressOf PrintPrincipalInformation))
        t.Start()
        t.Join()

        ' Wait for user input before terminating.
        Console.ReadLine()
    End Sub 'Main


    Shared Sub PrintPrincipalInformation()
        Dim curPrincipal As IPrincipal = Thread.CurrentPrincipal
        If Not (curPrincipal Is Nothing) Then
            Console.WriteLine("Type: " & CType(curPrincipal, Object).GetType().Name)
            Console.WriteLine("Name: " & curPrincipal.Identity.Name)
            Console.WriteLine("Authenticated: " & curPrincipal.Identity.IsAuthenticated)
            Console.WriteLine()

        End If
    End Sub 'PrintPrincipalInformation
End Class 'ADPrincipal 
' </SNIPPET1>