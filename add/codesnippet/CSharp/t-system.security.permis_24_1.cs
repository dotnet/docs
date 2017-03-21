// This sample demonstrates the use of the SecurityPermissionAttribute.

using System;
using System.Security.Permissions;
using System.Security;


class MyClass
{
    public static void PermissionDemo()
    {
        try
        {
            DenySecurityPermissions();
            DenyAllSecurityPermissions();
            DoNotDenySecurityPermissions();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message.ToString());
        }



    }

    // This method demonstrates the use of the SecurityPermissionAttribute to deny individual security permissions.
    // Set the Assertion property.
    [SecurityPermissionAttribute(SecurityAction.Deny, Assertion = true)]
        // Set the ControlAppDomain property.
    [SecurityPermissionAttribute(SecurityAction.Deny, ControlAppDomain = true)]
        // Set the ControlDomainPolicy property.
    [SecurityPermissionAttribute(SecurityAction.Deny, ControlDomainPolicy = true)]
        // Set the ControlEvidence property.
    [SecurityPermissionAttribute(SecurityAction.Deny, ControlEvidence = true)]
        // Set the ControlPolicy property.
    [SecurityPermissionAttribute(SecurityAction.Deny, ControlPolicy = true)]
        // Set the ControlPrincipal property.
    [SecurityPermissionAttribute(SecurityAction.Deny, ControlPrincipal = true)]
        // Set the ControlThread property.
    [SecurityPermissionAttribute(SecurityAction.Deny, ControlThread = true)]
        // Set the Execution property.
    [SecurityPermissionAttribute(SecurityAction.Deny, Execution = true)]
        // Set the Flags property.
    [SecurityPermissionAttribute(SecurityAction.Deny, Flags = SecurityPermissionFlag.NoFlags)]
        // Set the Infrastructure property.
    [SecurityPermissionAttribute(SecurityAction.Deny, Infrastructure = true)]
        // Set the RemotingConfiguration property.
    [SecurityPermissionAttribute(SecurityAction.Deny, RemotingConfiguration = true)]
        // Set the SerializationFormatter property.
    [SecurityPermissionAttribute(SecurityAction.Deny, SerializationFormatter = true)]
        // Set the SkipVerification property.
    [SecurityPermissionAttribute(SecurityAction.Deny, SkipVerification = true)]
        // Set the UnmanagedCode property.
    [SecurityPermissionAttribute(SecurityAction.Deny, UnmanagedCode = true)]

    public static void DenySecurityPermissions()
    {
        Console.WriteLine("Executing DenySecurityPermissions.");
        Console.WriteLine("Denied all permissions individually.");
        TestSecurityPermissions();
    }

    // This method demonstrates the use of SecurityPermissionFlag.AllFlags to deny all security permissions.
    [SecurityPermissionAttribute(SecurityAction.Deny, Flags = SecurityPermissionFlag.AllFlags)]
    public static void DenyAllSecurityPermissions()
    {
        Console.WriteLine("\nExecuting DenyAllSecurityPermissions.");
        Console.WriteLine("Denied all permissions using SecurityPermissionFlag.AllFlags.");
        TestSecurityPermissions();
    }

    // This method demonstrates the effect of not denying security permissions.
    public static void DoNotDenySecurityPermissions()
    {
        Console.WriteLine("\nExecuting DoNotDenySecurityPermissions.");
        Console.WriteLine("No permissions have been denied.");
        DemandSecurityPermissions();
    }

    public static void TestSecurityPermissions()
    {
        Console.WriteLine("\nExecuting TestSecurityPermissions.\n");
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.Assertion);
            Console.WriteLine("Demanding SecurityPermissionFlag.Assertion");
            // This demand should cause an exception.
            sp.Demand();
            // The TestFailed method is called if an exception is not thrown.
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.Assertion failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlAppDomain);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlAppDomain");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlAppDomain failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlDomainPolicy);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlDomainPolicy");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlDomainPolicy failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlEvidence);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlEvidence");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlEvidence failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlPolicy);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlPolicy");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlPolicy failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlPrincipal);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlPrincipal");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlPrincipal failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlThread);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlThread");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlThread failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.Execution);
            Console.WriteLine("Demanding SecurityPermissionFlag.Execution");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.Execution failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.Infrastructure);
            Console.WriteLine("Demanding SecurityPermissionFlag.Infrastructure");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.Infrastructure failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.RemotingConfiguration);
            Console.WriteLine("Demanding SecurityPermissionFlag.RemotingConfiguration");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.RemotingConfiguration failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.SerializationFormatter);
            Console.WriteLine("Demanding SecurityPermissionFlag.SerializationFormatter");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.SerializationFormatter failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.SkipVerification);
            Console.WriteLine("Demanding SecurityPermissionFlag.SkipVerification");
            sp.Demand();
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.SkipVerification failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
            Console.WriteLine("Demanding SecurityPermissionFlag.UnmanagedCode");
            // This demand should cause an exception.
            sp.Demand();
            // The TestFailed method is called if an exception is not thrown.
            TestFailed();
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.UnmanagedCode failed: " + e.Message);
        }

    }

    public static void TestFailed()
    {
        Console.WriteLine("In TestFailed method.");
        Console.WriteLine("Throwing an exception.");
        throw new Exception();
    }
	
    public static void DemandSecurityPermissions()
    {
        Console.WriteLine("\nExecuting DemandSecurityPermissions.\n");
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.Assertion);
            Console.WriteLine("Demanding SecurityPermissionFlag.Assertion");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.Assertion succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.Assertion failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlAppDomain);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlAppDomain");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlAppDomain succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlAppDomain failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlDomainPolicy);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlDomainPolicy");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlDomainPolicy succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlDomainPolicy failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlEvidence);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlEvidence");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlEvidence succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlEvidence failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlPolicy);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlPolicy");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlPolicy succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlPolicy failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlPrincipal);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlPrincipal");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlPrincipal succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlPrincipal failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.ControlThread);
            Console.WriteLine("Demanding SecurityPermissionFlag.ControlThread");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlThread succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.ControlThread failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.Execution);
            Console.WriteLine("Demanding SecurityPermissionFlag.Execution");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.Execution succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.Execution failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.Infrastructure);
            Console.WriteLine("Demanding SecurityPermissionFlag.Infrastructure");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.Infrastructure succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.Infrastructure failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.RemotingConfiguration);
            Console.WriteLine("Demanding SecurityPermissionFlag.RemotingConfiguration");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.RemotingConfiguration succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.RemotingConfiguration failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.SerializationFormatter);
            Console.WriteLine("Demanding SecurityPermissionFlag.SerializationFormatter");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.SerializationFormatter succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.SerializationFormatter failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.SkipVerification);
            Console.WriteLine("Demanding SecurityPermissionFlag.SkipVerification");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.SkipVerification succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.SkipVerification failed: " + e.Message);
        }
        try
        {
            SecurityPermission sp =
                new SecurityPermission(SecurityPermissionFlag.UnmanagedCode);
            Console.WriteLine("Demanding SecurityPermissionFlag.UnmanagedCode");
            sp.Demand();
            Console.WriteLine("Demand for SecurityPermissionFlag.UnmanagedCode succeeded.");
        }
        catch (Exception e)
        {
            Console.WriteLine("Demand for SecurityPermissionFlag.UnmanagedCode failed: " + e.Message);
        }

    }

    static void Main(string[] args)
    {
        PermissionDemo();
    }

}