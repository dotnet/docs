Imports System
Imports System.Security.Principal
Module Module1

    Sub Main()

        ' Retrieve the Windows account token for the current user.
        Dim logonToken As IntPtr = LogonUser()

        ' Constructor implementations.
        IntPtrConstructor(logonToken)
        IntPtrStringConstructor(logonToken)
        IntPtrStringTypeConstructor(logonToken)
        IntPrtStringTypeBoolConstructor(logonToken)

        ' Property implementations.
        UseProperties(logonToken)

        ' Method implementations.
        GetAnonymousUser()
        ImpersonateIdentity(logonToken)

        ' Align interface and conclude application.
        Console.WriteLine(vbCrLf + "This sample completed " + _
            "successfully; press Enter to exit.")
        Console.ReadLine()

    End Sub
    
    ' Create a WindowsIdentity object for the user represented by the
    ' specified Windows account token.
    Private Sub IntPtrConstructor(ByVal logonToken As IntPtr)
        ' Construct a WindowsIdentity object using the input account token.
        Dim windowsIdentity As New WindowsIdentity(logonToken)

        WriteLine("Created a Windows identity object named " + _
            windowsIdentity.Name + ".")
    End Sub
    ' Create a WindowsIdentity object for the user represented by the
    ' specified account token and authentication type.
    Private Sub IntPtrStringConstructor(ByVal logonToken As IntPtr)
        ' Construct a WindowsIdentity object using the input account token 
        ' and the specified authentication type
        Dim authenticationType = "WindowsAuthentication"
        Dim windowsIdentity As _
            New WindowsIdentity(logonToken, authenticationType)

        WriteLine("Created a Windows identity object named " + _
            windowsIdentity.Name + ".")
    End Sub

    ' Create a WindowsIdentity object for the user represented by the
    ' specified account token, authentication type, and Windows account
    ' type.
    Private Sub IntPtrStringTypeConstructor(ByVal logonToken As IntPtr)
        ' Construct a WindowsIdentity object using the input account token,
        ' and the specified authentication type and Windows account type.
        Dim authenticationType As String = "WindowsAuthentication"
        Dim guestAccount As WindowsAccountType = WindowsAccountType.Guest
        Dim windowsIdentity As _
            New WindowsIdentity(logonToken, authenticationType, guestAccount)

        WriteLine("Created a Windows identity object named " + _
            windowsIdentity.Name + ".")
    End Sub

    ' Create a WindowsIdentity object for the user represented by the
    ' specified account token, authentication type, Windows account type,
    ' and Boolean authentication flag.
    Private Sub IntPrtStringTypeBoolConstructor(ByVal logonToken As IntPtr)
        ' Construct a WindowsIdentity object using the input account token,
        ' and the specified authentication type, Windows account type, and
        ' authentication flag.
        Dim authenticationType As String = "WindowsAuthentication"
        Dim guestAccount As WindowsAccountType = WindowsAccountType.Guest
        Dim isAuthenticated As Boolean = True
        Dim windowsIdentity As New WindowsIdentity( _
            logonToken, authenticationType, guestAccount, isAuthenticated)

        WriteLine("Created a Windows identity object named " + _
            windowsIdentity.Name + ".")
    End Sub
        
    ' Access the properties of a WindowsIdentity object.
    Private Sub UseProperties(ByVal logonToken As IntPtr)
        Dim windowsIdentity As New WindowsIdentity(logonToken)
        Dim propertyDescription As String = "The Windows identity named "

        ' Retrieve the Windows logon name from the Windows identity object.
        propertyDescription += windowsIdentity.Name

        ' Verify that the user account is not considered to be an Anonymous
        ' account by the system.
        If Not windowsIdentity.IsAnonymous Then
            propertyDescription += " is not an Anonymous account"
        End If

        ' Verify that the user account has been authenticated by Windows.
        If (windowsIdentity.IsAuthenticated) Then
            propertyDescription += ", is authenticated"
        End If

        ' Verify that the user account is considered to be a System account by
        ' the system.
        If (windowsIdentity.IsSystem) Then
            propertyDescription += ", is a System account"
        End If

        ' Verify that the user account is considered to be a Guest account by
        ' the system.
        If (windowsIdentity.IsGuest) Then
            propertyDescription += ", is a Guest account"
        End If
        Dim authenticationType As String = windowsIdentity.AuthenticationType

        ' Append the authenication type to the output message.
        If (Not authenticationType Is Nothing) Then
            propertyDescription += (" and uses " + authenticationType)
            propertyDescription += (" authentication type.")
        End If

        WriteLine(propertyDescription)

        ' Display the SID for the owner.
        Console.Write("The SID for the owner is : ")
        Dim si As SecurityIdentifier
        si = windowsIdentity.Owner
        Console.WriteLine(si.ToString())
        ' Display the SIDs for the groups the current user belongs to.
        Console.WriteLine("Display the SIDs for the groups the current user belongs to.")
        Dim irc As IdentityReferenceCollection
        Dim ir As IdentityReference
        irc = windowsIdentity.Groups
        For Each ir In irc
            Console.WriteLine(ir.Value)
        Next
        Dim token As TokenImpersonationLevel
        token = windowsIdentity.ImpersonationLevel
        Console.WriteLine("The impersonation level for the current user is : " + token.ToString())
    End Sub
    ' Retrieve the account token from the current WindowsIdentity object
    ' instead of calling the unmanaged LogonUser method in the advapi32.dll.
    Private Function LogonUser() As IntPtr
        Dim accountToken As IntPtr = WindowsIdentity.GetCurrent().Token

        Return accountToken
    End Function

    ' Get the WindowsIdentity object for an Anonymous user.
    Private Sub GetAnonymousUser()
        ' Retrieve a WindowsIdentity object that represents an anonymous
        ' Windows user.
        Dim windowsIdentity As WindowsIdentity
        windowsIdentity = windowsIdentity.GetAnonymous()
    End Sub

    ' Impersonate a Windows identity.
    Private Sub ImpersonateIdentity(ByVal logonToken As IntPtr)
        ' Retrieve the Windows identity using the specified token.
        Dim windowsIdentity As New WindowsIdentity(logonToken)

        ' Create a WindowsImpersonationContext object by impersonating the
        ' Windows identity.
        Dim impersonationContext As WindowsImpersonationContext
        impersonationContext = windowsIdentity.Impersonate()

        WriteLine("Name of the identity after impersonation: " + _
            windowsIdentity.GetCurrent().Name + ".")

        ' Stop impersonating the user.
        impersonationContext.Undo()

        ' Check the identity.
        WriteLine("Name of the identity after performing an Undo on the " + _
            "impersonation: " + windowsIdentity.GetCurrent().Name + ".")
    End Sub
    ' Write out message with carriage return to output textbox.
    Private Sub WriteLine(ByVal message As String)
        Console.WriteLine(message + vbCrLf)
    End Sub

End Module
