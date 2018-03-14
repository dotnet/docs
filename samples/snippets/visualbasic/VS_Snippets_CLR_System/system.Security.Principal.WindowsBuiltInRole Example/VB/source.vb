' <Snippet1>
Imports System
Imports System.Threading
Imports System.Security.Permissions
Imports System.Security.Principal

Class SecurityPrincipalDemo

    Public Shared Sub DemonstrateWindowsBuiltInRoleEnum()
        Dim myDomain As AppDomain = Thread.GetDomain()

        myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal)
        Dim myPrincipal As WindowsPrincipal = CType(Thread.CurrentPrincipal, WindowsPrincipal)
        Console.WriteLine("{0} belongs to: ", myPrincipal.Identity.Name.ToString())
        Dim wbirFields As Array = [Enum].GetValues(GetType(WindowsBuiltInRole))
        '<Snippet2>
        Dim roleName As Object
        For Each roleName In wbirFields
            Try
                ' Cast the role name to a RID represented by the WindowsBuildInRole value.
                Console.WriteLine("{0}? {1}.", roleName, myPrincipal.IsInRole(CType(roleName, WindowsBuiltInRole)))
                Console.WriteLine("The RID for this role is: " + Fix(roleName).ToString())

            Catch
                Console.WriteLine("{0}: Could not obtain role for this RID.", roleName)
            End Try
        Next roleName
        '</Snippet2>
        '<Snippet3>
        ' Get the role using the string value of the role.
        Console.WriteLine("{0}? {1}.", "Administrators", myPrincipal.IsInRole("BUILTIN\" + "Administrators"))
        Console.WriteLine("{0}? {1}.", "Users", myPrincipal.IsInRole("BUILTIN\" + "Users"))
        '</Snippet3>
        '<Snippet4>
        ' Get the role using the WindowsBuiltInRole enumeration value.
        Console.WriteLine("{0}? {1}.", WindowsBuiltInRole.Administrator, myPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
        '</Snippet4>
        '<Snippet5>
        ' Get the role using the WellKnownSidType.
        Dim sid As New SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, Nothing)
        Console.WriteLine("WellKnownSidType BuiltinAdministratorsSid  {0}? {1}.", sid.Value, myPrincipal.IsInRole(sid))

    End Sub 'DemonstrateWindowsBuiltInRoleEnum
    '</snippet5>

    Public Shared Sub Main()
        DemonstrateWindowsBuiltInRoleEnum()

    End Sub 'Main
End Class 'SecurityPrincipalDemo 
' </Snippet1>

